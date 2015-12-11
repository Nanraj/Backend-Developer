using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.Dto;
using MusicServices.Dto;


namespace Web.Api.Tests
{
    [TestClass]
    public class test_search_artist_release 
    {
        HttpResponseMessage Response;
        HttpClient client;

        public test_search_artist_release()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://test.api/api/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [TestMethod]
        public void search_artist_release_success()
        {
            Response = client.GetAsync("artist/65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab/albums").Result;
            Assert.IsTrue(Response.IsSuccessStatusCode);

            List<ReleaseDto> Release = Response.Content.ReadAsAsync<List<ReleaseDto>>().Result;

            Assert.IsTrue(Release.Count() > 10);
        }

        [TestMethod]
        public void search_artist_release_noresult()
        {
            Response = client.GetAsync("artist/xxx/albums").Result;
            Assert.IsTrue(Response.IsSuccessStatusCode);

            List<ReleaseDto> Release = Response.Content.ReadAsAsync<List<ReleaseDto>>().Result;

            Assert.IsTrue(Release.Count() < 1);
        }

    }
}
