using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvc_music_store.Models;

namespace mvc_music_store.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}