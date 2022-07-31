using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using Repositories.GeneratedModels;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var cs = builder.Configuration["MyDBConnectionString"];
builder.Services.AddDbContext<MyDBContext>(options => options.UseNpgsql(cs));

builder.Services.AddMailKit(optionBuilder =>
{
    optionBuilder.UseMailKit(new MailKitOptions()
    {
        //get options from sercets.json
        Server = builder.Configuration["Server"],
        Port = Convert.ToInt32(builder.Configuration["Port"]),
        SenderName = builder.Configuration["SenderName"],
        SenderEmail = builder.Configuration["SenderEmail"],
        // can be optional with no authentication 
        Account = builder.Configuration["Account"],
        Password = builder.Configuration["Password"],
        // enable ssl or tls
        Security = true
    });
});
builder.Services.AddScoped<EmailManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();