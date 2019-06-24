using RestaurantRaterMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRaterMVC.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantDbContext _restaurantDb = new RestaurantDbContext();

        // GET: Restaurant
        public ActionResult Index()
        {
            return View(_restaurantDb.Restaurants.ToList());
        }
        //GET: restaurant/create
        public ActionResult Create()
        {
            return View();
        }
        //POST: restaurant/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _restaurantDb.Restaurants.Add(restaurant);
                _restaurantDb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }



        //GET: restaurant/edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _restaurantDb.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }
        //POST: restaurant/edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _restaurantDb.Entry(restaurant).State = EntityState.Modified; //grabbing model, and states changes and updates??
                _restaurantDb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }



        //GET: restaurant/delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _restaurantDb.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        //POST: restaurant/delete/{id}
        [HttpPost]
        [ActionName("Delete")] //this way it ties this method to the other method named DELETE
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = _restaurantDb.Restaurants.Find(id);
            _restaurantDb.Restaurants.Remove(restaurant);
            _restaurantDb.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}