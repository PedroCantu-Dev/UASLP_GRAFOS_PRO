using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace editorDeGrafos
{

    public class Node
    {
        #region NodeDeclarations
        /*DEFAULT CONSTANTS AND DECLARATIONS:*/

        #region FunctionalDeclarations
        //*FUNCTIONAL VARIABLES:
        string nameID = "";//a node unique name in the graph
        int uniqueID; //a primary key for vertices (integer type)
        int index; //for control in the graph 
        //this three are asigned by the Graph with the method create.

        Boolean visited = false;                      //for routing
        Boolean colored = false;                      //for especial algorithms that use color atribute

        //this represent the list of nodes that can be reached from this one
        List<NodeRef> neighbors = new List<NodeRef>();
        //each NodeRef have the reference to the next node and the weight of the edge between them
      
        //for the transposed matrix
        List<NodeRef> transposedNeighbors = new List<NodeRef>();

        /*for graph traversal*/
        int level;
        #endregion

        #region GraphicalDeclarations
        //*GRAPHICs VARIABLES:
        //those wich help with the graphical enviroment of the graph editor
        Point position = new Point(0, 0);//position for drawing the node
        Color color = Color.Black;      //color for drawing the node
        int selected = 0;                   //to select nodes in graph mode
        int radiusLenght = 30;           //the radius of the node to Draw

        // this colors will be used dependig on the selected state of the node.
        //this can grow depending on the different options you want to give to the users
        //control the node colors depending on the node state and the selection mode active in the graphic envirtoment
        static int numSelectionStates = 3;

        #endregion

        #endregion

        #region NodeConstructors
        public Node() //default constructor of the class Node
        {
            //sometimes you need an empty Node
        }

        public Node(int x, int y)//this constructor works when the only util information is the position of the graph, normaly for drawing it
        {
            this.Position = new Point(x, y);
        }

        public Node(Point position, int radius, int index, int identifier)
        {
            this.position = position;
            this.radiusLenght = radius;
            this.index = index;//ID of the node
            uniqueID = identifier;
        }
        public Node(Point position, int radius, int index, int identifier, Color color)
        {
            this.position = position;
            this.radiusLenght = radius;
            this.index = index;//ID of the node
            uniqueID = identifier;
            this.color = color;
        }
        #endregion

        #region NodeProperties
        /*******************************************************
         *               Geters and seters(Begin)              *
         *******************************************************/
        public Point Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public int Radius
        {
            get { return this.radiusLenght; }
            set { this.radiusLenght = value; }
        }

        public int Status
        {
            get { return selected; }
            set { selected = value; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        
        public bool Visited
        {
            get { return visited; }
            set {visited = value; }
        }

        public Color Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

        public Boolean SelectedBool
        {
            get
            {
                if (selected == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }

        public int Index
        {
            get { return this.index; }
            set { this.index = value; }
        }

        public int ID
        {
            get { return this.uniqueID; }
            set { this.uniqueID = value; }
        }

        public int GradeOut
        {
            get { return this.Neighbors.Count(); }
        }

        public int GradeIn
        {
            get { return this.TransposedNeighbors.Count(); }
        }


        public List<NodeRef> Neighbors
        {
            get { return this.neighbors; }
            set { this.neighbors = value; }
        }


        public List<NodeRef> TransposedNeighbors
        {
            get { return this.transposedNeighbors; }
            set { this.transposedNeighbors = value; }
        }

        public List<int> NeighborsIdList
        {
            get
            {
                List<int> res = new List<int>();

                foreach (NodeRef nodeR in this.TransposedNeighbors)
                {
                    res.Add(nodeR.ID);
                }
                return res;
            }
        }


        public List<int> TransposedNeighborsIdList
        {
            get
            {
                List<int> res = new List<int>();

                foreach (NodeRef nodeR in this.TransposedNeighbors)
                {
                    res.Add(nodeR.ID);
                }
                return res;
            }
        }
        /*******************************************************
         *                Geters and seters(End)               *
         *******************************************************/
        #endregion

        #region NodeMethods
        /*******************************************************
         *                Methods(Begin)                       *
         *******************************************************/

        public Node Clone()
        {
            Node res = new Node(this.position, this.radiusLenght, this.index, uniqueID, this.color);
            res.Level = this.Level;
            return res;
        }

        //returns true if any neigbor edge is directed
        public bool AnyDirected()
        {
            foreach (NodeRef nodeR in this.Neighbors)
            {
                if (nodeR.Directed)
                {
                    return true;
                }
            }
            return false;
        }

        public void ResetNeighbors()
        {
            foreach (NodeRef nodeR in this.Neighbors)
            {
                nodeR.reset();
            }
        }

        //node Equals for node comparation, only the ID is needed due to is unique
        public Boolean Equals(Node other)
        {
            if (other != null)
            {
                if (other.ID == this.ID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsNeigtborOf(Node other)
        {
            foreach(NodeRef nodeR in Neighbors)
            {
                if(other.Equals(nodeR))//if any of its neighbors has it return
                {
                    return true;
                }
            }
            return false;
        }

        public List<Node> NeighborListNode()
        {
            List<Node> res = new List<Node>();

            foreach(NodeRef nodeR in this.neighbors)
            {
                res.Add(nodeR.Node);
            }
            return res;
        }

        public override String ToString()
        {
            return this.ID + this.position.ToString() + " -index = " + this.Index;
        }

        //add undirected neighbor
        public void AddUndirectedNeighbor(Node server, int weight)
        {
            Node client = this;

            NodeRef serverR = new NodeRef(weight, server,'u', this.NeighborsIdList);
            NodeRef clientR = new NodeRef(weight, client, 'u', server.NeighborsIdList);
             
            client.neighbors.Add(serverR);
            server.TransposedNeighbors.Add(serverR);

            server.neighbors.Add(clientR);
            client.TransposedNeighbors.Add(clientR);
        }

        //add a directed neighbor
        public void AddDirectedNeighbor(Node server, int weight)
        {
            Node client = this;

            NodeRef serverR = new NodeRef(weight, server, 'd', this.NeighborsIdList);

            client.neighbors.Add(serverR);
            server.TransposedNeighbors.Add(serverR);
        }

        //this will be used in a foreach loop for link elimination in case a node is eliminated 
        public void DeleteNeighbor(Node server)
        {
            List < NodeRef > newListOfReferencesAux = new List<NodeRef>();
            //For the new transposed naighbor list
            foreach(NodeRef nodeR in this.TransposedNeighbors)
            {
                if(server != nodeR.Node)
                {
                    newListOfReferencesAux.Add(nodeR);
                }
            }
            this.TransposedNeighbors = newListOfReferencesAux;

            newListOfReferencesAux = this.Neighbors;

            //for the new neighbor list
            foreach (NodeRef nodeR in this.Neighbors)
            {
                if (server != nodeR.Node)
                {
                    newListOfReferencesAux.Add(nodeR);
                }
            }
            this.Neighbors = newListOfReferencesAux;
        }

        //eliminate the node Ref pased
        public void DeleteNeighborEdge(NodeRef serverR)
        {
            if (serverR.Type == 'u')
            {
                this.Neighbors.Remove(serverR);
                serverR.Node.TransposedNeighbors.Remove(serverR);

                this.DeleteTransposedNeighborById(serverR.ID);
                serverR.Node.DeleteNeighborById(serverR.ID);

            }
            else
            {
                this.Neighbors.Remove(serverR);
                serverR.Node.TransposedNeighbors.Remove(serverR);  
            }
        }

        public void DeleteTransposedNeighborById(int neighborId)
        {
            NodeRef eliminate = null;
            foreach(NodeRef nodeR in this.TransposedNeighbors)
            {
                if(neighborId == nodeR.ID)
                {
                    eliminate = nodeR;
                    break;
                }
            }
            if(eliminate != null)
            {
                this.TransposedNeighbors.Remove(eliminate);
            }
        }

        public void DeleteNeighborById(int neighborId)
        {
            NodeRef eliminate = null;
            foreach (NodeRef nodeR in this.Neighbors)
            {
                if (neighborId == nodeR.ID)
                {
                    eliminate = nodeR;
                    break;
                }
            }
            if (eliminate != null)
            {
                this.Neighbors.Remove(eliminate);
            }
        }

        #endregion

        #region NodeEvents
        public void Click()
        {
            if (selected == numSelectionStates)
            {
                selected = 0;
            }
            else
            {
                selected++;
            }
        }

        public void Reset()
        {
            selected = 0;
            visited = false;
            level = -1;
            colored = false;
        }
        #endregion

    }//Node Class.



}
