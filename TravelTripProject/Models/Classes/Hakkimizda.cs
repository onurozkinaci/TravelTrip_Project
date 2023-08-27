using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.Classes
{
    public class Hakkimizda
    {
        [Key]
        public int ID { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}