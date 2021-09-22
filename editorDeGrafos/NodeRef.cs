using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace editorDeGrafos
{
    public class NodeRef
    {
        int weight;
        Node nodo;// the node that is visited
        TidyPair tidy;
        Boolean activeNode;
        Boolean visited = false;
        char typeOfConection = 'u';
        bool pared = true;


        public NodeRef(int weight, Node nodo, TidyPair tidyPair, char typeOfEdge)
        {
            this.tidy = tidyPair;
            this.nodo = nodo;
            this.weight = weight;
            activeNode = false;            
            if (typeOfEdge == 'd')
            {
                this.typeOfConection = typeOfEdge;
                this.pared = false;
            }
        }

        public NodeRef(int weight, Node nodo, TidyPair tidyPair, Boolean active, char typeOfEdge)
        {
            this.tidy = tidyPair;
            this.nodo = nodo;
            this.weight = weight;
            activeNode = active;
            
            if (typeOfEdge == 'd')
            {
                this.typeOfConection = typeOfEdge;
                this.pared = false;
            }
        }

        public Node NODO
        {
            get { return this.nodo; }
        }

        public int W
        {
            get { return this.weight; }
            set { this.weight = value; }
        }

        public TidyPair TidyPair
        {
            get { return this.tidy; }
            set { this.tidy = value; }
        }

        public Boolean ACTIVATION
        {
            get { return activeNode; }
        }

        public Boolean Visited
        {
            get { return visited; }
            set { visited = value; }
        }

        public void reset()
        {
            visited = false;
            pared = false;
        }

        public char Type
        {
            get { return this.typeOfConection; }
        }

        public bool Directed
        {
            get {
                if (this.Type == 'd')
                {
                    return true;
                }
                return false;
            }

        }

        public bool Pared
        {
            get { return pared; }
            set {
                if (this.Type == 'd')
                {
                    pared = value;
                }
            }
        }

    }//NodeRef.
}
