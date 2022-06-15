var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//We have to add Cors
builder.Services.AddCors(
    (builder) => {
                    builder.AddDefaultPolicy((policy) => {
                        //Make sure the origin is exact
                        //http://localhost:3000 != http://localhost:3000/ they are NOT the same!
                        policy.WithOrigins("http://localhost:3000", "https://localhost:3000","http://localhost:5000","http://pokemonapireston-env.eba-3kaqziuz.us-east-1.elasticbeanstalk.com:5000")
                            .AllowAnyHeader() //Allows any header we provide in the http header request
                            .AllowAnyMethod(); //Allows any method we provide in the http request
                    });
                }
);

builder.Services.AddControllers();
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

//This is another line you have to add to enable CORS
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
