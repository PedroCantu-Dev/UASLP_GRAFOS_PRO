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

        Color[] colorsArray = new Color[] { Color.Black, Color.ForestGreen, Color.Blue, Color.Red};
        //normal colors:
        //0 is the default color
        //1 is the first color depending on the selection
        //2 is the next color depending on the selection
        //3....
        //.....

        Color _colorDefault = Color.Black;
        // this colors will be used dependig on the selected state of the node.
        //this can grow depending on the different options you want to give to the users
        //this are alternative colors, this is util when editing modes are active

        Color[] _colorsArray = new Color[] { Color.Black, Color.ForestGreen, Color.Blue, Color.Red };
        //mode actives
        //0 is the default color
        //1 is the first color depending on the selection
        //2 is the next color depending on the selection
        //3....
        //.....
        int numSelectionStates = 3;

        //this two arrays control the node colors depending on the node state and the selection mode active in the graphic envirtoment

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

        //for asking for color
        public Color COLORS {
            get {
                //depending on the slected state the node have different colors
                return this.colorsArray[this.selected];
            }
        }

        // when inverted colors are asked.
        public Color _COLORS {
            get {
                return this._colorsArray[this.selected];
            }
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


        public override String ToString()
        {
            return this.ID + this.position.ToString() + " -index = " + this.Index;
        }
        #endregion

    }//Node class.



}
