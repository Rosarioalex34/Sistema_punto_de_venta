namespace Copy_Express
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.registrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroCiudadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroProuctosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroMarcasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroCategoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasRealizadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasRealizadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteComprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarCesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSecionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.text_ced = new System.Windows.Forms.Label();
            this.textCed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textNomUser = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Highlight;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrosToolStripMenuItem,
            this.productosToolStripMenuItem,
            this.ventasToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.calendarioToolStripMenuItem,
            this.cerrarCesionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(775, 48);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // registrosToolStripMenuItem
            // 
            this.registrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.personalToolStripMenuItem,
            this.proveedoresToolStripMenuItem,
            this.registroCiudadesToolStripMenuItem});
            this.registrosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.registrosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("registrosToolStripMenuItem.Image")));
            this.registrosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.registrosToolStripMenuItem.Name = "registrosToolStripMenuItem";
            this.registrosToolStripMenuItem.Size = new System.Drawing.Size(81, 44);
            this.registrosToolStripMenuItem.Text = "Inicio";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clientesToolStripMenuItem.Image")));
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // personalToolStripMenuItem
            // 
            this.personalToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("personalToolStripMenuItem.Image")));
            this.personalToolStripMenuItem.Name = "personalToolStripMenuItem";
            this.personalToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.personalToolStripMenuItem.Text = "Seguridad";
            this.personalToolStripMenuItem.Click += new System.EventHandler(this.personalToolStripMenuItem_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("proveedoresToolStripMenuItem.Image")));
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
            // 
            // registroCiudadesToolStripMenuItem
            // 
            this.registroCiudadesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("registroCiudadesToolStripMenuItem.Image")));
            this.registroCiudadesToolStripMenuItem.Name = "registroCiudadesToolStripMenuItem";
            this.registroCiudadesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.registroCiudadesToolStripMenuItem.Text = "Registro Ciudades";
            this.registroCiudadesToolStripMenuItem.Click += new System.EventHandler(this.registroCiudadesToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroProuctosToolStripMenuItem,
            this.inventarioProductosToolStripMenuItem,
            this.registroMarcasToolStripMenuItem,
            this.registroCategoriasToolStripMenuItem});
            this.productosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.productosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("productosToolStripMenuItem.Image")));
            this.productosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(107, 44);
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // registroProuctosToolStripMenuItem
            // 
            this.registroProuctosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("registroProuctosToolStripMenuItem.Image")));
            this.registroProuctosToolStripMenuItem.Name = "registroProuctosToolStripMenuItem";
            this.registroProuctosToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.registroProuctosToolStripMenuItem.Text = "Registro Productos";
            this.registroProuctosToolStripMenuItem.Click += new System.EventHandler(this.registroProuctosToolStripMenuItem_Click);
            // 
            // inventarioProductosToolStripMenuItem
            // 
            this.inventarioProductosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("inventarioProductosToolStripMenuItem.Image")));
            this.inventarioProductosToolStripMenuItem.Name = "inventarioProductosToolStripMenuItem";
            this.inventarioProductosToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.inventarioProductosToolStripMenuItem.Text = "Inventario Productos";
            this.inventarioProductosToolStripMenuItem.Click += new System.EventHandler(this.inventarioProductosToolStripMenuItem_Click);
            // 
            // registroMarcasToolStripMenuItem
            // 
            this.registroMarcasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("registroMarcasToolStripMenuItem.Image")));
            this.registroMarcasToolStripMenuItem.Name = "registroMarcasToolStripMenuItem";
            this.registroMarcasToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.registroMarcasToolStripMenuItem.Text = "Registro Marcas";
            this.registroMarcasToolStripMenuItem.Click += new System.EventHandler(this.registroMarcasToolStripMenuItem_Click);
            // 
            // registroCategoriasToolStripMenuItem
            // 
            this.registroCategoriasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("registroCategoriasToolStripMenuItem.Image")));
            this.registroCategoriasToolStripMenuItem.Name = "registroCategoriasToolStripMenuItem";
            this.registroCategoriasToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.registroCategoriasToolStripMenuItem.Text = "Registro Categorias";
            this.registroCategoriasToolStripMenuItem.Click += new System.EventHandler(this.registroCategoriasToolStripMenuItem_Click);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasToolStripMenuItem1,
            this.comprasToolStripMenuItem,
            this.ventasRealizadasToolStripMenuItem,
            this.comprasRealizadasToolStripMenuItem});
            this.ventasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ventasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ventasToolStripMenuItem.Image")));
            this.ventasToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(88, 44);
            this.ventasToolStripMenuItem.Text = "Ventas";
            // 
            // ventasToolStripMenuItem1
            // 
            this.ventasToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ventasToolStripMenuItem1.Image")));
            this.ventasToolStripMenuItem1.Name = "ventasToolStripMenuItem1";
            this.ventasToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.ventasToolStripMenuItem1.Text = "Ventas";
            this.ventasToolStripMenuItem1.Click += new System.EventHandler(this.ventasToolStripMenuItem1_Click);
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("comprasToolStripMenuItem.Image")));
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.comprasToolStripMenuItem.Text = "Compras";
            this.comprasToolStripMenuItem.Click += new System.EventHandler(this.comprasToolStripMenuItem_Click);
            // 
            // ventasRealizadasToolStripMenuItem
            // 
            this.ventasRealizadasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ventasRealizadasToolStripMenuItem.Image")));
            this.ventasRealizadasToolStripMenuItem.Name = "ventasRealizadasToolStripMenuItem";
            this.ventasRealizadasToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.ventasRealizadasToolStripMenuItem.Text = "Ventas Realizadas";
            this.ventasRealizadasToolStripMenuItem.Click += new System.EventHandler(this.ventasRealizadasToolStripMenuItem_Click);
            // 
            // comprasRealizadasToolStripMenuItem
            // 
            this.comprasRealizadasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("comprasRealizadasToolStripMenuItem.Image")));
            this.comprasRealizadasToolStripMenuItem.Name = "comprasRealizadasToolStripMenuItem";
            this.comprasRealizadasToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.comprasRealizadasToolStripMenuItem.Text = "Compras Realizadas";
            this.comprasRealizadasToolStripMenuItem.Click += new System.EventHandler(this.comprasRealizadasToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportesVentasToolStripMenuItem,
            this.reporteComprasToolStripMenuItem,
            this.reporteDeClientesToolStripMenuItem});
            this.reportesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.reportesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportesToolStripMenuItem.Image")));
            this.reportesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(102, 44);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // reportesVentasToolStripMenuItem
            // 
            this.reportesVentasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportesVentasToolStripMenuItem.Image")));
            this.reportesVentasToolStripMenuItem.Name = "reportesVentasToolStripMenuItem";
            this.reportesVentasToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.reportesVentasToolStripMenuItem.Text = "Reportes Ventas";
            this.reportesVentasToolStripMenuItem.Click += new System.EventHandler(this.reportesVentasToolStripMenuItem_Click);
            // 
            // reporteComprasToolStripMenuItem
            // 
            this.reporteComprasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reporteComprasToolStripMenuItem.Image")));
            this.reporteComprasToolStripMenuItem.Name = "reporteComprasToolStripMenuItem";
            this.reporteComprasToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.reporteComprasToolStripMenuItem.Text = "Reporte Compras";
            this.reporteComprasToolStripMenuItem.Click += new System.EventHandler(this.reporteComprasToolStripMenuItem_Click);
            // 
            // reporteDeClientesToolStripMenuItem
            // 
            this.reporteDeClientesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reporteDeClientesToolStripMenuItem.Image")));
            this.reporteDeClientesToolStripMenuItem.Name = "reporteDeClientesToolStripMenuItem";
            this.reporteDeClientesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.reporteDeClientesToolStripMenuItem.Text = "Reporte de Clientes";
            this.reporteDeClientesToolStripMenuItem.Click += new System.EventHandler(this.reporteDeClientesToolStripMenuItem_Click);
            // 
            // calendarioToolStripMenuItem
            // 
            this.calendarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calendarioToolStripMenuItem1});
            this.calendarioToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.calendarioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("calendarioToolStripMenuItem.Image")));
            this.calendarioToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.calendarioToolStripMenuItem.Name = "calendarioToolStripMenuItem";
            this.calendarioToolStripMenuItem.Size = new System.Drawing.Size(109, 44);
            this.calendarioToolStripMenuItem.Text = "Calendario";
            // 
            // calendarioToolStripMenuItem1
            // 
            this.calendarioToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("calendarioToolStripMenuItem1.Image")));
            this.calendarioToolStripMenuItem1.Name = "calendarioToolStripMenuItem1";
            this.calendarioToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.calendarioToolStripMenuItem1.Text = "Calendario";
            this.calendarioToolStripMenuItem1.Click += new System.EventHandler(this.calendarioToolStripMenuItem1_Click);
            // 
            // cerrarCesionToolStripMenuItem
            // 
            this.cerrarCesionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSecionToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.cerrarCesionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cerrarCesionToolStripMenuItem.Image = global::Copy_Express.Properties.Resources.remove_24x24_32;
            this.cerrarCesionToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cerrarCesionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cerrarCesionToolStripMenuItem.Name = "cerrarCesionToolStripMenuItem";
            this.cerrarCesionToolStripMenuItem.Size = new System.Drawing.Size(117, 44);
            this.cerrarCesionToolStripMenuItem.Text = "Cerrar Sesión";
            // 
            // cerrarSecionToolStripMenuItem
            // 
            this.cerrarSecionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cerrarSecionToolStripMenuItem.Image")));
            this.cerrarSecionToolStripMenuItem.Name = "cerrarSecionToolStripMenuItem";
            this.cerrarSecionToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.cerrarSecionToolStripMenuItem.Text = "Iniciar nueva seción";
            this.cerrarSecionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSecionToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("salirToolStripMenuItem.Image")));
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // text_ced
            // 
            this.text_ced.AutoSize = true;
            this.text_ced.BackColor = System.Drawing.Color.White;
            this.text_ced.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_ced.ForeColor = System.Drawing.Color.Black;
            this.text_ced.Location = new System.Drawing.Point(289, 16);
            this.text_ced.Name = "text_ced";
            this.text_ced.Size = new System.Drawing.Size(25, 15);
            this.text_ced.TabIndex = 3;
            this.text_ced.Text = "ID:";
            // 
            // textCed
            // 
            this.textCed.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textCed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textCed.Enabled = false;
            this.textCed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCed.ForeColor = System.Drawing.Color.White;
            this.textCed.Location = new System.Drawing.Point(322, 17);
            this.textCed.Multiline = true;
            this.textCed.Name = "textCed";
            this.textCed.Size = new System.Drawing.Size(145, 16);
            this.textCed.TabIndex = 4;
            this.textCed.WordWrap = false;
            this.textCed.TextChanged += new System.EventHandler(this.textCed_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(-3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Usuario:";
            // 
            // textNomUser
            // 
            this.textNomUser.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textNomUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textNomUser.Enabled = false;
            this.textNomUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNomUser.ForeColor = System.Drawing.Color.Black;
            this.textNomUser.Location = new System.Drawing.Point(64, 16);
            this.textNomUser.Multiline = true;
            this.textNomUser.Name = "textNomUser";
            this.textNomUser.Size = new System.Drawing.Size(219, 15);
            this.textNomUser.TabIndex = 6;
            this.textNomUser.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Controls.Add(this.lblHora);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.textNomUser);
            this.panel1.Controls.Add(this.text_ced);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textCed);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 396);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(0, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(775, 381);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.White;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.Black;
            this.lblFecha.Location = new System.Drawing.Point(537, 16);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(51, 16);
            this.lblFecha.TabIndex = 15;
            this.lblFecha.Text = "Fecha";
            // 
            // lblHora
            // 
            this.lblHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHora.AutoSize = true;
            this.lblHora.BackColor = System.Drawing.Color.White;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.Color.Black;
            this.lblHora.Location = new System.Drawing.Point(473, 17);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(42, 16);
            this.lblHora.TabIndex = 14;
            this.lblHora.Text = "Hora";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(775, 444);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Menu Principal";
            this.TransparencyKey = System.Drawing.SystemColors.ControlLight;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem registrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroProuctosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calendarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem personalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroCiudadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventarioProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroMarcasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroCategoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteComprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasRealizadasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasRealizadasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calendarioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cerrarCesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSecionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        public System.Windows.Forms.Label text_ced;
        public System.Windows.Forms.TextBox textCed;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textNomUser;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label lblFecha;
        internal System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Timer timer1;
    }
}

