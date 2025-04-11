using Microsoft.AspNetCore.Mvc;
using MvcTeste.Data;
using MvcTeste.Models;

namespace MvcTeste.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        //carregando Banco de dados como uma varivel _db
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        //listando do banco de dados
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        //Metodo do tipo httpPost que salva um objeto de um formulario
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display order cannot exactly match the Name.");
            }

            if (obj.Name.ToLower() == "teste")
            {
                ModelState.AddModelError("", "test is an invalid value");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }


        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);

            //outros metodos para procurar um id
            //FisrtOrDefault funciona também para outros atributos alem da chave primaria
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.CategoryId == id);
            //Category? categoryFromDb2 = _db.Categories.Where(u => u.CategoryId == id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //Metodo do tipo httpPost que salva um objeto de um formulario
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    _db.Categories.Update(obj);
                    _db.SaveChanges();
                    TempData["success"] = "Category edited successfully";
                    return RedirectToAction("Index");
                }
                return View(obj);
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //Metodo do tipo httpPost que salva um objeto de um formulario
        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePost(int? id)
        {
            Category obj = _db.Categories.Find(id);

            if(obj == null)
            { 
                return NotFound(); 
            }

            _db.Categories.Remove(obj);

            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
