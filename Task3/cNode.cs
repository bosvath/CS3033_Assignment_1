using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class cNode
    {
        /// <summary>
        /// INITIALIZATION OF GLOBAL VARIABLES
        ///     node_Name = the name of the node (eg. A, B, C etc.)
        ///     connections_List = the connections (the edges) of the node
        ///     min_Cost_To_Start = calculated cost to the start node (S)
        ///     heuristic_Value = heuristic cost to the end node (G)
        ///     nearest_Node_To_Start = this is used in the DoSearchWithAStar() function to store the nearest node to the start node (S)
        ///     is_Visited = stores if the node is already visited or not
        /// </summary>
        public string node_Name { get; set; }
        public List<cEdge> connections_List { get; set; } = new List<cEdge>();
        public double? min_Cost_To_Start { get; set; }
        public double heuristic_Value { get; set; }
        public cNode nearest_Node_To_Start { get; set; }
        public bool is_Visited { get; set; }
    }
}
