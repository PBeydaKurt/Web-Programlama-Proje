using System.ComponentModel.DataAnnotations;

namespace AlbumProject.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        public string AlbumTitle { get; set; }

        public int AlbumSongCount { get; set; }

        public string AlbumGenre { get; set; }

        public int AlbumScore { get; set; }

        public int AlbumYear { get; set; }

        public int SingerId { get; set; }

        public Singer Sing { get; set; }








    }
}
