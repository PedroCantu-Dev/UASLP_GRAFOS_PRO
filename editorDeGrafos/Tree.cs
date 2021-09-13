using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace editorDeGrafos
{
    public class Tree : Graph 
    {
        public Tree()
        {
        }

        public Node getRoots() // the root is the first node that was added
        {
            if(this.NODE_LIST.Count >0)
            {
                return this.NODE_LIST[0];
            }
            else
            {
                return null;
            }
        }
        
        public String toStringID()
        {
            String res = "";
            foreach (Node nod in this.NODE_LIST)
            {
                res += nod.Index.ToString() + "->";
            }

            res += "(null)";

            return res;
        }

        public String toString()
        {
            String res = "";
            foreach (Node nod in this.NODE_LIST)
            {
                res += nod.ID.ToString() + "->";
            }

            res += "(null)";

            return res;
        }
    }
}
