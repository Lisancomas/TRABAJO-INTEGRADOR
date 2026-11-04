using System;

namespace Agencia
{
    public class Camioneta : Vehiculo, IAsegurable
    {
        private const decimal ADICIONAL_4X4_POR_DIA = 5000m;
        private const decimal SEGURO_POR_DIA = 12000m;

        private double _capacidadCargaKg;

        public double CapacidadCargaKg
        {
            get { return _capacidadCargaKg; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("La capacidad de carga debe ser mayor a 0.");
                _capacidadCargaKg = value;
            }
        }

        public bool Es4x4 { get; private set; }

        public Camioneta(string patente, string marca, string modelo, int anio,
                         decimal precioPorDia, double capacidadCargaKg, bool es4x4,
                         bool disponible = true)
            : base(patente, marca, modelo, anio, precioPorDia, disponible)
        {
            CapacidadCargaKg = capacidadCargaKg;
            Es4x4 = es4x4;
        }

        // Precio por día x días, más $5.000 por día si es 4x4.
        public override decimal CalcularCostoAlquiler(int dias)
        {
            decimal costo = CalcularCostoBase(dias);
            if (Es4x4)
                costo += ADICIONAL_4X4_POR_DIA * dias;
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
            return "[Camioneta] " + base.ToString() +
                   $" | Carga: {CapacidadCargaKg:N0} kg | 4x4: {(Es4x4 ? "Sí" : "No")}";
        }
    }
}
