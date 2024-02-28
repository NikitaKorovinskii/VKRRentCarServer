using System;
using System.Text.Json;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () => "Hello World!");

var cars = new List<Car>
{
    new Car(1, "Octavia RS", "Skoda", "01.02.2022", "����", "�����", "������ ������", 200, 4, "assets/img/Octavia.png"),
    new Car(2, "M 3 Series", "BMW", "20.07.2023", "����", "�������", "�������� ������", 500, 4, "assets/img/M3.png"),
    new Car(3, "CLA", "Mercedes-Benz", "25.08.2023", "����", "�����", "������ ������", 600, 2, "assets/img/cla.png"),
    new Car(4, "A4", "Audi", "10.09.2023", "����", "������", "������ ������", 700, 4, "assets/img/audi-a4.png"),
    new Car(5, "Golf GTI", "Volkswagen", "15.10.2023", "����", "�����", "�������� ������", 800, 4, "assets/img/GTI.png"),
    new Car(6, "Camry LE", "Toyota", "20.11.2023", "����", "�����������", "�������� ������", 900, 4, "assets/img/camry.png"),
    new Car(7, "Accord EX", "Honda", "25.12.2023", "����", "�������", "������ ������", 1000, 4, "assets/img/accord.png"),
    new Car(8, "Cruze", "Chevrolet", "10.01.2024", "����", "�����", "�������� ������", 1100, 4, "assets/img/cruze.png"),
    new Car(9, "Logan", "Renault", "15.02.2024", "����", "������", "������ ������", 1200, 4, "assets/img/logan.png")
};
var users = new List<User>
{
    new User(1, "������", "nikita", "123")
};


app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:4200");
    context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
    context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");

    if (context.Request.Method == "OPTIONS")
    {
        context.Response.StatusCode = 200;
        await context.Response.CompleteAsync();
    }
    else
    {
        await next();
    }
});
app.MapGet("/cars", (HttpContext context) =>
{
    var json = JsonSerializer.Serialize(cars);
    return context.Response.WriteAsync(json);
});
app.MapPost("/login", (User userData, HttpContext context) =>
{
    var user = users.FirstOrDefault(u => u.Id == userData.Id);
    if (user == null || user.Login != userData.Login || user.Password != userData.Password)
    {
        context.Response.StatusCode = 404;
        return Results.NotFound(new { message = "������������ �� ������" });
    }

    context.Response.StatusCode = 200;
    return Results.Json(user);
});
app.MapPost("/rentCar", async (context) =>
{
    // ��������� ������ �� �������
    var requestBody = await context.Request.ReadFromJsonAsync<RentCarRequest>();

    // ���������� ��������� ������
    var (numberOfDays, totalPrice) = Class.CalculateRent(requestBody);

    // ������������ ������
    var response = new RentCarResponse
    {
        NumberOfDays = numberOfDays,
        TotalPrice = totalPrice
    };

    // �������� ������
    await context.Response.WriteAsJsonAsync(response);
});

app.Run();

