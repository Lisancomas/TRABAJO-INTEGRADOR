namespace Agencia
{
    /// <summary>
    /// Contrato para los vehículos que permiten contratar un seguro adicional.
    /// </summary>
    public interface IAsegurable
    {
        /// <summary>Costo total del seguro para la cantidad de días indicada.</summary>
        decimal CalcularCostoSeguro(int dias);

        /// <summary>Costo del seguro por cada día de alquiler.</summary>
        decimal ObtenerCostoSeguroPorDia();
    }
}
