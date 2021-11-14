using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class cEdge
    {
        /// <summary>
        /// INITIALIZATION OF GLOBAL VARIABLES
        ///     cost_To_Next_Node = the name is very descriptive, it stores the cost to the connected node.
        ///     connected_Node = here also, it stores the connected node as a cNode class (see cNode.cs's comments for further description).
        /// </summary>
        public double cost_To_Next_Node { get; set; }
        public cNode connected_Node { get; set; }
    }
}
