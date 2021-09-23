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
        /*DEFAULT CONSTANTS:*/

        // this colors will be used dependig on the selected state of the node.
        //this can grow depending on the different options you want to give to the users
        //

    
        static int numSelectionStates = 3;

        //this two arrays control the node colors depending on the node state and the selection mode active in the graphic envirtoment

        //*FUNCTIONAL VARIABLES:
        //String nameID = "";//a node unique name in the graph
        int uniqueID;//a primary key for vertices (integer type)
        int index;//for control in the graph 
        //this three are asigned by the Graph with the method create.

        Boolean visited = false;                      //for routing
        //Boolean colored = false;                      //for especial algorithms that use color atribute
        List<NodeRef> neighbors = new List<NodeRef>();//this represent the list of nodes that can be reached from this one
        //each NodeRef have the reference to the next node and the weight of the edge between them
        //for the transposed matrix
        List<NodeRef> transposedNeighbors = new List<NodeRef>();

        //*GRAPHICs VARIABLES://those wich help with the graphical enviroment of the graph editor
        Point position = new Point(0, 0);//position for drawing the node
        Color color = Color.Black;      //color for drawing the node
        int selected = 0;                   //to select nodes in graph mode
        int radiusLenght = 30;           //the radius of the node to Draw


        #region NodeConstructors
        public Node() //default constructor of the class Node
        {
            //sometimes you need an empty Node
        }

        public Node(int x, int y)//this constructor works when the only util information is the position of the graph normaly when is for drawing it
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

        
        #region NodeGetSet

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

        /*for graph traversal*/
        int level;
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


        public Color COLOR
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
        
        public Node clone()
        {
            Node res =  new Node(this.position , this.radiusLenght, this.index, uniqueID, this.color);
            res.Level = this.Level;
            return res;
        }

       //returns true if any neigbor edge is directed
        public bool anyDirected()
        {
            foreach(NodeRef nodeR in this.NEIGHBORS)
            {
                if(nodeR.Directed)
                {
                    return true;
                }
            }
            return false;
        }

        public void Click()
        {
           if(selected == numSelectionStates)
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
            //colored = false;
        }

        public void ResetNeighbors()
        {
           foreach(NodeRef nodeR in this.NEIGHBORS)
            {
                nodeR.reset();
            }
        }

        public Boolean SelectedBool
        {
            get { 
                if(selected == 0)
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
            get { return this.NEIGHBORS.Count(); }
        }

        public int GradeIn
        {
            get { return this.TRANSPOSED_NEIGHBORS.Count(); }
        }


        public List<NodeRef> NEIGHBORS
            {
                get { return this.neighbors; }
                set { this.neighbors = value; }
            }

           
        public List<NodeRef> TRANSPOSED_NEIGHBORS
        {
            get { return this.transposedNeighbors; }
            set { this.transposedNeighbors = value; }
        }

        public List<int> NEIGBORS_ID_LIST
        {
            get
            {
                List<int> res = new List<int>();

                foreach (NodeRef nodeR in this.TRANSPOSED_NEIGHBORS)
                {
                    res.Add(nodeR.ID);
                }
                return res;
            }
        }


        public List<int> TRANS_NEIGHBORS_ID_LIST
        {
            get {
                List<int> res = new List<int>();

                foreach(NodeRef nodeR in this.TRANSPOSED_NEIGHBORS)
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


        //node Equals for node comparation, only the ID is needed due to is unique
        public Boolean nodeEquals(Node other)
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

        public bool isNeigtbor(Node other)
        {
            foreach(NodeRef nodeR in NEIGHBORS)
            {
                if(other.Equals(nodeR))//if any of its neighbors has it return
                {
                    return true;
                }
            }
            return false;
        }

        public List<Node> neighborListNode()
        {
            List<Node> res = new List<Node>();

            foreach(NodeRef nodeR in this.neighbors)
            {
                res.Add(nodeR.NODO);
            }
            return res;
        }

        public override String ToString()
        {
            return this.ID + this.position.ToString() + " -index = " + this.Index;
        }

        //add undirected neighbor
        public void add_U_Neighbor(Node server, int weight)
        {
            Node client = this;

            NodeRef serverR = new NodeRef(weight, server,'u', this.NEIGBORS_ID_LIST);
            NodeRef clientR = new NodeRef(weight, client, 'u', server.NEIGBORS_ID_LIST);
             
            client.neighbors.Add(serverR);
            server.TRANSPOSED_NEIGHBORS.Add(serverR);

            server.neighbors.Add(clientR);
            client.TRANSPOSED_NEIGHBORS.Add(clientR);
        }

        //add a directed neighbor
        public void add_D_Neighbor(Node server, int weight)
        {
            Node client = this;

            NodeRef serverR = new NodeRef(weight, server, 'd', this.NEIGBORS_ID_LIST);

            client.neighbors.Add(serverR);
            server.TRANSPOSED_NEIGHBORS.Add(serverR);
        }

        //this will be used in a foreach loop for link elimination in case a node is eliminated 
        public void eliminate_Neighbor(Node server)
        {
            List < NodeRef > newListOfReferencesAux = new List<NodeRef>();
            //For the new transposed naighbor list
            foreach(NodeRef nodeR in this.TRANSPOSED_NEIGHBORS)
            {
                if(server != nodeR.NODO)
                {
                    newListOfReferencesAux.Add(nodeR);
                }
            }
            this.TRANSPOSED_NEIGHBORS = newListOfReferencesAux;

            newListOfReferencesAux = this.NEIGHBORS;

            //for the new neighbor list
            foreach (NodeRef nodeR in this.NEIGHBORS)
            {
                if (server != nodeR.NODO)
                {
                    newListOfReferencesAux.Add(nodeR);
                }
            }
            this.NEIGHBORS = newListOfReferencesAux;
        }

        //eliminate the node Ref pased
        public void eliminate_NeighborEdge(NodeRef serverR)
        {
            if (serverR.Type == 'u')
            {
                this.NEIGHBORS.Remove(serverR);
                serverR.NODO.TRANSPOSED_NEIGHBORS.Remove(serverR);

                this.remove_TransNeighbor_ByID(serverR.ID);
                serverR.NODO.remove_Neighbor_ByID(serverR.ID);

            }
            else
            {
                this.NEIGHBORS.Remove(serverR);
                serverR.NODO.TRANSPOSED_NEIGHBORS.Remove(serverR);  
            }
        }

        public void remove_TransNeighbor_ByID(int NR_ID)
        {
            NodeRef eliminate = null;
            foreach(NodeRef nodeR in this.TRANSPOSED_NEIGHBORS )
            {
                if(NR_ID == nodeR.ID)
                {
                    eliminate = nodeR;
                    break;
                }
            }
            if(eliminate != null)
            {
                this.TRANSPOSED_NEIGHBORS.Remove(eliminate);
            }
        }

        public void remove_Neighbor_ByID(int NR_ID)
        {
            NodeRef eliminate = null;
            foreach (NodeRef nodeR in this.NEIGHBORS)
            {
                if (NR_ID == nodeR.ID)
                {
                    eliminate = nodeR;
                    break;
                }
            }
            if (eliminate != null)
            {
                this.NEIGHBORS.Remove(eliminate);
            }
        }

        #endregion

    }//Node class.



}
