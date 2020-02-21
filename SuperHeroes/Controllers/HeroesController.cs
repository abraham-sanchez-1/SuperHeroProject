using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroes.Data;
using SuperHeroes.Models;

namespace SuperHeroes.Controllers
{
    public class HeroesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HeroesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Heroes
        public ActionResult Index()
        {

            return View(_context.Heroes.ToList());
        }

        // GET: Heroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var hero = _context.Heroes.Where(a => a.id == id).FirstOrDefault();
            return View(hero);
        }

        // GET: Heroes/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Heroes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hero hero)
        {
            if (ModelState.IsValid)
            {
                _context.Heroes.Add(hero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }      
                return View(hero);
            
        }

        // GET: Heroes/Edit/5
        public ActionResult Edit(int id)
        {
            Hero hero = _context.Heroes.Where(a => a.id == id).FirstOrDefault();
            return View(hero);
        }

        // POST: Heroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Hero Hero)
        {
            try
            {
                // TODO: Add update logic here
                Hero updatedHero = _context.Heroes.Where(a => a.id == id).FirstOrDefault();
                updatedHero.Name = Hero.Name;
                updatedHero.PrimaryAbility = Hero.PrimaryAbility;
                updatedHero.SecondaryAbility = Hero.SecondaryAbility;
                updatedHero.AlterEgo = Hero.AlterEgo;
                updatedHero.CatchPhrase = Hero.CatchPhrase;
                _context.SaveChanges();

                //User u = UserCollection.FirstOrDefault(u => u.Id == 1);
                //u.FirstName = "Bob"

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Heroes/Delete/5
        public ActionResult Delete(int id)
        {
            Hero hero = _context.Heroes.Where(a => a.id == id).FirstOrDefault();
            return View(hero);
        }

        // POST: Heroes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Hero hero)
        {
            try
            {
                // TODO: Add delete logic here
                _context.Heroes.Remove(hero);
                _context.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}