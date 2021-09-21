namespace editorDeGrafos
{
    partial class GraphForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.terminal = new System.Windows.Forms.TextBox();
            this.statusTB = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.operacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveAllAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moReFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undirectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrizDeIncidenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bridgesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algoritmosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dFSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automaticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kruskalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.primToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warshallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floydToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dijkstraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caminosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eulerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hamiltonToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.isomorfismoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fuerzaBrutaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.transpuestaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intercambioManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.isomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fuerzaBrutaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traspuestaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intercambioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IsomtextBox = new System.Windows.Forms.TextBox();
            this.gradoTruncadoButton = new System.Windows.Forms.Button();
            this.trunquedGradeTextBox = new System.Windows.Forms.TextBox();
            this.matrixTB = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator,
            this.toolStripSeparator1,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(141, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(29, 28);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.Click += new System.EventHandler(this.New_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(29, 28);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.Load_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(29, 28);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.Save_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(29, 28);
            this.helpToolStripButton.Text = "He&lp";
            this.helpToolStripButton.Click += new System.EventHandler(this.helpToolStripButton_Click);
            // 
            // terminal
            // 
            this.terminal.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.terminal.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.terminal.Location = new System.Drawing.Point(1304, 15);
            this.terminal.Margin = new System.Windows.Forms.Padding(4);
            this.terminal.Multiline = true;
            this.terminal.Name = "terminal";
            this.terminal.ReadOnly = true;
            this.terminal.Size = new System.Drawing.Size(200, 149);
            this.terminal.TabIndex = 1;
            this.terminal.TabStop = false;
            // 
            // statusTB
            // 
            this.statusTB.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.statusTB.Location = new System.Drawing.Point(1007, 15);
            this.statusTB.Margin = new System.Windows.Forms.Padding(4);
            this.statusTB.Multiline = true;
            this.statusTB.Name = "statusTB";
            this.statusTB.ReadOnly = true;
            this.statusTB.Size = new System.Drawing.Size(288, 149);
            this.statusTB.TabIndex = 3;
            this.statusTB.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operacionesToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.algoritmosToolStripMenuItem,
            this.isomToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(155, 1);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(470, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // operacionesToolStripMenuItem
            // 
            this.operacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveMToolStripMenuItem,
            this.moveAllAToolStripMenuItem,
            this.removeXToolStripMenuItem,
            this.moReFToolStripMenuItem,
            this.linkingToolStripMenuItem});
            this.operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            this.operacionesToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.operacionesToolStripMenuItem.Text = "Operaciones";
            this.operacionesToolStripMenuItem.Click += new System.EventHandler(this.operacionesToolStripMenuItem_Click);
            // 
            // moveMToolStripMenuItem
            // 
            this.moveMToolStripMenuItem.Name = "moveMToolStripMenuItem";
            this.moveMToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.moveMToolStripMenuItem.Text = "Move (M) ";
            this.moveMToolStripMenuItem.Click += new System.EventHandler(this.Move_Click);
            // 
            // moveAllAToolStripMenuItem
            // 
            this.moveAllAToolStripMenuItem.Name = "moveAllAToolStripMenuItem";
            this.moveAllAToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.moveAllAToolStripMenuItem.Text = "Move All (A)";
            this.moveAllAToolStripMenuItem.Click += new System.EventHandler(this.MoveAll_Click);
            // 
            // removeXToolStripMenuItem
            // 
            this.removeXToolStripMenuItem.Name = "removeXToolStripMenuItem";
            this.removeXToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.removeXToolStripMenuItem.Text = "Remove (R)";
            this.removeXToolStripMenuItem.Click += new System.EventHandler(this.Remove_Click);
            // 
            // moReFToolStripMenuItem
            // 
            this.moReFToolStripMenuItem.Name = "moReFToolStripMenuItem";
            this.moReFToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.moReFToolStripMenuItem.Text = "MoRe (F)";
            this.moReFToolStripMenuItem.Click += new System.EventHandler(this.MoRe_Click);
            // 
            // linkingToolStripMenuItem
            // 
            this.linkingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undirectToolStripMenuItem,
            this.directToolStripMenuItem});
            this.linkingToolStripMenuItem.Name = "linkingToolStripMenuItem";
            this.linkingToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.linkingToolStripMenuItem.Text = "Linking (L)";
            this.linkingToolStripMenuItem.Click += new System.EventHandler(this.linking_Click);
            // 
            // undirectToolStripMenuItem
            // 
            this.undirectToolStripMenuItem.Name = "undirectToolStripMenuItem";
            this.undirectToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.undirectToolStripMenuItem.Text = "Undirect (U)";
            this.undirectToolStripMenuItem.Click += new System.EventHandler(this.linking_U_Click);
            // 
            // directToolStripMenuItem
            // 
            this.directToolStripMenuItem.Name = "directToolStripMenuItem";
            this.directToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.directToolStripMenuItem.Text = "Direct (D)";
            this.directToolStripMenuItem.Click += new System.EventHandler(this.linking_D_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matrizDeIncidenciaToolStripMenuItem,
            this.pesosToolStripMenuItem,
            this.bridgesToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.viewToolStripMenuItem.Text = "Vista";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // matrizDeIncidenciaToolStripMenuItem
            // 
            this.matrizDeIncidenciaToolStripMenuItem.Name = "matrizDeIncidenciaToolStripMenuItem";
            this.matrizDeIncidenciaToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.matrizDeIncidenciaToolStripMenuItem.Text = "Matriz de Incidencia";
            // 
            // pesosToolStripMenuItem
            // 
            this.pesosToolStripMenuItem.Name = "pesosToolStripMenuItem";
            this.pesosToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.pesosToolStripMenuItem.Text = "Pesos";
            this.pesosToolStripMenuItem.Click += new System.EventHandler(this.pesosToolStripMenuItem_Click);
            // 
            // bridgesToolStripMenuItem
            // 
            this.bridgesToolStripMenuItem.Name = "bridgesToolStripMenuItem";
            this.bridgesToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.bridgesToolStripMenuItem.Text = "Bridges ";
            // 
            // algoritmosToolStripMenuItem
            // 
            this.algoritmosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dFSToolStripMenuItem,
            this.kruskalToolStripMenuItem,
            this.primToolStripMenuItem,
            this.warshallToolStripMenuItem,
            this.floydToolStripMenuItem,
            this.dijkstraToolStripMenuItem,
            this.caminosToolStripMenuItem1,
            this.isomorfismoToolStripMenuItem});
            this.algoritmosToolStripMenuItem.Name = "algoritmosToolStripMenuItem";
            this.algoritmosToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            this.algoritmosToolStripMenuItem.Text = "Algoritmos";
            this.algoritmosToolStripMenuItem.Click += new System.EventHandler(this.algoritmosToolStripMenuItem_Click);
            // 
            // dFSToolStripMenuItem
            // 
            this.dFSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.automaticToolStripMenuItem,
            this.manualToolStripMenuItem});
            this.dFSToolStripMenuItem.Name = "dFSToolStripMenuItem";
            this.dFSToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.dFSToolStripMenuItem.Text = "DFS ( tree generation)";
            // 
            // automaticToolStripMenuItem
            // 
            this.automaticToolStripMenuItem.Name = "automaticToolStripMenuItem";
            this.automaticToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.automaticToolStripMenuItem.Text = "Automatic";
            this.automaticToolStripMenuItem.Click += new System.EventHandler(this.automaticToolStripMenuItem_Click);
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.manualToolStripMenuItem.Text = "Manual";
            // 
            // kruskalToolStripMenuItem
            // 
            this.kruskalToolStripMenuItem.Name = "kruskalToolStripMenuItem";
            this.kruskalToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.kruskalToolStripMenuItem.Text = "Kruskal";
            // 
            // primToolStripMenuItem
            // 
            this.primToolStripMenuItem.Name = "primToolStripMenuItem";
            this.primToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.primToolStripMenuItem.Text = "Prim";
            // 
            // warshallToolStripMenuItem
            // 
            this.warshallToolStripMenuItem.Name = "warshallToolStripMenuItem";
            this.warshallToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.warshallToolStripMenuItem.Text = "Warshall";
            // 
            // floydToolStripMenuItem
            // 
            this.floydToolStripMenuItem.Name = "floydToolStripMenuItem";
            this.floydToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.floydToolStripMenuItem.Text = "Floyd";
            // 
            // dijkstraToolStripMenuItem
            // 
            this.dijkstraToolStripMenuItem.Name = "dijkstraToolStripMenuItem";
            this.dijkstraToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.dijkstraToolStripMenuItem.Text = "Dijkstra";
            // 
            // caminosToolStripMenuItem1
            // 
            this.caminosToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eulerToolStripMenuItem1,
            this.hamiltonToolStripMenuItem1});
            this.caminosToolStripMenuItem1.Name = "caminosToolStripMenuItem1";
            this.caminosToolStripMenuItem1.Size = new System.Drawing.Size(238, 26);
            this.caminosToolStripMenuItem1.Text = "Caminos";
            // 
            // eulerToolStripMenuItem1
            // 
            this.eulerToolStripMenuItem1.Name = "eulerToolStripMenuItem1";
            this.eulerToolStripMenuItem1.Size = new System.Drawing.Size(154, 26);
            this.eulerToolStripMenuItem1.Text = "Euler";
            // 
            // hamiltonToolStripMenuItem1
            // 
            this.hamiltonToolStripMenuItem1.Name = "hamiltonToolStripMenuItem1";
            this.hamiltonToolStripMenuItem1.Size = new System.Drawing.Size(154, 26);
            this.hamiltonToolStripMenuItem1.Text = "Hamilton";
            // 
            // isomorfismoToolStripMenuItem
            // 
            this.isomorfismoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fuerzaBrutaToolStripMenuItem1,
            this.transpuestaToolStripMenuItem,
            this.intercambioManualToolStripMenuItem});
            this.isomorfismoToolStripMenuItem.Name = "isomorfismoToolStripMenuItem";
            this.isomorfismoToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.isomorfismoToolStripMenuItem.Text = "Isomorfismo";
            // 
            // fuerzaBrutaToolStripMenuItem1
            // 
            this.fuerzaBrutaToolStripMenuItem1.Name = "fuerzaBrutaToolStripMenuItem1";
            this.fuerzaBrutaToolStripMenuItem1.Size = new System.Drawing.Size(239, 26);
            this.fuerzaBrutaToolStripMenuItem1.Text = "Fuerza Bruta";
            // 
            // transpuestaToolStripMenuItem
            // 
            this.transpuestaToolStripMenuItem.Name = "transpuestaToolStripMenuItem";
            this.transpuestaToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
            this.transpuestaToolStripMenuItem.Text = "Transpuesta";
            // 
            // intercambioManualToolStripMenuItem
            // 
            this.intercambioManualToolStripMenuItem.Name = "intercambioManualToolStripMenuItem";
            this.intercambioManualToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
            this.intercambioManualToolStripMenuItem.Text = "Intercambio ( Manual)";
            // 
            // isomToolStripMenuItem
            // 
            this.isomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fuerzaBrutaToolStripMenuItem,
            this.traspuestaToolStripMenuItem,
            this.intercambioToolStripMenuItem});
            this.isomToolStripMenuItem.Name = "isomToolStripMenuItem";
            this.isomToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.isomToolStripMenuItem.Text = "Isom";
            // 
            // fuerzaBrutaToolStripMenuItem
            // 
            this.fuerzaBrutaToolStripMenuItem.Name = "fuerzaBrutaToolStripMenuItem";
            this.fuerzaBrutaToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.fuerzaBrutaToolStripMenuItem.Text = "Fuerza Bruta";
            // 
            // traspuestaToolStripMenuItem
            // 
            this.traspuestaToolStripMenuItem.Name = "traspuestaToolStripMenuItem";
            this.traspuestaToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.traspuestaToolStripMenuItem.Text = "Traspuesta";
            // 
            // intercambioToolStripMenuItem
            // 
            this.intercambioToolStripMenuItem.Name = "intercambioToolStripMenuItem";
            this.intercambioToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.intercambioToolStripMenuItem.Text = "Intercambio(Manual)";
            // 
            // IsomtextBox
            // 
            this.IsomtextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.IsomtextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.IsomtextBox.Location = new System.Drawing.Point(1513, 15);
            this.IsomtextBox.Margin = new System.Windows.Forms.Padding(4);
            this.IsomtextBox.Multiline = true;
            this.IsomtextBox.Name = "IsomtextBox";
            this.IsomtextBox.ReadOnly = true;
            this.IsomtextBox.Size = new System.Drawing.Size(296, 149);
            this.IsomtextBox.TabIndex = 6;
            this.IsomtextBox.TabStop = false;
            // 
            // gradoTruncadoButton
            // 
            this.gradoTruncadoButton.BackColor = System.Drawing.SystemColors.Control;
            this.gradoTruncadoButton.Location = new System.Drawing.Point(628, 6);
            this.gradoTruncadoButton.Margin = new System.Windows.Forms.Padding(4);
            this.gradoTruncadoButton.Name = "gradoTruncadoButton";
            this.gradoTruncadoButton.Size = new System.Drawing.Size(75, 25);
            this.gradoTruncadoButton.TabIndex = 7;
            this.gradoTruncadoButton.Text = "GradoT";
            this.gradoTruncadoButton.UseVisualStyleBackColor = false;
            this.gradoTruncadoButton.Click += new System.EventHandler(this.gradoTruncadoButton_Click);
            // 
            // trunquedGradeTextBox
            // 
            this.trunquedGradeTextBox.Location = new System.Drawing.Point(537, 6);
            this.trunquedGradeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.trunquedGradeTextBox.Name = "trunquedGradeTextBox";
            this.trunquedGradeTextBox.Size = new System.Drawing.Size(81, 22);
            this.trunquedGradeTextBox.TabIndex = 8;
            // 
            // matrixTB
            // 
            this.matrixTB.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.matrixTB.Location = new System.Drawing.Point(1007, 172);
            this.matrixTB.Margin = new System.Windows.Forms.Padding(4);
            this.matrixTB.Multiline = true;
            this.matrixTB.Name = "matrixTB";
            this.matrixTB.ReadOnly = true;
            this.matrixTB.Size = new System.Drawing.Size(803, 872);
            this.matrixTB.TabIndex = 2;
            this.matrixTB.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1007, 172);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(279, 163);
            this.dataGridView1.TabIndex = 9;
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1827, 922);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.trunquedGradeTextBox);
            this.Controls.Add(this.gradoTruncadoButton);
            this.Controls.Add(this.IsomtextBox);
            this.Controls.Add(this.statusTB);
            this.Controls.Add(this.matrixTB);
            this.Controls.Add(this.terminal);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GraphForm";
            this.Text = "Grafos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.TextBox terminal;
        private System.Windows.Forms.TextBox statusTB;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox IsomtextBox;
        private System.Windows.Forms.ToolStripMenuItem operacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linkingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem directToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undirectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveAllAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matrizDeIncidenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moReFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bridgesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem isomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fuerzaBrutaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traspuestaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intercambioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algoritmosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caminosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem eulerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hamiltonToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem isomorfismoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fuerzaBrutaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem transpuestaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intercambioManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dijkstraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floydToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warshallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem primToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kruskalToolStripMenuItem;
        private System.Windows.Forms.Button gradoTruncadoButton;
        private System.Windows.Forms.TextBox trunquedGradeTextBox;
        private System.Windows.Forms.ToolStripMenuItem pesosToolStripMenuItem;
        private System.Windows.Forms.TextBox matrixTB;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem dFSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automaticToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
    }
}

