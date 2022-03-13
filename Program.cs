var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => {
    var todo = new ToDo(Guid.NewGuid(), "Ir para academia", false);
    return Results.Ok(todo);
});

app.Run();
