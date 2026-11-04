using System;
using System.Collections.Generic;

namespace Agencia
{
    public class Cliente
    {
        private string _nombrecliente;
        private string _apellidocliente;
        private int _dni;
        private int _telefono;

        public string Nombre{ get {return _nombrecliente;}}
        public string Apellido{ get {return _apellidocliente;}}
        public int Dni { get { return _dni; } }
        public int Telefono{ get { return _telefono;}}

        public Cliente(string nombre, string apellido, int dni, int telefono)
        {
            _nombrecliente = nombre;
            _apellidocliente = apellido;
            _dni = dni;
            _telefono = telefono;    
        }
    }
}