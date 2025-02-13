using CivittaTask.DatabaseProvider;
using CivittaTask.DatabaseProvider.Interfaces;
using CivittaTask.DatabaseProvider.Repositories;
using CivittaTask.Services.Interfaces;
using CivittaTask.Services.Profiles;
using CivittaTask.Services.Services;
using CivittaTask.Shared.Const;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient(HttpClientKeywords.EnricoClientName, config =>
{
    var url = builder.Configuration.GetSection(HttpClientKeywords.EnricoApiUrlSection).Value;
    config.BaseAddress = new Uri(url);
});
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IEnricoService, EnricoService>();
builder.Services.AddScoped<IHolidayService, HolidayService>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IHolidayRepository, HolidayRepository>();
builder.Services.AddScoped<IDayRepository, DayRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<DataContext>(context => 
                 context.UseSqlServer(builder.Configuration.GetConnectionString(DatabaseKeywords.DbNameSection)),
                 ServiceLifetime.Scoped);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
