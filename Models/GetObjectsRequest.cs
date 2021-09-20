using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metropolitan.Models
{
    public class GetObjectsRequest
    {
        public string metadataDate { get; set; }
        public int departmentIds { get; set; }
    }
}
