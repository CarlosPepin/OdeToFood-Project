using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Data;
using OdeToFood.Core;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; } 
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
 
        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }
        
        public void OnGet()
        {
           Message = config["Message"];
           Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}