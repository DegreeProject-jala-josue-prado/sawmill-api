using System.Text.Json.Serialization;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using yume_api.src.profiles;
using yume_api.src.repository.entities;
using yume_api.src.repository.repositories.concrets;
using yume_api.src.repository.repositories.interfaces;
using yume_api.src.valodator.concret;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    //options.Filters.Add<ErrorHandler>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BaseContext>(options
    => options.UseNpgsql(builder.Configuration.GetConnectionString("UniversityDb")));

//builder.Logging.AddLog4Net("log.config");
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IValidator<User>, UserValidator>();

builder.Services.AddControllers()
                                .AddJsonOptions(x
                                        => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

// builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// builder.Services.AddMediatR(typeof(UniversityProfile).Assembly);
// builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UniversityProfile).Assembly));

builder.Services.AddAutoMapper(typeof(UniversityProfile).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BaseContext>();
    context.Database.Migrate();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
