using System;
using System.Collections.Generic;

namespace Agencia
{
    public class Agencia
    {
        public string Nombre {get; set;}
        private List<Vehiculo> Vehiculos {get; private set;}
        private List<Cliente> Clientes {get; private set;}
        private List<Alquiler> Alquileres {get; private set;}

        public Agencia(string nombre)
        {
            Nombre = nombre;
            Vehiculos = new List<Vehiculo>();
            Clientes = new List<Cliente>();
            Alquileres = new List<Alquiler>();
        }




    } 

    
}