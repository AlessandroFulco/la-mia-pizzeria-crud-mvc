﻿using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Controllers
{
    public class CategoryController : Controller
    {
        PizzeriaDbContext db;
        public CategoryController()
        {
            db = new PizzeriaDbContext();
        } 
        public IActionResult Index()
        {
            List<Category> lista = db.Categories.ToList();
            return View(lista);
        }

        public IActionResult Detail(int id) 
        {
            Category category = db.Categories.Where(category => category.Id == id).FirstOrDefault();
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if(!ModelState.IsValid)
            {
                return View(category);
            }

            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Category category = db.Categories.Where(category => category.Id == id).FirstOrDefault();

            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Category formData)
        {
            if(!ModelState.IsValid)
                return View(formData);

            Category category = db.Categories.Where(category=>category.Id == id).FirstOrDefault();
            if(category == null)
                return NotFound();

            category.Name = formData.Name;

            db.SaveChanges();

            return RedirectToAction("Index");   

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Category category = db.Categories.Where(c => c.Id == id).FirstOrDefault();
            List<Pizza> lista = db.Pizze.ToList();

            Category empty = db.Categories.Where(category => category.Name == "nessuna selezionata").FirstOrDefault();

            foreach(Pizza pizza in lista)
            {
                if(pizza.CategoryId == category.Id)
                {
                    pizza.CategoryId = empty.Id;
                    db.Categories.Remove(category);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

    }
}
