using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using Agencia;

namespace Agencia
{
    public class Alquiler
    {
        private Cliente _cliente;
        private Vehiculo _vehiculo;
        private int _cantidadDias;
        private double _costoTotal;

        public Cliente Cliente {get {return _cliente;}}
        public Vehiculo Vehiculo {get {return _vehiculo;}}
        public int CantidadDias {get {return _cantidadDias;}}
        public double CostoTotal {get {return _costoTotal;}}


        public Alquiler(Cliente ncliente, Vehiculo nvehiculo, int cdias)
        {
            _cliente = ncliente;
            _vehiculo = nvehiculo;
            _cantidadDias = cdias;
            //FALTA EL CALCULO DEL COSTO TOTAL, NO TENGO LA FUNCION DEL INTEGRANTE 1 'calcularcostoalquiler()'
        }
    }
}