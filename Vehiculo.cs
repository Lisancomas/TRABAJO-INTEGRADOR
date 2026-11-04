using System;

namespace Agencia
{
    /// <summary>
    /// Clase base abstracta de todos los vehículos de la agencia.
    /// </summary>
    public abstract class Vehiculo
    {
        private string _patente;
        private string _marca;
        private string _modelo;
        private int _anio;
        private decimal _precioPorDia;
        private bool _disponible;

        public string Patente
        {
            get { return _patente; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La patente no puede estar vacía.");
                _patente = value.Trim().ToUpper();
            }
        }

        public string Marca
        {
            get { return _marca; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La marca no puede estar vacía.");
                _marca = value.Trim();
            }
        }

        public string Modelo
        {
            get { return _modelo; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El modelo no puede estar vacío.");
                _modelo = value.Trim();
            }
        }

        public int Anio
        {
            get { return _anio; }
            protected set
            {
                if (value < 1900 || value > DateTime.Now.Year + 1)
                    throw new ArgumentException("El año ingresado no es válido.");
                _anio = value;
            }
        }

        public decimal PrecioPorDia
        {
            get { return _precioPorDia; }
            protected set
            {
                if (value <= 0)
                    throw new ArgumentException("El precio por día debe ser mayor a 0.");
                _precioPorDia = value;
            }
        }

        /// <summary>Indica si el vehículo está disponible para alquilar.</summary>
        public bool Disponible { get {return _disponible;} set{_disponible = value;} }

        protected Vehiculo(string patente, string marca, string modelo, int anio,
                           decimal precioPorDia, bool disponible = true)
        {
            _patente = patente;
            _marca = marca;
            _modelo = modelo;
            _anio = anio;
            _precioPorDia = precioPorDia;
            _disponible = disponible;
        }

        /// <summary>
        /// Cada tipo de vehículo calcula su costo de alquiler de forma distinta.
        /// </summary>
        public abstract decimal CalcularCostoAlquiler(int dias);

        /// <summary>
        /// Costo base (precio por día x días). Lo reutilizan las subclases
        /// para no duplicar código. También valida la cantidad de días.
        /// </summary>
        protected decimal CalcularCostoBase(int dias)
        {
            if (dias <= 0)
                throw new ArgumentException("La cantidad de días debe ser mayor a 0.");
            return PrecioPorDia * dias;
        }

        public override string ToString()
        {
            return $"Patente: {Patente} | {Marca} {Modelo} ({Anio}) | " +
                   $"Precio por día: ${PrecioPorDia:N0} | " +
                   $"Disponible: {(Disponible ? "Sí" : "No")}";
        }
    }
}
