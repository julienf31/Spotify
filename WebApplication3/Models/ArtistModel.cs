using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class ArtistModel
    {
        public String Name { get; set; }
        public String Id { get; set; }

        public SpotifyAPI.Web.Models.FullArtist Artist { get; set; }

        public ArtistModel(string name, string id, SpotifyAPI.Web.Models.FullArtist artist)
        {
            Name = name;
            Id = id;
            Artist = artist;
        }
    }
}