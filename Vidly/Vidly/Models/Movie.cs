using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models.Validation.Movie_only;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please specify Name of Movie")]
        [StringLength(255)]
        //[Is_Unique_MovieName] //IsMovie_Name_used", "Movies", ErrorMessage = "Movie Name Already in use...")]
        public string Name { get; set; }

        [Display(Name ="Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Released Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Required(ErrorMessage ="Please Enter Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name ="Number in Stock")]
        [Required(ErrorMessage ="Please Enter Number in Stock")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Enter valid Number")]
        [Range(1,10,ErrorMessage ="Range is from 1 - 10")]
        public byte NumberInStock { get; set; }

        [Display(Name ="Genre")]
        [Required(ErrorMessage ="Please select Genre")]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }
        
        public byte NumberAvailable { get; set; }
    }
}