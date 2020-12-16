using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class FoodDb
    {
        static FoodDb()
        {
            _reviews = new List<RestaurantReview>();
            _reviews.Add(new RestaurantReview
            {
                Body = "A fantastic culinary pleasure",
                Created = DateTime.Now,
                ID = 1,
                Rating = 9,
                Restaurant = new Restaurant
                {
                    name = "Mannequin Pis"
                }
            });
        }
    }
}