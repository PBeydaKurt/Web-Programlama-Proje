/*using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AlbumProject.Models
{
    public class Singer
    {
        public int SingerId { get; set; }
        public string? SingerName { get; set;}

        public string? SingerLName { get; set; }

        public string? SingerNationality { get; set; }

        public int SingerAge { get; set; }  

        public ICollection<Album>? Albums { get; set; }

        
    }
}
*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumProject.Models
{
    public class Singer
    {
        [Display(Name = "Singer ID")]
        public int SingerId { get; set; }
        [Required(ErrorMessage = "Ad alanı zorunlu")]
        [Display(Name = "Singer Name")]
        public string SingerName { get; set; }
        [Display(Name = "Singer LName")]
        public string SingerLName { get; set; }
        [Display(Name = "Singer Singer Nationality")]
        public string SingerNationality { get; set; }
        [Display(Name = "Singer Age")]
        public int SingerAge { get; set; }
        public ICollection<Album> Albums { get; set; }
    }

}

