namespace Agencia
{
    public interface IAsegurable
    {
        double CalcularCostoSeguro(int dias);
        double ObtenerCostoSeguroPorDia();
    }
}