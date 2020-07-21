using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AppWeb.Models;

namespace AppWeb.ViewModel
{
    public class MovieGenreViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 50)]
        [Required]
        public int? InStock { get; set; }

        public string Title => Id != 0 ? "Edit Movie" : "New Movie";


        public MovieGenreViewModel()
        {
            Id = 0;
        }

        public MovieGenreViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;
            InStock = movie.InStock;
        }
    }
}