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
    public partial class FormEditar : Form
    {
        private Administrar gestor = new Administrar();

        public FormEditar()
        {
            InitializeComponent();
            CargarTareas();
        }

        private void CargarTareas()
        {
            dgvEditar.DataSource = gestor.ObtenerTareas();
            dgvEditar.Columns["Id"].Visible = false;

            if (!dgvEditar.Columns.Contains("Acciones"))
            {
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                btnEditar.HeaderText = "Acciones";
                btnEditar.Text = "Editar";
                btnEditar.UseColumnTextForButtonValue = true;
                btnEditar.Name = "btnEditar";
                dgvEditar.Columns.Add(btnEditar);
            }
        }

        private void dgvEditar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvEditar.Columns["btnEditar"].Index && e.RowIndex >= 0)
            {
                Tareas tarea = (Tareas)dgvEditar.Rows[e.RowIndex].DataBoundItem;

                string nuevaDescripcion = Microsoft.VisualBasic.Interaction.InputBox("Nueva descripción:", "Editar tarea", tarea.Descripcion);
                if (string.IsNullOrWhiteSpace(nuevaDescripcion)) return;

                DateTime nuevaFecha = tarea.FechaLimite;
                using (var fechaDialog = new DateTimePicker { Value = tarea.FechaLimite, Format = DateTimePickerFormat.Short })
                {
                    Form fechaForm = new Form
                    {
                        Text = "Selecciona nueva fecha",
                        StartPosition = FormStartPosition.CenterParent,
                        Width = 250,
                        Height = 100
                    };
                    fechaDialog.Dock = DockStyle.Fill;
                    fechaForm.Controls.Add(fechaDialog);
                    fechaForm.ShowDialog();
                    nuevaFecha = fechaDialog.Value;
                }

                gestor.EditarTarea(tarea.Id, nuevaDescripcion, nuevaFecha);
                MessageBox.Show("Tarea actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTareas();
            }
        }
    }
}
