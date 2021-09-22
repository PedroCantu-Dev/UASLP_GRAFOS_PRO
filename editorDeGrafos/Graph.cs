using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace editorDeGrafos
{
    public class Graph
    {
        #region GraphVariables
        //
        private List<List<NodeRef>> graph;//list of lists of NodeRef is a graph
        private List<List<NodeRef>> transposedGraph;// a transposed gragph created 

        private List<Node> nodeList_G = new List<Node>();//all Nodes in the graph.
        private List<int> IDList_G;//list of created IDs.

        private List<Edge> edgeList_G = new List<Edge>();//all undirected Edges.
        private List<Edge> diEdgeList_G = new List<Edge>();//all directed Edges.
        private List<Edge> cicleEdgeList_G = new List<Edge>();// all cicled Edges.

        #endregion

        #region GraphStyles

        /* STYLES for the graph */

        Color[] colorsArray = new Color[] { Color.Black, Color.ForestGreen, Color.Blue, Color.Red };
        //normal colors:
        //0 is the default color
        //1 is the first color depending on the selection
        //2 is the next color depending on the selection
        //3....
        //.....

        Color[] _colorsArray = new Color[] { Color.SlateGray, Color.HotPink, Color.RosyBrown, Color.BlueViolet };
        //mode actives
        //0 is the default color
        //1 is the first color depending on the selection
        //2 is the next color depending on the selection
        //3....
        //.....

        /**********************************************
         * 
         * 
         * ||||||||||||| Styles of the graph |||||||||||||||||
         * 
         * 
         * *******************************************/
        // for asking for color
        public Color COLORS(Node nodo)
        {
            //depending on the slected state the node have different colors
            return this.colorsArray[nodo.Status];
        }
        public Color COLORS(int indice)
        {
            //depending on the slected state the node have different colors
            return this.colorsArray[indice];
        }
        //// when inverted colors are asked.
        public Color _COLORS(Node nodo)
        {
            return this._colorsArray[nodo.Status];
        }
        public Color _COLORS(int indice)
        {
            return this._colorsArray[indice];
        }
        #endregion

        #region GraphConstructor

        /*******************************************************************
         * 
         * 
         * |||||||||||||||   Graph constructors (Begin) |||||||||||||||
         * 
         * 
         * *****************************************************************/
        public Graph()
        {
            commonCostructor();
            graph = new List<List<NodeRef>>();
        }

        Graph(List<List<NodeRef>> graph, List<Node> nodeList, List<Edge> edgeList)
        {
            commonCostructor();
            this.graph = graph;
            this.nodeList_G = nodeList;
            this.edgeList_G = edgeList;
        }

        Graph(List<List<NodeRef>> graph, List<Node> nodeList, List<Edge> edgeList, List<Edge> diEdgeList, List<Edge> cicleEdgeList)
        {
            commonCostructor();
            this.graph = graph;
            this.nodeList_G = nodeList;
            this.edgeList_G = edgeList;
            this.diEdgeList_G = diEdgeList;
            this.cicleEdgeList_G = cicleEdgeList;
        }

        private void commonCostructor()// for all common variables.
        {
            IDList_G = new List<int>();
            IDList_G.Add(1000);
        }
        #endregion

        #region GraphGeters&Seters

        /*********************************************************
         * 
         * 
         * ||||||||||||| geters and seters (Begin) ||||||||||||||||
         * 
         * 
         * ********************************************************/
        public List<List<NodeRef>> GRAPH
        {
            get { return this.graph; }
            set { this.graph = value; }
        }

        public List<Node> NODE_LIST
        {
            get { return this.nodeList_G; }
            set { this.nodeList_G = value; }
        }

        public List<Edge> EDGE_LIST
        {
            get { return this.edgeList_G; }
            set { this.edgeList_G = value; }
        }

        public List<Edge> DIEDGE_LIST
        {
            get { return this.diEdgeList_G; }
            set { this.diEdgeList_G = value; }
        }

        public List<Edge> CIEDGE_LIST
        {
            get { return this.cicleEdgeList_G; }
            set { this.cicleEdgeList_G = value; }
        }

        public List<int> ID_LIST
        {
            get { return this.IDList_G; }
            set { this.IDList_G = value; }
        }
        #endregion

        #region GraphInfoMethods

        /*************************** types ********************************/
        //determine if the graph is a pseudoGraph
        public Boolean Pseudo()
        {
            Boolean res = false;
            for (int i = 0; i < graph.Count(); i++)
            {
                if (graph[i][i].W > -1)
                {
                    res = true;
                }
            }
            return res;
        }

        //Determine if a graph is directed
        public Boolean Directed()
        {
            if (diEdgeList_G.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //determine if a graph is complete
        public Boolean Complete()
        {
            Boolean res = true;
            for (int i = 0; i < graph.Count(); i++)
            {
                for (int j = 0; j < graph[i].Count(); j++)
                {
                    if (graph[i][j].W < 0 && i != j)
                    {
                        res = false;
                    }
                }
            }
            return res;
        }

        //deternmine if a undirectedgraph is clicled
        public Boolean Cicled()
        {
            if (this.Directed())
                return this.directedCicled();
            else
                return this.UndirectedCicled();
        }

        public Boolean UndirectedCicled()
        {
            HashSet<int> visited = new HashSet<int>();
            for (int vertex = 0; vertex < graph.Count(); vertex++)
            {
                if (visited.Contains(vertex))
                {
                    continue;
                }
                Boolean flag = dfsU(vertex, visited, -1);
                if (flag)
                {
                    return true;
                }
            }
            return false;
        }
        public Boolean dfsU(int vertex, HashSet<int> visited, int parent)
        {
            visited.Add(vertex);
            foreach (NodeRef nodeR in graph[vertex])
            {
                if (nodeR.W > -1)
                {
                    if (nodeR.NODO.Index.Equals(parent))
                    {
                        continue;
                    }
                    if (visited.Contains(nodeR.NODO.Index))
                    {
                        return true;
                    }
                    Boolean hasCycle = dfsU(nodeR.NODO.Index, visited, vertex);
                    if (hasCycle)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //Determine if a graph is cicled with BFS algorithm.
        //watch this video: https://www.youtube.com/watch?v=rKQaZuoUR4M 
        public Boolean directedCicled()
        {
            Boolean res = false;

            HashSet<int> whiteSet = new HashSet<int>();
            HashSet<int> graySet = new HashSet<int>();
            HashSet<int> blackSet = new HashSet<int>();

            for (int i = 0; i < graph.Count(); i++)
            {
                whiteSet.Add(i);
            }

            while (whiteSet.Count() > 0)
            {
                // int current = whiteSet.First();
                int current = whiteSet.Min();
                if (dfs(current, whiteSet, graySet, blackSet))
                {
                    return true;
                }
            }
            return res;
        }
        private void moveVertex(int v_Index, HashSet<int> sourceSet, HashSet<int> destinationSet)
        {
            sourceSet.Remove(v_Index);
            destinationSet.Add(v_Index);
        }

        private Boolean dfs(int currentIndex, HashSet<int> whiteS, HashSet<int> grayS, HashSet<int> blackS)
        {
            //move current to gray set from white set and then explore it.
            moveVertex(currentIndex, whiteS, grayS);
            foreach (NodeRef nodeR in graph[currentIndex])
            {
                if (nodeR.W > -1)
                {
                    //if in black set means already explored so continue.
                    if (blackS.Contains(nodeR.NODO.Index))
                    {
                        continue;
                    }
                    //if in gray set then cycle found.
                    if (grayS.Contains(nodeR.NODO.Index))
                    {
                        return true;
                    }
                    if (dfs(nodeR.NODO.Index, whiteS, grayS, blackS))
                    {
                        return true;
                    }
                }
            }
            //move vertex from gray set to black set when done exploring.
            moveVertex(currentIndex, grayS, blackS);
            return false;
        }



        //public Boolean Bipartita()
        //{
        //    HashSet<int> whiteSet = new HashSet<int>();
        //    HashSet<int> blueSet = new HashSet<int>();
        //    HashSet<int> redSet = new HashSet<int>();
        //    HashSet<int> visited = new HashSet<int>();

        //    for (int i = 0; i < graph.Count(); i++)
        //    {
        //        whiteSet.Add(i);
        //    }
        //    moveVertex(0, whiteSet, blueSet);
        //    visited.Add(0);
        //    return Bipartita2(0, visited, blueSet, redSet, whiteSet);
        //}

        //public Boolean Bipartita2(int origin, HashSet<int> visited, HashSet<int> originColorSet, HashSet<int> destinationColorSet, HashSet<int> whiteSet)
        //{
        //    foreach (NodeRef nodeR in graph[origin])
        //    {
        //        if (nodeR.W > -1)
        //        {
        //            if (!visited.Contains(nodeR.NODO.Index))
        //            {
        //                // mark present vertic as visited 
        //                visited.Add(nodeR.NODO.Index);

        //                // mark its color opposite to its parent 
        //                this.moveVertex(nodeR.NODO.Index, whiteSet, destinationColorSet);

        //                // if the subtree rooted at vertex v is not bipartite 
        //                if (Bipartita2(nodeR.NODO.Index, visited, destinationColorSet, originColorSet, whiteSet))
        //                    return false;
        //            }
        //            else
        //             if (originColorSet.Contains(nodeR.NODO.Index) && originColorSet.Contains(origin))
        //                return false;
        //        }
        //    }
        //    return true;
        //}
        public Boolean Bip()
        {
            if (graph.Count() > 0)
            {
                // Create a color array to store  
                // colors assigned to all veritces. 
                // Vertex number is used as index  
                // in this array. The value '-1' 
                // of colorArr[i] is used to indicate  
                // that no color is assigned 
                // to vertex 'i'. The value 1 is  
                // used to indicate first color 
                // is assigned and value 0 indicates  
                // second color is assigned. 
                int[] colorArr = new int[graph.Count()];
                for (int i = 0; i < graph.Count(); ++i)
                    colorArr[i] = -1;

                // Assign first color to source 
                colorArr[0] = 1;

                // Create a queue (FIFO) of vertex numbers  
                // and enqueue source vertex for BFS traversal 
                List<int> q = new List<int>();
                q.Add(0);

                // Run while there are vertices 
                // in queue (Similar to BFS) 
                while (q.Count != 0)
                {
                    // Dequeue a vertex from queue 
                    int u = q[0];
                    q.RemoveAt(0);

                    // Return false if there is a self-loop  
                    if (graph[u][u].W > -1)
                        return false;

                    // Find all non-colored adjacent vertices 
                    for (int v = 0; v < graph.Count(); ++v)
                    {
                        // An edge from u to v exists  
                        // and destination v is not colored 
                        if (graph[u][v].W > -1 && colorArr[v] == -1)
                        {
                            // Assign alternate color  
                            // to this adjacent v of u 
                            colorArr[v] = 1 - colorArr[u];
                            q.Add(v);
                        }

                        // An edge from u to v exists and  
                        // destination v is colored with 
                        // same color as u 
                        else if (graph[u][v].W > -1 &&
                                 colorArr[v] == colorArr[u])
                            return false;
                    }
                }

                for (int i = 0; i < graph.Count(); i++)
                {
                    for (int j = 0; j < graph.Count(); j++)
                    {
                        if (this.Directed() == true)
                        {
                            if (this.GradeOfDirectedNode(graph[i][j].NODO).Total == 0)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (graph[i][j].NODO.Grade == 0)
                            {
                                return false;
                            }
                        }
                        if (graph[i][i].W > -1)
                        {
                            return false;
                        }
                    }
                }
                // If we reach here, then all adjacent vertices 
                // can be colored with alternate color 
                return true;
            }
            else
            {
                return false;
            }
        }

        public Node mostGrade(List<Node> nodeList)
        {
            int mostGrade = 0;
            Node res = null;

            foreach (Node node in nodeList)
            {
                if (node.Grade > mostGrade)
                {
                    res = node;
                    mostGrade = node.Grade;
                }
            }
            return res;
        }

        public List<Node> mostGrades(List<Node> nodeList)
        {
            int mostGrade = 0;
            List<Node> res = null;

            foreach (Node node in nodeList)
            {
                if (node.Grade > mostGrade)
                {
                    res = new List<Node>();
                    res.Add(node);

                    mostGrade = node.Grade;
                }
                else if (node.Grade== mostGrade)
                {
                    res.Add(node);
                }
            }
            return res;
        }

        #endregion

        #region GraphPrivateMethods
        private int createID()//crea un id diferente a cualquiera de la lista de nodos
        {
            Boolean different;
            int res;
            Random random = new Random();

            do
            {
                different = true;
                res = random.Next(1000, 9999);
                foreach (int num in this.IDList_G)//ID list should be a tree so the time-complexity to compruebe the exixtence of the random number generated could decresse
                {
                    if (res == num)
                    {
                        different = false;
                        break;//doesn't make sense continuing serching. Basic heuristic avrd.
                    }
                }
            }
            while (different == false);
            return res;
        }

        private int createIDAlpha()//crea un id diferente a cualquiera de la lista de nodos
        {
            Boolean different;
            int res;
            Random random = new Random();

            do
            {
                different = true;
                res = random.Next(1000, 9999);
                foreach (int num in this.IDList_G)//ID list should be a tree so the time-complexity to compruebe the exixtence of the random number generated could decresse
                {
                    if (res == num)
                    {
                        different = false;
                        break;//doesn't make sense continuing serching. Basic heuristic avrd.
                    }
                }
            }
            while (different == false);
            return res;
        }

        #endregion//Private Methods END

        #region GraphPublicMethods

        /********************** Basics Operations(Begin) **************************/
        //create and add a new node to the graph
        public void create(Point cor, int generalRadius)
        {
            Point newNodePosition = new Point(cor.X, cor.Y);
            Node newNode;
            newNode = new Node(newNodePosition, generalRadius, this.nodeList_G.Count(), this.createID());
            //this.addNode(newNode);
        }

        public void create(Coordenate cor, int generalRadius, Color color)
        {
            Point newNodePosition = new Point(cor.X, cor.Y);
            Node newNode;
            newNode = new Node(newNodePosition, generalRadius, this.nodeList_G.Count(), this.createID(), color);
            //this.addNode(newNode);
        }

        public void removeNode(Node nodo)//almost the same process as addNode() but vice versa.
        {
            int nodeIndexToEiminate = nodo.Index;
            nodeList_G.Remove(nodo);

          
            graph.RemoveAt(nodeIndexToEiminate);


            for(int j = this.nodeList_G.Count()-1; j == 0; j--)
            {
                nodeList_G[j].Index--;
            }

        }//remove a node.


        /*
        public void addNode(Node nodo)
        {
            List<NodeRef> newNodeRefList = new List<NodeRef>();//the new list for the new node conections.           
            nodeList_G.Add(nodo);

            if (graph.Count() == 0)//ther's no elements
            {
                TidyPair tidyP = new TidyPair(0, 0); ;
                NodeRef nodoRef = new NodeRef(-1, nodo, tidyP, true);            //the new Node that is going to be added have no conection, so it have a -1 value.
                newNodeRefList.Add(nodoRef);
                graph.Add(newNodeRefList);
            }
            else//At least one element.
            {
                //int j = 0;
                for (int i = 0; i < graph.Count; i++)
                {
                    if (i == graph.Count)
                    {
                        newNodeRefList.Add(new NodeRef(-1, graph[i][i].NODO, new TidyPair(i, graph.Count()), true)); //making the new list for the end of the "array".
                    }
                    else
                    {
                        newNodeRefList.Add(new NodeRef(-1, graph[i][i].NODO, new TidyPair(i, graph.Count()))); //making the new list for the end of the "array".
                    }

                }

                graph.Add(newNodeRefList);//adding the list made.
                                          // terminal = "hay elementos" + graph.Count() + graph[0][0].NODO.ToString();
                int iF = 0;
                foreach (List<NodeRef> row in graph)
                {
                    row.Add(new NodeRef(-1, nodo, new TidyPair(nodo.Index, iF))); //adding to each row the new Node.
                    iF++;
                }
            }
        }
        */


        public void addUndirectedEdge(Node client, Node server, int weight)
        {
            edgeList_G.Add(new Edge(client, server, weight));
            if (graph.Count > client.Index && graph.Count > server.Index)
            {
                if (graph[client.Index].Count > server.Index && graph[server.Index].Count > client.Index)
                {
                    graph[client.Index][server.Index].W = weight;
                    graph[server.Index][client.Index].W = weight;
                }
            }
        }

        public void addUndirectedEdge(Edge edge)
        {
            edgeList_G.Add(edge);
        }
        public void addUndirectedEdge(Edge edge, int weight)
        {
            edgeList_G.Add(edge);
            if (graph.Count > edge.client.Index && graph.Count > edge.server.Index)
            {
                if (graph[edge.client.Index].Count > edge.server.Index && graph[edge.server.Index].Count > edge.client.Index)
                {
                    graph[edge.client.Index][edge.server.Index].W = weight;
                    graph[edge.server.Index][edge.client.Index].W = weight;
                }
            }
        }

        public void addDirectedEdge(Node client, Node server, int weight)
        {
            graph[client.Index][server.Index].W = weight;
            this.diEdgeList_G.Add(new Edge(client, server, weight));
        }



        public void addCicledEdge(Node node, int weight)
        {
            graph[node.Index][node.Index].W = weight;
            this.cicleEdgeList_G.Add(new Edge(node, weight));
        }


        /*
         * 
         * Description: returns a pure bool matrix representing the graph conections
         * this kind of matrix is known as adjacency Matrix.
         * 
         * 
         * 
         * */
        public bool[,] adjacencyMatrix()
        {
            //a boolean matrix is created to represent the adjacency matrix
            //at the begining every space initialize in false.
            bool[,] res = new bool[this.nodeList_G.Count(), this.nodeList_G.Count()];

            //for each node in the node list of the graph 
            foreach (Node node in this.nodeList_G)
            {
                //for each neighbor in the neirghbr list of the node working
                foreach (NodeRef neighbor in node.NEIGHBORS)
                {
                    res[this.nodeList_G.IndexOf(node), this.nodeList_G.IndexOf(neighbor.NODO)] = true;
                }
            }
            return res;
        }

        /*
         * 
         * Description: returns a boolean matrix represented with 1s and 0s only.
         * 
         * 
         */

        public int[,] adjacencyMatrix(int any)
        {
            //a integer matrix is created to represent the adjacency matrix(only 0s and 1s)
            //at the begining every space initialize in false.
            int[,] res = new int[this.nodeList_G.Count(), this.nodeList_G.Count()];

            //for each node in the node list of the graph 
            foreach (Node node in this.nodeList_G)
            {
                //for each neighbor in the neirghbr list of the node working
                foreach (NodeRef neighbor in node.NEIGHBORS)
                {
                    res[this.nodeList_G.IndexOf(node), this.nodeList_G.IndexOf(neighbor.NODO)] = 1;
                }
            }
            return res;
        }


        /*
         * 
         * Description: return a matrix that representing the graph with the minimum cost edges
         * 
         * 
         */
        public int[][] incidenceMatrix()
        {
            //a boolean matrix is created to represent the adjacency matrix
            //at the begining every space initialize in false.
            int[][] res;

            res = Enumerable.Repeat(Enumerable.Repeat(-1, this.nodeList_G.Count()).ToArray(), this.nodeList_G.Count()).ToArray();

            //for each node in the node list of the graph 
            foreach (Node node in this.nodeList_G)
            {
                //for each neighbor in the neirghbor list of the node working
                foreach (NodeRef neighbor in node.NEIGHBORS)
                {
                    int comparison = res[this.nodeList_G.IndexOf(node)][this.nodeList_G.IndexOf(neighbor.NODO)];


                    if (res[this.nodeList_G.IndexOf(node)][this.nodeList_G.IndexOf(neighbor.NODO)] == -1)
                    {
                        res[this.nodeList_G.IndexOf(node)][this.nodeList_G.IndexOf(neighbor.NODO)] = neighbor.W;
                    }
                    else
                    {
                        //if the value in the matrix is grater than the value in the list
                        if (res[this.nodeList_G.IndexOf(node)][this.nodeList_G.IndexOf(neighbor.NODO)] > neighbor.W)
                        {
                            res[this.nodeList_G.IndexOf(node)][this.nodeList_G.IndexOf(neighbor.NODO)] = neighbor.W;
                        }
                    }

                }
            }
            return res;
        }



        /*
 * 
 * Description: return a matrix that representing the graph with the maximum cost edges
 * 
 * 
 */
        public int[][] incidenceMatrix(int any)
        {
            //a boolean matrix is created to represent the adjacency matrix
            //at the begining every space initialize in false.
            int[][] res;

            res = Enumerable.Repeat(Enumerable.Repeat(-1, this.nodeList_G.Count()).ToArray(), this.nodeList_G.Count()).ToArray();

            //for each node in the node list of the graph 
            foreach (Node node in this.nodeList_G)
            {
                //for each neighbor in the neirghbor list of the node working
                foreach (NodeRef neighbor in node.NEIGHBORS)
                {
                    int comparison = res[this.nodeList_G.IndexOf(node)][this.nodeList_G.IndexOf(neighbor.NODO)];


                    if (res[this.nodeList_G.IndexOf(node)][this.nodeList_G.IndexOf(neighbor.NODO)] == -1)
                    {
                        res[this.nodeList_G.IndexOf(node)][this.nodeList_G.IndexOf(neighbor.NODO)] = neighbor.W;
                    }
                    else
                    {
                        //if the value in the matrix is less than the value in the list
                        if (res[this.nodeList_G.IndexOf(node)][this.nodeList_G.IndexOf(neighbor.NODO)] < neighbor.W)
                        {
                            res[this.nodeList_G.IndexOf(node)][this.nodeList_G.IndexOf(neighbor.NODO)] = neighbor.W;
                        }
                    }

                }
            }
            return res;

        }

        public String ToString(bool paramBool)
        {
            String resString = "";
            int i = 0;
            foreach (List<NodeRef> row in graph)
            {
                resString += "@" + i;
                foreach (NodeRef nodoR in row)
                {
                    if (paramBool == false)
                    {
                        resString += "\t" + "(" + i + ":" + nodoR.NODO.Index + ")= " + nodoR.W;
                    }
                    else
                    {
                        if (nodoR.W > -1)
                            resString += "\t" + 1;
                        else
                            resString += "\t" + 0;
                    }
                }
                resString += System.Environment.NewLine;
                i++;
            }
            return resString;
        }


        public void markAllEdgesAsNotVisited(List<Edge> listEdge)
        {
            foreach (Edge edge in listEdge)
            {
                edge.visitada = false;
                edge.COLOR = Color.Black;
            }
        }


        public void eliminateNexetDirectedEdges(Node node)
        {
            List<Edge> newEdges = new List<Edge>();

            foreach (Edge edge in diEdgeList_G)
            {
                if (edge.Client != node && edge.Server != node)
                {
                    newEdges.Add(edge);
                }
            }
            diEdgeList_G = newEdges;
        }

        public void eliminateCicledEdges(Node node)
        {
            List<Edge> newEdges = new List<Edge>();

            foreach (Edge edge in cicleEdgeList_G)
            {
                if (edge.Client != node && edge.Server != node)
                {
                    newEdges.Add(edge);
                }
            }
            cicleEdgeList_G = newEdges;
        }

        public void resetNew()
        {
            graph = new List<List<NodeRef>>();//list of lists of NodeRef is a graph

            transposedGraph = new List<List<NodeRef>>();//list of reference nodes 

            this.nodeList_G = new List<Node>();//all Nodes in the graph.

            this.edgeList_G = new List<Edge>();//all undirected Edges.

            this.diEdgeList_G = new List<Edge>();//all directed Edges.

            this.cicleEdgeList_G = new List<Edge>();// all cicled Edges.

            List<int> IDList_G = new List<int>();//list of created IDs.
        }





        /*public List<Node> neighborListNode(Node workingNode)
        {
            List<Node> res = new List<Node>();
            for (int i = 0; i < graph[workingNode.Index].Count(); i++)
            {
                if (graph[workingNode.Index][i].W > -1)
                {
                    res.Add(graph[workingNode.Index][i].NODO);
                }
            }
            return res;
        }
        */

        public List<Node> neighborListIndex(int workingNode)
        {
            List<Node> res = new List<Node>();
            for (int i = 0; i < graph[workingNode].Count(); i++)
            {
                if (graph[workingNode][i].W > -1)
                {
                    res.Add(graph[workingNode][i].NODO);
                }
            }
            return res;
        }

        public List<Node> neighborListNodeNoVisited(Node workingNode)
        {
            List<Node> res = new List<Node>();
            for (int i = 0; i < graph[workingNode.Index].Count(); i++)
            {
                if (graph[workingNode.Index][i].W > -1 && graph[workingNode.Index][i].NODO.Visited == false)
                {
                    res.Add(graph[workingNode.Index][i].NODO);

                }
            }
            return res;
        }

        public List<Node> notVisitedList()
        {
            List<Node> res = new List<Node>();
            foreach (Node node in nodeList_G)
            {
                if (node.Visited == false)
                {
                    res.Add(node);
                }
            }
            return res;
        }

        public List<Edge> notVisitedListEdge()
        {
            List<Edge> res = new List<Edge>();
            foreach (Edge edge in edgeList_G)
            {
                if (edge.visitada == false)
                {
                    res.Add(edge);
                }
            }
            return res;
        }

        public void restoreNotVisited(List<Node> notVisitedYet)
        {
            foreach (Node node in nodeList_G)
            {
                if (notVisitedYet.Contains(node))
                {
                    node.Visited = false;
                }
                else
                {
                    node.Visited = true;
                }
            }
        }

        public void restoreNotVisitedEdge(List<Edge> notVisitedYetEdge)
        {
            foreach (Edge edge in edgeList_G)
            {
                if (notVisitedYetEdge.Contains(edge))
                {
                    edge.visitada = false;
                }
                else
                {
                    edge.visitada = true;
                }
            }
        }

        public List<Node> listOfconectedNodes()//nodes that have at least one conection.
        {
            List<Node> resList = new List<Node>();
            for (int i = 0; i < graph.Count(); i++)
            {
                if (graph[i][i].W > -1)
                {
                    resList.Add(graph[i][i].NODO);
                }
            }
            return resList;

        }

        public Boolean isACutNodeBool(Node node)
        {
            node.Visited = true;
            isConected();
            if (allVisitedExept(node))
            {
                return true;
            }
            return false;
        }

      /*  public Boolean redeiPAthUtil(Node workingNode)
        {
            foreach (Node node in this.nodeList_G)
            {
                if (!this.neighborListNode(workingNode).Contains(node))
                {
                    if (this.neighborListNode(workingNode).Count()
                        + this.neighborListNode(node).Count()
                        < this.nodeList_G.Count() - 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
      */

        /*
        public Boolean redeiCycleUtil(Node workingNode)
        {
            foreach (Node node in this.nodeList_G)
            {
                if (!this.neighborListNode(workingNode).Contains(node))
                {
                    if (this.neighborListNode(workingNode).Count()
                        + this.neighborListNode(node).Count()
                        < this.nodeList_G.Count())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        */

        /*
        public Boolean redeiPAth()
        {
            foreach (Node node in this.nodeList_G)
            {
                if (!redeiPAthUtil(node))//if any does not do the redei
                {
                    return false;
                }
            }
            return true;
        }
        */
        /*
        public Boolean redeiCycle(Node workingNode)
        {
            foreach (Node node in this.nodeList_G)
            {
                if (!this.neighborListNode(workingNode).Contains(node))
                {
                    if (this.neighborListNode(workingNode).Count()
                        + this.neighborListNode(node).Count()
                        < this.nodeList_G.Count())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        */
        public Boolean isConected()
        {
            // Mark all the vertices as not visited 
            markAllLikeNotVisited();

            // Start DFS traversal from a vertex with non-zero degree 
            DFSUtilAllConected(this.nodeList_G[0]);

            // Check if all non-zero degree vertices are visited 
            foreach (Node node in this.nodeList_G)
            {
                if (node.Visited == false)
                {
                    return false;
                }
            }
            return true;
        }

        public void markIsolateNodesAsVisited()
        {
            List<Node> conectedNodes = listOfconectedNodes();
            foreach (Node node in nodeList_G)//each node 
            {
                if (!conectedNodes.Contains(node))//if the node is out of the list of conectedNodes
                {
                    node.Visited = true;
                }
            }
        }

        public void allBlack()
        {
            foreach (Edge edge in diEdgeList_G)
            {
                edge.COLOR = Color.Gray;
            }
            foreach (Edge edge in edgeList_G)
            {
                edge.COLOR = Color.Black;
            }
            foreach (Edge edge in cicleEdgeList_G)
            {
                edge.COLOR = Color.Black;
            }
            //foreach (Node node in nodeList_G)
            //{
            //    node.COLOR = Color.Black;
            //}
        }

        public void eliminateNexetEdges(Node node)
        {
            List<Edge> newEdges = new List<Edge>();

            foreach (Edge edge in this.edgeList_G)
            {
                if (edge.Client != node && edge.Server != node)
                {
                    newEdges.Add(edge);
                }
            }
            this.edgeList_G = newEdges;
        }

        public Edge thisEdge(Node client, Node server)
        {
            Edge thisEdge = new Edge(client, server);

            foreach (Edge edge in this.edgeList_G)
            {
                if (edge.EqualsU(thisEdge))
                {
                    return edge;
                }
            }
            return null;
        }

        public Edge thisEdgeDirOrIndir(int client, int server)
        {

            if (thisEdge_Directed(client, server) != null)
            {
                return thisEdge_Directed(client, server);
            }
            else if (thisEdge_Undirected(client, server) != null)
            {
                return thisEdge_Directed(client, server);
            }
            return null;
        }

        public Edge thisEdge_Directed(int client, int server)
        {
            foreach (Edge edge in this.diEdgeList_G)
            {
                if ((edge.Client.Index == client && edge.Server.Index == server) ^ (edge.Client.Index == server && edge.Server.Index == client))
                {
                    return edge;
                }
            }
            return null;
        }

        public Edge thisEdge_Undirected(int client, int server)
        {

            foreach (Edge edge in this.edgeList_G)
            {
                if ((edge.Client.Index == client && edge.Server.Index == server) || (edge.Client.Index == server && edge.Server.Index == client))
                {
                    return edge;
                }
            }
            return null;
        }

        public List<Edge> thisEdgesWeight_Undirected(int weight)
        {
            List<Edge> res = new List<Edge>();
            for (int j = 0; j < graph.Count(); j++)
            {
                for (int i = 0; i < graph.Count(); i++)
                {
                    if (graph[j][i].W > -1 && j != i)
                    {
                        if (graph[j][i].W == weight)
                        {
                            res.Add(this.thisEdge_Undirected(j, i));
                        }
                    }
                }
            }

            return res;
        }

        public Boolean directEdgeVisitated_ByIndex(int Client, int Server)
        {
            foreach (Edge edge in edgeList_G)
            {
                if ((edge.Client.Index == Client && edge.Server.Index == Server) || (edge.Client.Index == Server && edge.Server.Index == Client))
                {
                    return edge.visitada;
                }
            }
            return false;
        }

        public int[] nodeListIndexOfedgeList(List<Edge> edgeList)
        {
            List<int> res = new List<int>();
            foreach (Edge edge in edgeList)
            {
                if (!res.Contains(edge.Client.Index))
                {
                    res.Add(edge.Client.Index);
                }
                if (!res.Contains(edge.Server.Index))
                {
                    res.Add(edge.Server.Index);
                }
            }
            return res.ToArray();
        }

        public Boolean allNodesVisitedBool()
        {
            foreach (Node node in nodeList_G)
            {
                if (node.Visited == false)
                    return false;
            }
            return true;
        }

        public void markAllNodesLikeNotVisited()
        {
            foreach (Node node in this.nodeList_G)
            {
                node.Visited = false;
            }
        }



        public void markAllEdgesLikeNotVisited()
        {
            foreach (Edge edge in edgeList_G)
            {
                edge.visitada = false;
            }
        }

        public void markAllNodeAndEdgesNotVisited()
        {
            markAllNodesLikeNotVisited();
            markAllEdgesLikeNotVisited();

        }

        public void markAllLikeNotVisited(int code)
        {
            markAllLikeNotVisited();
            foreach (Edge edge in edgeList_G)
            {
                edge.visitada = false;
            }
        }

        public void markAllLikeNotBridge()
        {
            foreach (Edge edge in this.edgeList_G)
            {
                edge.Bridge = false;
            }
        }

        public Graph clone()
        {
            List<List<NodeRef>> graphEno = new List<List<NodeRef>>();
            List<Node> listOfNodes = new List<Node>();
            List<Edge> listOfEdges = new List<Edge>();

            foreach (Edge edge in edgeList_G)
            {
                listOfEdges.Add(edge);
            }
            foreach (Node node in nodeList_G)
            {
                listOfNodes.Add(node);
            }
            graphEno = this.graph;
            return (new Graph(graphEno, listOfNodes, listOfEdges));
        }

        public void markAllLikeNotVisited()
        {
            for (int j = 0; j < graph.Count(); j++)
                for (int i = 0; i < graph.Count(); i++)
                {
                    graph[j][i].NODO.Visited = false;
                    //graph[j][i].NODO.COLOR = Color.Black;
                }
        }

        public void markAsVisited_T_F(int index, Boolean mark)
        {
            graph[index][index].NODO.Visited = mark;
        }

        public Node thisode(int index)
        {
            foreach(Node node in this.NODE_LIST)
            {
                if(node.Index == index)
                {
                    return node;
                }
            }
            return null;
        }

        public Node thisnode(int ID)
        {
            foreach (Node node in this.NODE_LIST)
            {
                if (node.ID == ID)
                {
                    return node;
                }
            }
            return null;
        }

        public Node thisnode(Node other)
        {
            foreach (Node node in this.NODE_LIST)
            {
                if (node.ID == other.ID)
                {
                    return node;
                }
            }
            return null;
        }

        public Matrix toMatrix()
        {
            Matrix res;
            int[,] toDoMatrix = new int[graph.Count(), graph.Count()];

            for (int j = 0; j < graph.Count(); j++)
                for (int i = 0; i < graph.Count(); i++)
                {
                    if (graph[j][i].W > -1)
                        toDoMatrix[j, i] = 1;
                    else
                        toDoMatrix[j, i] = 0;
                }
            res = new Matrix(toDoMatrix);
            return res;
        }


        public int Grade()
        {
            int res = 0;
            for (int i = 0; i < graph.Count(); i++)
            {
                res += graph[i][i].NODO.Grade;
            }
            return res;
        }

        public Node getNodeByPosition(Point cor)
        {
            Node resNode = null;
            foreach (Node onNode in this.NODE_LIST)
            {
                if (cor.X > onNode.Position.X - onNode.Radius //for conditions in order to determine wheter or not , a click hit the specific node
                   && cor.X < onNode.Position.X + onNode.Radius
                   && cor.Y < onNode.Position.Y + onNode.Radius
                   && cor.Y > onNode.Position.Y - onNode.Radius)
                {
                    resNode = onNode;
                }//one node clicked.
            }//check all the node list.
            return resNode;

        }
        

        public DirectedGrade GradeOfDirectedNode(Node nodo)
        {
            DirectedGrade res;
            int input = 0;
            int output = 0;
            foreach (List<NodeRef> row in graph)
            {
                foreach (NodeRef nodeR in row)
                {
                    if (graph.IndexOf(row) == row.IndexOf(nodeR))
                    {
                        if (nodeR.W > -1)
                        {
                            input++;
                            output++;
                        }
                    }
                    else
                    {
                        if (graph.IndexOf(row) == nodo.Index)
                        {
                            if (nodeR.W > -1)
                            {
                                output++;
                            }
                        }
                        if (row.IndexOf(nodeR) == nodo.Index)
                        {
                            if (nodeR.W > -1)
                            {
                                input++;
                            }
                        }

                    }
                }
            }
            res = new DirectedGrade(input, output);
            return res;
        }

        public Boolean allVisitedExept(Edge workinEdge)
        {
            foreach (Edge edge in this.edgeList_G)
            {
                if (edge != workinEdge && edge.visitada == false)
                {
                    return false;
                }
            }
            return true;
        }


        public Boolean allVisitedExept(Node workingNode)
        {
            foreach (Edge edge in edgeList_G)
            {
                if (edge.server != workingNode)
                {
                    if (edge.server.Visited == false)
                    {
                        return false;
                    }
                }
                if (edge.client != workingNode)
                {
                    if (edge.client.Visited)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

      


        public Boolean allVisitedExept(List<Node> listNodes, Node workingNode)
        {
            foreach (Node node in listNodes)
            {
                if (node != workingNode)
                {
                    if (node.Visited == false)
                        return false;
                }
            }
            return true;
        }

        /********************** Basics Operations (End) **************************/
        #endregion//public methods END

        #region Algorithms


        List<Edge> edgeListforGeneratedCycle;
        Edge edgeForGeneratedCycle;
        public Boolean generateCycle(List<Edge> edgeList, Edge prove)
        {
            edgeListforGeneratedCycle = edgeList;
            edgeForGeneratedCycle = prove;

            HashSet<int> visited = new HashSet<int>();
            for (int vertex = 0; vertex < graph.Count(); vertex++)
            {
                if (visited.Contains(vertex))
                {
                    continue;
                }
                Boolean flag = dfsGenerateCycle(vertex, visited, -1);
                if (flag)
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean dfsGenerateCycle(int vertex, HashSet<int> visited, int parent)
        {
            visited.Add(vertex);
            foreach (NodeRef nodeR in graph[vertex])
            {
                Edge auxEdge = this.thisEdge_Undirected(vertex, nodeR.NODO.Index);
                if (nodeR.W > -1 && (edgeListforGeneratedCycle.Contains(auxEdge) || auxEdge == edgeForGeneratedCycle))
                {
                    if (nodeR.NODO.Index.Equals(parent))
                    {
                        continue;
                    }
                    if (visited.Contains(nodeR.NODO.Index))
                    {
                        return true;
                    }
                    Boolean hasCycle = dfsGenerateCycle(nodeR.NODO.Index, visited, vertex);
                    if (hasCycle)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        #region isomorphism
        /******************************************************************************************************************
         * 
         * STARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTART
         * 
         *                         ----- START OF ALGORITHM OF ISOMORFISM -----
         *                                    
         * STARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTARTSTART
         * 
         ********************************************************************************************************************/
        private Boolean heuristicIsom(Graph other)
        {
            if (this.GRAPH.Count() == other.GRAPH.Count())
            {
                if (this.Grade() == other.Grade())
                    if (this.Directed() == other.Directed())
                        if (this.Complete() == other.Complete())
                            if (this.Pseudo() == other.Pseudo())
                                if (this.Cicled() == other.Cicled())
                                    if (this.Bip() == other.Bip())
                                        return true;
            }
            return false;
        }

        private PermutationSetStruct heuristicIsom_SEC_FASE(Graph other)
        {
            PermutationSetStruct res = new PermutationSetStruct(other.GRAPH.Count());
            int grade_T;
            int grade_O;

            for (int i = 0; i < other.GRAPH.Count(); i++)
            {
                grade_T = this.GRAPH[i][i].NODO.Grade;

                res.addIndex_T(grade_T, this.GRAPH[i][i].NODO.Index);

                grade_O = other.GRAPH[i][i].NODO.Grade;
                res.addIndex_O(grade_O, other.GRAPH[i][i].NODO.Index);
            }
            return res;
        }



        /******************************************************************************************************************
        * 
        * ENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDEND
        * 
        *                              ----- END OF ALGORITHM OF ISOMORFISM -----
        *                                    
        * ENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDENDEND
        * 
        ********************************************************************************************************************/
        #endregion

        #region isomorphism_Brute_Force
        /********************************************************************************************
        * 
        * 
        *      ISOMORPHISM : First algorithm of isimorphism. Implemented by me... ñ_ñ 
        * 
        * 
        * *******************************************************************************************/
        listOfNodeListsGrade thisIsomList;
        listOfNodeListsGrade otherIsomList;
        public Boolean equals(Graph other)
        {
            if (other.GRAPH.Count() != this.GRAPH.Count())
            {
                return false;
            }
            for (int j = 0; j < other.GRAPH.Count(); j++)
            {
                for (int i = 0; i < other.GRAPH.Count(); i++)
                {
                    if (this.GRAPH[j][i].W != other.GRAPH[j][i].W)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public Boolean Isomo_Fuerza_Bruta(Graph other)
        {
            //Boolean res = false;              
            if (heuristicIsom(other))
            {
                //PermutationSetStruct gradePairs;
                //gradePairs = heuristicIsom_SEC_FASE(other);

                if (other.GRAPH.Count() <= 1 && this.GRAPH.Count() <= 1)//
                {
                    return true;
                }
                else
                {
                    if (this.equals(other))//si los grafos son iguales retorna true.
                    {
                        return true;
                    }
                    else
                    {
                        thisIsomList = new listOfNodeListsGrade();
                        otherIsomList = new listOfNodeListsGrade();
                        thisIsomList.init(this);
                        otherIsomList.init(other);
                        if (!thisIsomList.equals(otherIsomList))
                        {
                            return false;
                        }
                        else
                        {
                            // return true;// Isomo_Fuerza_Bruta_Algorithm();    
                            return Isomo_Fuerza_Bruta_Algorithm(thisIsomList, otherIsomList, other);
                        }


                    }
                }
            }//END of the heuristic.
            return false;
        }



        public Boolean Isomo_Fuerza_Bruta_Algorithm(listOfNodeListsGrade this_L_Nlg, listOfNodeListsGrade other_L_Nlg, Graph other)
        {
            this.markAllNodeAndEdgesNotVisited();
            other.markAllNodeAndEdgesNotVisited();

            int iterations = 1;
            int i_Other = 0;
            int j_Other = 0;

            foreach (NodeListGrade nlg in other_L_Nlg.LIST_OF_LISTS)
            {
                iterations *= nlg.GRADE_NODE_LIST.Count();
            }

            Boolean res = true;

            for (int k = 0; k < iterations; k++)
            {
                res = true;
                for (int j = 0; j < this.graph.Count(); j++)
                {
                    j_Other = other_L_Nlg.Index_Of_cor(this_L_Nlg.cor_Of_Index(j));
                    for (int i = 0; i < other.GRAPH.Count(); i++)
                    {
                        i_Other = other_L_Nlg.Index_Of_cor(this_L_Nlg.cor_Of_Index(i));
                        if (this.GRAPH[j][i].W != other.GRAPH[j_Other][i_Other].W)
                        {
                            res = false;
                            break;
                        }
                    }
                    if (res == false)
                    {
                        break;
                    }
                }

                if (res)
                {
                    return res;
                }
                else
                {
                    other_L_Nlg.Rotate();
                }
            }
            return false;
        }// (END)

        #endregion

        #region isomorphism_traspose_matrix
        /********************************************************************************************
         * 
         * 
         *      ISOMORPHISM :algorithm of tranpose matrix.
         * 
         * 
         * *******************************************************************************************/
        public Boolean Isom_Traspuesta(Graph other)
        {
            //Boolean res = false;              

            if (heuristicIsom(other))
            {
                PermutationSetStruct gradePairs;
                gradePairs = heuristicIsom_SEC_FASE(other);

                if (other.GRAPH.Count() < 1 && this.GRAPH.Count() < 1)//
                {
                    return true;
                }
                else
                {
                    if (this.GRAPH.Equals(other.GRAPH))//si los grafos son iguales retorna true.
                    {
                        return true;
                    }
                    else
                    {
                        if (gradePairs.validateSet())
                        {
                            return Isom_Traspuesta_Algorithm(other, gradePairs);
                        }
                    }
                }
            }
            return false;
        }
        public Boolean Isom_Traspuesta_Algorithm(Graph other, PermutationSetStruct gradePairs)//Algorithm
        {
            int limitOfPermutations = 40000;
            Matrix thisMatrix = this.toMatrix();
            Matrix otherMatrix = other.toMatrix();

            Matrix permutationMatrix = new Matrix();
            Matrix permutationMatrixTrans = new Matrix();

            Matrix resMatrixOperation = new Matrix();
            ListOfPerPairLists listOfPerPairLists = new ListOfPerPairLists(gradePairs);
            PermutationPairList aux;

            while (limitOfPermutations > 0 && listOfPerPairLists.PER_ALFA_LIST.Count() > 0)
            {
                //get the next permutation:
                aux = listOfPerPairLists.PER_ALFA_LIST.ElementAt(0);
                listOfPerPairLists.PER_ALFA_LIST.RemoveAt(0);

                aux.toMatrixOfPermutationB(ref permutationMatrix, ref permutationMatrixTrans);//make the permutation matrix and the transpose.

                resMatrixOperation = permutationMatrix.MatrixProduct(otherMatrix);
                resMatrixOperation = resMatrixOperation.MatrixProduct(permutationMatrixTrans);

                if (thisMatrix.Equals(resMatrixOperation))
                {
                    return true;
                }
                limitOfPermutations--;
            }
            return false;
        }


        #endregion

        #region isomorphism_manual

        /********************************************************************************************
        * 
        * 
        *      ISOMORPHISM : In the manual.
        * 
        * 
        * *******************************************************************************************/
        public Boolean Isom_Inter(Graph other)
        {
            if (heuristicIsom(other))
            {
                PermutationSetStruct gradePairs;
                gradePairs = heuristicIsom_SEC_FASE(other);

                if (other.GRAPH.Count() < 1 && this.GRAPH.Count() < 1)//
                {
                    return true;
                }
                else
                {
                    if (this.GRAPH.Equals(other.GRAPH))//si los grafos son iguales retorna true.
                    {
                        return true;
                    }
                    else
                    {
                        if (gradePairs.validateSet())
                        {
                            return Isom_Inter_Algorithm(other);
                        }
                    }
                }
            }//END of the heuristic.
            return false;
        }

        public Boolean Isom_Inter_Algorithm(Graph other)
        {
            Matrix thisMatrix = this.toMatrix();
            Matrix otherMatrix = other.toMatrix();

            List<int> colIndexOne;
            List<int> sumEachRow = new List<int>();
            int sumCol = 0;

            List<int> colIndex_Two = new List<int>();
            int sumaCol_Two = 0;
            List<int> sumEachRow_Two = new List<int>();

            //int sumaRen;

            for (int iteratorInt = 0; iteratorInt < this.GRAPH.Count() - 1; iteratorInt++)
            {
                colIndexOne = new List<int>();
                sumCol = 0;
                sumEachRow = new List<int>();

                for (int j = 0; j < this.GRAPH.Count(); j++)
                {
                    if (thisMatrix.MATRIX[j, iteratorInt] == 1)
                    {
                        colIndexOne.Add(j);
                        sumCol++;
                        sumEachRow.Add(0);
                    }
                }

                int inte = 0;
                foreach (int index in colIndexOne)
                {
                    for (int j = 0; j < this.GRAPH.Count(); j++)
                    {
                        sumEachRow[inte] += thisMatrix.MATRIX[index, j];
                    }
                    inte++;
                }

                //EN EL SEGUNDO GRAFO:
                int iteratorColSec = iteratorInt + 1;

                for (int i = iteratorColSec; i < other.GRAPH.Count(); i++)
                {
                    colIndex_Two = new List<int>();
                    sumaCol_Two = 0;
                    sumEachRow_Two = new List<int>();

                    for (int j = 0; j < other.GRAPH.Count(); j++)
                    {
                        if (otherMatrix.MATRIX[j, iteratorColSec] == 1)
                        {
                            colIndex_Two.Add(j);
                            sumaCol_Two++;
                            sumEachRow_Two.Add(0);
                        }
                    }

                    inte = 0;
                    foreach (int index in colIndex_Two)
                    {
                        for (int j = 0; j < this.GRAPH.Count(); j++)
                        {
                            if (index < this.GRAPH.Count() && inte < sumEachRow.Count())
                                sumEachRow[inte] += thisMatrix.MATRIX[index, j];
                        }
                        inte++;
                    }

                    if (sumaCol_Two == sumCol && colIndexOne.Count() == colIndex_Two.Count())
                    {
                        sumEachRow.Sort();
                        sumEachRow_Two.Sort();
                        if (sumEachRow.Count() == sumEachRow_Two.Count())
                        {
                            int k;
                            for (k = 0; k < colIndexOne.Count(); k++)
                            {
                                if (sumEachRow[k] != sumEachRow_Two[k])
                                {
                                    continue;
                                }
                            }
                            if (k < colIndexOne.Count())
                            {
                                continue;
                            }

                            otherMatrix.interchangeRC(ref otherMatrix, otherMatrix.MATRIX.GetLength(0), iteratorInt, i);
                            if (otherMatrix.Equals(thisMatrix))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            continue;
                        }

                    }
                    else
                    {
                        continue;
                    }
                }
            }



            return false;
        }
        #endregion


        void DFSUtilAllConected(Node workingNode/*int v, bool visited[]*/)
        {
            // Mark the current node as visited
            workingNode.Visited = true;


            // Recur for all the vertices adjacent to this vertex
            foreach (Node node in workingNode.neighborListNode())
            {
                if (node.Visited == false)
                {
                    DFSUtilAllConected(node);
                }
            }
        }
        
        #endregion


        /************************************
         * 
         * Its time for new code, so.. take a deep breath and continue pal
         * 
         * 
         * ************************************/

        /********************** Basics Operations(Begin) **************************/
        //create and add a new node to the graph

        public void create_(Point cor, int generalRadius)
        {
            Point newNodePosition = new Point(cor.X, cor.Y);
            Node newNode;
            newNode = new Node(newNodePosition, generalRadius, this.nodeList_G.Count(), this.createID());
            //this.addNode(newNode);
            this.nodeList_G.Add(newNode);
        }

        public void create_(Node other)
        {
            this.nodeList_G.Add(other.clone()) ;
        }

        

        public void create_(Point cor, int generalRadius, Color color)
        {
            Point newNodePosition = new Point(cor.X, cor.Y);
            Node newNode;
            newNode = new Node(newNodePosition, generalRadius, this.nodeList_G.Count(), this.createID(), color);
            //this.addNode(newNode);
            this.nodeList_G.Add(newNode);
        }

        public void removeNode_(Node nodo)//almost the same process as addNode() but vice versa.
        {
            int nodeIndexToEiminate = nodo.Index;
            nodeList_G.Remove(nodo);

            foreach (List<NodeRef> row in graph)
            {
                row.RemoveAt(nodeIndexToEiminate);//removing the NodeRef of all the list of nodes.                                               
            }

            graph.RemoveAt(nodeIndexToEiminate);

            for (int j = 0; j < graph.Count(); j++)
            {
                List<NodeRef> noRe = graph[j];
                for (int i = 0; i < noRe.Count(); i++)
                {
                    if (i == j && noRe[i].NODO.Index > nodeIndexToEiminate)
                    {
                        noRe[i].NODO.Index--;
                    }
                }
            }

        }//remove a node.


        public int Count
        {
            get { return this.NODE_LIST.Count(); }
        }

        public void addNode(Node node)
        {
            this.NODE_LIST.Add(node);
        }

        //an undirected edge counts like a directed edge in both directions and same weight
        public void addUndirectedEdge_(Node client, Node server, int weight)
        {
            if (this.NODE_LIST.Contains(server) && this.NODE_LIST.Contains(client)) {
                client.addNeightbor(server, weight);
                server.addTransposedNeighbor(client, weight);

                server.addNeightbor(client, weight);
                client.addTransposedNeighbor(server, weight);

                edgeList_G.Add(new Edge(client, server, weight));
            }
        }

        public void addUndirectedEdge_(Edge edge)
        {
            if (this.NODE_LIST.Contains(edge.server) && this.NODE_LIST.Contains(edge.client))
            {
                edge.client.addNeightbor(edge.server, edge.Weight);
                edge.server.addTransposedNeighbor(edge.client, edge.Weight);

                edge.server.addNeightbor(edge.client, edge.Weight);
                edge.client.addTransposedNeighbor(edge.server, edge.Weight);

                edgeList_G.Add(edge);
            }

        }

        public void addUndirectedEdge_(Edge edge, int weight)
        {
            if (this.NODE_LIST.Contains(edge.server) && this.NODE_LIST.Contains(edge.client))
            {
                edge.client.addNeightbor(edge.server, weight);
                edge.server.addTransposedNeighbor(edge.client, weight);

                edge.server.addNeightbor(edge.client, weight);
                edge.client.addTransposedNeighbor(edge.server, weight);

                edgeList_G.Add(edge);
            }
        }

        public void addDirectedEdge_(Node client, Node server, int weight)
        {
            client.addNeightbor(server, weight);
            server.addTransposedNeighbor(client, weight);

            this.diEdgeList_G.Add(new Edge(client, server, weight));
        }

        public void addCicledEdge_(Node node, int weight)
        {
            node.addNeightbor(node, weight);
            node.addTransposedNeighbor(node, weight); 

            this.cicleEdgeList_G.Add(new Edge(node, weight));
        }


        //return a root 
        public Node rootNode()
        {
            if(this.Count > 0)
            {
                return this.NODE_LIST[0];
            }
            else
            {
                return null;
            }
        }

        public void reset()
        {
            foreach(Node node in this.NODE_LIST)
            {
                node.Visited = false;
                node.Level = 0;
            }
        }

        public Forest getForestDFS(Node root)
        {
            this.reset();//reset the graph 
            Forest fRes = new Forest();


            if(root == null)
            {
                root = this.rootNode().clone();
            }

            if(root != null) //no Node was selected it guides with nodes indicess
            {
                Tree tree = new Tree();//make a new tree for each root
                root.Level = 0;
                Node newRoot = root.clone();
                
                tree.addNode(newRoot);
                _getForestDFS_(root, tree);
                fRes.ListOfTrees.Add(tree);

                foreach (Node node in this.NODE_LIST)//visit each node in the node list 
                {
                    if (!node.Visited)// if was not visited it means it's a root
                    {
                        tree = new Tree();//make a new tree for each root 
                        node.Level = 0;//cre mens root
                        newRoot = node.clone();
                        tree.addNode(newRoot);
                        _getForestDFS_(node, tree);
                        fRes.ListOfTrees.Add(tree);
                    }
                }
            }

            

            return fRes;
        }

        public void _getForestDFS_(Node parent, Tree tree)
        {
            parent.Visited = true;
            foreach(NodeRef nodeR in parent.NEIGHBORS)//for each neigthbor
            {
                if (!nodeR.NODO.Visited)//if node wasnt visited yet
                {
                    nodeR.NODO.Level = parent.Level + 1;
                    Node newTreeNode = nodeR.NODO.clone();
                    tree.addNode(newTreeNode);//add a cloned node to the actual tree
                    tree.addDirectedEdge_(tree.thisnode(parent), newTreeNode, 0);//add edge of parent with actual node
                    _getForestDFS_(nodeR.NODO, tree);
                }
            }
        }


        public Forest getForestBFS(Node root)
        {
            this.reset();//reset the graph 
            Forest fRes = new Forest();

            if (root != null) //no Node was selected it guides with nodes indicess
            {
                Tree tree = new Tree();//make a new tree for each root 
                _getForestBFS_(root, tree);
                fRes.ListOfTrees.Add(tree);
            }

            foreach (Node node in this.NODE_LIST)//visit each node in the node list 
            {
                if (!node.Visited)// if was not visited it means it's a root
                {
                    Tree tree = new Tree();//make a new tree for each root 
                    _getForestBFS_(node, tree);
                    fRes.ListOfTrees.Add(tree);
                }
            }

            return fRes;
        }

        public List<Node> visitAllDescendence(Node parent)
        {
            List<Node> res = new List<Node>();
            foreach(NodeRef nodeR in parent.NEIGHBORS)
            {
                if (!nodeR.NODO.Visited)//if the node wawsnt visited yet
                {
                    nodeR.NODO.Level = parent.Level + 1;//assing a level
                    nodeR.NODO.Visited = true;
                    res.Add(nodeR.NODO);
                }
            }
            return res;
        }

        public void _getForestBFS_(Node parent, Tree tree)
        {
            parent.Visited = true;
            var sons = this.visitAllDescendence(parent);//mark all sons like visited 
            foreach (Node node in sons)//for each neigthbor
            {
                tree.addDirectedEdge(parent, node,0);
                _getForestBFS_(node, tree);
            }
        }









    }//AdjacencyList(END).    
}
