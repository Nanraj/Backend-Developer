using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.Dto;


namespace Web.Api.Tests
{
    [TestClass]
    public class test_search_artist_partial_name 
    {
        HttpResponseMessage Response;
        HttpClient client;

        public test_search_artist_partial_name()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://test.api/api/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [TestMethod]
        public void search_artist_success()
        {
            Response = client.GetAsync("artist/search/joh").Result;
            Assert.IsTrue(Response.IsSuccessStatusCode);

            ArtistResultDto Artists = Response.Content.ReadAsAsync<ArtistResultDto>().Result;

            Assert.IsTrue(Artists.results.Count() > 0);
        }

        [TestMethod]
        public void search_artist_noresult()
        {
            Response = client.GetAsync("artist/search/xx").Result;
            Assert.IsTrue(Response.IsSuccessStatusCode);

            ArtistResultDto Artists = Response.Content.ReadAsAsync<ArtistResultDto>().Result;

            Assert.IsTrue(Artists.results.Count() < 1);
        }

    }
}
