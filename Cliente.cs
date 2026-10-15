using System;
using System.Collections.Generic;

namespace Agencia
{
    public class Cliente
    {
        private string _nombrecliente{get; set;}
        private string _apellidocliente{get; set;}
        private int _dni{get; set;}
        private int _telefono{get; set;}

        public Cliente(string nombre, string apellido, int dni, int telefono)
        {
            _nombrecliente = nombre;
            _apellidocliente = apellido;
            _dni = dni;
            _telefono = telefono;
        }
    }
}