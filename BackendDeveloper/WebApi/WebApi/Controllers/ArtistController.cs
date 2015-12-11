using DataLayer;
using MusicServices;
using Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ArtistController : ApiController
    {
        MusicService _service;

        public ArtistController()
        {
            _service = new MusicService();
        }

        [HttpGet]
        public HttpResponseMessage Search(string name = "", int page_number = 1, int page_size = 10)
        {
            var artists = _service.SearchArtists(name);

            page_number = page_number < 1 ? 1 : page_number;
            page_size = page_size < 1 ? 1 : page_size;

            var rowCount = artists.Count();
            var numPage = (rowCount / page_size) == 0 ? 1 : (int)Math.Ceiling((decimal)rowCount / page_size);

            artists = artists.OrderBy(a => a.Name).Skip(page_size * (page_number - 1)).Take(page_size);

            return Request.CreateResponse(HttpStatusCode.OK, new ArtistResultDto { results = artists, numberOfSearchResults = rowCount, page = page_number, pageSize = page_size, numberOfPages = numPage });
        }

        [HttpGet]
        public HttpResponseMessage albums(string id)
        {
            var releases = _service.GetReleases(id);

            return Request.CreateResponse(HttpStatusCode.OK, releases);
        }
    }
}
