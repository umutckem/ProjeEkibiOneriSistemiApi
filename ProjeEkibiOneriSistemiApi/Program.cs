
using Microsoft.EntityFrameworkCore;
using ProjeEkibiOneriSistemiApi.EfCore;
using ProjeEkibiOneriSistemiApi.Models;
using ProjeEkibiOneriSistemiApi.Services;

namespace ProjeEkibiOneriSistemiApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var conStr = builder.Configuration
            .GetConnectionString("DefaultConnection") ??
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<OgrenciAnalizDbContext>(options =>
            options.UseSqlServer(conStr));
            
            builder.Services.AddScoped<IOgrenciServices, OgrenciServices>();
            builder.Services.AddScoped<IKategoriServices, KategoriServices>();
            builder.Services.AddScoped<ISoruServices, SoruServices>();
            builder.Services.AddScoped<IKullaniciYanitiServices, KullaniciYanitiServices>();

            // Add services to the container.
            builder.Services.AddAuthorization();

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

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //Ogrenci App'leri

            app.MapGet("/Ogrenci", async (IOgrenciServices ogrenciServices) =>
            {
                var ogrenciler = await ogrenciServices.GetOgrencis();
                return Results.Ok(ogrenciler);
            });

            app.MapPost("/Ogrenci", async (IOgrenciServices ogrenciServices, Ogrenci ogrenci) =>
            {
                await ogrenciServices.ogrenciEkle(ogrenci);
                return Results.Created($"/Ogrenci/{ogrenci.Id}", ogrenci);
            });

            app.MapPut("/Ogrenci/{id}", async (IOgrenciServices ogrenciServices, Guid id, Ogrenci ogrenci) =>
            {
                var existingStudent = await ogrenciServices.GetOgrencis();
                if (!existingStudent.Any(o => o.Id == id))
                {
                    return Results.NotFound($"ID {id} olan öðrenci bulunamadý.");
                }

                ogrenci.Id = id; // ID'nin deðiþmemesini saðla
                await ogrenciServices.ogrenciGuncelle(ogrenci);
                return Results.Ok(ogrenci);
            });

            app.MapDelete("/Ogrenci/{id}", async (IOgrenciServices ogrenciServices, Guid id) =>
            {
                var existingStudent = await ogrenciServices.GetOgrencis();
                if (!existingStudent.Any(o => o.Id == id))
                {
                    return Results.NotFound($"ID {id} olan öðrenci bulunamadý.");
                }

                await ogrenciServices.ogrenciSil(id);
                return Results.Ok($"ID {id} olan öðrenci silindi.");
            });

            //Kategori App'leri

            app.MapGet("/Kategori", async (IKategoriServices kategoriServices) =>
            {
                var ogrenciler = await kategoriServices.GetKategoriListAsync();
                return Results.Ok(ogrenciler);
            });

            app.MapPost("/Kategori", async (IKategoriServices kategoriServices, Kategori kategori) =>
            {
                await kategoriServices.ekleKategori(kategori);
                return Results.Created($"/Kategori/{kategori.Id}", kategori);
            });

            app.MapDelete("/Kategori/{id}", async (IKategoriServices kategoriServices, int id) =>
            {
                var existingKategori = await kategoriServices.GetKategoriListAsync();
                if (!existingKategori.Any(o => o.Id == id))
                {
                    return Results.NotFound($"ID {id} olan Kategori bulunamadý.");
                }

                await kategoriServices.removeKategori(id);
                return Results.Ok($"ID {id} olan Kategori silindi.");
            });

            //Soru App'leri

            app.MapGet("/Soru", async (ISoruServices soruServices) =>
            {
                var ogrenciler = await soruServices.GetSorus();
                return Results.Ok(ogrenciler);
            });

            app.MapPost("/Soru", async (ISoruServices soruServices, Soru soru) =>
            {
                await soruServices.ekleSoru(soru);
                return Results.Created($"/Kategori/{soru.Id}", soru);
            });

            app.MapPut("/Soru/{id}", async (ISoruServices soruServices, int id, Soru soru) =>
            {
                var existingSoru = await soruServices.GetSorus();
                if (!existingSoru.Any(o => o.Id == id))
                {
                    return Results.NotFound($"ID {id} olan Soru bulunamadý.");
                }

                soru.Id = id; // ID'nin deðiþmemesini saðla
                await soruServices.guncelleSoru(soru);
                return Results.Ok(soru);
            });

            app.MapDelete("/Soru/{id}", async (ISoruServices soruServices, int id) =>
            {
                var existingKategori = await soruServices.GetSorus();
                if (!existingKategori.Any(o => o.Id == id))
                {
                    return Results.NotFound($"ID {id} olan Soru bulunamadý.");
                }

                await soruServices.silSoru(id);
                return Results.Ok($"ID {id} olan Soru silindi.");
            });

            //Kullanici App'leri

            app.MapGet("/Yanitlar", async (IKullaniciYanitiServices kullaniciYanitiServices) =>
            {
                var ogrenciler = await kullaniciYanitiServices.GetKullaniciYanitis();
                return Results.Ok(ogrenciler);
            });

            app.MapPost("/Yanitlar", async (IKullaniciYanitiServices kullaniciYanitiServices, KullaniciYaniti kullaniciYaniti) =>
            {
                await kullaniciYanitiServices.ekleKullaniciYaniti(kullaniciYaniti);
                return Results.Created($"/Kategori/{kullaniciYaniti.Id}", kullaniciYaniti);
            });

            app.MapDelete("/Yanitlar/{id}", async (IKullaniciYanitiServices KullaniciYanitiServices, int id) =>
            {
                var existingYanit = await KullaniciYanitiServices.GetKullaniciYanitis();
                if (!existingYanit.Any(o => o.Id == id))
                {
                    return Results.NotFound($"ID {id} olan Kullanici bulunamadý.");
                }

                await KullaniciYanitiServices.silKullaniciYaniti(id);
                return Results.Ok($"ID {id} olan Yanýt silindi.");
            });


            app.Run();
        }
    }
}
