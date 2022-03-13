var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(); // A connection string esjá está configurada
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Swagger API


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("v1/todos", (AppDbContext context) =>
{
    var todos = context.ToDos.ToList();
    return Results.Ok(todos);
}).Produces<ToDo>();

app.MapPost("v1/todos", (
 AppDbContext context,
 CreateToDoViewModel model) =>
{
    var todo = model.MapTo();

    // Validação
    if (!model.IsValid) return Results.BadRequest(model.Notifications);

    // Adicionando no banco
    context.ToDos.Add(todo);
    context.SaveChanges();

    return Results.Created($"/v1/todos/{todo.Id}", todo);
});

app.Run();
