namespace App_Almacen_Computadoras.Formularios
{
    partial class form_vnta
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
            this.tabla_vntas = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.texCedv = new System.Windows.Forms.TextBox();
            this.textnomCl_vnta = new System.Windows.Forms.TextBox();
            this.texttelf_vnta = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnBuscarCli = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textCodFac = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textsubtotal = new System.Windows.Forms.TextBox();
            this.textIva = new System.Windows.Forms.TextBox();
            this.textDescto = new System.Windows.Forms.TextBox();
            this.textTotal = new System.Windows.Forms.TextBox();
            this.textdir_vnta = new System.Windows.Forms.TextBox();
            this.textFecha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.GuardarVenta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboPago = new System.Windows.Forms.ComboBox();
            this.textCedEmpl = new System.Windows.Forms.TextBox();
            this.comboEmpleado = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_vntas)).BeginInit();
            this.SuspendLayout();
            // 
            // tabla_vntas
            // 
            this.tabla_vntas.AllowUserToAddRows = false;
            this.tabla_vntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_vntas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.tabla_vntas.Location = new System.Drawing.Point(12, 217);
            this.tabla_vntas.Name = "tabla_vntas";
            this.tabla_vntas.RowHeadersVisible = false;
            this.tabla_vntas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabla_vntas.Size = new System.Drawing.Size(626, 135);
            this.tabla_vntas.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Código";
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Cantidad";
            this.Column2.Name = "Column2";
            this.Column2.Width = 70;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Detalle";
            this.Column3.Name = "Column3";
            this.Column3.Width = 180;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Precio";
            this.Column4.Name = "Column4";
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Iva";
            this.Column5.Name = "Column5";
            this.Column5.Width = 80;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Desc";
            this.Column6.Name = "Column6";
            this.Column6.Width = 80;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Total";
            this.Column7.Name = "Column7";
            this.Column7.Width = 80;
            // 
            // texCedv
            // 
            this.texCedv.Location = new System.Drawing.Point(69, 45);
            this.texCedv.Name = "texCedv";
            this.texCedv.Size = new System.Drawing.Size(151, 20);
            this.texCedv.TabIndex = 1;
            this.texCedv.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textnomCl_vnta
            // 
            this.textnomCl_vnta.Location = new System.Drawing.Point(69, 79);
            this.textnomCl_vnta.Name = "textnomCl_vnta";
            this.textnomCl_vnta.Size = new System.Drawing.Size(516, 20);
            this.textnomCl_vnta.TabIndex = 2;
            // 
            // texttelf_vnta
            // 
            this.texttelf_vnta.Location = new System.Drawing.Point(69, 113);
            this.texttelf_vnta.Name = "texttelf_vnta";
            this.texttelf_vnta.Size = new System.Drawing.Size(111, 20);
            this.texttelf_vnta.TabIndex = 3;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(482, 188);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBuscarCli
            // 
            this.btnBuscarCli.Location = new System.Drawing.Point(236, 43);
            this.btnBuscarCli.Name = "btnBuscarCli";
            this.btnBuscarCli.Size = new System.Drawing.Size(64, 23);
            this.btnBuscarCli.TabIndex = 5;
            this.btnBuscarCli.Text = "---";
            this.btnBuscarCli.UseVisualStyleBackColor = true;
            this.btnBuscarCli.Click += new System.EventHandler(this.btnBuscarCli_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Número:";
            // 
            // textCodFac
            // 
            this.textCodFac.Location = new System.Drawing.Point(318, 9);
            this.textCodFac.Name = "textCodFac";
            this.textCodFac.Size = new System.Drawing.Size(100, 20);
            this.textCodFac.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(563, 188);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Quitar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textsubtotal
            // 
            this.textsubtotal.Location = new System.Drawing.Point(538, 369);
            this.textsubtotal.Name = "textsubtotal";
            this.textsubtotal.Size = new System.Drawing.Size(100, 20);
            this.textsubtotal.TabIndex = 10;
            // 
            // textIva
            // 
            this.textIva.Location = new System.Drawing.Point(538, 395);
            this.textIva.Name = "textIva";
            this.textIva.Size = new System.Drawing.Size(100, 20);
            this.textIva.TabIndex = 11;
            // 
            // textDescto
            // 
            this.textDescto.Location = new System.Drawing.Point(538, 421);
            this.textDescto.Name = "textDescto";
            this.textDescto.Size = new System.Drawing.Size(100, 20);
            this.textDescto.TabIndex = 12;
            // 
            // textTotal
            // 
            this.textTotal.Location = new System.Drawing.Point(539, 450);
            this.textTotal.Name = "textTotal";
            this.textTotal.Size = new System.Drawing.Size(99, 20);
            this.textTotal.TabIndex = 13;
            // 
            // textdir_vnta
            // 
            this.textdir_vnta.Location = new System.Drawing.Point(251, 113);
            this.textdir_vnta.Name = "textdir_vnta";
            this.textdir_vnta.Size = new System.Drawing.Size(334, 20);
            this.textdir_vnta.TabIndex = 14;
            // 
            // textFecha
            // 
            this.textFecha.Location = new System.Drawing.Point(485, 9);
            this.textFecha.Name = "textFecha";
            this.textFecha.Size = new System.Drawing.Size(100, 20);
            this.textFecha.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(434, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Fecha:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Cliente:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Cedula:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(186, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Dirección:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Teléfono:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(93, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 21;
            this.button4.Text = "Registrar";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 22;
            this.button5.Text = "Nuevo";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // GuardarVenta
            // 
            this.GuardarVenta.Location = new System.Drawing.Point(137, 412);
            this.GuardarVenta.Name = "GuardarVenta";
            this.GuardarVenta.Size = new System.Drawing.Size(124, 36);
            this.GuardarVenta.TabIndex = 23;
            this.GuardarVenta.Text = "Realizar venta";
            this.GuardarVenta.UseVisualStyleBackColor = true;
            this.GuardarVenta.Click += new System.EventHandler(this.button6_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(472, 372);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Subtotal";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(472, 398);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Iva:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(472, 424);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Descuento:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(472, 453);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Total:";
            // 
            // comboPago
            // 
            this.comboPago.FormattingEnabled = true;
            this.comboPago.Items.AddRange(new object[] {
            "Contado",
            "Credito"});
            this.comboPago.Location = new System.Drawing.Point(105, 358);
            this.comboPago.Name = "comboPago";
            this.comboPago.Size = new System.Drawing.Size(156, 21);
            this.comboPago.TabIndex = 28;
            // 
            // textCedEmpl
            // 
            this.textCedEmpl.Location = new System.Drawing.Point(137, 468);
            this.textCedEmpl.Name = "textCedEmpl";
            this.textCedEmpl.Size = new System.Drawing.Size(106, 20);
            this.textCedEmpl.TabIndex = 29;
            // 
            // comboEmpleado
            // 
            this.comboEmpleado.FormattingEnabled = true;
            this.comboEmpleado.Location = new System.Drawing.Point(69, 147);
            this.comboEmpleado.Name = "comboEmpleado";
            this.comboEmpleado.Size = new System.Drawing.Size(516, 21);
            this.comboEmpleado.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Vendedor:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 358);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Tipo de Pago:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "Calcular";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // form_vnta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 492);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboEmpleado);
            this.Controls.Add(this.textCedEmpl);
            this.Controls.Add(this.comboPago);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GuardarVenta);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textFecha);
            this.Controls.Add(this.textdir_vnta);
            this.Controls.Add(this.textTotal);
            this.Controls.Add(this.textDescto);
            this.Controls.Add(this.textIva);
            this.Controls.Add(this.textsubtotal);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textCodFac);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBuscarCli);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.texttelf_vnta);
            this.Controls.Add(this.textnomCl_vnta);
            this.Controls.Add(this.texCedv);
            this.Controls.Add(this.tabla_vntas);
            this.Name = "form_vnta";
            this.Text = "Factura de Venta";
            this.Load += new System.EventHandler(this.form_vnta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabla_vntas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tabla_vntas;
        private System.Windows.Forms.TextBox texCedv;
        private System.Windows.Forms.TextBox textnomCl_vnta;
        private System.Windows.Forms.TextBox texttelf_vnta;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnBuscarCli;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textCodFac;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textsubtotal;
        private System.Windows.Forms.TextBox textIva;
        private System.Windows.Forms.TextBox textDescto;
        private System.Windows.Forms.TextBox textTotal;
        private System.Windows.Forms.TextBox textdir_vnta;
        private System.Windows.Forms.TextBox textFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button GuardarVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboPago;
        private System.Windows.Forms.TextBox textCedEmpl;
        private System.Windows.Forms.ComboBox comboEmpleado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}