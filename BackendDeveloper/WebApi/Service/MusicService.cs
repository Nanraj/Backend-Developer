using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Dto;
using MusicServices.MusicBrain;
using MusicServices.Dto;
using MusicServices.MusicBrain.Release;

namespace MusicServices
{
    public class MusicService : IMusicService
    {
        MusicEntities entity;
        public MusicService()
        {
            this.entity = new MusicEntities();
        }

        public IEnumerable<ArtistDto> SearchArtists(string name)
        {

            var result = from a in entity.Artists
                         where a.Name.StartsWith(name)
                         select new ArtistDto
                         {
                             Name = a.Name,
                             Country = a.Country,
                             Url = string.Concat("http://musicbrainz.org/artist/", a.UniqueIdentifier),
                             Alias = entity.ArtistAlias.Where(b => b.ArtistUniqueIdentifier == a.UniqueIdentifier).Select(c =>  c.Alias).ToList()

                         };

            return result;
        }
        
        public List<ReleaseDto> GetReleases(string ArtistId)
        {
            return ReleaseMusicBrain.GetReleases(ArtistId);
        }
    }
}
