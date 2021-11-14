using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    class cAStarSearch
    {
        /// <summary>
        /// INITIALIZATION OF THE GLOBAL VARIABLES
        ///     space = is the space for the graph
        ///     start_Node = stores the start node
        ///     end_Node = stores the end node
        ///     shortest_Path_Cost = cost of the shortest path
        ///     FinalOutputDict = this dictionary is used to store the costs of the nodes in the shortest path.
        /// </summary>
        public cSpace space { get; set; }
        public cNode start_Node { get; set; }
        public cNode end_Node { get; set; }
        public double shortest_Path_Cost { get; private set; }
        public Dictionary<string, double?> FinalOutputDict { get; set; } = new Dictionary<string, double?>();

        /// <summary>
        /// CONSTRUCTOR OF THE cAStarSearch CLASS
        /// </summary>
        /// <param name="space">THE INITIALIZED SPACE WHICH HAS ALL THE IMPORTANT BITS FOR THE A* SEARCH</param>
        public cAStarSearch(cSpace space)
        {
            this.space = space;
            this.end_Node = space.end_Node;
            this.start_Node = space.start_Node;
        }

        /// <summary>
        /// BUILD THE SHORTEST PATH TO THE END NODE
        /// </summary>
        /// <param name="path">SHORTEST PATH</param>
        /// <param name="node">END NODE</param>
        private void BuildShortestPathFromListFromEndNode(List<cNode> path, cNode node)
        {
            // CHECK IF nearest_Node_To_Start IS NULL OR NOT
            //   IF YES > RETURN
            if (node.nearest_Node_To_Start == null)
                return;

            //   IF NO  > CONTINUE

            // ADD nearest_Node_To_Start TO THE SHORTEST PATH
            path.Add(node.nearest_Node_To_Start);
            // CALCULATE shortest_Path_Cost
            shortest_Path_Cost += node.connections_List.Single(x => x.connected_Node == node.nearest_Node_To_Start).cost_To_Next_Node;
            // RECURSIVELY CALL THE FUNCTION WITH THE NEW (EXTENDED) SHORTEST PATH
            BuildShortestPathFromListFromEndNode(path, node.nearest_Node_To_Start);
        }

        /// <summary>
        /// A* SEARCH SUB METHOD
        /// </summary>
        /// <returns>THE SHORTEST PATH</returns>
        public List<cNode> GetShortestPath()
        {
            // CALL A STAR SEARCH
            DoSearchWithAStar();
            // BUILD SHORTEST PATH FROM THE END NODE
            List<cNode> shortestPath = new List<cNode>();
            shortestPath.Add(end_Node);
            BuildShortestPathFromListFromEndNode(shortestPath, end_Node);
            // REVERSE THE LIST
            shortestPath.Reverse();
            return shortestPath;
        }

        /// <summary>
        /// A* SEARCH MAIN METHOD
        /// </summary>
        private void DoSearchWithAStar()
        {
            start_Node.min_Cost_To_Start = 0;
            List<cNode> tmp_Nodes = new List<cNode>();
            // ADD START NODE TO tmp_Nodes
            tmp_Nodes.Add(start_Node);
            // DO UNTIL tmp_Nodes IS NOT NULL
            do
            {
                // CALCULATE MIN COST TO START NODE + HEURISTIC VALUE AND SELECT FIRST (let's call it tmp_Node) > REMOVE IT FROM THE tmp_Nodes LIST
                tmp_Nodes = tmp_Nodes.OrderBy(x => x.min_Cost_To_Start + x.heuristic_Value).ToList();
                var tmp_Node = tmp_Nodes.First();
                tmp_Nodes.Remove(tmp_Node);
                // WE LOOP THROUGH THE tmp_Node.connections_List ORDERED BY THE cost_To_Next_Node
                foreach (var cnn in tmp_Node.connections_List.OrderBy(x => x.cost_To_Next_Node))
                {
                    // SAVE FINAL COST FOR EACH NODE
                    if (!FinalOutputDict.Keys.Contains(tmp_Node.node_Name))
                        FinalOutputDict.Add(tmp_Node.node_Name, tmp_Node.heuristic_Value + tmp_Node.min_Cost_To_Start);

                    var childNode = cnn.connected_Node;
                    // IF THE CONNECTED NODE (childNode = cnn.connected_Node) IS ALREADY VISITED
                    // > CONTINUE (we don't exit the whole loop just skip this one)
                    if (childNode.is_Visited)
                        continue;
                    // IF THE CONNECTED NODE's min_Cost_To_Start IS NULL OR tmp_Node.min_Cost_To_Start + tmp_Node's current connection's cost_To_Next_Node < CONNECTED NODE's min_Cost_To_Start
                    if (childNode.min_Cost_To_Start == null ||
                        tmp_Node.min_Cost_To_Start + cnn.cost_To_Next_Node < childNode.min_Cost_To_Start)
                    {
                        // SET THE CONNECTED NODE's min_Cost_To_Start to ...
                        childNode.min_Cost_To_Start = tmp_Node.min_Cost_To_Start + cnn.cost_To_Next_Node;
                        // SET THE CONNECTED NODE's nearest_Node_To_Start to ...
                        childNode.nearest_Node_To_Start = tmp_Node;
                        // CHECK IF OUR LIST (tmp_Nodes) ALREADY CONTAINS THE CONNECTED NODE
                        // IF YES > DO NOTHING
                        if (!tmp_Nodes.Contains(childNode))
                            // IF NO > ADD IT TO tmp_Nodes
                            tmp_Nodes.Add(childNode);
                    }
                }
                // SET is_Visited TO true, since we checked (visited) that node
                tmp_Node.is_Visited = true;
                // CHECK IF IT WAS THE END NODE
                // IF NO > DO NOTHING
                if (tmp_Node == end_Node)
                    // IF YES
                    return;
            } while (tmp_Nodes.Any());
        }

        /// <summary>
        /// COSMETIC METHOD
        ///     PRINTING OUT THE FINAL OUTPUT DICTIONARY TO SEE THE SOLUTION WITH EACH NODE & COST
        /// </summary>
        public void PrintFinalOutputDict()
        {
            foreach (var node in FinalOutputDict)
                Console.WriteLine($"\tVisited node: {node.Key}, f({node.Key}) = g({node.Key}) + h({node.Key}) = {node.Value}");
        }
    }
}
