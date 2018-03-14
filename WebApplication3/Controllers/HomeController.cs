using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth; 
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private static SpotifyWebAPI _spotify;
        private ClientCredentialsAuth auth;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(String search)
        {
            auth = new ClientCredentialsAuth()
            {
                ClientId = "db746b6fb12b4c458d58074788960ab1",
                ClientSecret = "c4d744eb8c0d4a5fb967a93af5145cf0",
                Scope = Scope.UserReadPrivate,
            };
            Token token = auth.DoAuth();

            _spotify = new SpotifyWebAPI()
            {
                TokenType = token.TokenType,
                AccessToken = token.AccessToken,
            };

            SearchItem item = _spotify.SearchItems(search, SearchType.Artist, 50);

            

            List<ArtistModel> artistsList = new List<ArtistModel>();

            item.Artists.Items.ForEach(artist => {
                ArtistModel artists = new ArtistModel(artist.Name, artist.Id, artist);
                artistsList.Add(artists);
            });


            ViewData["artistsList"] = artistsList;

            return View();
        }

        [HttpGet]
        public ActionResult Artist(String id)
        {
            auth = new ClientCredentialsAuth()
            {
                ClientId = "db746b6fb12b4c458d58074788960ab1",
                ClientSecret = "c4d744eb8c0d4a5fb967a93af5145cf0",
                Scope = Scope.UserReadPrivate,
            };
            Token token = auth.DoAuth();

            _spotify = new SpotifyWebAPI()
            {
                TokenType = token.TokenType,
                AccessToken = token.AccessToken,
            };

            Paging<SimpleAlbum> albums = _spotify.GetArtistsAlbums(id, AlbumType.All, 50);


            List<AlbumModel> albumList = new List<AlbumModel>();

            albums.Items.ForEach(album => {
                AlbumModel artistAlbum = new AlbumModel(album.Name, album);
                albumList.Add(artistAlbum);
            });


            ViewData["albumList"] = albumList;

            return View();
        }

    }
}