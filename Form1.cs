using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AgendaElectronica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void MostrarRegistros()
        {
            string connectionString = "Data Source=.;Initial Catalog=agendaelectronica;Integrated Security=True";
            string query = "SELECT * FROM Agenda";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvRegistros.DataSource = dataTable;
                }
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            DateTime fechaNacimiento = dtpFechaNacimiento.Value;
            string direccion = txtDireccion.Text;
            string genero = cmbGenero.SelectedItem.ToString();
            string estadoCivil = cmbEstadoCivil.SelectedItem.ToString();
            string movil = txtMovil.Text;
            string telefono = txtTelefono.Text;
            string correoElectronico = txtCorreoElectronico.Text;

            string connectionString = "Data Source=.;Initial Catalog=agendaelectronica;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Agenda (Nombre, Apellido, FechaNacimiento, Direccion, Genero, EstadoCivil, Movil, Telefono, CorreoElectronico) VALUES (@Nombre, @Apellido, @FechaNacimiento, @Direccion, @Genero, @EstadoCivil, @Movil, @Telefono, @CorreoElectronico)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Apellido", apellido);
                    command.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                    command.Parameters.AddWithValue("@Direccion", direccion);
                    command.Parameters.AddWithValue("@Genero", genero);
                    command.Parameters.AddWithValue("@EstadoCivil", estadoCivil);
                    command.Parameters.AddWithValue("@Movil", movil);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@CorreoElectronico", correoElectronico);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Registro insertado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error al insertar el registro.");
                    }
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            DateTime fechaNacimiento = dtpFechaNacimiento.Value;
            string direccion = txtDireccion.Text;
            string genero = cmbGenero.SelectedItem.ToString();
            string estadoCivil = cmbEstadoCivil.SelectedItem.ToString();
            string movil = txtMovil.Text;
            string telefono = txtTelefono.Text;
            string correoElectronico = txtCorreoElectronico.Text;

            string connectionString = "Data Source=.;Initial Catalog=agendaelectronica;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Agenda SET Nombre=@Nombre, Apellido=@Apellido, FechaNacimiento=@FechaNacimiento, Direccion=@Direccion, Genero=@Genero, EstadoCivil=@EstadoCivil, Movil=@Movil, Telefono=@Telefono, CorreoElectronico=@CorreoElectronico WHERE Id=@Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Apellido", apellido);
                    command.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                    command.Parameters.AddWithValue("@Direccion", direccion);
                    command.Parameters.AddWithValue("@Genero", genero);
                    command.Parameters.AddWithValue("@EstadoCivil", estadoCivil);
                    command.Parameters.AddWithValue("@Movil", movil);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@CorreoElectronico", correoElectronico);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Registro modificado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error al modificar el registro.");
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            string connectionString = "Data Source=.;Initial Catalog=agendaelectronica;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Agenda WHERE Id=@Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            txtNombre.Text = reader["Nombre"].ToString();
                            txtApellido.Text = reader["Apellido"].ToString();
                            dtpFechaNacimiento.Value = Convert.ToDateTime(reader["FechaNacimiento"]);
                            txtDireccion.Text = reader["Direccion"].ToString();
                            cmbGenero.SelectedItem = reader["Genero"].ToString();
                            cmbEstadoCivil.SelectedItem = reader["EstadoCivil"].ToString();
                            txtMovil.Text = reader["Movil"].ToString();
                            txtTelefono.Text = reader["Telefono"].ToString();
                            txtCorreoElectronico.Text = reader["CorreoElectronico"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún registro con el Id especificado.");
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            string connectionString = "Data Source=.;Initial Catalog=agendaelectronica;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Agenda WHERE Id=@Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("El registro ha sido eliminado correctamente.");
                        
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún registro con el Id especificado.");
                    }
                }
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            MostrarRegistros();
        }
    }
}
