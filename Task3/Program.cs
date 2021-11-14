using System;
using System.Collections.Generic;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintDivider();

            /// <summary>
            /// INITIALIZE THE SPACE FOR THE GRAPH
            /// </summary>

            cSpace space = new cSpace();

            /// <summary>
            /// INITIALIZE THE NODES FOR THE GRAPH
            /// </summary>

            cNode G = new cNode() { node_Name = "G", heuristic_Value = 0 };
            cNode C = new cNode() { node_Name = "C", heuristic_Value = 100, connections_List = new List<cEdge>() };
            cNode D = new cNode() { node_Name = "D", heuristic_Value = 250, connections_List = new List<cEdge>() };
            cNode B = new cNode() { node_Name = "B", heuristic_Value = 300, connections_List = new List<cEdge>() };
            cNode E = new cNode() { node_Name = "E", heuristic_Value = 450, connections_List = new List<cEdge>() };
            cNode F = new cNode() { node_Name = "F", heuristic_Value = 400, connections_List = new List<cEdge>() };
            cNode S = new cNode() { node_Name = "S", heuristic_Value = 500, connections_List = new List<cEdge>() };
            cNode A = new cNode() { node_Name = "A", heuristic_Value = 400, connections_List = new List<cEdge>() };

            /// <summary>
            /// INITIALIZE / ADD THE EDGES OF THE GRAPH
            /// EDGES ARE POINTING TO BOTH DIRECTIONS
            /// </summary>

            G.connections_List.Add(new cEdge() { cost_To_Next_Node = 100, connected_Node = C });
            C.connections_List.Add(new cEdge() { cost_To_Next_Node = 200, connected_Node = B });
            C.connections_List.Add(new cEdge() { cost_To_Next_Node = 200, connected_Node = D });
            C.connections_List.Add(new cEdge() { cost_To_Next_Node = 100, connected_Node = G });
            B.connections_List.Add(new cEdge() { cost_To_Next_Node = 200, connected_Node = A });
            B.connections_List.Add(new cEdge() { cost_To_Next_Node = 200, connected_Node = C });
            D.connections_List.Add(new cEdge() { cost_To_Next_Node = 300, connected_Node = A });
            D.connections_List.Add(new cEdge() { cost_To_Next_Node = 250, connected_Node = E });
            D.connections_List.Add(new cEdge() { cost_To_Next_Node = 200, connected_Node = C });
            S.connections_List.Add(new cEdge() { cost_To_Next_Node = 200, connected_Node = A });
            S.connections_List.Add(new cEdge() { cost_To_Next_Node = 300, connected_Node = E });
            S.connections_List.Add(new cEdge() { cost_To_Next_Node = 150, connected_Node = F });
            E.connections_List.Add(new cEdge() { cost_To_Next_Node = 200, connected_Node = F });
            E.connections_List.Add(new cEdge() { cost_To_Next_Node = 300, connected_Node = S });
            E.connections_List.Add(new cEdge() { cost_To_Next_Node = 200, connected_Node = D });
            F.connections_List.Add(new cEdge() { cost_To_Next_Node = 150, connected_Node = S });
            F.connections_List.Add(new cEdge() { cost_To_Next_Node = 200, connected_Node = E });
            A.connections_List.Add(new cEdge() { cost_To_Next_Node = 200, connected_Node = S });
            A.connections_List.Add(new cEdge() { cost_To_Next_Node = 300, connected_Node = D });
            A.connections_List.Add(new cEdge() { cost_To_Next_Node = 200, connected_Node = B });

            /// <summary>
            /// SET START AND END NODES
            /// </summary>

            space.start_Node = S;
            space.end_Node = G;

            /// <summary>
            /// ADD THE NODES TO OUR NODE LIST FOR FURTHER USE
            /// </summary>

            space.node_List.Add(S);
            space.node_List.Add(A);
            space.node_List.Add(B);
            space.node_List.Add(C);
            space.node_List.Add(D);
            space.node_List.Add(E);
            space.node_List.Add(F);
            space.node_List.Add(G);

            /// <summary>
            /// INITIALIZE THE A* SEARCH CLASS
            ///     THEN CALL THE GetShortestPath METHOD TO SEARCH OUR node_List AND FIND THE SHORTEST PATH FOR IT.
            ///     IF THE SHORTEST PATH IS FOUND THEN PRINT OUT THE PATH
            /// </summary>

            cAStarSearch search = new cAStarSearch(space);
            space.shortest_Path = search.GetShortestPath();
            TaskIII3();
            Console.WriteLine();
            search.PrintFinalOutputDict();
            Console.WriteLine();
            space.PrintShortestPath();

            PrintDivider();

            /// <summary>
            /// INITIALIZE THE SPACE FOR THE GRAPH
            /// </summary>

            space = new cSpace();

            /// <summary>
            /// INITIALIZE THE NODES FOR THE GRAPH
            /// </summary>

            G = new cNode() { node_Name = "G", heuristic_Value = 0 };
            C = new cNode() { node_Name = "C", heuristic_Value = 90, connections_List = new List<cEdge>() { new cEdge() { cost_To_Next_Node = 100, connected_Node = G } } };
            D = new cNode() { node_Name = "D", heuristic_Value = 290, connections_List = new List<cEdge>() { new cEdge() { cost_To_Next_Node = 200, connected_Node = C } } };
            B = new cNode() { node_Name = "B", heuristic_Value = 330, connections_List = new List<cEdge>() { new cEdge() { cost_To_Next_Node = 200, connected_Node = C } } };
            E = new cNode() { node_Name = "E", heuristic_Value = 490, connections_List = new List<cEdge>() { new cEdge() { cost_To_Next_Node = 200, connected_Node = D } } };
            F = new cNode() { node_Name = "F", heuristic_Value = 690, connections_List = new List<cEdge>() { new cEdge() { cost_To_Next_Node = 200, connected_Node = E } } };
            S = new cNode() { node_Name = "S", heuristic_Value = 690, connections_List = new List<cEdge>() { new cEdge() { cost_To_Next_Node = 300, connected_Node = E }, new cEdge() { cost_To_Next_Node = 150, connected_Node = F } } };
            A = new cNode() { node_Name = "A", heuristic_Value = 490, connections_List = new List<cEdge>() { new cEdge() { cost_To_Next_Node = 200, connected_Node = S }, new cEdge() { cost_To_Next_Node = 300, connected_Node = D }, new cEdge() { cost_To_Next_Node = 200, connected_Node = B } } };

            /// <summary>
            /// INITIALIZE / ADD THE EDGES OF THE GRAPH
            /// EDGES ARE POINTING TO BOTH DIRECTIONS
            /// </summary>

            G.connections_List.Add(new cEdge() { cost_To_Next_Node = 100, connected_Node = C });
            C.connections_List.Add(new cEdge() { cost_To_Next_Node = 200, connected_Node = B });
            C.connections_List.Add(new cEdge() { cost_To_Next_Node = 200, connected_Node = D });
            B.connections_List.Add(new cEdge() { cost_To_Next_Node = 200, connected_Node = A });
            D.connections_List.Add(new cEdge() { cost_To_Next_Node = 300, connected_Node = A });
            D.connections_List.Add(new cEdge() { cost_To_Next_Node = 250, connected_Node = E });
            S.connections_List.Add(new cEdge() { cost_To_Next_Node = 200, connected_Node = A });
            E.connections_List.Add(new cEdge() { cost_To_Next_Node = 200, connected_Node = F });
            E.connections_List.Add(new cEdge() { cost_To_Next_Node = 300, connected_Node = S });
            F.connections_List.Add(new cEdge() { cost_To_Next_Node = 150, connected_Node = S });

            /// <summary>
            /// SET START AND END NODES
            /// </summary>

            space.start_Node = S;
            space.end_Node = G;

            /// <summary>
            /// ADD THE NODES TO OUR NODE LIST FOR FURTHER USE
            /// </summary>

            space.node_List.Add(S);
            space.node_List.Add(A);
            space.node_List.Add(B);
            space.node_List.Add(C);
            space.node_List.Add(D);
            space.node_List.Add(E);
            space.node_List.Add(F);
            space.node_List.Add(G);

            /// <summary>
            /// INITIALIZE THE A* SEARCH CLASS
            ///     THEN CALL THE GetShortestPath METHOD TO SEARCH OUR node_List AND FIND THE SHORTEST PATH FOR IT.
            ///     IF THE SHORTEST PATH IS FOUND THEN PRINT OUT THE PATH
            /// </summary>

            search = new cAStarSearch(space);
            space.shortest_Path = search.GetShortestPath();
            TaskIII4a();
            Console.WriteLine();
            search.PrintFinalOutputDict();
            Console.WriteLine();
            space.PrintShortestPath();
        }

        /// <summary>
        /// SIMPLE METHOD TO PRINT OUT THREE NEW LINES JUST TO MAKE THE OUTPUT NICER
        /// </summary>
        private static void PrintDivider()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// COSMETIC METHOD
        ///     PRINTING OUT JUST A NICER WAY TO LET THE USER KNOW WHICH TASK IT IS (TASK III 3)
        /// </summary>
        private static void TaskIII3()
        {
            Console.WriteLine("\t\t_===========================_");
            Console.WriteLine("\t\t|         TASK III.         |");
            Console.WriteLine("\t\t|            |3|            |");
            Console.WriteLine("\t\t\\===========================/");
        }

        /// <summary>
        /// COSMETIC METHOD
        ///     PRINTING OUT JUST A NICER WAY TO LET THE USER KNOW WHICH TASK IT IS (Task III 4 a)
        /// </summary>
        private static void TaskIII4a()
        {
            Console.WriteLine("\t\t_===========================_");
            Console.WriteLine("\t\t|         TASK III.         |");
            Console.WriteLine("\t\t|            |4|            |");
            Console.WriteLine("\t\t|             a             |");
            Console.WriteLine("\t\t\\===========================/");
        }
    }
}
