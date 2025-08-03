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
using Proyecto_de_Clase.Modelos;

namespace Proyecto_de_Clase
{
    public partial class FormEliminar : Form
    {
        private Administrar gestor = new Administrar();

        public FormEliminar()
        {
            InitializeComponent();
            CargarTareas();
        }

        private void CargarTareas()
        {
            dgvEliminar.DataSource = gestor.ObtenerTareas();
            dgvEliminar.Columns["Id"].Visible = false;

            if (!dgvEliminar.Columns.Contains("btnEliminar"))
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.HeaderText = "Acciones";
                btnEliminar.Text = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                btnEliminar.Name = "btnEliminar";
                dgvEliminar.Columns.Add(btnEliminar);
            }
        }

        private void dgvEliminar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvEliminar.Columns["btnEliminar"].Index && e.RowIndex >= 0)
            {
                Tareas tarea = (Tareas)dgvEliminar.Rows[e.RowIndex].DataBoundItem;

                var confirmar = MessageBox.Show($"¿Seguro que deseas eliminar la tarea?\n\n{tarea.Descripcion}",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmar == DialogResult.Yes)
                {
                    gestor.EliminarTarea(tarea.Id);
                    MessageBox.Show("Tarea eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTareas();
                }
            }
        }
    }
}
