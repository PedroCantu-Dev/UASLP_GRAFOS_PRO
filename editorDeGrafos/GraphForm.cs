using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace editorDeGrafos
{
    public partial class GraphForm : Form
    {
        #region GraphFormVariables
        /********************* Selected Nodes control ***********************/
        Node selectedNode_FV = null;//selected node in the graphical enviroment
        Node selectedNode_Moving_FV = null;//for moving.
        Node selectedNode_Linking_FV = null;

        /*********************  Inner flags ********************/
        Boolean mousePressed_FV = false;//  mouse pressed for animations 
        Boolean mousePressed_R_FV = false;
        Boolean mousePressed_L_FV = false;
        Boolean justSaved_FV = true;// -> storage saveStateAuxiliar.

        /***************** windows and Forms ******************************/
        GraphFormIsomorphic isomorphismForm_FV;//-> form for isomofism comparison.
        SaveChangesWindow gdcForm_FV;// -> changes window.

        /************************ other variables ********************/
        int generalRadius_FV;
        String fileName_FV = "";//   -> fileName.
        public Graph graph_FV;// -> graph of the form.

        /****************** for view Operations ****************************/
        Boolean matIn_FV = false;
        Boolean pesosActivated_FV = true;

        /****************************** for operations Do ******************
         * 
         * sample: Button_key_type. 
         * 
         * ************************************************************/

        int operationIndex_FV = 0;


        Color[] operationVertexColorArray = new Color[]
        {
            Color.Black,
            Color.FromArgb(55, 150, 15),//Move_M_Do
            Color.FromArgb(60, 230, 125), //Move_A_Do
            Color.FromArgb(245, 75, 60), //Remove_E_Do
            Color.FromArgb(60, 80, 245),//MoRe_F_Do
            Color.Purple,//Link_Do
            Color.Orange,//Link_U_Do
            Color.AliceBlue//Link_D_Do
        };


        //this will go.........
        private Boolean Move_M_Do
        {
            get
            {
                if (operationIndex_FV == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private Boolean Move_A_Do
        {
            get
            {
                if (operationIndex_FV == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private Boolean Remove_E_Do
        {
            get
            {
                if (operationIndex_FV == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private Boolean MoRe_F_Do
        {
            get
            {
                if (operationIndex_FV == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private Boolean Link_Do
        {
            get
            {
                if (operationIndex_FV == 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private Boolean Link_U_Do
        {
            get
            {
                if (operationIndex_FV == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private Boolean Link_D_Do
        {
            get
            {
                if (operationIndex_FV == 7)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /********** for linking operations ************************/
        Edge linkingEdge = null;

        Boolean D_linkingAnimation = false;
        Boolean U_LinkingAnimation = false;
        Boolean left_Linkind = false;
        Boolean right_Linking = false;

        /**************** Trunqued grades ************************/
        Boolean trunquedGrade = false;

        /****************** for Isomorphism *************************/
        Boolean isoForm;

        /****************** for paths and cicles ********************/
        List<NodeRef> pathToAnimate;
        Node initialNodePath = null;
        Node finalNodePath = null;

        Timer timerColor = new System.Windows.Forms.Timer();

        int tmpCount = 0;
        #endregion

        #region GraphFormConstructors

        /****************************************************************************************
         * 
         * 
         *              GraphForm constructors
         * 
         * 
         * *************************************************************************************/
        public GraphForm()
        {
            InitializeComponent();
            commonCostructor();
            isoForm = false;
            fuerzaBrutaToolStripMenuItem.Visible = false;
            traspuestaToolStripMenuItem.Visible = false;
            intercambioToolStripMenuItem.Visible = false;
            IsomtextBox.Visible = false;
        }

        public GraphForm(int equis)
        {
            InitializeComponent();
            commonCostructor();
            isoForm = true;
            fuerzaBrutaToolStripMenuItem.Visible = true;
            traspuestaToolStripMenuItem.Visible = true;
            intercambioToolStripMenuItem.Visible = true;
            IsomtextBox.Visible = true;
        }

        private void commonCostructor()// for all common variables.
        {
            generalRadius_FV = 30;
            mousePressed_FV = false;
            graph_FV = new Graph();
            statusTB.Text = "Nombre :" + fileName_FV;
            terminal.Text = "Node selected : ";
        }
        #endregion

        #region MouseEvents


        /************* Mouse Events*****************/
        private void Reset_All()
        {
            Reset_Operations();
            Reset_Selected();
            Reset_Algo();
        }

        private void Reset_Operations()
        {

        }

        private void Reset_Selected()
        {
            if (selectedNode_FV != null)
            {
                //selectedNode_FV.Status = 0;//change to the original state.
                selectedNode_FV.Reset();
                AllowDrop = false;//
                selectedNode_FV = null;
            }
        }

        private void Reset_Algo()
        {
            DoAlgo_Option = 0;
        }

        private void reset()
        {

            //deselect();

            selectedNode_Moving_FV = null;//for moving.
            selectedNode_Linking_FV = null;
            mousePressed_FV = false;
            justSaved_FV = true;// -> storage saveStateAuxiliar.    

            /********** for linking operations ************************/
            D_linkingAnimation = false;
            U_LinkingAnimation = false;
            linkingEdge = null;
            left_Linkind = false;
            right_Linking = false;


            initialNodePath = null;
            finalNodePath = null;
        }



        private void reset(Boolean deselectBool)
        {

            selectedNode_Moving_FV = null;//for moving.
            selectedNode_Linking_FV = null;
            mousePressed_FV = false;
            justSaved_FV = true;

            D_linkingAnimation = false;
            U_LinkingAnimation = false;
            linkingEdge = null;
            left_Linkind = false;
            right_Linking = false;

            initialNodePath = null;
            finalNodePath = null;
        }


        /**************** deselect Operations ***************/


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Middle)//the scroll button works ass deselecter
            {
                if (selectedNode_FV != null)
                {
                    Reset_All();
                }
                this.operationIndex_FV = 0;
            }
            else
            {
                //offWhenClickingMouseOrKey();
                Node oneNode = null;
                if (operationIndex_FV > 0)//graph operation activated
                {
                    selectedNode_Moving_FV = graph_FV.getNodeByPosition(new Point(e.X, e.Y));
                    selectedNode_FV = selectedNode_Moving_FV;
                    oneNode = selectedNode_Moving_FV;
                    Form1_MouseDown_G_Operations(sender, e, oneNode);

                }
                else if (operationIndex_FV == 0) //operations for Vertex and form
                {
                    oneNode = graph_FV.getNodeByPosition(new Point(e.X, e.Y));
                    if (selectedNode_FV == null)
                    {
                        selectedNode_FV = oneNode;
                    }
                    Form1_MouseDown_Node_Operations(sender, e, oneNode);
                }
            }

            InvalidatePlus(1);
        }//Form_MouseDown(). BYE FOR THE MDF KING!!!! 

        private void resetSelectedNode_FV()
        {
            if (selectedNode_FV != null)
            {
                this.selectedNode_FV.Status = 0;
                this.selectedNode_FV = null;
            }

        }
        private void Form1_MouseDown_Node_Operations(object sender, MouseEventArgs e, Node oneNode)
        {
            //in orther to determine if one existing node was clicked, check all the node list.
            oneNode = graph_FV.getNodeByPosition(new Point(e.X, e.Y));
            if (oneNode != null)//one node was clicked
            {
                if (oneNode.Equals(selectedNode_FV))//if the selected node is equals the node clicked
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Right)//RIGHT
                    {
                        switch (selectedNode_FV.Status)
                        {
                            case 1://R--> Move 
                                mousePressed_FV = true;
                                mousePressed_R_FV = true;
                                break;
                            case 2://R--> Cicled Edge
                                int weight;
                                //here i have to ask the weight of the link.
                                if (trunquedGrade)//if trunqued means the weight is automatic
                                {
                                    int.TryParse(trunquedGradeTextBox.Text, out weight);
                                }
                                else
                                {
                                    weight = AFWeight("Cicled");
                                }

                                if (weight >= 0)
                                {
                                    //Edge edge = new Edge(selectedNode_FV, oneNode, weight);
                                    graph_FV.addCicledEdge(oneNode, weight);
                                }
                                break;
                            case 3://R--> Remove 
                                this.graph_FV.removeNode(oneNode);
                                this.selectedNode_FV = null;
                                break;
                            default:
                                break;
                        }
                    }
                    else if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        oneNode.Click();
                        if (oneNode.Status == 0)
                        {
                            selectedNode_FV = null;
                        }
                    }
                }
                else//if the node is a diferent one----> OTHER
                {
                    if (selectedNode_FV != null)
                    {
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            switch (selectedNode_FV.Status)
                            {
                                case 1:
                                    //do nothing
                                    break;
                                default://change of node selected
                                    oneNode.Status = selectedNode_FV.Status;
                                    selectedNode_FV.Status = 0;
                                    selectedNode_FV = oneNode;
                                    break;
                            }
                        }
                        else if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            int weight;
                            switch (selectedNode_FV.Status)
                            {
                                case 1:
                                    oneNode.Status = selectedNode_FV.Status;
                                    selectedNode_FV.Status = 0;
                                    selectedNode_FV = oneNode;
                                    break;
                                case 2:
                                    //here i have to ask the weight of the link.
                                    if (trunquedGrade)//if trunqued means the weight is automatic
                                    {
                                        int.TryParse(trunquedGradeTextBox.Text, out weight);
                                    }
                                    else
                                    {
                                        weight = AFWeight("Bidireccional");
                                    }
                                    if (weight >= 0)
                                    {
                                        //Edge edge = new Edge(selectedNode_FV, oneNode, weight);
                                        graph_FV.addUndirectedEdge(edge, weight);
                                    }
                                    break;
                                case 3:
                                    //int weight;
                                    //here i have to ask the weight of the link.
                                    if (trunquedGrade)//if trunqued means the weight is automatic
                                    {
                                        int.TryParse(trunquedGradeTextBox.Text, out weight);
                                    }
                                    else
                                    {
                                        weight = AFWeight("Directed");
                                    }
                                    if (weight >= 0)
                                    {
                                        //Edge edge = new Edge(selectedNode_FV, oneNode, weight);
                                        graph_FV.addDirectedEdge(selectedNode_FV, oneNode, weight);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            selectedNode_FV = oneNode;
                        }
                    }
                }
            }
            else//operations for the form
            {
                if (selectedNode_FV == null || !(selectedNode_FV != null && selectedNode_FV.Status == 1 && e.Button == MouseButtons.Right))
                {
                    graph_FV.create_(e.Location, generalRadius_FV);
                }
            }
        }//Node operations END

        private void Form1_MouseDown_G_Operations(object sender, MouseEventArgs e, Node oneNode)
        {
            if (oneNode != null)//one node was clicked
            {
                int weight;
                switch (operationIndex_FV)
                {
                    case 1://Moving individually
                        mousePressed_FV = true;
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            mousePressed_R_FV = true;
                        }
                        else if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            mousePressed_L_FV = true;
                        }
                        this.selectedNode_FV.Status = 0;
                        this.selectedNode_FV = oneNode;

                        break;
                    case 2://Moving all
                        mousePressed_FV = true;
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            mousePressed_R_FV = true;
                        }
                        else if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            mousePressed_L_FV = true;
                        }
                        break;
                    case 3://REmove
                        this.graph_FV.removeNode(oneNode);//remove the node pressed
                        break;
                    case 4://MoRe
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.graph_FV.removeNode(oneNode);//remove the node pressed
                        }
                        else if (e.Button == System.Windows.Forms.MouseButtons.Left)//for moving
                        {
                            mousePressed_FV = true;
                            mousePressed_L_FV = true;
                        }
                        break;
                    case 5:
                        if (!oneNode.Equals(this.selectedNode_Linking_FV) && selectedNode_Linking_FV != null)//The links are made only if a diferent node was cliked so not equals
                        {
                            if (e.Button == System.Windows.Forms.MouseButtons.Right)//directed link
                            {
                                if (trunquedGrade)//if trunqued means the weight is automatic
                                {
                                    int.TryParse(trunquedGradeTextBox.Text, out weight);
                                }
                                else
                                {
                                    weight = AFWeight("Directed");
                                }
                                if (weight >= 0)
                                {
                                    //Edge edge = new Edge(selectedNode_Linking_FV, oneNode, weight);
                                    graph_FV.addDirectedEdge(selectedNode_Linking_FV, oneNode, weight);
                                }
                            }
                            else if (e.Button == System.Windows.Forms.MouseButtons.Left)//undirected link
                            {
                                if (trunquedGrade)//if trunqued means the weight is automatic
                                {
                                    int.TryParse(trunquedGradeTextBox.Text, out weight);
                                }
                                else
                                {
                                    weight = AFWeight("Bidireccional");
                                }
                                if (weight >= 0)
                                {
                                    Edge edge = new Edge(selectedNode_Linking_FV, oneNode, weight);
                                    graph_FV.addUndirectedEdge(edge, weight);
                                }
                            }
                        }
                        else
                        {
                            this.selectedNode_Linking_FV = oneNode;
                            mousePressed_FV = true;
                            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                            {
                                mousePressed_R_FV = true;
                            }
                            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
                            {
                                mousePressed_L_FV = true;
                            }
                        }
                        break;
                    case 6:
                        if (!oneNode.Equals(this.selectedNode_Linking_FV) && this.selectedNode_Linking_FV != null)//The links are made only if a diferent node was cliked so not equals
                        {
                            if (trunquedGrade)//if trunqued means the weight is automatic
                            {
                                int.TryParse(trunquedGradeTextBox.Text, out weight);
                            }
                            else
                            {
                                weight = AFWeight("Bidireccional");
                            }
                            if (weight >= 0)
                            {
                                Edge edge = new Edge(selectedNode_Linking_FV, oneNode, weight);
                                graph_FV.addUndirectedEdge(edge, weight);
                            }
                        }
                        else
                        {
                            this.selectedNode_Linking_FV = oneNode;
                            mousePressed_FV = true;
                            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                            {
                                mousePressed_R_FV = true;
                            }
                            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
                            {
                                mousePressed_L_FV = true;
                            }
                        }
                        break;
                    case 7:
                        if (trunquedGrade)//if trunqued means the weight is automatic
                        {
                            int.TryParse(trunquedGradeTextBox.Text, out weight);
                        }
                        else
                        {
                            weight = AFWeight("Directed");
                        }
                        if (weight >= 0)
                        {
                            Edge edge = new Edge(selectedNode_FV, oneNode, weight);
                            graph_FV.addDirectedEdge(selectedNode_FV, oneNode, weight);
                        }
                        break;
                }
            }
            else//operations for the form
            {
                graph_FV.create_(e.Location, generalRadius_FV);
            }
        }//Graph operations.


        public void Form1_MouseMove(object sender, MouseEventArgs e)//for the mouse moving.
        {

            if (mousePressed_FV == true && e.Button == MouseButtons.Right && selectedNode_FV != null && selectedNode_FV.Status == 1)//Selected: mouse moving 
            {
                selectedNode_FV.Position = e.Location;
                InvalidatePlus(1);
            }
            if (mousePressed_FV == true && Move_M_Do == true && selectedNode_Moving_FV != null)//Move
            {
                selectedNode_Moving_FV.Position = e.Location;

                InvalidatePlus(1);
            }
            if (mousePressed_FV == true && Move_A_Do == true && selectedNode_Moving_FV != null)//MoveAll
            {
                if (mouseLastPosition != null)
                {
                    //Calculate delta of the mouse moving
                    int deltaX = selectedNode_Moving_FV.Position.X - e.X;
                    int deltaY = selectedNode_Moving_FV.Position.Y - e.Y;
                    Coordenate deltaOfCoordenate = new Coordenate(deltaX, deltaY);

                    foreach (Node node in graph_FV.NODE_LIST)
                    {
                        int xPo = node.Position.X - deltaOfCoordenate.X;
                        int yPo = node.Position.Y - deltaOfCoordenate.Y;

                        node.Position = new Point(xPo, yPo);
                    }
                }
                mouseLastPosition = new Coordenate(e.X, e.Y);
                InvalidatePlus(1);
            }
            if (mousePressed_FV == true && e.Button == MouseButtons.Left && MoRe_F_Do == true && selectedNode_Moving_FV != null)//MoRe
            {

                selectedNode_Moving_FV.Position = e.Location;
                InvalidatePlus(1);
            }
            if (mousePressed_FV == true && (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) && Link_Do == true && selectedNode_Linking_FV != null)//Linking
            {
                Node auxMouseUperNode = findNodeClicked(new Point(e.X, e.Y));
                Point corToDraw;

                if (auxMouseUperNode != null)
                {
                    corToDraw = auxMouseUperNode.Position;
                }
                else
                {
                    corToDraw = new Point(e.X, e.Y);
                }

                linkingEdge = new Edge(selectedNode_Linking_FV, corToDraw);

                if (e.Button == MouseButtons.Left)//for undirected Edges.
                {
                    U_LinkingAnimation = true;
                    left_Linkind = true;
                    right_Linking = false;
                }
                else if (e.Button == MouseButtons.Right)//directed edges
                {
                    D_linkingAnimation = true;
                    left_Linkind = false;
                    right_Linking = true;
                }

                Invalidate();

            }
            if (mousePressed_FV == true && (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) && Link_D_Do == true && selectedNode_Linking_FV != null)//Linking D
            {
                Node auxMouseUperNode = findNodeClicked(new Point(e.X, e.Y));
                Point corToDraw;

                if (auxMouseUperNode != null)
                {
                    corToDraw = auxMouseUperNode.Position;
                }
                else
                {
                    corToDraw = new Point(e.X, e.Y);
                }
                D_linkingAnimation = true;
                linkingEdge = new Edge(selectedNode_Linking_FV, corToDraw);
                Invalidate();
            }
            if (mousePressed_FV == true && (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) && Link_U_Do == true && selectedNode_Linking_FV != null)//Linking D
            {
                Node auxMouseUperNode = findNodeClicked(new Point(e.X, e.Y));
                Point corToDraw;

                if (auxMouseUperNode != null)
                {
                    corToDraw = auxMouseUperNode.Position;
                }
                else
                {
                    corToDraw = new Point(e.X, e.Y);
                }
                U_LinkingAnimation = true;
                linkingEdge = new Edge(selectedNode_Linking_FV, corToDraw);
                Invalidate();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mousePressed_FV = false;
                mousePressed_L_FV = false;
            }
            else if (e.Button == MouseButtons.Right)
            {
                mousePressed_R_FV = false;
            }
            if (Link_Do || Link_D_Do || Link_U_Do)//Linking
            {
                int weight = 0;

                Node auxMouseUperNode = findNodeClicked(new Point(e.X, e.Y));
                if (auxMouseUperNode != null && selectedNode_Linking_FV != null)
                {
                    if (Link_Do)
                    {
                        if (left_Linkind)//undirected
                        {
                            //here i have to ask the weight of the link.
                            if (trunquedGrade)
                            {
                                int.TryParse(trunquedGradeTextBox.Text, out weight);
                            }
                            else
                            {
                                weight = AFWeight("Bidireccional");
                            }
                            if (weight >= 0)
                            {
                                this.graph_FV.addUndirectedEdge_(selectedNode_Linking_FV, auxMouseUperNode, weight);
                                justSaved_FV = false;
                            }
                        }
                        else if (right_Linking)//directed
                        {
                            //here i have to ask the weight of the link.
                            if (trunquedGrade)
                            {
                                int.TryParse(trunquedGradeTextBox.Text, out weight);
                            }
                            else
                            {
                                weight = AFWeight("Dirijido");
                            }

                            if (weight >= 0)
                            {
                                graph_FV.addDirectedEdge(selectedNode_Linking_FV, auxMouseUperNode, weight);
                                justSaved_FV = false;
                            }
                        }
                    }
                    else if (Link_D_Do)
                    {
                        //here i have to ask the weight of the link.
                        if (trunquedGrade)
                        {
                            int.TryParse(trunquedGradeTextBox.Text, out weight);
                        }
                        else
                        {
                            weight = AFWeight("Dirijido");
                        }
                        if (weight >= 0)
                        {
                            graph_FV.addDirectedEdge(selectedNode_Linking_FV, auxMouseUperNode, weight);
                            justSaved_FV = false;
                        }
                    }
                    else if (Link_U_Do)
                    {
                        //here i have to ask the weight of the link.
                        if (trunquedGrade)
                        {
                            int.TryParse(trunquedGradeTextBox.Text, out weight);
                        }
                        else
                        {
                            weight = AFWeight("Bidireccional");
                        }
                        if (weight >= 0)
                        {
                            graph_FV.addUndirectedEdge_(selectedNode_Linking_FV, auxMouseUperNode, weight);
                            justSaved_FV = false;
                        }
                    }
                }
                selectedNode_Linking_FV = null;
                InvalidatePlus(1);
            }
        }

        Coordenate mouseLastPosition = null;//for last position in all moving.

        public int AFWeight(String edgeType)
        {
            int res = 0;
            AskForWeight afaw = new AskForWeight(edgeType);
            afaw.ShowDialog();
            res = afaw.getX;
            return res;
        }

        #endregion

        #region operation
        /********************** OPERATIONS *****************/
        #region operationEvents
        /************************ clicking an operation *****************/

        private void Move_Click(object sender, EventArgs e)
        {
            keyM_OR_MoveClick();
        }

        private void MoveAll_Click(object sender, EventArgs e)
        {
            keyA_OR_MoveAllClick();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            keyR_OR_RemoveClick();
        }

        private void MoRe_Click(object sender, EventArgs e)
        {
            keyF_OR_MoReClick();
        }

        private void linking_Click(object sender, EventArgs e)
        {
            keyL_OR_LinkingClick();
        }

        private void linking_D_Click(object sender, EventArgs e)
        {
            keyD_OR_D_LinkingClick();
        }

        private void linking_U_Click(object sender, EventArgs e)
        {
            keyU_OR_U_LinkingClick();
        }

        /************************ clicking operation keys *****************/
        private void Form1_KeyDown(object sender, KeyEventArgs e)// keys down.
        {
            //offWhenClickingMouseOrKey();
            if ((e.KeyCode == Keys.Escape || e.KeyCode == Keys.S) && selectedNode_FV != null)
            {
                //deselect();

            }
            if (e.KeyCode == Keys.M)//Move (M).
            {
                keyM_OR_MoveClick();
            }
            if (e.KeyCode == Keys.A)//Move All (A).
            {
                keyA_OR_MoveAllClick();
            }
            if (e.KeyCode == Keys.R)//Remove (R).
            {
                keyR_OR_RemoveClick();
            }
            if (e.KeyCode == Keys.F)//MoRe (F). 
            {
                keyF_OR_MoReClick();
            }
            if (e.KeyCode == Keys.L)//Linking (L).
            {
                keyL_OR_LinkingClick();
            }
            if (e.KeyCode == Keys.D)//Linking (D).
            {
                keyD_OR_D_LinkingClick();
            }
            if (e.KeyCode == Keys.U)//Linking (U)
            {
                keyU_OR_U_LinkingClick();
            }
            if (e.KeyCode == Keys.Q)// (Q for quit any mode)
            {
                keyQ_OR_QuitClick();
            }
            if (e.KeyCode == Keys.X && selectedNode_FV != null)//((eliminate node selected))
            {
                eliminate();
                InvalidatePlus();
            }

        }

        #endregion
        #region commonKeyOperations

        /********************* common key-operations (Begin) ****************************/

        private void keyM_OR_MoveClick()//
        {
            //deselect();
            if (operationIndex_FV == 1)
            {
                operationIndex_FV = 0;
            }
            else
            {
                operationIndex_FV = 1;
                //allOperationOff();
            }
            InvalidatePlus(1);
        }

        private void keyA_OR_MoveAllClick()
        {
            //deselect();
            if (operationIndex_FV == 2)
            {
                operationIndex_FV = 0;
            }
            else
            {
                operationIndex_FV = 2;
                //allOperationOff();
            }
            InvalidatePlus(1);
        }

        private void keyR_OR_RemoveClick()
        {
            //deselect();
            if (operationIndex_FV == 3)
            {
                operationIndex_FV = 0;
            }
            else
            {
                operationIndex_FV = 3;
                //allOperationOff();
            }
            InvalidatePlus(1);
        }

        private void keyF_OR_MoReClick()
        {
            //deselect();
            if (operationIndex_FV == 4)
            {
                operationIndex_FV = 0;
            }
            else
            {
                //allOperationOff();
                operationIndex_FV = 4;
            }
            InvalidatePlus(1);
        }

        private void keyL_OR_LinkingClick()
        {
            //deselect();
            if (operationIndex_FV == 5)
            {
                operationIndex_FV = 0;
            }
            else
            {
                //                allOperationOff();
                operationIndex_FV = 5;
            }
            InvalidatePlus(1);
        }

        private void keyU_OR_U_LinkingClick()
        {
            //deselect();
            if (operationIndex_FV == 6)
            {
                operationIndex_FV = 0;
            }
            else
            {
                //                allOperationOff();
                operationIndex_FV = 6;
            }
            InvalidatePlus(1);
        }

        private void keyD_OR_D_LinkingClick()
        {
            //deselect();
            if (operationIndex_FV == 7)
            {
                operationIndex_FV = 0;
            }
            else
            {
                //                allOperationOff();
                operationIndex_FV = 7;
            }
            InvalidatePlus(1);
        }

        private void keyQ_OR_QuitClick()
        {
            resetSelectedNode_FV();
            operationIndex_FV = 0;
        }



        /********************* common key-operations (END) ****************************/
        #endregion
        #endregion

        #region algorithmsEvents
        /*************************************************************************************************
        * 
        * 
        *||||||||||||||||||||||||||||||||  ALGORITMOS EVENTS (Begin)|||||||||||||||||||||||||||||||||||
        *          
        * 
        * ************************************************************************************************/


        //ISOMORFISMO:
        protected virtual void fuerzaBrutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isomorphismForm_FV != null && isomorphismForm_FV.Visible)
            {
                changeIsomtextBox(this.graph_FV.Isomo_Fuerza_Bruta(isomorphismForm_FV.graph_FV).ToString());
            }
        }

        protected virtual void traspuestaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isomorphismForm_FV != null && isomorphismForm_FV.Visible)
            {
                changeIsomtextBox(this.graph_FV.Isom_Traspuesta(isomorphismForm_FV.graph_FV).ToString());
            }
        }

        protected virtual void intercambioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isomorphismForm_FV != null && isomorphismForm_FV.Visible)
            {
                changeIsomtextBox(this.graph_FV.Isom_Inter(isomorphismForm_FV.graph_FV).ToString());
            }
        }
        public void closeIsoFormClicked(object sender, EventArgs e)
        {
            InvalidatePlus();
        }




        private void dFSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /***************||||||||||||||  ALGORITMOS EVENTS (END) |||||||||||||||||||||||*******************/
        #endregion

        #region viewEvents
        /*********************  View (Begin) **********************/
        private void maIn_Click(object sender, EventArgs e)
        {
            if (f3.Operation == 1)
            {
                graph_FV.allBlack();
                Invalidate();
                f3.Operation = 0;
            }

            if (matIn_FV)
                matIn_FV = false;
            else
                matIn_FV = true;
            InvalidatePlus();
        }

        private void gradoTruncadoButton_Click(object sender, EventArgs e)
        {
            trunquedGrade = !trunquedGrade;
            if (trunquedGrade)
            {
                gradoTruncadoButton.BackColor = Color.DarkSeaGreen;
            }
            else
            {
                gradoTruncadoButton.BackColor = Color.White;
            }
        }

        private void pesosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pesosActivated_FV = !pesosActivated_FV;
            Invalidate();
        }
         
        #endregion

        #region fileOperations

        /*********************** file Operations (Begin) ********************************/

        private void Save_Click(object sender, EventArgs e)
        {
            //offWhenClickingMouseOrKey(false);
            saveFile();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            //offWhenClickingMouseOrKey(false);
            if (justSaved_FV == false)
            {
                gdcForm_FV = new SaveChangesWindow();
                gdcForm_FV.ShowDialog();
                if (gdcForm_FV.Operation == 1 || gdcForm_FV.Operation == 2)
                {
                    if (gdcForm_FV.Operation == 1)
                    {
                        saveFile();
                    }
                    loadCommonActions();
                }
            }
            else
            {
                loadCommonActions();
            }
        }

        private void New_Click(object sender, EventArgs e)
        {
            //offWhenClickingMouseOrKey();
            if (justSaved_FV == false)//si el trabajo no ha sido guardado
            {
                SaveChangesWindow gdc = new SaveChangesWindow();
                gdc.ShowDialog();
                if (gdc.Operation == 1 || gdc.Operation == 2)
                {
                    if (gdc.Operation == 1)
                    {
                        saveFile();
                    }
                }
            }
            this.reset();
            graph_FV.resetNew();
            fileName_FV = "";
            justSaved_FV = true;
            InvalidatePlus();
        }



        // when load a graph we need to regenerate all the parts of the graph, 
        //if it is no possible to load, the values are retored.
        private void loadCommonActions()
        {
            Graph graph_BU = graph_FV;
            List<Node> nodeList_BU = graph_FV.NODE_LIST;
            List<Edge> edgeList_BU = graph_FV.EDGE_LIST;
            List<Edge> diEdgeList_BU = graph_FV.DIEDGE_LIST;
            List<Edge> cicleEdgeList_BU = graph_FV.CIEDGE_LIST;

            graph_FV = new Graph();
            graph_FV.NODE_LIST = new List<Node>();
            graph_FV.EDGE_LIST = new List<Edge>();
            graph_FV.DIEDGE_LIST = new List<Edge>();
            graph_FV.CIEDGE_LIST = new List<Edge>();

            if (openFile() == 0)//couldn't open
            {
                graph_FV = graph_BU;
                graph_FV.NODE_LIST = nodeList_BU;
                graph_FV.EDGE_LIST = edgeList_BU;
                graph_FV.DIEDGE_LIST = diEdgeList_BU;
                graph_FV.CIEDGE_LIST = cicleEdgeList_BU;
            }
            else//it was opened succesfully
            {
                justSaved_FV = true;
            }
            InvalidatePlus();
        }

        public void saveFile()
        {
            TextWriter sw = null;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save text Files";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                sw = new StreamWriter(saveFileDialog.FileName);
                MessageBox.Show(saveFileDialog.FileName);

                String auxFileName = saveFileDialog.FileName;
                fileName_FV = " " + auxFileName.Substring(auxFileName.LastIndexOf(@"\") + 1, auxFileName.Length - auxFileName.LastIndexOf(@"\") - 1);
            }
            /********************************************* 
                atributes of a node that can be unique
                Coordenate position; 
                int radiusLenght; 
                int index;
                int uniqueID;
            *************************************************/
            if (sw != null)
            {

                foreach (Node node in graph_FV.NODE_LIST)//all about the node
                {
                    sw.WriteLine(node.ID + "," + node.Index + "," + node.Position.X + "," + node.Position.Y + "," + node.Radius);
                }
                sw.WriteLine("Matrix");
                foreach (List<NodeRef> row in graph_FV.GRAPH)
                {
                    foreach (NodeRef nodeR in row)
                    {
                        sw.Write(nodeR.Weight + ",");
                    }
                    sw.WriteLine();
                }
                sw.WriteLine("Edges");
                foreach (Edge edge in graph_FV.EDGE_LIST)
                {
                    sw.WriteLine(edge.Client.Index + "," + edge.Server.Index + "," + edge.Weight);
                }
                sw.WriteLine("D_Edges");
                foreach (Edge edge in graph_FV.DIEDGE_LIST)
                {
                    sw.WriteLine(edge.Client.Index + "," + edge.Server.Index + "," + edge.Weight);
                }
                sw.WriteLine("C_Edges");
                foreach (Edge edge in graph_FV.CIEDGE_LIST)
                {
                    sw.WriteLine(edge.Client.Index + "," + edge.Weight);
                }
                sw.Close();
                justSaved_FV = true;
            }
            InvalidatePlus();
        }

        public int openFile()
        {
            int statusRes = 0;

            StreamReader sr = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                String auxFileName = openFileDialog.FileName;
                fileName_FV = " " + auxFileName.Substring(auxFileName.LastIndexOf(@"\") + 1, auxFileName.Length - auxFileName.LastIndexOf(@"\") - 1);

                sr = new StreamReader(auxFileName);
                char[] Delimiters = new char[] { ',' };
                string[] Input = sr.ReadLine().Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);

                while (sr != null && !sr.EndOfStream && Input[0] != "Matrix")
                {

                    int idON;
                    int indexON;
                    int x;
                    int y;
                    int radiusON;


                    int.TryParse(Input[0], out idON);
                    int.TryParse(Input[1], out indexON);
                    int.TryParse(Input[2], out x);
                    int.TryParse(Input[3], out y);
                    int.TryParse(Input[4], out radiusON);

                    Point cor = new Point(x, y);
                    Node node = new Node(cor, radiusON, indexON, idON);
                    //graph_FV.addNode(node);
                    graph_FV.addNode(node);
                    //nodeList.Add(node);
                    Input = sr.ReadLine().Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
                }
                if (Input[0] == "Matrix")
                {
                    Input = sr.ReadLine().Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
                }

                int i = 0;
                while (sr != null && !sr.EndOfStream && Input[0] != "Edges")
                {
                    int Peso;

                    for (int j = 0; j < Input.Length; j++)
                    {
                        int.TryParse(Input[j], out Peso);
                        graph_FV.GRAPH[i][j].Weight = Peso;
                    }
                    Input = sr.ReadLine().Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
                    i++;
                }
                if (Input[0] == "Edges")
                {
                    Input = sr.ReadLine().Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
                }
                while (sr != null && !sr.EndOfStream && Input[0] != "D_Edges")
                {
                    Node server = new Node();
                    Node client = new Node();

                    int weigth;
                    int.TryParse(Input[2], out weigth);
                    int nodo_C;
                    int.TryParse(Input[1], out nodo_C);
                    int nodo_S;
                    int.TryParse(Input[0], out nodo_S);


                    for (int j = 0; j < graph_FV.GRAPH.Count; j++)
                    {
                        if (graph_FV.GRAPH[j][j].Node.Index == nodo_C)
                        {
                            client = graph_FV.GRAPH[j][j].Node;
                        }
                        if (graph_FV.GRAPH[j][j].Node.Index == nodo_S)
                        {
                            server = graph_FV.GRAPH[j][j].Node;
                        }
                    }

                    Edge edge = new Edge(server, client, weigth);

                    graph_FV.addUndirectedEdge(edge);
                    Input = sr.ReadLine().Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
                }
                if (Input[0] == "D_Edges" && !sr.EndOfStream)
                {
                    Input = sr.ReadLine().Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
                }
                while (sr != null && !sr.EndOfStream && Input[0] != "C_Edges")
                {
                    Node server = new Node();
                    Node client = new Node();

                    int weight;
                    int.TryParse(Input[2], out weight);
                    int nodo_C;
                    int.TryParse(Input[1], out nodo_C);
                    int nodo_S;
                    int.TryParse(Input[0], out nodo_S);

                    for (int j = 0; j < graph_FV.GRAPH.Count; j++)
                    {
                        if (graph_FV.GRAPH[j][j].Node.Index == nodo_C)
                        {
                            client = graph_FV.GRAPH[j][j].Node;
                        }
                        if (graph_FV.GRAPH[j][j].Node.Index == nodo_S)
                        {
                            server = graph_FV.GRAPH[j][j].Node;
                        }
                    }

                    Edge edge = new Edge(server, client, weight);
                    graph_FV.DIEDGE_LIST.Add(edge);
                    Input = sr.ReadLine().Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
                }
                if (Input[0] == "C_Edges" && !sr.EndOfStream)
                {
                    Input = sr.ReadLine().Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
                }
                while (sr != null && !sr.EndOfStream)
                {
                    Node server = new Node();

                    int weight;
                    int.TryParse(Input[1], out weight);
                    int nodo_S;
                    int.TryParse(Input[0], out nodo_S);

                    for (int j = 0; j < graph_FV.GRAPH.Count; j++)
                    {
                        if (graph_FV.GRAPH[j][j].Node.Index == nodo_S)
                        {
                            server = graph_FV.GRAPH[j][j].Node;
                        }
                    }

                    graph_FV.addCicledEdge(server, weight);
                    Input = sr.ReadLine().Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
                }
                sr.Close();
                statusRes = 1;
            }
            InvalidatePlus();
            return statusRes;
        }
        /**************************** file operations(END) **********************/
        #endregion 

        #region Paint
        /*****************************
         * 
         *      method for painting.
         * 
         * ****************************/
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.Black, 5);

            Brush brush = new SolidBrush(BackColor);
            Rectangle rectangle;

            //foreach (Edge edge in graph_FV.CIEDGE_LIST)//cicled edge.
            //{
            //    drawCicledEdge(graphics, edge, e);
            //}

            //foreach (Edge edge in graph_FV.EDGE_LIST)//undirected edges.
            //{
            //    drawEdge(graphics, edge);
            //}
            //foreach (Edge edge in graph_FV.DIEDGE_LIST)//directed edges.
            //{
            //    drawDirectedEdge(graphics, edge);
            //}

            if (operationIndex_FV == 0)
            {
                foreach (Node nodo in this.graph_FV.NODE_LIST)
                {
                    rectangle = new Rectangle(nodo.Position.X - nodo.Radius, nodo.Position.Y - nodo.Radius, nodo.Radius * 2, nodo.Radius * 2);
                    graphics.FillEllipse(brush, rectangle);

                    pen.Color = this.graph_FV.COLORS(nodo);
                    graphics.DrawEllipse(pen, nodo.Position.X - nodo.Radius, nodo.Position.Y - nodo.Radius, nodo.Radius * 2, nodo.Radius * 2);

                    //draw inside the node a index.
                    String index_S = "" + nodo.Index;
                    int fontSize = generalRadius_FV - 10;
                    graphics.DrawString(index_S, new Font(FontFamily.GenericSansSerif, fontSize), new SolidBrush(Color.Black), nodo.Position.X - (fontSize / 2), nodo.Position.Y - (fontSize / 2));

                }
            }
            else
            {
                foreach (Node nodo in this.graph_FV.NODE_LIST)
                {
                    rectangle = new Rectangle(nodo.Position.X - nodo.Radius, nodo.Position.Y - nodo.Radius, nodo.Radius * 2, nodo.Radius * 2);
                    graphics.FillEllipse(brush, rectangle);

                    pen.Color = this.operationVertexColorArray[operationIndex_FV];

                    graphics.DrawEllipse(pen, nodo.Position.X - nodo.Radius, nodo.Position.Y - nodo.Radius, nodo.Radius * 2, nodo.Radius * 2);

                    //draw inside the node a index.
                    String index_S = "" + nodo.Index;
                    int fontSize = generalRadius_FV - 10;
                    graphics.DrawString(index_S, new Font(FontFamily.GenericSansSerif, fontSize), new SolidBrush(Color.Black), nodo.Position.X - (fontSize / 2), nodo.Position.Y - (fontSize / 2));

                }
            }



            if (D_linkingAnimation || U_LinkingAnimation)
            {
                if (D_linkingAnimation)//for undirected 
                {
                    drawDirectedEdge(graphics, linkingEdge);
                }
                else if (U_LinkingAnimation)//for directed 
                {
                    drawEdge(graphics, linkingEdge);
                }

                D_linkingAnimation = false;
                U_LinkingAnimation = false;
            }
        }



/*
        private void drawEdge(Graphics graphics, Edge edge)
        {
            Pen pen2 = new Pen(edge.COLOR, 5);

            graphics.DrawLine(pen2, edge.A.X, edge.A.Y, edge.B.X, edge.B.Y);

            if (pesosActivated_FV)
            {
                Brush brush = new SolidBrush(Color.Gray);
                String fuente = "Arial";
                Font f = new Font(fuente, 15);
                graphics.DrawString("e" + edge.Weight + "", f, brush, (edge.A.X + edge.B.X) / 2 + 2, (edge.A.Y + edge.B.Y) / 2 + 2, new StringFormat());
            }
        }

        private void drawEdge(Graphics graphics, Edge edge, Color color)
        {
            Pen pen2 = new Pen(color, 5);

            graphics.DrawLine(pen2, edge.A.X, edge.A.Y, edge.B.X, edge.B.Y);

            if (pesosActivated_FV)
            {
                Brush brush = new SolidBrush(Color.Gray);
                String fuente = "Arial";
                Font f = new Font(fuente, 15);
                graphics.DrawString("e" + edge.Weight + "", f, brush, (edge.A.X + edge.B.X) / 2 + 2, (edge.A.Y + edge.B.Y) / 2 + 2, new StringFormat());
            }
        }

        private void drawCicledEdge(Graphics graphics, Edge edge, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 5);
            Point StartPoint = new Point(edge.A.X, edge.A.Y);
            Point unoP = new Point(edge.A.X - generalRadius_FV * 4, edge.A.Y - generalRadius_FV * 4);
            Point dosP = new Point(edge.A.X - generalRadius_FV * 4, edge.A.Y + generalRadius_FV * 4);
            GraphicsPath gPath = new GraphicsPath();
            gPath.AddBezier(StartPoint, unoP, dosP, StartPoint);
            e.Graphics.DrawPath(pen, gPath);

            if (pesosActivated_FV)
            {
                Brush brush = new SolidBrush(Color.Green);
                String fuente = "Arial";
                Font f = new Font(fuente, 15);
                graphics.DrawString("e" + edge.Weight + "", f, brush, edge.A.X - 85, edge.A.Y - 10, new StringFormat());
            }
        }

        private void drawDirectedEdge(Graphics graphics, Edge edge)
        {
            Pen penDirect = new Pen(Color.DimGray, 8);
            //if (dijkstraShow && (edgesToColor[edge.Client.Index] == edge.Server.Index))
            //{
            //    penDirect = new Pen(Color.Red, 5);
            //}
            //else
            //{
                if (edge.COLOR != Color.Black)
                {
                    penDirect = new Pen(edge.COLOR, 5);
                }
            //}

            penDirect.StartCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;
            penDirect.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            Double equis_X;
            Double ye_Y;
            Double rate = edge.Distancia / generalRadius_FV;
            equis_X = (edge.A.X + rate * edge.B.X) / (1 + rate);
            ye_Y = (edge.A.Y + rate * edge.B.Y) / (1 + rate);
            graphics.DrawLine(penDirect, edge.A.X, edge.A.Y, (float)equis_X, (float)ye_Y);

            if (pesosActivated_FV)
            {
                Brush brush = new SolidBrush(Color.Gray);
                String fuente = "Arial";
                Font f = new Font(fuente, 15);
                graphics.DrawString("e" + edge.Weight + "", f, brush, (edge.A.X + edge.B.X) / 2 + 2, (edge.A.Y + edge.B.Y) / 2 + 2, new StringFormat());
            }
        }

        private void drawDirectedEdge(Graphics graphics, Edge edge, Color color)
        {
            Pen penDirect = new Pen(color, 5);
            penDirect.StartCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;
            penDirect.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            Double equis_X;
            Double ye_Y;
            Double rate = edge.Distancia / generalRadius_FV;
            equis_X = (edge.A.X + rate * edge.B.X) / (1 + rate);
            ye_Y = (edge.A.Y + rate * edge.B.Y) / (1 + rate);
            graphics.DrawLine(penDirect, edge.A.X, edge.A.Y, (float)equis_X, (float)ye_Y);

            if (pesosActivated_FV)
            {
                Brush brush = new SolidBrush(Color.Gray);
                String fuente = "Arial";
                Font f = new Font(fuente, 15);
                graphics.DrawString("e" + edge.Weight + "", f, brush, (edge.A.X + edge.B.X) / 2 + 2, (edge.A.Y + edge.B.Y) / 2 + 2, new StringFormat());
            }
        }
*/
        #endregion

        #region InvalidatePlus
        /****************************************************************************
         * 
         *  ||||||||||||||||||||| MENTADO INVALIDATE() (Begin) ||||||||||||||||||||
         * 
         * *****************************************************************************/

        /****************** invalidate Plus (Begin) ***************************/
        public void InvalidatePlus()
        {
            commonInvalidateActions();
            Invalidate();
        }
        public void InvalidatePlus(int code)// just save change to false because of an operation.
        {
            justSaved_FV = false;// almost all that requires invalidate also should change the jusSaved state.           
            commonInvalidateActions();
            Invalidate();
        }
        /****************** invalidate Plus (END) ***************************/
        /****************** invalidate common (Begin) ***************************/
        public void commonInvalidateActions()
        {
            matrixTB.Text = graph_FV.ToString(matIn_FV);

            if (selectedNode_FV != null)
            {
                terminal.Text = "Node selected : " + System.Environment.NewLine + "ID = " + selectedNode_FV.ID + System.Environment.NewLine + "Index = " + selectedNode_FV.Index + "\t" + System.Environment.NewLine;
                if (graph_FV.Directed() == true)
                {
                    DirectedGrade dG;
                    dG = graph_FV.GradeOfDirectedNode(selectedNode_FV);
                    terminal.Text += "Grado(Nodo): " + dG.Total;
                    terminal.Text += System.Environment.NewLine;
                    terminal.Text += "  GradoEntrada ( [<-] ): " + selectedNode_FV.GradeIn;
                    terminal.Text += System.Environment.NewLine;
                    terminal.Text += "  GradoSalida    ( [->] ): " + selectedNode_FV.GradeOut;
                }
                else
                {
                    terminal.Text += "Grado(Nodo): " + selectedNode_FV.GradeOut;
                }
            }
            else
            {
                terminal.Text = "Node selected : ";
            }
            statusTB.Text = "Nombre :" + fileName_FV + System.Environment.NewLine;
            statusTB.Text += "Grado(Grafo) : " + graph_FV.Grade();
            statusTB.Text += System.Environment.NewLine;
            statusTB.Text += "Dirigido : " + graph_FV.Directed();
            statusTB.Text += System.Environment.NewLine;
            statusTB.Text += "Completo : " + graph_FV.Complete();
            statusTB.Text += System.Environment.NewLine;
            statusTB.Text += "Pseudo: " + graph_FV.Pseudo();
            statusTB.Text += System.Environment.NewLine;
            statusTB.Text += "Cíclico : " + graph_FV.Cicled();
            statusTB.Text += System.Environment.NewLine;
            statusTB.Text += "Bipartita : " + graph_FV.Bip();
            statusTB.Text += System.Environment.NewLine;

            if ((isomorphismForm_FV == null || (isomorphismForm_FV != null && isomorphismForm_FV.Visible == false)) && isoForm == false)
            {
                IsomtextBox.Visible = false;
            }
        }
        /****************** invalidate common (END) ***************************/
        #endregion

        #region utilAlgorithms

        /*************************************************************************************************************************
         * 
         * |||||||||||||||||||||||||||||||||||||||||||||||||||||   OTHER METHODS ()  |||||||||||||||||||||||||||||||||||||||||||||||||||
         * 
         * ***********************************************************************************************************************/
        public Node findNodeClicked(Point cor)
        {
            Node resNode = null;

            foreach (Node onNode in graph_FV.NODE_LIST)
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

        public void eliminate()
        {
            if (graph_FV.NODE_LIST.Count() <= 1)
                justSaved_FV = true;
            if (selectedNode_FV != null)
            {
                graph_FV.eliminateNexetEdges(selectedNode_FV);
                graph_FV.eliminateNexetDirectedEdges(selectedNode_FV);
                graph_FV.eliminateCicledEdges(selectedNode_FV);
                graph_FV.removeNode(selectedNode_FV);

                selectedNode_FV = null;
            }
            InvalidatePlus(1);
        }

        public void changeIsomtextBox(String str)
        {
            IsomtextBox.Text = "Isomorfismo : ";
            IsomtextBox.Text += System.Environment.NewLine;
            IsomtextBox.Text += str;
        }
        /*************************************************************************************************************************
         * 
         * |||||||||||||||||||||||||||||||||||||||||||||||||||||   ALGORITHMS  |||||||||||||||||||||||||||||||||||||||||||||||||||
         * 
         * ***********************************************************************************************************************/

        Graph aux;
        List<Edge> cutEdges;
        pathsOK f3 = new pathsOK();

        /**************************************
         * 
         * 
         * Bool to comproove .
         * 
         * **********************************/
        public Boolean allConected(Graph graph)
        {
            // Mark all the vertices as not visited 
            graph.markAllLikeNotVisited();

            // Start DFS traversal from a vertex with non-zero degree 
            DFSUtilAllConected(graph.NODE_LIST[0]);

            // Check if all non-zero degree vertices are visited 
            foreach (Node node in graph.NODE_LIST)
            {
                if (node.Visited == false)
                {
                    return false;
                }
            }

            return true;
        }

        void DFSUtilAllConected(Node workingNode/*int v, bool visited[]*/)
        {
            // Mark the current node as visited
            workingNode.Visited = true;


            // Recur for all the vertices adjacent to this vertex
            foreach (NodeRef nodeR in workingNode.Neighbors)
            {
                if (nodeR.Node.Visited == false)
                {
                    DFSUtilAllConected(nodeR.Node);
                }
            }
        }

        public Boolean isABridgeVisitedsBool(Edge posibleBridge, Graph graph)
        {
            List<int> listOfNonVisited = new List<int>();
            foreach (Node node in graph.NODE_LIST)
            {
                if (node.Visited == false)
                {
                    listOfNonVisited.Add(node.Index);
                }
            }

            // Mark all the vertices as not visited 
            graph.markAllLikeNotVisited();

            // Start DFS traversal from a vertex with non-zero degree 
            //DFSUtilAllConectedBridge(aux.LIST_NODES[0], posibleBridge);
            DFSUtilAllConectedVisitedsBridge(graph.NODE_LIST[0], posibleBridge, graph);

            // Check if all non-zero degree vertices are visited 
            //foreach (Node node in aux.LIST_NODES)
            foreach (Node node in this.graph_FV.NODE_LIST)
            {
                if (node.Visited == false)
                {
                    //posibleBridge.COLOR = Color.Gold;
                    posibleBridge.Bridge = true;


                    foreach (Node nodeG in graph.NODE_LIST)
                    {
                        if (listOfNonVisited.Contains(nodeG.Index))
                        {
                            nodeG.Visited = false;
                        }
                        else
                        {
                            nodeG.Visited = true;
                        }
                    }

                    return true;
                }
            }

            posibleBridge.Bridge = false;

            foreach (Node node in graph.NODE_LIST)
            {
                if (listOfNonVisited.Contains(node.Index))
                {
                    node.Visited = false;
                }
                else
                {
                    node.Visited = true;
                }
            }
            return false;//if all vertices was visited evenif the edge was cutted.
        }

        void DFSUtilAllConectedVisitedsBridge(Node workingNode, Edge posibleBridge, Graph graph/*int v, bool visited[]*/)
        {
            // Mark the current node as visited
            workingNode.Visited = true;

            // Recur for all the vertices adjacent to this vertex
            foreach (NodeRef nodeR in workingNode.Neighbors)
            {
                if (workingNode == posibleBridge.Client && nodeR.Node == posibleBridge.Server
                 || workingNode == posibleBridge.Server && nodeR.Node == posibleBridge.Client)
                {

                }
                else if (nodeR.Node.Visited == false && graph.thisEdge(workingNode, nodeR.Node).visitada == false)
                {
                    DFSUtilAllConectedVisitedsBridge(nodeR.Node, posibleBridge, graph);
                }
            }
        }

        public Boolean allVisited(List<Edge> listEdges)
        {
            foreach (Edge edge in listEdges)
            {
                if (edge.visitada == false)
                    return false;
            }
            return true;
        }
        #endregion

        #region forPathAnimation
        protected virtual void isoForm_Click(object sender, EventArgs e)
        {
            //offWhenClickingMouseOrKey();
            Invalidate();

            if (isomorphismForm_FV == null || isomorphismForm_FV.Visible == false)
            {
                isomorphismForm_FV = new GraphFormIsomorphic(this);
                isomorphismForm_FV.Show();
            }

            fuerzaBrutaToolStripMenuItem.Visible = true;
            traspuestaToolStripMenuItem.Visible = true;
            intercambioToolStripMenuItem.Visible = true;
            IsomtextBox.Visible = true;

            //formaIsomorfismo.Show();
        }

        Boolean switcher = false;

        public void GraphTimerColor(object sender, EventArgs e)
        {
            //if (pathOfNodes != null && tmpCount >= pathOfNodes.Count())
            //{
            //    timerColor.Stop();
            //    if (f3.Operation == 1)
            //    {
            //        graph_FV.allBlack();
            //        Invalidate();
            //        f3.Operation = 0;
            //    }

            //}
            //else
            //{
            //    if (pathOfNodes != null)
            //    {
            //        if (switcher == false)
            //        {
            //            pathOfNodes[tmpCount].COLOR = Color.Aquamarine;
            //            switcher = true;
            //        }
            //        else
            //        {

            //            int serverIndex = tmpCount + 1;
            //            if (serverIndex == pathOfNodes.Count())
            //            {
            //                serverIndex = 0;
            //            }

            //            Edge otroX = this.graph_FV.thisEdge(pathOfNodes[tmpCount], pathOfNodes[serverIndex]);

            //            Edge auxEdge = this.graph_FV.thisEdge(pathOfNodes[tmpCount], pathOfNodes[serverIndex]);
            //            if (auxEdge != null)
            //            {
            //                auxEdge.COLOR = Color.Red;
            //            }
            //            Invalidate();
            //            switcher = false;
            //            tmpCount++;
            //        }

            //    }
            //    else
            //    {
            timerColor.Stop();
            if (f3.Operation == 1)
            {
                graph_FV.allBlack();
                Invalidate();
                f3.Operation = 0;
            }
            //}
            //}
            Invalidate();
        }

        //Boolean switcher2 = false;
        List<Edge> workingEdgesList;
        // List<NeightborsTreatet>

        public void GraphTimerColor2(object sender, EventArgs e)
        {
            graph_FV.markAllLikeNotVisited();

            Edge[] workingEdgesArray = new Edge[graph_FV.EDGE_LIST.Count()];
            graph_FV.EDGE_LIST.CopyTo(workingEdgesArray);
            workingEdgesList = workingEdgesArray.ToList();

            graph_FV.markAllEdgesAsNotVisited(workingEdgesList);

            do
            {
                BFSColored(initialNodePath);
            }
            while (allVisited(workingEdgesList) == true);
            Invalidate();
            timerColor.Stop();
        }

        public void BFSColored(Node node)
        {
            node.Visited = true;
            node.Color = Color.Red;

            foreach (NodeRef nodoR in node.Neighbors)
            {
                foreach (Edge edge in workingEdgesList)
                {
                    if (!edge.isThis(node, nodoR.Node))
                    {
                        if (edge.visitada == false)
                        {
                            edge.visitada = true;
                            edge.COLOR = Color.Green;
                            BFSColored(nodoR.Node);
                        }
                    }
                }

            }
            Invalidate();
        }

        private static Timer algorithms_Handling_Timer;


        private void Form1_Load(object sender, EventArgs e)
        {
            //pruebas pb = new pruebas();
            //pb.ShowDialog();
            timerColor = new System.Windows.Forms.Timer();
            timerColor.Interval = 800;
            timerColor.Tick += new EventHandler(GraphTimerColor/*GraphTimerColor*/);
            tmpCount = 0;

            algorithms_Handling_Timer = new Timer();
            algorithms_Handling_Timer.Interval = 500;
            algorithms_Handling_Timer.Tick += new EventHandler(callAlgorithms);
            algorithms_Handling_Timer.Start();


        }

        #endregion

        #region DoAlgo FlagsAndEvents


        /******************************** for ALGORITMOS EVENTS  **********************************************/
        const int DoAlgo_DFS_Auto = 1;
        const int DoAlgo_DFS_Manual = 2;
        const int DoAlgo_BFS_Auto = 3;
        const int DoAlgo_BFS_Manual = 4;
        const int DoAlgo_Kruskal = 5;//Undirected graphs only
        const int DoAlgo_Prim = 6;//Undirected grpaphs only
        const int DoAlgo_Warshall = 7;
        const int DoAlgo_Floyd = 8;
        const int DoAlgo_Dijkstra = 9;
        const int DoAlgo_Hamilton = 10;//any kind of graph
        const int DoAlgo_Euler = 11;//any kind of graph
        const int DoAlgo_Iso_FuerzaBruta = 12;//any kind of graph
        const int DoAlgo_Iso_Transpuesta = 13;//any kind of graph
        const int DoAlgo_Iso_Intercambio = 14;//any kind of graph
        int DoAlgo_Option = 0;
       

        private bool anyDoAlgo_Actived()
        {
            if(DoAlgo_Option > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //DFS AUTO:
        private void DoAlgo_DFS_Auto_Click(object sender, EventArgs e)
        {
            DoAlgo_Option = DoAlgo_DFS_Auto ;
            Reset_All();
            algorithms_Handling_Timer.Start();
        }

        //DFS MANUAL:
        private void DoAlgo_DFS_Manual_Click(object sender, EventArgs e)
        {
            DoAlgo_Option = DoAlgo_DFS_Manual;
            Reset_All();
            algorithms_Handling_Timer.Start();
        }

        //BFS AUTO:
        private void DoAlgo_BFS_Auto_Click(object sender, EventArgs e)
        {
            DoAlgo_Option = DoAlgo_BFS_Auto;
            Reset_All();
            algorithms_Handling_Timer.Start();
        }

        //BFS MANUAL:
        private void DoAlgo_BFS_Manual_Click(object sender, EventArgs e)
        {
            DoAlgo_Option = DoAlgo_BFS_Manual;
            Reset_All();
            algorithms_Handling_Timer.Start();
        }

        //KRUSKAL:
        private void DoAlgo_Kruskal_Click(object sender, EventArgs e)
        {
            DoAlgo_Option = DoAlgo_Kruskal;
            Reset_All();
            algorithms_Handling_Timer.Start();
        }
       
        //PRIM:
        private void DoAlgo_Prim_Click(object sender, EventArgs e)
        {
            DoAlgo_Option = DoAlgo_Prim;
            Reset_All();
            algorithms_Handling_Timer.Start();
        }

        //WARSHALL:
        private void DoAlgo_Warshall_Click(object sender, EventArgs e)
        {
            DoAlgo_Option = DoAlgo_Warshall;
            Reset_All();
            algorithms_Handling_Timer.Start();
        }

        //FLOYD:
        private void DoAlgo_Floyd_Click(object sender, EventArgs e)
        {
            DoAlgo_Option = DoAlgo_Floyd;
            Reset_All();
            algorithms_Handling_Timer.Start();
        }

        //DIJKSTRA:      
        private void DoAlgo_Dijkstra_Click(object sender, EventArgs e)
        {
            DoAlgo_Option = DoAlgo_Dijkstra ;
            Reset_All();
            algorithms_Handling_Timer.Start();
        }

       //HAMILTON:
        private void DoAlgo_Hamilton_Click(object sender, EventArgs e)
        {
            DoAlgo_Option = DoAlgo_Hamilton;
            Reset_All();
            algorithms_Handling_Timer.Start();
        }

       //EULER:
        private void DoAlgo_Euler_Click(object sender, EventArgs e)
        {
            DoAlgo_Option = DoAlgo_Euler;
            Reset_All();
            algorithms_Handling_Timer.Start();
        }

        //ISOM BF
        private void DoAlgo_Iso_FuerzaBruta_Click(object sender, EventArgs e)
        {
            DoAlgo_Option = DoAlgo_Iso_FuerzaBruta ;
            Reset_All();
            algorithms_Handling_Timer.Start();
        }

        //ISOM TRANSPOSED MATRIX
        private void DoAlgo_Iso_Transpuesta_Click(object sender, EventArgs e)
        {
            DoAlgo_Option = DoAlgo_Iso_Transpuesta;
            Reset_All();
            algorithms_Handling_Timer.Start();
        } 

        //ISOM graph theory manual
        private void DoAlgo_Iso_Intercambio_Click(object sender, EventArgs e)
        {
            DoAlgo_Option = DoAlgo_Iso_Intercambio ;
            Reset_All();
            algorithms_Handling_Timer.Start();
        }

        /*
         * 
         * This function is a timer hanler, it helps to determine if the editor can perform the 
         * algoithm by certain conditions, as initial node or root, etc.
         * 
         * */
        Node initialNode = null;
        private void callAlgorithms(object sender, EventArgs e)
        {
            switch (DoAlgo_Option)
            {
                case DoAlgo_DFS_Auto:
                    //this algorithms does not need anything for start
                    DoAlgo_DFS_Auto_Start();
                    break;
                case DoAlgo_DFS_Manual:
                    //needs a root
                    if (initialNode != null)
                    {
                        DoAlgo_DFS_Manual_Start();
                    }
                    break;
                case DoAlgo_BFS_Auto:
                    //this algorithms does not ned anything for start
                    DoAlgo_BFS_Auto_Start();
                    break;
                case DoAlgo_BFS_Manual:
                    //needs a root
                    if (initialNode != null)
                    {
                        DoAlgo_BFS_Manual_Start();
                    }
                    break;
                case DoAlgo_Kruskal://for minimum spanining tree
                    //this algorithms does not need anything for start
                    DoAlgo_Kruskal_Start();
                    break;
                case DoAlgo_Prim:
                    //this algorithms does not need anything for start
                    DoAlgo_Prim_Start();
                    break;
                case DoAlgo_Warshall:
                    //this algorithms does not need anything for start
                    DoAlgo_Warshall_Start();
                    break;
                case DoAlgo_Floyd:
                    //this algorithms does not need anything for start
                    DoAlgo_Floyd_Start();
                    break;
                case DoAlgo_Dijkstra:
                    //this algorithms does not need anything for start
                    DoAlgo_Dijkstra_Start();
                    break;
                case DoAlgo_Hamilton:
                    //this algorithms does not need anything for start
                    DoAlgo_Hamilton_Start();
                    break;
                case DoAlgo_Euler:
                    //this algorithms does not need anything for start
                    DoAlgo_Euler_Start();
                    break;
                case DoAlgo_Iso_FuerzaBruta:
                    //this algorithms does not need anything for start
                    DoAlgo_Iso_FuerzaBruta_Start();
                    break;
                case DoAlgo_Iso_Transpuesta:
                    //this algorithms does not need anything for start
                    DoAlgo_Iso_Transpuesta_Start();
                    break;
                case DoAlgo_Iso_Intercambio:
                    //this algorithms does not need anything for start
                    DoAlgo_Iso_Intercambio_Start();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Algorithms ForCalling
        /*
         * 
         *  DFS in automatic mode doesn´t need anything to start
         * 
         * */
        private void DoAlgo_DFS_Auto_Start()
        {
           Forest forest =  this.graph_FV.getForestDFS(graph_FV.rootNode());
        }

        /*
         * 
         *  DFS in manual mode need a specific root Node
         * 
         * */
        private void DoAlgo_DFS_Manual_Start()
        {
            Forest forest = this.graph_FV.getForestDFS(initialNode);
        }

        /*
         * 
         *  DFS in manual mode need a specific root Node
         * 
         * */
        private void DoAlgo_BFS_Auto_Start()
        {
            Forest forest = this.graph_FV.getForestBFS(graph_FV.rootNode());
        }

        /*
        * 
        *  BFS in manual mode need a specific root Node
        * 
        * */
        private void DoAlgo_BFS_Manual_Start()
        {
            Forest forest = this.graph_FV.getForestDFS(initialNode);
        }

        private void DoAlgo_Kruskal_Start()
        {
            
        }
        private void DoAlgo_Prim_Start()
        {
            
        }

        private void DoAlgo_Warshall_Start()
        {
            
        }

        private void DoAlgo_Floyd_Start()
        {
            
        }

        private void DoAlgo_Dijkstra_Start()
        {
            
        }

        private void DoAlgo_Hamilton_Start()
        {
            
        }

        private void DoAlgo_Euler_Start()
        {
         
        }
        private void DoAlgo_Iso_FuerzaBruta_Start()
        {
            
        }

        private void DoAlgo_Iso_Transpuesta_Start()
        {
          
        }

        private void DoAlgo_Iso_Intercambio_Start()
        {
           
        }

        #endregion

    }//Form(END).
}//namespace(END).