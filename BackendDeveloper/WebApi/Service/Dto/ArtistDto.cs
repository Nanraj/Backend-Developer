using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class ArtistDto
    {
        public string UniqueIdentifier { get; set; }
        public string Name { get; set; }
        public string Country { get; set; } 
        public string Url { get; set; }
        public List<string> Alias { get; set; }
    }
}
