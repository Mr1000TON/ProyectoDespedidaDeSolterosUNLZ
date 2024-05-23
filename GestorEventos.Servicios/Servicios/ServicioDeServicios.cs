using Dapper;
using GestorEventos.Servicios.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
    public class ServicioDeServicios
    {

        private string _connectionString;

        public ServicioDeServicios()
        {
            _connectionString = "Server=localhost;Database=db_py_unlz;Uid=root;Pwd=admin;";
        } 


        public IEnumerable<Servicio> ObtenerServicios()
        {
            using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                List<Servicio> servicios = db.Query<Servicio>("SELECT * FROM servicios WHERE Borrado = 0").ToList();
                return servicios;
            }
        }

        public Servicio ObtenerServicioId(int IdServicio)
        {
            using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                Servicio servicios = db.Query<Servicio>("SELECT * FROM servicios WHERE IdServicio = " + IdServicio.ToString()).First();
                return servicios;
            }
        }
        


        public bool AgregarServicio(Servicio servicios)
        {
            using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                string query = "INSERT INTO servicios(IdServicio, Descripcion, PrecioServicio, Borrado) VALUES(@IdServicio, @Descripcion, @PrecioServicio, @Borrado)";
                db.Execute(query, servicios);
                return true;
            }

        }

        public bool ModificarServicio(int IdServicio, Servicio servicios)
        {
            using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                string query = "UPDATE servicios SET Descripcion = @Descripcion, PrecioServicio = @PrecioServicio WHERE IdServicio = " + IdServicio.ToString();
                db.Execute(query, servicios);
                return true;
            }
        }

        public bool BorradoLogicoServicio(int IdServicio)
        {
            using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                string query = "UPDATE servicios SET Borrado = 1 WHERE IdServicio = " + IdServicio.ToString();
                db.Execute(query);
                return true;
            }
        }

        public bool DesacerBorradoLogicoServicio(int IdServicio)
        {
            using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                string query = "UPDATE servicios SET Borrado = 0 WHERE IdServicio = " + IdServicio.ToString();
                db.Execute(query);
                return true;
            }
        }

        public bool BorradoFisicoServicio(int IdServicio)
        {
            using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM servicios WHERE IdServicio = " + IdServicio.ToString();
                db.Execute(query);
                return true;
            }
        }

    }
}
