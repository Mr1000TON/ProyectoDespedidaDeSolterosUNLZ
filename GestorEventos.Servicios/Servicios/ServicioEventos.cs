﻿using Dapper;
using GestorEventos.Servicios.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
    public interface IServicioEventos
    {
        bool AgregarEvento(Evento evento);
        bool BorradoFisicoEvento(int IdEvento);
        bool BorradoLogicoEvento(int IdEvento);
        bool ModificarEvento(int IdEvento, Evento evento);
        IEnumerable<Evento> ObtenerEventos();
        Evento ObtenerEventosId(int IdEvento);
    }

    public class ServicioEventos : IServicioEventos
    {

        private string _connectionString;

        public ServicioEventos()
        {
            //_connectionString = "Data Source=Jimi-Floyd\\SQLEXPRESS;Initial Catalog=BDDespedidas;User ID=sa;Password=12345678;Persist Security Info=True";
            _connectionString = "Server=localhost;Database=db_py_unlz;Uid=root;";
        }


        public IEnumerable<Evento> ObtenerEventos()
        {
             using (MySqlConnection db = new MySqlConnection(_connectionString))
            //using (IDbConnection db = new SqlConnection(_connectionString))
            {
                List<Evento> servicios = db.Query<Evento>("").ToList();
                return servicios;
            }
        }

        public Evento ObtenerEventosId(int IdEvento)
        {
            // using (MySqlConnection db = new MySqlConnection(_connectionString))
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Evento evento = db.Query<Evento>("" + IdEvento.ToString()).First();
                return evento;
            }
        }

        public bool AgregarEvento(Evento evento)
        {
            // using (MySqlConnection db = new MySqlConnection(_connectionString))
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "";
                db.Execute(query, evento);
                return true;
            }
        }

        public bool ModificarEvento(int IdEvento, Evento evento)
        {
            // using (MySqlConnection db = new MySqlConnection(_connectionString))
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "" + IdEvento.ToString();
                db.Execute(query, evento);
                return true;
            }
        }

        public bool BorradoLogicoEvento(int IdEvento)
        {
            // using (MySqlConnection db = new MySqlConnection(_connectionString))
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "" + IdEvento.ToString();
                db.Execute(query);
                return true;
            }
        }

        public bool BorradoFisicoEvento(int IdEvento)
        {
            // using (MySqlConnection db = new MySqlConnection(_connectionString))
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "" + IdEvento.ToString();
                db.Execute(query);
                return true;
            }
        }

    }
}
