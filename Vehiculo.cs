using System;

namespace Agencia
{
    public abstract class Vehiculo
    {
        private string _patente;
        private string _marca;
        private string _modelo;
        private int _anio;
        private double _precioxdia;
        private bool _disponible;
        public string Patente {get; set;}
        public string Marca{get; set;}
        public string Modelo{get; set;}
        public int Anio{get; set;}
        public double Precioxdia{get; set;}
        public bool Disponible{get; set;}


        public Vehiculo(string patente, string marca, string modelo, int anio, double preciodia, bool disponible)
        {
            _patente = patente;
            _marca = marca;
            _modelo = modelo;
            _anio = anio;
            _precioxdia = preciodia;
            _disponible = disponible;
        }
        public abstract double CalcularCostoAlquiler(int dias);
    }
}