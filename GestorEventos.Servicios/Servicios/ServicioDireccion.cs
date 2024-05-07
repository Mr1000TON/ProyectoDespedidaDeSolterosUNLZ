    using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
    public class ServicioDireccion
    {

        IEnumerable<Direccion> Direcciones { get; set;}

        public ServicioDireccion()
        {

            Direcciones = new List<Direccion>
            {

                new Direccion
                {
                    IdDireccion = 1,
                    Calle = "Entre Rios",
                    NumeroCalle = "522",
                    Piso = "-",
                    Departamento = "-",
                    Visible = true
                }
            };
        }


        public IEnumerable<Direccion> Get()
        {
            return Direcciones.Where(x => x.Visible == true);
        }

        public Direccion GetDireccion(int IdDireccion)
        {
            try
            {
                Direccion direccion = Direcciones.Where(x => x.IdDireccion == IdDireccion).First();
                return direccion;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public bool AgregarDireccion(Direccion direccion)
        {
            try
            {
                List<Direccion> lista = Direcciones.ToList();
                lista.Add(direccion); 
                return true; 
            }
            catch( Exception ex)
            {
                return false;
            }
        }

        public bool ModificarDireccion(int IdDireccion, Direccion direccion)
        {
            try
            {
                var direccionAModificar = Direcciones.Where(x => x.IdDireccion == IdDireccion).First();

                direccionAModificar.Calle = direccion.Calle;
                direccionAModificar.Piso = direccion.Piso;
                direccionAModificar.Departamento = direccion.Departamento;
                direccionAModificar.NumeroCalle = direccion.NumeroCalle;

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool EliminarDireccion(int IdDireccion)
        {
            try
            {
                var direccionAEliminar = Direcciones.Where(x => x.IdDireccion == IdDireccion).First();

                direccionAEliminar.Visible = false;

                return true;
            }
            catch (Exception ex)
            {
                return false; 
            }
        }


    }
}
