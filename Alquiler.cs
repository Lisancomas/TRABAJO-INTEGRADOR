using System;
using System.Collections.Generic;
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
            decimal costoBase = _vehiculo.CalcularCostoAlquiler(_cantidadDias); //Se crea una variable que lo que hace es almacenar el valor del alquiler dependiendo de que tipo de vehiculo sea (CalcularCostoAlquiler es un metodo abstracto de Vehiculo) y de la cantidad de dias ingresado.
            
            if (_vehiculo is IAsegurable asegurable) //si el vehiculo ingresado en el constructor es de un tipo de vehiculo que haya implementado la interfaz IAsegurable...
            {
                costoBase += asegurable.CalcularCostoSeguro(_cantidadDias); //Al costo base se le suma el costo del seguro dependiendo de cuanto se le cobre al tipo de vehiculo correspondiente.
            }
            _costoTotal = Convert.ToDouble(costoBase); //se actualiza la propiedad.
        }
        
    }
}