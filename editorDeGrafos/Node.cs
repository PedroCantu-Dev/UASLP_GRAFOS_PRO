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
        //*FUNCTIONAL VARIABLES:
        String nameID = "";//a node unique name in the graph
        int uniqueID;//a primary key for vertices (integer type)
        int index;//-----------
        //this three are asigned by the Graph with the method create.

        Boolean visited = false;                      //for routing
        Boolean colored = false;                      //for especial algorithms that use color atribute
        List<NodeRef> neighbors = new List<NodeRef>();//this represent the list of nodes that can be reached from this one
        //each NodeRef have the reference to the next node and the weight of the edge between them

        //*GRAPHICs VARIABLES://those wich help with the graphical enviroment of the graph editor
        Point position = new Point(0, 0);//position for drawing the node
        Color color = Color.Black;      //color for drawing the node
        Boolean justSelected;           //for drawing control
        int selected = 0;                   //to select nodes in graph mode
        int radiusLenght = 30;           //the radius of the node to Draw


        #region NodeConstructors
        public Node() //default constructor of the class Node
        {
            //sometimes you need an empty Node
        }

        public Node(int x, int y)
        {
            this.Position = new Point(x, y);
        }

        public Node(Point position, int radius, int index, int identifier)
        {
            this.position = position;
            this.radiusLenght = radius;
            this.index = index;//ID of the node
            color = Color.Black;
            uniqueID = identifier;
        }
        public Node(Point position, int radius, int index, int identifier, Color color)
        {
            this.position = position;
            this.radiusLenght = radius;
            this.index = index;//ID of the node
            this.color = color;
            uniqueID = identifier;
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

        public Color COLOR
        {
            get {
                if(justSelected == true)
                {
                    
                }
                else
                {

                    return this.color;
                }
            }
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
            get { return this.visited; }
            set { this.visited = value; }
        }

        public List<NodeRef> NEIGHBORS
            {
            get { return this.neighbors; }
            }
        /*******************************************************
         *                Geters and seters(End)               *
         *******************************************************/

        #endregion

        #region NodeMethods

        /*******************************************************
         *                Methods(Begin)                       *
         *******************************************************/


        /*
         * 
         * 
         * Description: return the color that node have to take deending of the selected grade
         * */
        private Color colorSelected()
        {
            switch (this.selected)
            {
                case 0:
                    

                    break;
                case 1:
                    break;

                case 2:
                    break;

                default:
                    break;
           }

        }




        public override String ToString()
        {
            return this.ID + this.position.ToString() + " -index = " + this.Index;
        }
        #endregion

    }//Node class.



}
