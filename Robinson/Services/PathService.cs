using Robinson.Models;
using Robinson.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Robinson.Services
{  public class PathService
    {
        private readonly List<NodeModel> _nodes = new List<NodeModel>();

        public PathService() {

            var UnitedStates = new NodeModel("USA", null);
            var Canada = new NodeModel("CAN", UnitedStates);
            var Mexico = new NodeModel("MEX", UnitedStates);
            var Belize = new NodeModel("BLZ", Mexico);
            var Guatemala = new NodeModel("GTM", Mexico);
            var ElSalvador = new NodeModel("SLV", Guatemala);
            var Honduras = new NodeModel("HND", Guatemala);
            var Nicaragua = new NodeModel("NIC", Honduras);
            var CostaRica = new NodeModel("CRI", Nicaragua);
            var Panama = new NodeModel("PAN", CostaRica);
           
            _nodes.AddRange(new[] {
            UnitedStates,
            Canada,
            Mexico,
            Belize,
            Guatemala,
            ElSalvador,
            Honduras,
            Nicaragua,
            CostaRica,
            Panama
            });
        }

        public PathFindingResponseModel GetPath(string destination)
        {
            var output = new PathFindingResponseModel();
            output.Destination = destination;

            var actualNode = _nodes.FirstOrDefault(x=>x.Code == destination);

            if(actualNode == null)
            {
                throw new ApiException("Code does not match any know country");
            }

            int counter = 0;

            while(actualNode != null)
            {
                output.List.Add(actualNode.Code);
                actualNode = actualNode.Node;
                
                counter++;
                if(counter > _nodes.Count)
                {
                    throw new ApiException("Path could not be found");
                }
            }

            return output;
        }
    }
}
