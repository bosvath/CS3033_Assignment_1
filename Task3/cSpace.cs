using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Task3
{
    public class cSpace
    {
        /// <summary>
        /// INITIALIZATION OF GLOBAL 
        ///     node_List = is to store all the nodes, which we will use the GetShortestPath() method on.
        ///     start_Node = is essential to know which is the start node in the graph.
        ///     end_Node = is essential to know which is the end node in the graph.
        ///     shortest_Path = will be storing the final result as our shortest path.
        /// </summary>
        public List<cNode> node_List { get; set; } = new List<cNode>();

        public cNode start_Node { get; set; }

        public cNode end_Node { get; set; }

        public List<cNode> shortest_Path { get; set; } = new List<cNode>();

        /// <summary>
        /// COSMETIC METHOD
        ///     PRINTING OUT THE SHORTEST PATH IN A NICE WAY
        /// </summary>
        public void PrintShortestPath()
        {
            string finalString = "\t       Solution: ";
            foreach (cNode node in shortest_Path)
            {
                finalString += $"{node.node_Name} => ";
            }
            finalString = finalString.Substring(0, finalString.Length - 4);
            Console.WriteLine(finalString);
        }

        /// <summary>
        /// COSMETIC METHOD
        ///     PRINTING OUT JUST THE CONNECTIONS IN OUR PATH
        ///     THIS WAS USED FOR ONLY DEBUGGING PURPOSES
        /// </summary>
        public void PrintConnections()
        {
            foreach (var n in node_List)
            {
                Console.WriteLine($"{n.node_Name} ({n.heuristic_Value})");
                foreach (var c in n.connections_List)
                    Console.WriteLine($"\t ->{c.connected_Node.node_Name} ({c.cost_To_Next_Node})");
            }
        }
    }
}
