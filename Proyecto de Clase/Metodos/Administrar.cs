using MySql.Data.MySqlClient;
using Proyecto_de_Clase.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_de_Clase.Metodos
{
    public class Administrar
    {
        private string connectionString = "server=localhost;user=root;password=;database=gestor_tareas;";

        public void AgregarTarea(string descripcion, DateTime fechaLimite)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO tareas (descripcion, fecha_limite) VALUES (@desc, @fecha)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@desc", descripcion);
                cmd.Parameters.AddWithValue("@fecha", fechaLimite);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Tareas> ObtenerTareas()
        {
            List<Tareas> lista = new List<Tareas>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM tareas ORDER BY id ASC";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Tareas
                    {
                        Id = reader.GetInt32("id"),
                        Descripcion = reader.GetString("descripcion"),
                        FechaLimite = reader.GetDateTime("fecha_limite")
                    });
                }
            }
            return lista;
        }

        public void EditarTarea(int id, string nuevaDescripcion, DateTime nuevaFecha)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE tareas SET descripcion = @desc, fecha_limite = @fecha WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@desc", nuevaDescripcion);
                cmd.Parameters.AddWithValue("@fecha", nuevaFecha);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarTarea(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM tareas WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
