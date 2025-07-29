
using FundamentosBlazor.Repositorio.Interfaces;

namespace FundamentosBlazor.Repositorio;

public class MyService : IMyService
{
    public string GetMessage()
    {
        return "Hola desde el servicio";
    }
}
