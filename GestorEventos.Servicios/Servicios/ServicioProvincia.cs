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
    public interface IServicioProvincia
    {
        bool AgregarProvincia(Provincia provincia);
        bool BorradoFisicoProvincia(int IdProvincia);
        bool BorradoLogicoProvincia(int IdProvincia);
        bool ModificarProvincia(int IdProvincia, Provincia provincia);
        IEnumerable<Provincia> ObtenerProvincia();
        Provincia ObtenerProvinciaId(int IdProvincia);
    }

    public class ServicioProvincia : IServicioProvincia
    {

        private string _connectionString;

        public ServicioProvincia()
        {
            _connectionString = "Server=localhost;Database=db_py_unlz;Uid=root;Pwd=admin;";
        }


        public IEnumerable<Provincia> ObtenerProvincia()
        {
            using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                List<Provincia> servicios = db.Query<Provincia>("").ToList();
                return servicios;
            }
        }

        public Provincia ObtenerProvinciaId(int IdProvincia)
        {
            using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                Provincia provincia = db.Query<Provincia>("" + IdProvincia.ToString()).First();
                return provincia;
            }
        }



        public bool AgregarProvincia(Provincia provincia)
        {
            using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                string query = "";
                db.Execute(query, provincia);
                return true;
            }

        }

        public bool ModificarProvincia(int IdProvincia, Provincia provincia)
        {
            using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                string query = "" + IdProvincia.ToString();
                db.Execute(query, provincia);
                return true;
            }
        }

        public bool BorradoLogicoProvincia(int IdProvincia)
        {
            using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                string query = "" + IdProvincia.ToString();
                db.Execute(query);
                return true;
            }
        }

        public bool BorradoFisicoProvincia(int IdProvincia)
        {
            using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                string query = "" + IdProvincia.ToString();
                db.Execute(query);
                return true;
            }
        }

    }
}
