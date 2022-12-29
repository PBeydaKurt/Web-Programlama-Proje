namespace AlbumProject.Models
{
    public class Singer
    {
        public int SingerId { get; set; }
        public string SingerName { get; set;}

        public string SingerLName { get; set; }

        public string SingerNationality { get; set; }

        public int SingerAge { get; set; }  

        public ICollection<Album> Albums { get; set; }

        
    }
}
