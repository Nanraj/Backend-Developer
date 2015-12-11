using Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicServices.Dto
{
    public class ReleaseDto
    {
        public ReleaseDto()
        {
            OtherArtists = new List<OtherArtistDto>();
        }
        public string ReleaseId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Label { get; set; }
        public int NumberOfTracks { get; set; }
        public List<OtherArtistDto> OtherArtists { get; set; }
    }
}
