using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Robinson.Models
{
    public class NodeModel
    {
        public NodeModel(string country, NodeModel node)
        {
            this.Code = country;
            this.Node = node;
        }

        public string Code { get; set; }
        public NodeModel Node { get; set; }
    }
}
