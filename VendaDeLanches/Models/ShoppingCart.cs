using Microsoft.EntityFrameworkCore;
using VendaDeLanches.Context;

namespace VendaDeLanches.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _context;

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItens> ShoppingCartItens { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services) 
        {
            //Define uma sessão
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            //Operador Elvis ('?.') -> Se a instância de IHttpContext não for null,
            //ele vai invocar e retornar a session a será usada

            //Obtem um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            //obtem ou gera o id do carrinho.Verifica se o valor da "Propriedade/String" existe, caso não, ele gera um novo
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            //Atribui o id do carrinho na sessão
            session.SetString("CartId", cartId);

            //Retorna o carrinho com o contexto e o Id atribuído ou obtido
            return new ShoppingCart(context)
            {
                ShoppingCartId = cartId
            };

        }

        //Adiciona um objeto do tipo lanche ao carrinho
        public void AddItem(Snack Snack)
        {
            //Verificar se o lanche já existe na tabela carrinho compra itens
            //Para isso, verificar se o id do lanche já existe e se o carrinho existe
            var shoppingCartItem = _context.ShoppingCartItens.SingleOrDefault(
                  s => s.Snack.SnackId == Snack.SnackId &&
                       s.ShoppingCartId == ShoppingCartId
                );

            //Existe algum item no carinho?
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new Models.ShoppingCartItens()
                {
                    ShoppingCartId = ShoppingCartId,
                    Snack = Snack,
                    Quantity = 1
                };
                _context.ShoppingCartItens.Add(shoppingCartItem);
            }
            else 
            {
                shoppingCartItem.Quantity++;
            }

            _context.SaveChanges();
            
        }

        //Remove um lanche do carrinho
        public int RemoveItem(Snack Snack)
        {
            var shoppingCartItem = _context.ShoppingCartItens.SingleOrDefault(
                s => s.Snack.SnackId == Snack.SnackId &&
                     s.ShoppingCartId == ShoppingCartId
                );

            var itemQuantity = 0;

            if (shoppingCartItem != null)
            {
                shoppingCartItem.Quantity--;
                itemQuantity = shoppingCartItem.Quantity;
            }
            else 
            {
                _context.ShoppingCartItens.Remove(shoppingCartItem);
            }

            _context.SaveChanges();
            return itemQuantity;

        }

        public List<ShoppingCartItens> GetShoppingCartItens() 
        {
            return ShoppingCartItens ??
                (ShoppingCartItens =
                _context.ShoppingCartItens
                .Where(s => s.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Snack).ToList());
        }

        public void CleanCart() 
        {
            //Montaas condições para a query
            var cartItens = _context.ShoppingCartItens
                .Where(s => s.ShoppingCartId == ShoppingCartId);

            //Monta a query de acordo com as condições estabelecidas
            _context.ShoppingCartItens.RemoveRange(cartItens);

            //Executa a query
            _context.SaveChanges();

        }

        public decimal GetTotalValueShoppingCart() 
        {
            var totalValueShoppingCart = _context.ShoppingCartItens
                .Where(s => s.ShoppingCartId == ShoppingCartId)
                .Select(s => s.Snack.Price * s.Quantity).Sum();

            return totalValueShoppingCart;
        
        }

    }
}
