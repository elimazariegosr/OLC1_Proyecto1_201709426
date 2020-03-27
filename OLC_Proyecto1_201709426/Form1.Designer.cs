namespace OLC_Proyecto1_201709426
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_agregar = new System.Windows.Forms.Button();
            this.tb_principal = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaVentanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarThompsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarTokensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarErroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorLexicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_analizar = new System.Windows.Forms.Button();
            this.txt_salida = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.com_afds = new System.Windows.Forms.ComboBox();
            this.com_tb = new System.Windows.Forms.ComboBox();
            this.com_afns = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pcb_imagen = new System.Windows.Forms.PictureBox();
            this.btn_validar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_imagen)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_agregar
            // 
            this.btn_agregar.Location = new System.Drawing.Point(12, 37);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(24, 23);
            this.btn_agregar.TabIndex = 0;
            this.btn_agregar.Text = "+";
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_principal
            // 
            this.tb_principal.Location = new System.Drawing.Point(12, 76);
            this.tb_principal.Name = "tb_principal";
            this.tb_principal.SelectedIndex = 0;
            this.tb_principal.Size = new System.Drawing.Size(415, 334);
            this.tb_principal.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1176, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.nuevaVentanaToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // nuevaVentanaToolStripMenuItem
            // 
            this.nuevaVentanaToolStripMenuItem.Name = "nuevaVentanaToolStripMenuItem";
            this.nuevaVentanaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nuevaVentanaToolStripMenuItem.Text = "Nueva Ventana";
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarThompsonToolStripMenuItem,
            this.guardarTokensToolStripMenuItem,
            this.guardarErroresToolStripMenuItem});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // cargarThompsonToolStripMenuItem
            // 
            this.cargarThompsonToolStripMenuItem.Name = "cargarThompsonToolStripMenuItem";
            this.cargarThompsonToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cargarThompsonToolStripMenuItem.Text = "Cargar Thompson";
            // 
            // guardarTokensToolStripMenuItem
            // 
            this.guardarTokensToolStripMenuItem.Name = "guardarTokensToolStripMenuItem";
            this.guardarTokensToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.guardarTokensToolStripMenuItem.Text = "Guardar Tokens";
            // 
            // guardarErroresToolStripMenuItem
            // 
            this.guardarErroresToolStripMenuItem.Name = "guardarErroresToolStripMenuItem";
            this.guardarErroresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.guardarErroresToolStripMenuItem.Text = "Guardar Errores";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.errorLexicoToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // errorLexicoToolStripMenuItem
            // 
            this.errorLexicoToolStripMenuItem.Name = "errorLexicoToolStripMenuItem";
            this.errorLexicoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.errorLexicoToolStripMenuItem.Text = "Analisis Lexico";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_analizar
            // 
            this.btn_analizar.Location = new System.Drawing.Point(352, 37);
            this.btn_analizar.Name = "btn_analizar";
            this.btn_analizar.Size = new System.Drawing.Size(75, 23);
            this.btn_analizar.TabIndex = 3;
            this.btn_analizar.Text = "Analizar";
            this.btn_analizar.UseVisualStyleBackColor = true;
            this.btn_analizar.Click += new System.EventHandler(this.btn_analizar_Click);
            // 
            // txt_salida
            // 
            this.txt_salida.BackColor = System.Drawing.SystemColors.InfoText;
            this.txt_salida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_salida.ForeColor = System.Drawing.Color.Goldenrod;
            this.txt_salida.Location = new System.Drawing.Point(12, 460);
            this.txt_salida.Name = "txt_salida";
            this.txt_salida.Size = new System.Drawing.Size(415, 115);
            this.txt_salida.TabIndex = 6;
            this.txt_salida.Text = "";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.com_afds);
            this.panel1.Controls.Add(this.com_tb);
            this.panel1.Controls.Add(this.com_afns);
            this.panel1.Location = new System.Drawing.Point(448, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 499);
            this.panel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "AFDs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tabla";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "AFNs";
            // 
            // com_afds
            // 
            this.com_afds.FormattingEnabled = true;
            this.com_afds.Items.AddRange(new object[] {
            "AFDs"});
            this.com_afds.Location = new System.Drawing.Point(17, 238);
            this.com_afds.Name = "com_afds";
            this.com_afds.Size = new System.Drawing.Size(121, 21);
            this.com_afds.TabIndex = 2;
            this.com_afds.SelectedIndexChanged += new System.EventHandler(this.com_afds_SelectedIndexChanged);
            // 
            // com_tb
            // 
            this.com_tb.FormattingEnabled = true;
            this.com_tb.Items.AddRange(new object[] {
            "Tabla"});
            this.com_tb.Location = new System.Drawing.Point(17, 128);
            this.com_tb.Name = "com_tb";
            this.com_tb.Size = new System.Drawing.Size(121, 21);
            this.com_tb.TabIndex = 1;
            this.com_tb.SelectedIndexChanged += new System.EventHandler(this.com_tb_SelectedIndexChanged);
            // 
            // com_afns
            // 
            this.com_afns.FormattingEnabled = true;
            this.com_afns.Items.AddRange(new object[] {
            "AFNs"});
            this.com_afns.Location = new System.Drawing.Point(17, 27);
            this.com_afns.Name = "com_afns";
            this.com_afns.Size = new System.Drawing.Size(121, 21);
            this.com_afns.TabIndex = 0;
            this.com_afns.SelectedIndexChanged += new System.EventHandler(this.com_afns_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.pcb_imagen);
            this.panel2.Location = new System.Drawing.Point(646, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(498, 504);
            this.panel2.TabIndex = 8;
            // 
            // pcb_imagen
            // 
            this.pcb_imagen.Location = new System.Drawing.Point(3, 3);
            this.pcb_imagen.Name = "pcb_imagen";
            this.pcb_imagen.Size = new System.Drawing.Size(300, 300);
            this.pcb_imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pcb_imagen.TabIndex = 0;
            this.pcb_imagen.TabStop = false;
            // 
            // btn_validar
            // 
            this.btn_validar.Location = new System.Drawing.Point(325, 431);
            this.btn_validar.Name = "btn_validar";
            this.btn_validar.Size = new System.Drawing.Size(102, 23);
            this.btn_validar.TabIndex = 9;
            this.btn_validar.Text = "Validar Lexemas";
            this.btn_validar.UseVisualStyleBackColor = true;
            this.btn_validar.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 441);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Resultado";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "|.er";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1176, 605);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_validar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_salida);
            this.Controls.Add(this.btn_analizar);
            this.Controls.Add(this.tb_principal);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_imagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.TabControl tb_principal;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaVentanaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarThompsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarTokensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarErroresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorLexicoToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_analizar;
        private System.Windows.Forms.RichTextBox txt_salida;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox com_afds;
        private System.Windows.Forms.ComboBox com_tb;
        private System.Windows.Forms.ComboBox com_afns;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pcb_imagen;
        private System.Windows.Forms.Button btn_validar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

