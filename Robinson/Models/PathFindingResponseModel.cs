using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Robinson.Models
{
    public class PathFindingResponseModel
    {
        public string Destination { get; set; }
        public List<string> List { get; set; } = new List<string>();
    }
}
