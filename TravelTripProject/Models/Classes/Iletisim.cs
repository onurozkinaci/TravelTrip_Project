using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.Classes
{
    public class Iletisim
    {
        [Key]
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; } 
        public string Message { get; set; } 
    }
}