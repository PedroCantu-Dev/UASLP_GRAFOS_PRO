using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace editorDeGrafos
{
    public class Forest
    {

        private List<Tree> listOfTrees;

        public List<Node> Roots
        {
            get {
                List<Node> res = new List<Node>();
                foreach(Tree t in listOfTrees){
                    Node node = t.getRoot();
                    if (node != null)
                    {
                        res.Add(node);
                    }
                }
                return res;
            }
        }

        public List<Tree> ListOfTrees
        {
            get {return this.listOfTrees;}
            set {this.listOfTrees = value;}
        }

        /*
         * this class represent a forest that means a collection
         * of trees 
         * 
         * */
        public Forest()
        {
            listOfTrees = new List<Tree>();
        }

        public Forest(List<Tree> forest)
        {
            this.listOfTrees = forest;
        }
  

      

        
    }
}
