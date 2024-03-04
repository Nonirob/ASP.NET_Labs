using System.Text.Json;


var builder = WebApplication.CreateBuilder();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.MapGet("/Library", () => Task.FromResult("Welcome to the Library!"));

app.MapGet("/Library/Books", () =>
{
    var books = File.ReadAllText("./data/books.json"); // Assuming books are stored in a JSON file
    return Task.FromResult(books);
});

app.MapGet("/Library/Profile/{id?}", async (HttpContext context) =>
{
    var userId = context.Request.RouteValues["id"]?.ToString();

    var usersJson = await File.ReadAllTextAsync("./data/users.json");
    var usersList = JsonSerializer.Deserialize<List<User>>(usersJson);

    User user;
    if (string.IsNullOrEmpty(userId))
    {
        user = usersList.FirstOrDefault();
    }
    else
    {
        if (int.TryParse(userId, out int id) && id >= 0 && id <= 5)
        {
            user = usersList.FirstOrDefault(u => u.Id == id);
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsync("Not appropriate profile Id value. It should be between 0 and 5.");
            return;
        }
    }
    
    if (user != null)
    {
        var formattedUserInfo = $"Id: {user.Id}\nName: {user.Name}\nEmail: {user.Email}\nAge: {user.Age}\nAddress: {user.Address}";
        context.Response.ContentType = "text/plain"; // Set content type as plain text
        await context.Response.WriteAsync(formattedUserInfo);
    }
    else
    {
        context.Response.StatusCode = StatusCodes.Status404NotFound;
        await context.Response.WriteAsync("User not found");
    }
});


app.Run();

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
}