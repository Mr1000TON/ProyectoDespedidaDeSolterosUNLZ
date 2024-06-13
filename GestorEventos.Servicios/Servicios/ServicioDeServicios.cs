using Dapper;
using GestorEventos.Servicios.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
    public interface IServicioDeServicios
    {
        bool AgregarServicio(Servicio servicios);
        bool BorradoFisicoServicio(int IdServicio);
        bool BorradoLogicoServicio(int IdServicio);
        bool ModificarServicio(int IdServicio, Servicio servicios);
        Servicio ObtenerServicioId(int IdServicio);
        IEnumerable<Servicio> ObtenerServicios();
    }

    public class ServicioDeServicios : IServicioDeServicios
    {

        private string _connectionString;

        public ServicioDeServicios()
        {
            //_connectionString = "Data Source=Jimi-Floyd\\SQLEXPRESS;Initial Catalog=BDDespedidas;User ID=sa;Password=12345678;Persist Security Info=True";

           
            _connectionString = "server=localhost; database=db_py_unlz; Uid=root; password=;";
        }


        public IEnumerable<Servicio> ObtenerServicios()
        {
           // using (IDbConnection db = new SqlConnection(_connectionString))
            using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                List<Servicio> servicios = db.Query<Servicio>("SELECT * FROM servicios WHERE Borrado = 0").ToList();
                return servicios;
            }
        }

        public Servicio ObtenerServicioId(int IdServicio)
        {
           // using (IDbConnection db = new SqlConnection(_connectionString))
            using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                Servicio servicios = db.Query<Servicio>("SELECT * FROM servicios WHERE IdServicio = " + IdServicio.ToString()).First();
                return servicios;
            }
        }



        public bool AgregarServicio(Servicio servicios)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            //using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                string query = "INSERT INTO servicios(IdServicio, Descripcion, PrecioServicio, Borrado) VALUES(@IdServicio, @Descripcion, @PrecioServicio, @Borrado)";
                db.Execute(query, servicios);
                return true;
            }

        }

        public bool ModificarServicio(int IdServicio, Servicio servicios)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            //using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                string query = "UPDATE servicios SET Descripcion = @Descripcion, PrecioServicio = @PrecioServicio WHERE IdServicio = " + IdServicio.ToString();
                db.Execute(query, servicios);
                return true;
            }
        }

        public bool BorradoLogicoServicio(int IdServicio)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            //using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                string query = "UPDATE servicios SET Borrado = 1 WHERE IdServicio = " + IdServicio.ToString();
                db.Execute(query);
                return true;
            }
        }

        public bool BorradoFisicoServicio(int IdServicio)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            //using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM servicios WHERE IdServicio = " + IdServicio.ToString();
                db.Execute(query);
                return true;
            }
        }

    }
}
