﻿using Dapper;
using GestorEventos.Servicios.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
    public interface IServicioLocalidad
    {
        bool AgregarLocalidad(Localidad localidad);
        bool BorradoFisicoLocalidad(int IdLocalidad);
        bool BorradoLogicoLocalidad(int IdLocalidad);
        bool ModificarLocalidad(int IdLocalidad, Localidad localidad);
        IEnumerable<Localidad> ObtenerLocalidad();
        Localidad ObtenerLocalidadId(int IdLocalidad);
    }

    public class ServicioLocalidad : IServicioLocalidad
    {
        private string _connectionString;

        public ServicioLocalidad()
        {
            _connectionString = "Server=localhost;Database=db_py_unlz;Uid=root;Pwd=admin;";
        }


        public IEnumerable<Localidad> ObtenerLocalidad()
        {
            using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                List<Localidad> localidad = db.Query<Localidad>("").ToList();
                return localidad;
            }
        }

        public Localidad ObtenerLocalidadId(int IdLocalidad)
        {
            using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                Localidad localidad = db.Query<Localidad>("" + IdLocalidad.ToString()).First();
                return localidad;
            }
        }



        public bool AgregarLocalidad(Localidad localidad)
        {
            using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                string query = "";
                db.Execute(query, localidad);
                return true;
            }

        }

        public bool ModificarLocalidad(int IdLocalidad, Localidad localidad)
        {
            using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                string query = "" + IdLocalidad.ToString();
                db.Execute(query, localidad);
                return true;
            }
        }

        public bool BorradoLogicoLocalidad(int IdLocalidad)
        {
            using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                string query = "" + IdLocalidad.ToString();
                db.Execute(query);
                return true;
            }
        }

        public bool BorradoFisicoLocalidad(int IdLocalidad)
        {
            using (MySqlConnection db = new MySqlConnection(_connectionString))
            {
                string query = "" + IdLocalidad.ToString();
                db.Execute(query);
                return true;
            }
        }

    }
}
