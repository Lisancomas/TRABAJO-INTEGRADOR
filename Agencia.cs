using System;
using System.Collections.Generic;

namespace Agencia
{
    public class Agencia
    {
        private string _nombre;
        private List<Vehiculo> _vehiculos; 
        private List<Cliente> _clientes; 
        private List<Alquiler> _alquileres;
        public string Nombre {get;}
        public List<Vehiculo> Vehiculos{get;} 
        public List<Cliente> Clientes{get;}
        public List<Alquiler> Alquileres{get;}

        public Agencia(string nombre)
        {
            Nombre = nombre;
            Vehiculos = new List<Vehiculo>();
            Clientes = new List<Cliente>();
            Alquileres = new List<Alquiler>();
        }




    } 

    
}