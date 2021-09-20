using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metropolitan.Models
{
    public class GetObjectResponse
    {
        public string accessionYear { get; set; }
        public string primaryImage { get; set; }
        public string title { get; set; }
        public string objectDate { get; set; }
        public string artistDisplayName { get; set; }
        public string artistNationality { get; set; }
        public string creditLine { get; set; }

    }
}
