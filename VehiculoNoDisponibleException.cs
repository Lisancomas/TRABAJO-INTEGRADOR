using System;

namespace Agencia
{
    public class VehiculoNoDisponibleException : Exception
    {
        public VehiculoNoDisponibleException (string mensaje) : base(mensaje){}
    }
}