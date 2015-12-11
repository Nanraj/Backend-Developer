using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class ArtistResultDto
    {
        public IEnumerable<ArtistDto> results { get; set; }
        public int numberOfSearchResults { get; set; }
        public int page { get; set; } 
        public int pageSize { get; set; }
        public int numberOfPages { get; set; }
    }
}
