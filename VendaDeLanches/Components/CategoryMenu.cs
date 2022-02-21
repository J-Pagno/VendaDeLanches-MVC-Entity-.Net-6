using Microsoft.AspNetCore.Mvc;
using System;
using VendaDeLanches.Repositories.Interfaces;

public class CategoryMenu : ViewComponent
{
    //Injeção da interface do repositório de categorias (Invoca a interface)
	private readonly ICategoryRepository _categoryRepository;

    //Toda injeção deve conter um construtor (Inicializa uma classe)
    public CategoryMenu(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    //Invoca o construtor
    public IViewComponentResult Invoke()
    {
        //Seleciona as categorias e as ordena pelo seu nome
        var cetgories = _categoryRepository.Categories.OrderBy(c => c.CategoryName);
        //Retorna as categorias ordenadas pelo nome
        return View(cetgories);
    }
}
