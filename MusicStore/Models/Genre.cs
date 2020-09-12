using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int AlbumId { get; set; }
        public virtual List<Album> Album { get; set; }

        public Genre()
        {
            Album = new List<Album>();
        }

    }
}
