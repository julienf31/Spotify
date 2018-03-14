using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class AlbumModel
    {
        public String Name { get; set; }

        public SimpleAlbum Album { get; set; }

        public AlbumModel(string name, SimpleAlbum album)
        {
            Name = name;
            Album = album;
        }
    }
}