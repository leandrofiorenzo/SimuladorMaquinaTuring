namespace SimuladorMaquinaTuring
{
    partial class Simulador
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnCorrer = new System.Windows.Forms.Button();
            this.btnTesting = new System.Windows.Forms.Button();
            this.dgvTablaTransiciones = new System.Windows.Forms.DataGridView();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Leer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Escribir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoSiguiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnStep = new System.Windows.Forms.Button();
            this.btnDetener = new System.Windows.Forms.Button();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.cmbCargarPruebas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIntervalo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaTransiciones)).BeginInit();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(12, 21);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(535, 29);
            this.txtInput.TabIndex = 1;
            this.txtInput.Text = "00101110";
            this.txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCorrer
            // 
            this.btnCorrer.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCorrer.Location = new System.Drawing.Point(595, 23);
            this.btnCorrer.Name = "btnCorrer";
            this.btnCorrer.Size = new System.Drawing.Size(75, 25);
            this.btnCorrer.TabIndex = 2;
            this.btnCorrer.Text = "Correr";
            this.btnCorrer.UseVisualStyleBackColor = true;
            this.btnCorrer.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnTesting
            // 
            this.btnTesting.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTesting.Location = new System.Drawing.Point(423, 140);
            this.btnTesting.Name = "btnTesting";
            this.btnTesting.Size = new System.Drawing.Size(75, 25);
            this.btnTesting.TabIndex = 3;
            this.btnTesting.Text = "Testing";
            this.btnTesting.UseVisualStyleBackColor = true;
            // 
            // dgvTablaTransiciones
            // 
            this.dgvTablaTransiciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTablaTransiciones.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTablaTransiciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTablaTransiciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablaTransiciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Estado,
            this.Leer,
            this.Escribir,
            this.Direccion,
            this.EstadoSiguiente});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTablaTransiciones.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTablaTransiciones.Location = new System.Drawing.Point(12, 96);
            this.dgvTablaTransiciones.Name = "dgvTablaTransiciones";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTablaTransiciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTablaTransiciones.Size = new System.Drawing.Size(535, 256);
            this.dgvTablaTransiciones.TabIndex = 5;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.FillWeight = 57.17046F;
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            // 
            // Leer
            // 
            this.Leer.DataPropertyName = "Leer";
            this.Leer.FillWeight = 73.94442F;
            this.Leer.HeaderText = "Leer";
            this.Leer.Name = "Leer";
            // 
            // Escribir
            // 
            this.Escribir.DataPropertyName = "Escribir";
            this.Escribir.FillWeight = 95.07851F;
            this.Escribir.HeaderText = "Escribir";
            this.Escribir.Name = "Escribir";
            // 
            // Direccion
            // 
            this.Direccion.DataPropertyName = "DireccionChar";
            this.Direccion.FillWeight = 121.5224F;
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.Name = "Direccion";
            this.Direccion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // EstadoSiguiente
            // 
            this.EstadoSiguiente.DataPropertyName = "EstadoSiguiente";
            this.EstadoSiguiente.FillWeight = 152.2843F;
            this.EstadoSiguiente.HeaderText = "Estado Siguiente";
            this.EstadoSiguiente.Name = "EstadoSiguiente";
            // 
            // btnStep
            // 
            this.btnStep.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStep.Location = new System.Drawing.Point(676, 23);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(75, 25);
            this.btnStep.TabIndex = 6;
            this.btnStep.Text = "Siguiente";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // btnDetener
            // 
            this.btnDetener.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetener.Location = new System.Drawing.Point(878, 23);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(75, 25);
            this.btnDetener.TabIndex = 7;
            this.btnDetener.Text = "Detener";
            this.btnDetener.UseVisualStyleBackColor = true;
            // 
            // txtResultado
            // 
            this.txtResultado.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultado.Location = new System.Drawing.Point(595, 127);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(237, 29);
            this.txtResultado.TabIndex = 8;
            this.txtResultado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbCargarPruebas
            // 
            this.cmbCargarPruebas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCargarPruebas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCargarPruebas.FormattingEnabled = true;
            this.cmbCargarPruebas.Items.AddRange(new object[] {
            "w/ w contiene 101"});
            this.cmbCargarPruebas.Location = new System.Drawing.Point(595, 204);
            this.cmbCargarPruebas.Name = "cmbCargarPruebas";
            this.cmbCargarPruebas.Size = new System.Drawing.Size(237, 29);
            this.cmbCargarPruebas.TabIndex = 9;
            this.cmbCargarPruebas.SelectedIndexChanged += new System.EventHandler(this.cmbCargarPruebas_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(591, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "Output";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(591, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "Pruebas:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(634, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "segs.";
            // 
            // txtIntervalo
            // 
            this.txtIntervalo.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIntervalo.Location = new System.Drawing.Point(595, 55);
            this.txtIntervalo.MaxLength = 2;
            this.txtIntervalo.Name = "txtIntervalo";
            this.txtIntervalo.Size = new System.Drawing.Size(33, 29);
            this.txtIntervalo.TabIndex = 15;
            this.txtIntervalo.Text = "1";
            this.txtIntervalo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIntervalo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIntervalo_KeyPress);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(757, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 16;
            this.button1.Text = "Pausar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Simulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(1009, 391);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtIntervalo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCargarPruebas);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.dgvTablaTransiciones);
            this.Controls.Add(this.btnTesting);
            this.Controls.Add(this.btnCorrer);
            this.Controls.Add(this.txtInput);
            this.Name = "Simulador";
            this.Text = "Máquina de Turing - Simulador";
            this.Load += new System.EventHandler(this.Simulador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaTransiciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnCorrer;
        private System.Windows.Forms.Button btnTesting;
        private System.Windows.Forms.DataGridView dgvTablaTransiciones;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.ComboBox cmbCargarPruebas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Leer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Escribir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoSiguiente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIntervalo;
        private System.Windows.Forms.Button button1;
    }
}

