namespace FabricaDeSoftware.App
{
    partial class ListaCalculos
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
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridCalculos = new System.Windows.Forms.DataGridView();
            this.txtDistanciaDaReta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewFilaCalculo = new System.Windows.Forms.DataGridView();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.btnAtualizarConsultas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCalculos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilaCalculo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridCalculos
            // 
            this.dataGridCalculos.AllowUserToAddRows = false;
            this.dataGridCalculos.AllowUserToDeleteRows = false;
            this.dataGridCalculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCalculos.Location = new System.Drawing.Point(12, 39);
            this.dataGridCalculos.Name = "dataGridCalculos";
            this.dataGridCalculos.ReadOnly = true;
            this.dataGridCalculos.Size = new System.Drawing.Size(1189, 222);
            this.dataGridCalculos.TabIndex = 0;
            this.dataGridCalculos.Text = "dataGridView1";
            // 
            // txtDistanciaDaReta
            // 
            this.txtDistanciaDaReta.Location = new System.Drawing.Point(12, 319);
            this.txtDistanciaDaReta.Name = "txtDistanciaDaReta";
            this.txtDistanciaDaReta.Size = new System.Drawing.Size(155, 23);
            this.txtDistanciaDaReta.TabIndex = 1;
            this.txtDistanciaDaReta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDistanciaDaReta_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Escolha a distância da reta";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(12, 348);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 3;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lista de Cálculos realizados";
            // 
            // dataGridViewFilaCalculo
            // 
            this.dataGridViewFilaCalculo.AllowUserToAddRows = false;
            this.dataGridViewFilaCalculo.AllowUserToDeleteRows = false;
            this.dataGridViewFilaCalculo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFilaCalculo.Location = new System.Drawing.Point(12, 423);
            this.dataGridViewFilaCalculo.Name = "dataGridViewFilaCalculo";
            this.dataGridViewFilaCalculo.ReadOnly = true;
            this.dataGridViewFilaCalculo.Size = new System.Drawing.Size(1189, 222);
            this.dataGridViewFilaCalculo.TabIndex = 0;
            this.dataGridViewFilaCalculo.Text = "dataGridView1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cálculos aguardando processamento";
            // 
            // btnAtualizarConsultas
            // 
            this.btnAtualizarConsultas.Location = new System.Drawing.Point(1052, 319);
            this.btnAtualizarConsultas.Name = "btnAtualizarConsultas";
            this.btnAtualizarConsultas.Size = new System.Drawing.Size(149, 43);
            this.btnAtualizarConsultas.TabIndex = 5;
            this.btnAtualizarConsultas.Text = "Atualizar Consultas";
            this.btnAtualizarConsultas.UseVisualStyleBackColor = true;
            this.btnAtualizarConsultas.Click += new System.EventHandler(this.btnAtualizarConsultas_Click);
            // 
            // ListaCalculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 666);
            this.Controls.Add(this.btnAtualizarConsultas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewFilaCalculo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDistanciaDaReta);
            this.Controls.Add(this.dataGridCalculos);
            this.Name = "ListaCalculos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calcular";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ListaCalculos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCalculos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilaCalculo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewFilaCalculo;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dataGridCalculos;
        private System.Windows.Forms.TextBox txtDistanciaDaReta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAtualizarConsultas;
    }
}