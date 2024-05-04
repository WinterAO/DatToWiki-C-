namespace DatToWiki {
    partial class frmMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btnConvertir = new Button();
            txtResultado = new TextBox();
            groupBox1 = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton5 = new RadioButton();
            radioButton6 = new RadioButton();
            txtRutaDats = new TextBox();
            btnBuscar = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnConvertir
            // 
            btnConvertir.Location = new Point(275, 498);
            btnConvertir.Name = "btnConvertir";
            btnConvertir.Size = new Size(219, 32);
            btnConvertir.TabIndex = 0;
            btnConvertir.Text = "Convertir";
            btnConvertir.UseVisualStyleBackColor = true;
            btnConvertir.Click += button1_Click;
            // 
            // txtResultado
            // 
            txtResultado.Location = new Point(12, 12);
            txtResultado.Multiline = true;
            txtResultado.Name = "txtResultado";
            txtResultado.Size = new Size(776, 387);
            txtResultado.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton4);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton5);
            groupBox1.Controls.Add(radioButton6);
            groupBox1.Location = new Point(12, 438);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 54);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tipo de datos a convertir";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(382, 22);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(100, 19);
            radioButton3.TabIndex = 5;
            radioButton3.Text = "Npc's Hostiles";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(303, 22);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(73, 19);
            radioButton4.TabIndex = 4;
            radioButton4.Text = "Hechizos";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(246, 22);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(59, 19);
            radioButton1.TabIndex = 3;
            radioButton1.Text = "Armas";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(178, 22);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(68, 19);
            radioButton2.TabIndex = 2;
            radioButton2.Text = "Escudos";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(89, 22);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(83, 19);
            radioButton5.TabIndex = 1;
            radioButton5.Text = "Armaduras";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Checked = true;
            radioButton6.Location = new Point(21, 22);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(62, 19);
            radioButton6.TabIndex = 0;
            radioButton6.TabStop = true;
            radioButton6.Text = "Cascos";
            radioButton6.UseVisualStyleBackColor = true;
            // 
            // txtRutaDats
            // 
            txtRutaDats.Location = new Point(12, 405);
            txtRutaDats.Multiline = true;
            txtRutaDats.Name = "txtRutaDats";
            txtRutaDats.Size = new Size(626, 27);
            txtRutaDats.TabIndex = 3;
            txtRutaDats.TextChanged += txtRutaDats_TextChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(644, 409);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(144, 23);
            btnBuscar.TabIndex = 0;
            btnBuscar.Text = "Buscar dats";
            btnBuscar.Click += btnBuscar_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 536);
            Controls.Add(btnBuscar);
            Controls.Add(txtRutaDats);
            Controls.Add(groupBox1);
            Controls.Add(txtResultado);
            Controls.Add(btnConvertir);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMain";
            Text = "DatToWiki";
            Load += frmMain_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConvertir;
        private TextBox txtResultado;
        private GroupBox groupBox1;
        private RadioButton radioButton5;
        private RadioButton radioButton6;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private TextBox txtRutaDats;
        private Button btnBuscar;
    }
}