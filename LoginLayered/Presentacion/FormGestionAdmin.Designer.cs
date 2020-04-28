namespace Presentacion
{
    partial class FormGestionAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGrid = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnMostrarAusencias = new System.Windows.Forms.Button();
            this.btnMarcarTodasA = new System.Windows.Forms.Button();
            this.btnMarcarTodasD = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.BackgroundColor = System.Drawing.Color.White;
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGrid.ColumnHeadersHeight = 35;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dataGrid.DoubleBuffered = true;
            this.dataGrid.EnableHeadersVisualStyles = false;
            this.dataGrid.HeaderBgColor = System.Drawing.Color.DodgerBlue;
            this.dataGrid.HeaderForeColor = System.Drawing.Color.White;
            this.dataGrid.Location = new System.Drawing.Point(106, 233);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(756, 331);
            this.dataGrid.TabIndex = 0;
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.ItemHeight = 13;
            this.cmbEstado.Items.AddRange(new object[] {
            "Pendientes",
            "Aprobadas",
            "Todas"});
            this.cmbEstado.Location = new System.Drawing.Point(365, 104);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(171, 21);
            this.cmbEstado.TabIndex = 1;
            this.cmbEstado.SelectedIndexChanged += new System.EventHandler(this.cmbEstado_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar por nombre: ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(106, 196);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(211, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // btnMostrarAusencias
            // 
            this.btnMostrarAusencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMostrarAusencias.Location = new System.Drawing.Point(757, 173);
            this.btnMostrarAusencias.Name = "btnMostrarAusencias";
            this.btnMostrarAusencias.Size = new System.Drawing.Size(105, 54);
            this.btnMostrarAusencias.TabIndex = 4;
            this.btnMostrarAusencias.Text = "Mostrar Ausencias";
            this.btnMostrarAusencias.UseVisualStyleBackColor = true;
            // 
            // btnMarcarTodasA
            // 
            this.btnMarcarTodasA.Location = new System.Drawing.Point(365, 180);
            this.btnMarcarTodasA.Name = "btnMarcarTodasA";
            this.btnMarcarTodasA.Size = new System.Drawing.Size(117, 36);
            this.btnMarcarTodasA.TabIndex = 5;
            this.btnMarcarTodasA.Text = "Marcar Todas Para Aprobar ";
            this.btnMarcarTodasA.UseVisualStyleBackColor = true;
            this.btnMarcarTodasA.Click += new System.EventHandler(this.btnMarcarTodasA_Click);
            // 
            // btnMarcarTodasD
            // 
            this.btnMarcarTodasD.Location = new System.Drawing.Point(488, 180);
            this.btnMarcarTodasD.Name = "btnMarcarTodasD";
            this.btnMarcarTodasD.Size = new System.Drawing.Size(117, 36);
            this.btnMarcarTodasD.TabIndex = 6;
            this.btnMarcarTodasD.Text = "Marcar Todas Para Denegar";
            this.btnMarcarTodasD.UseVisualStyleBackColor = true;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 48F;
            this.Column1.HeaderText = "Nombre";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 48.08403F;
            this.Column2.HeaderText = "Estado";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 48.08403F;
            this.Column5.HeaderText = "Dias";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 48.08403F;
            this.Column6.HeaderText = "Comentario";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.FalseValue = "0";
            this.Column7.FillWeight = 48.08403F;
            this.Column7.HeaderText = "Aprobar";
            this.Column7.IndeterminateValue = "1";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.FillWeight = 40F;
            this.Column8.HeaderText = "Denegar";
            this.Column8.Name = "Column8";
            // 
            // FormGestionAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(980, 576);
            this.Controls.Add(this.btnMarcarTodasD);
            this.Controls.Add(this.btnMarcarTodasA);
            this.Controls.Add(this.btnMostrarAusencias);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.dataGrid);
            this.Name = "FormGestionAdmin";
            this.Text = "FormGestionAdmin";
            this.Load += new System.EventHandler(this.FormGestionAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomDataGrid dataGrid;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnMostrarAusencias;
        private System.Windows.Forms.Button btnMarcarTodasA;
        private System.Windows.Forms.Button btnMarcarTodasD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
        private System.Windows.Forms.DataGridViewButtonColumn Column8;
    }
}