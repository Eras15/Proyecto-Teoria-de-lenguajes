namespace Proyecto_de_Clase
{
    partial class FormEditar
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
            this.dgvEditar = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEditar
            // 
            this.dgvEditar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEditar.Location = new System.Drawing.Point(12, 12);
            this.dgvEditar.Name = "dgvEditar";
            this.dgvEditar.Size = new System.Drawing.Size(776, 150);
            this.dgvEditar.TabIndex = 0;
            this.dgvEditar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEditar_CellContentClick);
            // 
            // FormEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 176);
            this.Controls.Add(this.dgvEditar);
            this.Name = "FormEditar";
            this.Text = "FormEditar";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEditar;
    }
}