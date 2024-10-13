namespace ADS.Delivery.API.V1.Models.Utils;

internal class Iterador(ADSBDEFContextoBaseInMemory _contextoADS)
{
    internal IterarPratosOuCategs(string parametro)
    {
        for (int i = 0; i < parametro.Count; i++)
            _contextoADS.Add(parametro);
    }
}
