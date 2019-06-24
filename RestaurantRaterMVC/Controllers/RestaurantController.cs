using RestaurantRaterMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        //GET: restaurat/create
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
    }
}