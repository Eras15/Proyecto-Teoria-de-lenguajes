using Proyecto_de_Clase.Metodos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_de_Clase {
    public partial class Form1 : Form
    {
        private Administrar gestor = new Administrar();

        public Form1()
        {
            InitializeComponent();
            CargarTareas();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string descripcion = txtDescripcion.Text.Trim();
            DateTime fecha = dtpFechaLimite.Value;

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Por favor escribe una descripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            gestor.AgregarTarea(descripcion, fecha);
            MessageBox.Show("Tarea guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtDescripcion.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FormEditar ventanaEditar = new FormEditar();
            ventanaEditar.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FormEliminar ventanaEliminar = new FormEliminar();
            ventanaEliminar.ShowDialog();
        }

        private void CargarTareas()
        {
            dgbnoti.DataSource = gestor.ObtenerTareas();
            dgbnoti.Columns["Id"].Visible = false;
        }

        private void dgbnoti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgbnoti_Click(object sender, EventArgs e)
        {
            CargarTareas();
        }
    }
}
    
