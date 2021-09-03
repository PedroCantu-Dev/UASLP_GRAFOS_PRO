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
        //graphic variables

        String nameID = "";//a node unique name in the graph 
        
        int radiusLenght;//
        Boolean justSelected;//
        int selected;//
        int index;//
        int uniqueID;//


        //functional variables
        Boolean visited = false;
        Boolean colored = false;

        Point position;//position for drawing the node
        Color color;//color for drawing the node



        List<NodeRef> neighbors = new List<NodeRef>();





        public Node() //default constructor of the class Node
        {

        }

        public Node(int x, int y)
        {
            this.Position = new Point(x, y);
        }

        public Node(Point position, int radius, int index, int identifier)
        {
            this.position = position;
            this.radiusLenght = radius;
            justSelected = false;
            selected = 0;
            this.index = index;//ID of the node
            color = Color.Black;
            uniqueID = identifier;
        }
        public Node(Point position, int radius, int index, int identifier, Color color)
        {
            this.position = position;
            this.radiusLenght = radius;
            justSelected = false;
            selected = 0;
            this.index = index;//ID of the node
            this.color = color;
            uniqueID = identifier;
        }

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

        public Color COLOR
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public Boolean SelectedBool
        {
            get { return this.justSelected; }
            set { this.justSelected = value; }
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

        public Boolean Visitado
        {
            get { return this.visitado; }
            set { this.visitado = value; }
        }

        public List<NodeRef> NEIGHBORS
            {
            get { return this.neighbors; }
            }
        /*******************************************************
         *                Geters and seters(End)               *
         *******************************************************/

        /*******************************************************
         *                Methods(Begin)                       *
         *******************************************************/

        public override String ToString()
        {
            return this.ID + this.position.ToString() + " -index = " + this.Index;
        }







    }//Node class.
}
