using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRaterMVC.Models
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Type of food")]
        public string FoodType { get; set; }
        public double Rating { get; set; }
        public Restaurant() { }

    }

    public class RestaurantDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }

}