namespace DeteccionRostros
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCUI = new System.Windows.Forms.NumericUpDown();
            this.lblCUI = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.lblNombres = new System.Windows.Forms.Label();
            this.imgBoxEstudianteNuevo = new Emgu.CV.UI.ImageBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPresentesEscene = new System.Windows.Forms.Label();
            this.lblRostrosDetectados = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTomarLista = new System.Windows.Forms.Button();
            this.imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvEstudiantes = new System.Windows.Forms.ListView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSeguridad = new System.Windows.Forms.TabPage();
            this.btnInitSecurity = new System.Windows.Forms.Button();
            this.gbGSM = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.lblCOM = new System.Windows.Forms.Label();
            this.cbModems = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.imgBoxFrameGrabberSecurity = new Emgu.CV.UI.ImageBox();
            this.tabLista = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnExport2Excel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCUI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxEstudianteNuevo)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabSeguridad.SuspendLayout();
            this.gbGSM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxFrameGrabberSecurity)).BeginInit();
            this.tabLista.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGuardar.Location = new System.Drawing.Point(88, 249);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(87, 31);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar Rostro";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(88, 147);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(107, 20);
            this.txtNombres.TabIndex = 7;
            this.txtNombres.Text = "Jair Francesco";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCUI);
            this.groupBox1.Controls.Add(this.lblCUI);
            this.groupBox1.Controls.Add(this.txtApellidos);
            this.groupBox1.Controls.Add(this.lblApellidos);
            this.groupBox1.Controls.Add(this.lblNombres);
            this.groupBox1.Controls.Add(this.txtNombres);
            this.groupBox1.Controls.Add(this.imgBoxEstudianteNuevo);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Location = new System.Drawing.Point(446, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 287);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Guardar Estudiantes";
            // 
            // txtCUI
            // 
            this.txtCUI.Location = new System.Drawing.Point(88, 211);
            this.txtCUI.Maximum = new decimal(new int[] {
            20172567,
            0,
            0,
            0});
            this.txtCUI.Name = "txtCUI";
            this.txtCUI.Size = new System.Drawing.Size(107, 20);
            this.txtCUI.TabIndex = 13;
            this.txtCUI.Value = new decimal(new int[] {
            20152567,
            0,
            0,
            0});
            // 
            // lblCUI
            // 
            this.lblCUI.AutoSize = true;
            this.lblCUI.Location = new System.Drawing.Point(32, 213);
            this.lblCUI.Name = "lblCUI";
            this.lblCUI.Size = new System.Drawing.Size(25, 13);
            this.lblCUI.TabIndex = 11;
            this.lblCUI.Text = "CUI";
            this.lblCUI.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(88, 177);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(107, 20);
            this.txtApellidos.TabIndex = 10;
            this.txtApellidos.Text = "Huaman Canqui";
            // 
            // lblApellidos
            // 
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Location = new System.Drawing.Point(32, 180);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(49, 13);
            this.lblApellidos.TabIndex = 9;
            this.lblApellidos.Text = "Apellidos";
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Location = new System.Drawing.Point(32, 154);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(49, 13);
            this.lblNombres.TabIndex = 8;
            this.lblNombres.Text = "Nombres";
            // 
            // imgBoxEstudianteNuevo
            // 
            this.imgBoxEstudianteNuevo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgBoxEstudianteNuevo.Location = new System.Drawing.Point(14, 19);
            this.imgBoxEstudianteNuevo.Name = "imgBoxEstudianteNuevo";
            this.imgBoxEstudianteNuevo.Size = new System.Drawing.Size(200, 121);
            this.imgBoxEstudianteNuevo.TabIndex = 5;
            this.imgBoxEstudianteNuevo.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblPresentesEscene);
            this.groupBox2.Controls.Add(this.lblRostrosDetectados);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(940, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(25, 242);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(9, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Persons present in the scene:";
            // 
            // lblPresentesEscene
            // 
            this.lblPresentesEscene.AutoSize = true;
            this.lblPresentesEscene.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresentesEscene.ForeColor = System.Drawing.Color.Blue;
            this.lblPresentesEscene.Location = new System.Drawing.Point(9, 53);
            this.lblPresentesEscene.Name = "lblPresentesEscene";
            this.lblPresentesEscene.Size = new System.Drawing.Size(61, 19);
            this.lblPresentesEscene.TabIndex = 16;
            this.lblPresentesEscene.Text = "Nobody";
            // 
            // lblRostrosDetectados
            // 
            this.lblRostrosDetectados.AutoSize = true;
            this.lblRostrosDetectados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRostrosDetectados.ForeColor = System.Drawing.Color.Red;
            this.lblRostrosDetectados.Location = new System.Drawing.Point(163, 124);
            this.lblRostrosDetectados.Name = "lblRostrosDetectados";
            this.lblRostrosDetectados.Size = new System.Drawing.Size(16, 16);
            this.lblRostrosDetectados.TabIndex = 15;
            this.lblRostrosDetectados.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Number of faces detected: ";
            // 
            // btnTomarLista
            // 
            this.btnTomarLista.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnTomarLista.Location = new System.Drawing.Point(149, 256);
            this.btnTomarLista.Name = "btnTomarLista";
            this.btnTomarLista.Size = new System.Drawing.Size(175, 37);
            this.btnTomarLista.TabIndex = 2;
            this.btnTomarLista.Text = "Activar reconocimiento y Tomar Lista";
            this.btnTomarLista.UseVisualStyleBackColor = true;
            this.btnTomarLista.Click += new System.EventHandler(this.btnTomarLista_Click);
            // 
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxFrameGrabber.Location = new System.Drawing.Point(6, 6);
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.Size = new System.Drawing.Size(388, 242);
            this.imageBoxFrameGrabber.TabIndex = 4;
            this.imageBoxFrameGrabber.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnExport2Excel);
            this.groupBox3.Controls.Add(this.lvEstudiantes);
            this.groupBox3.Location = new System.Drawing.Point(7, 309);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(707, 253);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lista de Asistentes";
            // 
            // lvEstudiantes
            // 
            this.lvEstudiantes.Location = new System.Drawing.Point(7, 20);
            this.lvEstudiantes.Name = "lvEstudiantes";
            this.lvEstudiantes.Size = new System.Drawing.Size(694, 188);
            this.lvEstudiantes.TabIndex = 0;
            this.lvEstudiantes.UseCompatibleStateImageBehavior = false;
            this.lvEstudiantes.View = System.Windows.Forms.View.Details;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSeguridad);
            this.tabControl1.Controls.Add(this.tabLista);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(728, 595);
            this.tabControl1.TabIndex = 11;
            // 
            // tabSeguridad
            // 
            this.tabSeguridad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabSeguridad.Controls.Add(this.btnInitSecurity);
            this.tabSeguridad.Controls.Add(this.gbGSM);
            this.tabSeguridad.Controls.Add(this.imgBoxFrameGrabberSecurity);
            this.tabSeguridad.Location = new System.Drawing.Point(4, 22);
            this.tabSeguridad.Name = "tabSeguridad";
            this.tabSeguridad.Padding = new System.Windows.Forms.Padding(3);
            this.tabSeguridad.Size = new System.Drawing.Size(720, 569);
            this.tabSeguridad.TabIndex = 1;
            this.tabSeguridad.Text = "Seguridad Con Notificación";
            // 
            // btnInitSecurity
            // 
            this.btnInitSecurity.Location = new System.Drawing.Point(122, 255);
            this.btnInitSecurity.Name = "btnInitSecurity";
            this.btnInitSecurity.Size = new System.Drawing.Size(189, 23);
            this.btnInitSecurity.TabIndex = 10;
            this.btnInitSecurity.Text = "Iniciar Sistema de Seguridad";
            this.btnInitSecurity.UseVisualStyleBackColor = true;
            this.btnInitSecurity.Click += new System.EventHandler(this.btnInitSecurity_Click);
            // 
            // gbGSM
            // 
            this.gbGSM.Controls.Add(this.label1);
            this.gbGSM.Controls.Add(this.txtMensaje);
            this.gbGSM.Controls.Add(this.lblCOM);
            this.gbGSM.Controls.Add(this.cbModems);
            this.gbGSM.Controls.Add(this.label4);
            this.gbGSM.Controls.Add(this.txtCelular);
            this.gbGSM.Location = new System.Drawing.Point(400, 6);
            this.gbGSM.Name = "gbGSM";
            this.gbGSM.Size = new System.Drawing.Size(314, 242);
            this.gbGSM.TabIndex = 9;
            this.gbGSM.TabStop = false;
            this.gbGSM.Text = "Configuración GSM";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 26);
            this.label1.TabIndex = 17;
            this.label1.Text = "Mensaje Personalizado";
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(88, 74);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(220, 139);
            this.txtMensaje.TabIndex = 16;
            this.txtMensaje.Text = "Cuidado, Hay alguien en la puerta de tu casa, mensaje enviado desde sistema de se" +
    "guridad.";
            // 
            // lblCOM
            // 
            this.lblCOM.AutoSize = true;
            this.lblCOM.Location = new System.Drawing.Point(6, 25);
            this.lblCOM.Name = "lblCOM";
            this.lblCOM.Size = new System.Drawing.Size(34, 13);
            this.lblCOM.TabIndex = 15;
            this.lblCOM.Text = "COM:";
            // 
            // cbModems
            // 
            this.cbModems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModems.FormattingEnabled = true;
            this.cbModems.Location = new System.Drawing.Point(88, 20);
            this.cbModems.Name = "cbModems";
            this.cbModems.Size = new System.Drawing.Size(220, 21);
            this.cbModems.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Celular:";
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(88, 47);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(220, 20);
            this.txtCelular.TabIndex = 7;
            this.txtCelular.Text = "959003224";
            // 
            // imgBoxFrameGrabberSecurity
            // 
            this.imgBoxFrameGrabberSecurity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgBoxFrameGrabberSecurity.Location = new System.Drawing.Point(6, 6);
            this.imgBoxFrameGrabberSecurity.Name = "imgBoxFrameGrabberSecurity";
            this.imgBoxFrameGrabberSecurity.Size = new System.Drawing.Size(388, 242);
            this.imgBoxFrameGrabberSecurity.TabIndex = 5;
            this.imgBoxFrameGrabberSecurity.TabStop = false;
            // 
            // tabLista
            // 
            this.tabLista.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabLista.Controls.Add(this.imageBoxFrameGrabber);
            this.tabLista.Controls.Add(this.groupBox3);
            this.tabLista.Controls.Add(this.groupBox1);
            this.tabLista.Controls.Add(this.btnTomarLista);
            this.tabLista.Location = new System.Drawing.Point(4, 22);
            this.tabLista.Name = "tabLista";
            this.tabLista.Padding = new System.Windows.Forms.Padding(3);
            this.tabLista.Size = new System.Drawing.Size(720, 569);
            this.tabLista.TabIndex = 0;
            this.tabLista.Text = "Tomar Lista";
            // 
            // btnExport2Excel
            // 
            this.btnExport2Excel.Location = new System.Drawing.Point(576, 214);
            this.btnExport2Excel.Name = "btnExport2Excel";
            this.btnExport2Excel.Size = new System.Drawing.Size(125, 23);
            this.btnExport2Excel.TabIndex = 1;
            this.btnExport2Excel.Text = "Exportar a Excel";
            this.btnExport2Excel.UseVisualStyleBackColor = true;
            this.btnExport2Excel.Click += new System.EventHandler(this.btnExport2Excel_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 613);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detección de Rostros aplicado a un sistema de seguridad y toma de Asistencia";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCUI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxEstudianteNuevo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabSeguridad.ResumeLayout(false);
            this.gbGSM.ResumeLayout(false);
            this.gbGSM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxFrameGrabberSecurity)).EndInit();
            this.tabLista.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
        private Emgu.CV.UI.ImageBox imgBoxEstudianteNuevo;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPresentesEscene;
        private System.Windows.Forms.Label lblRostrosDetectados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTomarLista;
        private System.Windows.Forms.Label lblCUI;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lvEstudiantes;
        private System.Windows.Forms.NumericUpDown txtCUI;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLista;
        private System.Windows.Forms.TabPage tabSeguridad;
        private System.Windows.Forms.GroupBox gbGSM;
        private System.Windows.Forms.Label lblCOM;
        private System.Windows.Forms.ComboBox cbModems;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCelular;
        private Emgu.CV.UI.ImageBox imgBoxFrameGrabberSecurity;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInitSecurity;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnExport2Excel;
    }
}

