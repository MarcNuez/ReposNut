namespace Presentacion
{
    partial class FormAusencias
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
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panelDesde = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.panelHasta = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.panelCalendarAusencias = new System.Windows.Forms.Panel();
            this.userControlAusencia1 = new Presentacion.CustomControls.UserControlAusencia();
            this.panelCalendarAusencias2 = new System.Windows.Forms.Panel();
            this.userControlAusencia2 = new Presentacion.CustomControls.UserControlAusencia();
            this.label5 = new System.Windows.Forms.Label();
            this.lblIntervalo = new System.Windows.Forms.Label();
            this.panelDesde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelHasta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelCalendarAusencias.SuspendLayout();
            this.panelCalendarAusencias2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Colegio",
            "Enfermedad",
            "Permiso Especial"});
            this.cmbTipo.Location = new System.Drawing.Point(45, 97);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(178, 21);
            this.cmbTipo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Desde:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hasta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Comentario: ";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(45, 340);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(447, 76);
            this.textBox1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(394, 448);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 48);
            this.button1.TabIndex = 8;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelDesde
            // 
            this.panelDesde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDesde.Controls.Add(this.pictureBox1);
            this.panelDesde.Controls.Add(this.lblFechaDesde);
            this.panelDesde.Location = new System.Drawing.Point(48, 219);
            this.panelDesde.Name = "panelDesde";
            this.panelDesde.Size = new System.Drawing.Size(193, 39);
            this.panelDesde.TabIndex = 10;
            this.panelDesde.Click += new System.EventHandler(this.ClickCalendar);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(158, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 25);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesde.Location = new System.Drawing.Point(15, 11);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(0, 18);
            this.lblFechaDesde.TabIndex = 0;
            // 
            // panelHasta
            // 
            this.panelHasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHasta.Controls.Add(this.pictureBox2);
            this.panelHasta.Controls.Add(this.lblFechaHasta);
            this.panelHasta.Location = new System.Drawing.Point(296, 219);
            this.panelHasta.Name = "panelHasta";
            this.panelHasta.Size = new System.Drawing.Size(193, 39);
            this.panelHasta.TabIndex = 11;
            this.panelHasta.Click += new System.EventHandler(this.ClickCalendar2);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(159, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 25);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHasta.Location = new System.Drawing.Point(14, 11);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(0, 18);
            this.lblFechaHasta.TabIndex = 1;
            // 
            // panelCalendarAusencias
            // 
            this.panelCalendarAusencias.Controls.Add(this.userControlAusencia1);
            this.panelCalendarAusencias.Location = new System.Drawing.Point(48, 264);
            this.panelCalendarAusencias.Name = "panelCalendarAusencias";
            this.panelCalendarAusencias.Size = new System.Drawing.Size(217, 212);
            this.panelCalendarAusencias.TabIndex = 12;
            this.panelCalendarAusencias.Visible = false;
            // 
            // userControlAusencia1
            // 
            this.userControlAusencia1.AñoSeleccionado = 2020;
            this.userControlAusencia1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlAusencia1.Location = new System.Drawing.Point(0, 0);
            this.userControlAusencia1.MesSeleccionado = 4;
            this.userControlAusencia1.Name = "userControlAusencia1";
            this.userControlAusencia1.Size = new System.Drawing.Size(217, 212);
            this.userControlAusencia1.TabIndex = 0;
            // 
            // panelCalendarAusencias2
            // 
            this.panelCalendarAusencias2.Controls.Add(this.userControlAusencia2);
            this.panelCalendarAusencias2.Location = new System.Drawing.Point(296, 264);
            this.panelCalendarAusencias2.Name = "panelCalendarAusencias2";
            this.panelCalendarAusencias2.Size = new System.Drawing.Size(217, 212);
            this.panelCalendarAusencias2.TabIndex = 13;
            this.panelCalendarAusencias2.Visible = false;
            // 
            // userControlAusencia2
            // 
            this.userControlAusencia2.AñoSeleccionado = 2020;
            this.userControlAusencia2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlAusencia2.Location = new System.Drawing.Point(0, 0);
            this.userControlAusencia2.MesSeleccionado = 4;
            this.userControlAusencia2.Name = "userControlAusencia2";
            this.userControlAusencia2.Size = new System.Drawing.Size(217, 212);
            this.userControlAusencia2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(48, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Nueva Solicitud";
            // 
            // lblIntervalo
            // 
            this.lblIntervalo.AutoSize = true;
            this.lblIntervalo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntervalo.ForeColor = System.Drawing.Color.Tomato;
            this.lblIntervalo.Location = new System.Drawing.Point(513, 231);
            this.lblIntervalo.Name = "lblIntervalo";
            this.lblIntervalo.Size = new System.Drawing.Size(0, 16);
            this.lblIntervalo.TabIndex = 15;
            // 
            // FormAusencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(610, 550);
            this.Controls.Add(this.lblIntervalo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panelCalendarAusencias2);
            this.Controls.Add(this.panelCalendarAusencias);
            this.Controls.Add(this.panelHasta);
            this.Controls.Add(this.panelDesde);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTipo);
            this.Name = "FormAusencias";
            this.Text = "FormAusencias";
            this.Load += new System.EventHandler(this.FormAusencias_Load);
            this.panelDesde.ResumeLayout(false);
            this.panelDesde.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelHasta.ResumeLayout(false);
            this.panelHasta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelCalendarAusencias.ResumeLayout(false);
            this.panelCalendarAusencias2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelDesde;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Panel panelHasta;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.Panel panelCalendarAusencias;
        private System.Windows.Forms.Panel panelCalendarAusencias2;
        private CustomControls.UserControlAusencia userControlAusencia1;
        private CustomControls.UserControlAusencia userControlAusencia2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblIntervalo;
    }
}