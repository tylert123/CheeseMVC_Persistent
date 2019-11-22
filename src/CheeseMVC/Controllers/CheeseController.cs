using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            //ViewBag.cheeses = CheeseData.GetAll();

            List<Cheese> cheeses = CheeseData.GetAll();

            return View(cheeses);
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();

            return View(addCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            // Add the new cheese to my existing cheeses
            //Cheeses.Add(new Cheese(name, description));

            /*Cheese newCheese = new Cheese
            {
                Description = description,
                Name = name
            };*/

            /*
             Above ^ same as below:
             Cheese newCheese = new Cheese();
             newCheese.Description = description;
             newCheese.Name = name;
             Don't need to create a constructor with the above, can use default
            */

            if (ModelState.IsValid)
            {

                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Type = addCheeseViewModel.Type,
                    Rating = addCheeseViewModel.Rating
                };

                CheeseData.Add(newCheese);

                return Redirect("/Cheese");
            }
            return View(addCheeseViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheese";
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            //TODO - remove cheeses from list
            foreach (int cheeseId in cheeseIds)
            {
                CheeseData.Remove(cheeseId);
            }
            return Redirect("/");
        }

        public IActionResult Edit(int cheeseId)
        {
            //ViewBag.cheese = CheeseData.GetById(cheeseId);

            AddEditCheeseViewModel addEditCheeseViewModel = new AddEditCheeseViewModel();
            Cheese cheese = CheeseData.GetById(cheeseId);

            addEditCheeseViewModel.CheeseId = cheese.CheeseId;
            addEditCheeseViewModel.Name = cheese.Name;
            addEditCheeseViewModel.Description = cheese.Description;
            addEditCheeseViewModel.Type = cheese.Type;

            return View(addEditCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Edit(AddEditCheeseViewModel addEditCheeseViewModel)
        {
            var id = CheeseData.GetById(addEditCheeseViewModel.CheeseId);
            CheeseData.Remove(addEditCheeseViewModel.CheeseId);
            //var editedCheese = new Cheese(cheeseId, name, description);
            //var editedCheese = new Cheese();
            //CheeseData.Add(Cheese editedCheese);
            Cheese editedCheese = new Cheese
            {
                Name = addEditCheeseViewModel.Name,
                Description = addEditCheeseViewModel.Description,
                CheeseId = addEditCheeseViewModel.CheeseId,
                Type = addEditCheeseViewModel.Type
            };
            CheeseData.Add(editedCheese);

            return Redirect("/");
        }
    }
}
