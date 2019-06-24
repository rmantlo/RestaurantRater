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
            Restaurant one = new Restaurant();
            one.RestaurantID = 1;
            one.Name = "Test";
            one.FoodType = "Thai";
            one.Rating = 5;
            
            return View(_restaurantDb.Restaurants.ToList());
        }
    }
}