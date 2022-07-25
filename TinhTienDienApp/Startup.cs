using System.Reflection;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.OpenApi.Models;
using TinhTienDienApp.Handlers;
using TinhTienDienApp.Handlers.Base;
using TinhTienDienApp.Helper;
using TinhTienDienApp.Logics;
using TinhTienDienApp.Mappers;
using TinhTienDienApp.Repositories.ConcreteRepo.Electricity;
using TinhTienDienApp.Repositories.ConcreteRepo.Hanzi;
using TinhTienDienApp.Repositories.ConcreteRepo.RoleRight;

namespace TinhTienDienApp;

public class Startup
{
    public const string SwaggerDocumentVersionName = "v1";
    public const string SwaggerDocumentServiceName = "My Awesome App";
    public const string API_PREFIX = "/Prod";

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();

        services.AddControllers();
        services.AddAutoMapper(typeof(HanziProfile).Assembly);
        services.AddAutoMapper(typeof(UserOutputModelProfile).Assembly);

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(
                SwaggerDocumentVersionName,
                new OpenApiInfo
                {
                    Title = SwaggerDocumentServiceName,
                    Version = $"{SwaggerDocumentVersionName}"
                });
            var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
        });

        services.AddEndpointsApiExplorer();
        var awsOptions = Configuration.GetAWSOptions();
        services.AddDefaultAWSOptions(awsOptions);
        services.AddAWSService<IAmazonDynamoDB>();
        services.AddScoped<IDynamoDBContext, DynamoDBContext>();

        services.AddScoped<IDataHelper, MockedDataHelper>();
        services.AddScoped<ICalculatorHandler, CalculatorHandler>();
        services.AddScoped<Calculator, Calculator>();
        services.AddScoped<HanziRepo>();
        services.AddScoped<IHanziHandler, HanziHandler>();

        services.AddScoped<RightRepo>();
        services.AddScoped<RoleRepo>();
        services.AddScoped<UserRepo>();
        services.AddScoped<ElectricityPriceRepo>();
        services.AddScoped<IUserRoleHandler, UserRoleHandler>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

        app.UseHttpsRedirection();

        // app.UseCors("_myAllowSpecificOrigins");
        app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)
            .AllowCredentials());

        // Enable middleware to serve generated Swagger as a JSON endpoint.
        app.UseSwagger(c => { c.RouteTemplate = "/swagger/{documentName}/swagger.json"; });

        /*
         * The main URL for the API you have released on lambda is https://DNS_URL/API_PREFIX/
Swagger UI needs to fetch the swagger.json file in order for it to work, and for your localhost it is working correctly since https://localhost:5001/swagger/v1/swagger.json is a valid endpoint
(*you have no prefix here)
And the version deployed to lambda is trying to fetch this swagger.json file under
https://DNS_URL/swagger/v1/swagger.json - without your API_PREFIX, thus it's returning 404, not found and swagger ui is displaying the Error message.
Quick fix, which you might apply, that I think would work:

app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "swagger/ui";
    c.SwaggerEndpoint($"{env.IsDevelopment() ? "" : API_PREFIX}/swagger/{SwaggerDocumentVersionName}/swagger.json", SwaggerDocumentServiceName);
});

Where the API_PREFIX is a string starting with '/'
         */
        var prefix = env.IsDevelopment() ? "" : API_PREFIX;
        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
        app.UseSwaggerUI(c =>
        {
            c.RoutePrefix = "swagger/ui";
            c.SwaggerEndpoint($"{prefix}/swagger/{SwaggerDocumentVersionName}/swagger.json",
                SwaggerDocumentServiceName);
        });

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/",
                async context =>
                {
                    await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
                });
        });
    }
}