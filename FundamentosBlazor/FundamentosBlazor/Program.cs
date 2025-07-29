using FundamentosBlazor.Components;
using FundamentosBlazor.Repositorio;
using FundamentosBlazor.Repositorio.Interfaces;

var builder = WebApplication.CreateBuilder(args);

/*
 * Trace: Registra eventos muy detallados y t�cnicos. Se utiliza para diagn�stico 
 * detallado. Este nivel rara vez se utiliza en producci�n debido a la gran cantidad de datos generados.(logger.LogTrace("Informaci�n de traza");)
 * Debug: Similar a Trace, pero menos detallado. Se utiliza para depuraci�n. En entornos de producci�n, 
 * normalmente est� deshabilitado.(logger.LogDebug("Informaci�n de depuraci�n");)
 * Information: Registra el flujo general de la aplicaci�n, como eventos de inicio, cierre, 
 * y otros procesos importantes.
 * Warning: Indica una situaci�n inesperada o algo que puede provocar problemas en el futuro. 
 * No es un error cr�tico, pero merece atenci�n.
 * Error: Indica un fallo en la aplicaci�n o un evento que requiere correcci�n.
 * Critical: Se utiliza para situaciones cr�ticas que requieren atenci�n inmediata, como fallos graves 
 * que podr�an causar la ca�da de la aplicaci�n.
 */

/*
 *appsettings.json
 *appsettings.<environment>.json
 *App secrets (secrets.json) - Solo en modo desarrollo (Development) ruta: %APPDATA%\Microsoft\UserSecrets
 *Variables de entorno (Environment Variables)
 *L�nea de comandos
 *Azure Key Vault
 * */


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// En Blazor .NET 8, como en versiones anteriores, se pueden registrar servicios en 3 niveles:
// Transitorio(Transient): Una nueva instancia del servicio es creada cada vez que se requeiere.
// De Ambito (Scoped): Se crea una instancia por cada solicitud (en Blazor Server es por cada conexion, y en Blazor WebAssembly es por la vida util de la sesion).
// Singleton: Se crea una unica instancia para toda la aplicacion.

// Registro de un servicio en Singleton de ejmeplo
builder.Services.AddSingleton<IMyService, MyService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
