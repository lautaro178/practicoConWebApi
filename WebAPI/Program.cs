using DAL;
using DAL.DALs;
using DAL.IDALs;
using Microsoft.EntityFrameworkCore;
using BL;
using BL.BLs;
using BL.IBLs;

try
{
    var builder = WebApplication.CreateBuilder(args);

    //For Entity Framework Core
    builder.Services.AddDbContext<DBContext>();

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    /******************************************************************************************************/
    /** Add Dependencies **/
    /******************************************************************************************************/
    #region Inyeccion de dependencias

    //DALs
    builder.Services.AddTransient<IDAL_Personas, DAL_Personas_EF>();

    //BLs
    builder.Services.AddTransient<IBL_Personas, BL_Personas>();

    #endregion


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

    UpdateDatabase();

    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

void UpdateDatabase()
{
    using (var context = new DBContext())
    {
        context?.Database.Migrate();
    }
}