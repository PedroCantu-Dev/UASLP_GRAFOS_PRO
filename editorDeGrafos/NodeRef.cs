using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace editorDeGrafos
{
    /*
     * This class represent a kind of container for nodes in the graph structure as the relation
     * these are really the edges
     */
    public class NodeRef
    {

        int weight;//the weight that represents the relation
        Node nodo;// the node that is visited
        //TidyPair tidy;

        //for traversal and other methods
        Boolean activeNode = true;
        Boolean visited = false;

        char typeOfConection = 'u';

        int Id;//every edge is unique

        public NodeRef(int weight, Node nodo, char typeOfEdge, List<int> IDlist)
        {
            this.nodo = nodo;
            this.weight = weight;

            if (typeOfEdge == 'd')
            {
                this.typeOfConection = typeOfEdge;
            }
            this.Id = Util.createID(IDlist);
        }

        public char Type
        {
            get { return this.typeOfConection; }
        }

        public bool Directed
        {
            get
            {
                if (this.Type == 'd')
                {
                    return true;
                }
                return false;
            }

        }

        public bool Undirected
        {
            get
            {
                if (this.Type == 'u')
                {
                    return true;
                }
                return false;
            }

        }

        public int ID
        {
            get { return this.ID; }
        }

        public Node Node
        {
            get { return this.nodo; }
        }

        public int W
        {
            get { return this.weight; }
            set { this.weight = value; }
        }

        public Boolean Activation
        {
            get { return activeNode; }
            set { activeNode = value; }
        }

        public Boolean Visited
        {
            get { return visited; }
            set { visited = value; }
        }

        public void reset()
        {
            visited = false;
        }

        


        //public NodeRef(int weight, Node nodo, TidyPair tidyPair, char typeOfEdge, List<int> IDlist)
        //{
        //    this.tidy = tidyPair;
        //    this.nodo = nodo;
        //    this.weight = weight;
        //    activeNode = false;            
        //    if (typeOfEdge == 'd')
        //    {
        //        this.typeOfConection = typeOfEdge;
        //    }
        //    this.Id = Util.createID(IDlist);
        //}

        //public NodeRef(int weight, Node nodo, TidyPair tidyPair, Boolean active, char typeOfEdge, List<int> IDlist)
        //{
        //    this.tidy = tidyPair;
        //    this.nodo = nodo;
        //    this.weight = weight;
        //    activeNode = active;

        //    if (typeOfEdge == 'd')
        //    {
        //        this.typeOfConection = typeOfEdge;  
        //    }
        //    this.Id = Util.createID(IDlist);
        //}

        //public TidyPair TidyPair
        //{
        //    get { return this.tidy; }
        //    set { this.tidy = value; }
        //}



    }//NodeRef.
}
