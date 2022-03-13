var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(); // A connection string esjá está configurada

var app = builder.Build();

app.MapGet("v1/todos", (AppDbContext context) =>
{
    var todos = context.ToDos.ToList();
    return Results.Ok(todos);
});

app.Run();
 