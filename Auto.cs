using System;

namespace Agencia
{
    public class Auto : Vehiculo, IAsegurable
    {
        private const decimal RECARGO_AUTOMATICO = 0.10m;
        private const decimal SEGURO_POR_DIA = 8000m;

        private int _cantidadPuertas;

        public int CantidadPuertas
        {
            get { return _cantidadPuertas; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("La cantidad de puertas debe ser mayor a 0.");
                _cantidadPuertas = value;
            }
        }

        public bool EsAutomatico { get; private set; }

        public Auto(string patente, string marca, string modelo, int anio,
                    decimal precioPorDia, int cantidadPuertas, bool esAutomatico,
                    bool disponible = true)
            : base(patente, marca, modelo, anio, precioPorDia, disponible)
        {
            CantidadPuertas = cantidadPuertas;
            EsAutomatico = esAutomatico;
        }

        // Precio por día x días. Si la caja es automática, recargo del 10%.
        public override decimal CalcularCostoAlquiler(int dias)
        {
            decimal costo = CalcularCostoBase(dias);
            if (EsAutomatico)
                costo += costo * RECARGO_AUTOMATICO;
            return costo;
        }

        public decimal CalcularCostoSeguro(int dias)
        {
            if (dias <= 0)
                throw new ArgumentException("La cantidad de días debe ser mayor a 0.");
            return SEGURO_POR_DIA * dias;
        }

        public decimal ObtenerCostoSeguroPorDia()
        {
            return SEGURO_POR_DIA;
        }

        public override string ToString()
        {
            return "[Auto] " + base.ToString() +
                   $" | Puertas: {CantidadPuertas} | Automático: {(EsAutomatico ? "Sí" : "No")}";
        }
    }
}
