using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.Classes
{
    //Blogun altina eklenecek panel alaninda yorum yapilabilecek ve yorumlar listelenebilecek.
    public class Yorumlar
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Comment { get; set; }
        public int BlogId { get; set; } //FK
        public virtual Blog Blog { get; set; } //Birecok iliskide bir yorum bir blog icin gecerlidir.
    }
}