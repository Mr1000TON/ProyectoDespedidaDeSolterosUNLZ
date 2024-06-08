using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IPersonaService, PersonaService>();

 
builder.Services.AddAuthentication(opciones =>
{
    opciones.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    opciones.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    opciones.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle(GoogleDefaults.AuthenticationScheme, opciones =>
{
    opciones.ClientId = builder.Configuration.GetSection("GooglaKeys:ClientId").Value + ".apps.googleusercontent.com";
    opciones.ClientSecret = builder.Configuration.GetSection("GooglaKeys:ClientPriv").Value;
 
    opciones.Events.OnCreatingTicket = ctx =>
    {
        var usuarioServicio = ctx.HttpContext.RequestServices.GetRequiredService<IUsuarioService>();

        string googleNameIdentifier = ctx.Identity.Claims.First(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value.ToString(); ;

        var usuario = usuarioServicio.GetUsuarioPorGoogleSubject(googleNameIdentifier);
        int idUsuario = 0;
        if (usuario == null)
        {
            Usuario usuarioNuevo = new Usuario();
            usuarioNuevo.Apellido = ctx.Identity.Claims.First(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname").Value.ToString();
            usuarioNuevo.Nombre = ctx.Identity.Claims.First(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname").Value.ToString();
            usuarioNuevo.NombreCompleto = ctx.Identity.Claims.First(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value.ToString();
            usuarioNuevo.GoogleIdentificador = googleNameIdentifier;
            usuarioNuevo.Borrado = false;
            usuarioNuevo.Email = ctx.Identity.Claims.First(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value.ToString();

            idUsuario = usuarioServicio.AgregarNuevoUsuario(usuarioNuevo);

        }
        else
        {
            idUsuario = usuario.IdUsuario;
        }
        //ctx.Identity.
         //   usuarioServicio.GetUsuarioPorGoogleSubject(ctx.Identity.Claims)
        // Agregar reclamaciones personalizadas aquí
        ctx.Identity.AddClaim(new System.Security.Claims.Claim("usuarioSolterout", idUsuario.ToString()));

        var accessToken = ctx.AccessToken;
        ctx.Identity.AddClaim(new System.Security.Claims.Claim("accessToken", accessToken));
        
        return Task.CompletedTask;
    };
});

var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

    app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
