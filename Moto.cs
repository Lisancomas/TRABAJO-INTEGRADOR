using System;

namespace Agencia
{
    public class Moto : Vehiculo
    {
        private const int CILINDRADA_LIMITE = 250;
        private const decimal DESCUENTO_BAJA_CILINDRADA = 0.15m;

        private int _cilindrada;

        public int Cilindrada
        {
            get { return _cilindrada; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("La cilindrada debe ser mayor a 0.");
                _cilindrada = value;
            }
        }

        public Moto(string patente, string marca, string modelo, int anio,
            decimal precioPorDia, int cilindrada, bool disponible = true)
            : base(patente, marca, modelo, anio, precioPorDia, disponible)
        {
            Cilindrada = cilindrada;
        }

        // Precio por día x días. Si la cilindrada es menor a 250 cc, descuento del 15%.
        public override decimal CalcularCostoAlquiler(int dias)
        {
            decimal costo = CalcularCostoBase(dias);
            if (Cilindrada < CILINDRADA_LIMITE)
                costo -= costo * DESCUENTO_BAJA_CILINDRADA;
            return costo;
        }

        public override string ToString()
        {
            return "[Moto] " + base.ToString() + $" | Cilindrada: {Cilindrada} cc";
        }
    }
}
