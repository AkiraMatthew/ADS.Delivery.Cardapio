namespace ADS.Delivery.API.V1;

internal static class Iterador(ADSBDEFContextoBaseInMemory _contextoADS)
{
    internal static IterarPratosOuCategs(string parametro)
    {
        for (int i = 0; i < parametro.Count; i++)
            _contextoADS.Add(parametro);
    }
}
