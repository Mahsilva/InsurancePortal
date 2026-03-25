var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseDefaultFiles();  // carrega index.html automaticamente
app.UseStaticFiles();   // serve arquivos HTML, CSS, JS

app.Run();
