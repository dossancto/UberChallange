using UberChallange.Adapters;
using UberChallange.Application.Services;
using UberChallange.Infra.EmailSender.Mailgun;

using DotNetEnv;
Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<MailgunConfiguration>();
builder.Services.AddScoped<IEmailSenderGateway, MailGunEmailSender>();
builder.Services.AddScoped<EmailSenderService>();

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
