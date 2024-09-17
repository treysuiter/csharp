using HoneyRaesAPI.Models;
using HoneyRaesAPI.Models.DTOs;

List<Customer> customers = new List<Customer>
                {
                new Customer {Id = 1, Name = "Jim Dandy", Address = "100 Cherry St"},
                new Customer {Id = 2, Name = "Donna Smith", Address = "200 Elm St"},
                new Customer {Id = 3, Name = "Jeff North", Address = "300 Hickory St"}
                };

List<Employee> employees = new List<Employee>
                {
                    new Employee {Id = 1, Name = "Roger Dodger", Specialty = "Transmissions"},
                    new Employee {Id = 3, Name = "Jen Jones", Specialty = "Exhausts"},
                };
List<ServiceTicket> serviceTickets = new List<ServiceTicket>
                {
                    new ServiceTicket {Id = 1, CustomerId = 1, EmployeeId = 1, Description = "need transmissions fixed", Emergency = false},
                    new ServiceTicket {Id = 2, CustomerId = 2, EmployeeId = 2, Description = "need Exhaust fixed", Emergency = false},
                    new ServiceTicket {Id = 3, CustomerId = 2, EmployeeId = 2, Description = "need Exhaust fixed", Emergency = false},
                    new ServiceTicket {Id = 4, CustomerId = 3, Description = "need Transmissions fixed", Emergency = false},
                    new ServiceTicket {Id = 5, CustomerId = 3, Description = "need breaks fixed", Emergency = false}
                };

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/servicetickets", () =>
{
    return serviceTickets.Select(t => new ServiceTicketDTO
    {
        Id = t.Id,
        CustomerId = t.CustomerId,
        EmployeeId = t.EmployeeId,
        Description = t.Description,
        Emergency = t.Emergency,
        DateCompleted = t.DateCompleted
    });
});

app.MapGet("/servicetickets/{id}", (int id) =>
{
    ServiceTicket serviceTicket = serviceTickets.FirstOrDefault(st => st.Id == id);

    if (serviceTicket == null) return Results.NotFound();

    return Results.Ok(new ServiceTicketDTO
    {
        Id = serviceTicket.Id,
        CustomerId = serviceTicket.CustomerId,
        EmployeeId = serviceTicket.EmployeeId,
        Description = serviceTicket.Description,
        Emergency = serviceTicket.Emergency,
        DateCompleted = serviceTicket.DateCompleted
    });
});

app.MapGet("/employees", () =>
{
    List<EmployeeDTO> ret = new List<EmployeeDTO>();

    foreach (var emp in employees)
    {
        ret.Add(new EmployeeDTO
        {
            Id = emp.Id,
            Name = emp.Name,
            Specialty = emp.Specialty
        });
    }

    return ret;
});

app.MapGet("/employees/{id}", (int id) =>
{
    Employee employee = employees.FirstOrDefault(e => e.Id == id);
    if (employee == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(new EmployeeDTO
    {
        Id = employee.Id,
        Name = employee.Name,
        Specialty = employee.Specialty
    });
});

app.MapGet("/customers", () =>
{
    List<CustomerDTO> ret = new List<CustomerDTO>();

    foreach (var cst in customers)
    {
        ret.Add(new CustomerDTO
        {
            Id = cst.Id,
            Name = cst.Name,
            Address = cst.Address
        });
    }

    return ret;
});

app.MapGet("/customers/{id}", (int id) =>
{
    Customer cust = customers.FirstOrDefault(x => x.Id == id);

    if (cust == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(new CustomerDTO
    {
        Id = cust.Id,
        Name = cust.Name,
        Address = cust.Address
    });
});


app.Run();

