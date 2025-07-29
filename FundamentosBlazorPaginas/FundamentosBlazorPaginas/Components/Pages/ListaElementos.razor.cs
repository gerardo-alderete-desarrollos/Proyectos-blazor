using Microsoft.AspNetCore.Components;

namespace FundamentosBlazorPaginas.Components.Pages;

public partial class ListaElementos: ComponentBase
{
    private List<string> elementos = new();
    private string nuevoElemento = string.Empty;

    private void AgregarElemento()
    {
        if (!string.IsNullOrWhiteSpace(nuevoElemento))
        {
            elementos.Add(nuevoElemento);
            nuevoElemento = string.Empty; // Limpiar el campo de entrada
        }
    }
}
