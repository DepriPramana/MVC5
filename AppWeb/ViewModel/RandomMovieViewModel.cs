using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppWeb.Models;

namespace AppWeb.ViewModel
{
    public class RandomMovieViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<Customers> Customers { get; set; }
    }
}