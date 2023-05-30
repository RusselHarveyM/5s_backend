using _5s.Context;
using _5s.Repositories;
using _5s.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureServices(builder.Services);
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

void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<DapperContext>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IRoomService, RoomService>();
    services.AddScoped<IBuildingService, BuildingService>();
    services.AddScoped<IRatingService, RatingService>();
    services.AddScoped<IRedTagService, RedTagService>();
    services.AddScoped<ISpaceService, SpaceService>();

    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IRoomRepository, RoomRepository>();
    services.AddScoped<IBuildingRepository, BuildingRepository>();
    services.AddScoped<IRatingsRepository, RatingsRepository>();
    services.AddScoped<IRedTagRepository, RedTagRepository>();
    services.AddScoped<ISpaceRepository, SpaceRepository>();


    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}