using FootsalTeam.Contract.UnitOfWork;
using FootsalTeam.Persistance;
using FootsalTeam.Persistance.Players;
using FootsalTeam.Persistance.Teams;
using FootsalTeam.Service.Players;
using FootsalTeam.Service.Players.Contracts;
using FootsalTeam.Service.Teams;
using FootsalTeam.Service.Teams.Contracts;
using Library.Persistant.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TeamRepository,EfTeamRepository>();
builder.Services.AddScoped<PlayerRepository,EFPlayerRepository>();
builder.Services.AddScoped<PlayerService,PlayerAppService>();
builder.Services.AddScoped<TeamService,TeamAppService>();
builder.Services.AddScoped<UnitOfWork,EfUnitOfWork>();
builder.Services.AddDbContext<EFDbContext>(option
    => option.UseSqlServer(builder.Configuration["ConnectionStrings:Database"]));

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
