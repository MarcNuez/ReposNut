namespace Presentacion
{
    partial class FormVacaciones
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
            this.lblDiasSelect = new System.Windows.Forms.Label();
            this.btnSolicitar = new System.Windows.Forms.Button();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDiasPendientes = new System.Windows.Forms.Label();
            this.pnlMuestra = new System.Windows.Forms.Panel();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.btnMensual = new System.Windows.Forms.Button();
            this.btnComparar = new System.Windows.Forms.Button();
            this.lblAño = new System.Windows.Forms.Label();
            this.btnAdelanteAño = new System.Windows.Forms.Button();
            this.btnAtrasAño = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userControlMensual1 = new Presentacion.CustomControls.UserControlMensual();
            this.panelContainer.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDiasSelect
            // 
            this.lblDiasSelect.AutoSize = true;
            this.lblDiasSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiasSelect.Location = new System.Drawing.Point(5, 5);
            this.lblDiasSelect.Margin = new System.Windows.Forms.Padding(5);
            this.lblDiasSelect.Name = "lblDiasSelect";
            this.lblDiasSelect.Size = new System.Drawing.Size(0, 16);
            this.lblDiasSelect.TabIndex = 2;
            // 
            // btnSolicitar
            // 
            this.btnSolicitar.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnSolicitar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSolicitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSolicitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolicitar.ForeColor = System.Drawing.Color.White;
            this.btnSolicitar.Location = new System.Drawing.Point(57, 506);
            this.btnSolicitar.Margin = new System.Windows.Forms.Padding(2);
            this.btnSolicitar.Name = "btnSolicitar";
            this.btnSolicitar.Size = new System.Drawing.Size(177, 49);
            this.btnSolicitar.TabIndex = 1;
            this.btnSolicitar.Text = "Solicitar";
            this.btnSolicitar.UseVisualStyleBackColor = false;
            this.btnSolicitar.Click += new System.EventHandler(this.btnSolicitar_Click);
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Vacaciones",
            "Ausencias"});
            this.cmbTipo.Location = new System.Drawing.Point(22, 102);
            this.cmbTipo.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(138, 21);
            this.cmbTipo.TabIndex = 5;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dias pendientes:";
            // 
            // lblDiasPendientes
            // 
            this.lblDiasPendientes.AutoSize = true;
            this.lblDiasPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiasPendientes.Location = new System.Drawing.Point(122, 28);
            this.lblDiasPendientes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiasPendientes.Name = "lblDiasPendientes";
            this.lblDiasPendientes.Size = new System.Drawing.Size(92, 31);
            this.lblDiasPendientes.TabIndex = 1;
            this.lblDiasPendientes.Text = "label2";
            // 
            // pnlMuestra
            // 
            this.pnlMuestra.BackColor = System.Drawing.Color.MediumTurquoise;
            this.pnlMuestra.Location = new System.Drawing.Point(165, 102);
            this.pnlMuestra.Name = "pnlMuestra";
            this.pnlMuestra.Size = new System.Drawing.Size(21, 21);
            this.pnlMuestra.TabIndex = 6;
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContainer.Controls.Add(this.userControlMensual1);
            this.panelContainer.Location = new System.Drawing.Point(297, 85);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(731, 502);
            this.panelContainer.TabIndex = 7;
            // 
            // btnMensual
            // 
            this.btnMensual.Location = new System.Drawing.Point(297, 28);
            this.btnMensual.Name = "btnMensual";
            this.btnMensual.Size = new System.Drawing.Size(104, 41);
            this.btnMensual.TabIndex = 8;
            this.btnMensual.Text = "Mensual";
            this.btnMensual.UseVisualStyleBackColor = true;
            this.btnMensual.Click += new System.EventHandler(this.btnMensual_Click);
            // 
            // btnComparar
            // 
            this.btnComparar.Location = new System.Drawing.Point(417, 29);
            this.btnComparar.Name = "btnComparar";
            this.btnComparar.Size = new System.Drawing.Size(104, 41);
            this.btnComparar.TabIndex = 9;
            this.btnComparar.Text = "Vacaciones Compañeros";
            this.btnComparar.UseVisualStyleBackColor = true;
            this.btnComparar.Click += new System.EventHandler(this.btnComparar_Click);
            // 
            // lblAño
            // 
            this.lblAño.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAño.Location = new System.Drawing.Point(23, 0);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(90, 38);
            this.lblAño.TabIndex = 10;
            this.lblAño.Text = "label4";
            this.lblAño.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAdelanteAño
            // 
            this.btnAdelanteAño.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAdelanteAño.Location = new System.Drawing.Point(113, 0);
            this.btnAdelanteAño.Name = "btnAdelanteAño";
            this.btnAdelanteAño.Size = new System.Drawing.Size(23, 38);
            this.btnAdelanteAño.TabIndex = 11;
            this.btnAdelanteAño.Text = ">";
            this.btnAdelanteAño.UseVisualStyleBackColor = true;
            this.btnAdelanteAño.Click += new System.EventHandler(this.btnAdelanteAño_Click);
            // 
            // btnAtrasAño
            // 
            this.btnAtrasAño.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAtrasAño.Location = new System.Drawing.Point(0, 0);
            this.btnAtrasAño.Name = "btnAtrasAño";
            this.btnAtrasAño.Size = new System.Drawing.Size(23, 38);
            this.btnAtrasAño.TabIndex = 12;
            this.btnAtrasAño.Text = "<";
            this.btnAtrasAño.UseVisualStyleBackColor = true;
            this.btnAtrasAño.Click += new System.EventHandler(this.btnAtrasAño_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Dias Seleccionados: ";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblDiasSelect);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(22, 288);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(242, 201);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblAño);
            this.panel1.Controls.Add(this.btnAtrasAño);
            this.panel1.Controls.Add(this.btnAdelanteAño);
            this.panel1.Location = new System.Drawing.Point(892, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(136, 38);
            this.panel1.TabIndex = 16;
            // 
            // userControlMensual1
            // 
            this.userControlMensual1.AñoSeleccionado = 2020;
            this.userControlMensual1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlMensual1.Location = new System.Drawing.Point(0, 0);
            this.userControlMensual1.MesSeleccionado = 4;
            this.userControlMensual1.Name = "userControlMensual1";
            this.userControlMensual1.Size = new System.Drawing.Size(731, 502);
            this.userControlMensual1.TabIndex = 0;
            // 
            // FormVacaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1065, 629);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnComparar);
            this.Controls.Add(this.btnMensual);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.pnlMuestra);
            this.Controls.Add(this.btnSolicitar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.lblDiasPendientes);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormVacaciones";
            this.Text = "FormVacaciones";
            this.Load += new System.EventHandler(this.FormVacaciones_Load);
            this.panelContainer.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDiasSelect;
        private System.Windows.Forms.Button btnSolicitar;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDiasPendientes;
        private System.Windows.Forms.Panel pnlMuestra;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button btnMensual;
        private System.Windows.Forms.Button btnComparar;
        private CustomControls.UserControlMensual userControlMensual1;
        private System.Windows.Forms.Label lblAño;
        private System.Windows.Forms.Button btnAdelanteAño;
        private System.Windows.Forms.Button btnAtrasAño;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}