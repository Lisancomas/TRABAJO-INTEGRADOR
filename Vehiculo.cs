using System;

namespace Agencia
{
    public abstract class Vehiculo
    {
        private string _patente{get;}
        private string _marca{get; set;}
        private string _modelo{get; set;}
        private int _anio{set;}
        private double _precioxdia{get; set;}
        private bool _disponible{get; set;}

        public Vehiculo(string patente, string marca, string modelo, int anio, double preciodia, bool disponible)
        {
            _patente = patente;
            _marca = marca;
            _modelo = modelo;
            _anio = anio;
            _precioxdia = preciodia;
            _disponible = disponible;
        }

        public abstract double CalcularCostoAlquiler(int dias)
        {
            double preciototal = 0;
            if(dias != 0 && dias != null)
            {
                preciototal = _precioxdia * dias;
            }

            return preciototal;
            
        }
    }

    public class Auto : Vehiculo
    {
        private int _puertas {get; 
        set{if(value != 0)
                {
                    _puertas = value;
                }
            }
        }
        private bool _cajaAutomatica{get; set;}

    }
}