using FormatTCC.API.Configurations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigureApi();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureDataBase(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureDependencyInjection();
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureMediatR();
builder.Services.ConfigureFluentValidation();
builder.Services.ConfigureFilters();

var app = builder.Build();

app.ConfigureApiApps();

