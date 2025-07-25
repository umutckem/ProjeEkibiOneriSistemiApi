
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
            builder.Services.AddScoped<IProjeServices, ProjeServices>();
            builder.Services.AddScoped<IOgrenciProjeServices, OgrenciProjeServices>();
            builder.Services.AddScoped<IKatilimciServices, KatilimciServices>();
            builder.Services.AddScoped<IGrupServices, GrupServices>();
            builder.Services.AddScoped<IDestekServices, DestekServices>();
            builder.Services.AddScoped<IRolServices, RolServices>();
            builder.Services.AddScoped<IYetkiServices, YetkiServices>();

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
                    return Results.NotFound($"ID {id} olan ��renci bulunamad�.");
                }

                ogrenci.Id = id; // ID'nin de�i�memesini sa�la
                await ogrenciServices.ogrenciGuncelle(ogrenci);
                return Results.Ok(ogrenci);
            });

            app.MapDelete("/Ogrenci/{id}", async (IOgrenciServices ogrenciServices, Guid id) =>
            {
                var existingStudent = await ogrenciServices.GetOgrencis();
                if (!existingStudent.Any(o => o.Id == id))
                {
                    return Results.NotFound($"ID {id} olan ��renci bulunamad�.");
                }

                await ogrenciServices.ogrenciSil(id);
                return Results.Ok($"ID {id} olan ��renci silindi.");
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
                    return Results.NotFound($"ID {id} olan Kategori bulunamad�.");
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
                    return Results.NotFound($"ID {id} olan Soru bulunamad�.");
                }

                soru.Id = id; // ID'nin de�i�memesini sa�la
                await soruServices.guncelleSoru(soru);
                return Results.Ok(soru);
            });

            app.MapDelete("/Soru/{id}", async (ISoruServices soruServices, int id) =>
            {
                var existingKategori = await soruServices.GetSorus();
                if (!existingKategori.Any(o => o.Id == id))
                {
                    return Results.NotFound($"ID {id} olan Soru bulunamad�.");
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
                    return Results.NotFound($"ID {id} olan Kullanici bulunamad�.");
                }

                await KullaniciYanitiServices.silKullaniciYaniti(id);
                return Results.Ok($"ID {id} olan Yan�t silindi.");
            });

            //Proje App'leri

            app.MapGet("/Projeler", async (IProjeServices projeServices) =>
            {
                var Projeler = await projeServices.GetProjeler();
                return Results.Ok(Projeler);
            });

            app.MapPost("/Projeler", async (IProjeServices projeServices, Proje proje) =>
            {
                await projeServices.projeEkle(proje);
                return Results.Created($"/Kategori/{proje.Id}", proje);
            });

            app.MapPut("/Projeler/{id}", async (IProjeServices projeServices, Guid id, Proje proje) =>
            {
                var existingProje = await projeServices.GetProjeler();
                if (!existingProje.Any(o => o.Id == id))
                {
                    return Results.NotFound($"ID {id} olan proje bulunamad�.");
                }

                proje.Id = id; // ID'nin de�i�memesini sa�la
                await projeServices.projeGuncelle(proje);
                return Results.Ok(proje);
            });

            app.MapDelete("/Projeler/{id}", async (IProjeServices projeServices, Guid id) =>
            {
                var existingProje = await projeServices.GetProjeler();
                if (!existingProje.Any(o => o.Id == id))
                {
                    return Results.NotFound($"ID {id} olan Proje bulunamad�.");
                }

                await projeServices.projeSil(id);
                return Results.Ok($"ID {id} olan proje silindi.");
            });

            //OgrenciProje App'leri


            app.MapGet("/OgrenciProjeler", async (IOgrenciProjeServices ogrenciProjeServices) =>
            {
                var ogrenciProjeler = await ogrenciProjeServices.GetOgrenciProjeler();
                return Results.Ok(ogrenciProjeler);
            });

            app.MapPost("/OgrenciProjeler", async (IOgrenciProjeServices ogrenciProjeServices, OgrenciProje ogrenciProje) =>
            {
                await ogrenciProjeServices.ekleOgrenciProje(ogrenciProje);
                return Results.Created($"/Kategori/{ogrenciProje.Id}", ogrenciProje);
            });

            app.MapPut("/OgrenciProjeler/{id}", async (IOgrenciProjeServices ogrenciProjeServices, int id, OgrenciProje ogrenciProje) =>
            {
                var existingOgrenciProje = await ogrenciProjeServices.GetOgrenciProjeler();
                if (!existingOgrenciProje.Any(o => o.Id == id))
                {
                    return Results.NotFound($"ID {id} olan ogrenci projesi bulunamad�.");
                }

                ogrenciProje.Id = id; // ID'nin de�i�memesini sa�la
                await ogrenciProjeServices.guncelleOgrenciProje(ogrenciProje);
                return Results.Ok(ogrenciProje);
            });

            app.MapDelete("/OgrenciProjeler/{id}", async (IOgrenciProjeServices ogrenciProjeServices, int id) =>
            {
                var existingOgrenciProje = await ogrenciProjeServices.GetOgrenciProjeler();
                if (!existingOgrenciProje.Any(o => o.Id == id))
                {
                    return Results.NotFound($"ID {id} olan ogrenci Projesi bulunamad�.");
                }

                await ogrenciProjeServices.silOgrenciProje(id);
                return Results.Ok($"ID {id} olan ogrenci projesi silindi.");
            });
            

            //Katilimci App'leri

            app.MapGet("/Katilimcilar", async (IKatilimciServices katilimciServices) =>
            {
                var Katilimcilar = await katilimciServices.GetKatilimcis();
                return Results.Ok(Katilimcilar);
            });

            app.MapPost("/Katilimcilar", async (IKatilimciServices katilimciServices, Katilimci katilimci) =>
            {
                await katilimciServices.KatlilimciEkle(katilimci);
                return Results.Created($"/Kategori/{katilimci.Id}", katilimci);
            });

            app.MapDelete("/Katilimcilar/{id}", async (IKatilimciServices katilimciServices, Guid id) =>
            {
                var existingOgrenciProje = await katilimciServices.GetKatilimcis();
                if (!existingOgrenciProje.Any(o => o.Id == id))
                {
                    return Results.NotFound($"ID {id} olan Katilimci Projesi bulunamad�.");
                }

                await katilimciServices.KatilimciSil(id);
                return Results.Ok($"ID {id} olan Katilimci projesi silindi.");
            });



            //Grup App'leri


            app.MapGet("/grup", async (IGrupServices grupServices) =>
            {
                var gruplar = await grupServices.getGrups();
                return Results.Ok(gruplar);
            });

            app.MapPost("/grup", async (IGrupServices grupServices, Grup grup) =>
            {
                await grupServices.ekleGrup(grup);
                return Results.Created($"/Kategori/{grup.Id}", grup);
            });

            app.MapPut("/grup/{id}", async (IGrupServices grupServices, Guid id, Grup grup) =>
            {
                var existingGrup = await grupServices.getGrups();
                if (!existingGrup.Any(o => o.Id == id))
                {
                    return Results.NotFound($"ID {id} olan grup bulunamad�.");
                }

                grup.Id = id; // ID'nin de�i�memesini sa�la
                await grupServices.guncelleGrup(grup);
                return Results.Ok(grup);
            });

            app.MapDelete("/grup/{id}", async (IGrupServices grupServices, Guid id) =>
            {
                var existingOgrenciProje = await grupServices.getGrups();
                if (!existingOgrenciProje.Any(o => o.Id == id))
                {
                    return Results.NotFound($"ID {id} olan grup bulunamad�.");
                }

                await grupServices.silGrup(id);
                return Results.Ok($"ID {id} olan grup silindi.");
            });

            //Destek App'leri

            app.MapGet("/Destek", async (IDestekServices destekServices) =>
            {
                var Destekler = await destekServices.GetAllDestek();
                return Results.Ok(Destekler);
            });

            app.MapPost("/Destek", async (IDestekServices destekServices, Destek destek) =>
            {
                await destekServices.ekleDestek(destek);
                return Results.Created($"/Kategori/{destek.Id}", destek);
            });

            app.MapDelete("/Destek/{id}", async (IDestekServices destekServices, int id) =>
            {
                var existingDestek = await destekServices.GetAllDestek();
                if (!existingDestek.Any(o => o.Id == id))
                {
                    return Results.NotFound($"ID {id} olan destek bulunamad�.");
                }

                await destekServices.silDestek(id);
                return Results.Ok($"ID {id} olan destek silindi.");
            });

            //Rol App'leri

            app.MapGet("/Rol", async (IRolServices rolServices) =>
            {
                var Roller = await rolServices.GetAllRol();
                return Results.Ok(Roller);
            });

            app.MapPost("/Rol", async (IRolServices rolServices, Rol rol) =>
            {
                await rolServices.ekleRol(rol);
                return Results.Created($"/Kategori/{rol.Id}", rol);
            });

            app.MapDelete("/Rol/{id}", async (IRolServices rolServices, Guid id) =>
            {
                var existingRol = await rolServices.GetAllRol();
                if (!existingRol.Any(o => o.Id == id))
                {
                    return Results.NotFound($"ID {id} olan rol bulunamad�.");
                }

                await rolServices.silRol(id);
                return Results.Ok($"ID {id} olan rol silindi.");
            });

            //Yetki App'leri


            app.MapGet("/Yetki", async (IYetkiServices yetkiServices) =>
            {
                var yetkiler = await yetkiServices.GetYetkis();
                return Results.Ok(yetkiler);
            });

            app.MapPost("/Yetki", async (IYetkiServices yetkiServices, Yetki yetki) =>
            {
                await yetkiServices.ekleYetki(yetki);
                return Results.Created($"/Kategori/{yetki.Id}", yetki);
            });

            app.MapPut("/Yetki/{id}", async (IYetkiServices yetkiServices, Guid id, Yetki yetki) =>
            {
                var existingYetkiler = await yetkiServices.GetYetkis();
                if (!existingYetkiler.Any(o => o.Id == id))
                {
                    return Results.NotFound($"ID {id} olan yetki bulunamad�.");
                }

                yetki.Id = id; // ID'nin de�i�memesini sa�la
                await yetkiServices.guncelleYetki(yetki);
                return Results.Ok(yetki);
            });

            app.MapDelete("/Yetki/{id}", async (IYetkiServices yetkiServices, Guid id) =>
            {
                var existingYetkiler = await yetkiServices.GetYetkis();
                if (!existingYetkiler.Any(o => o.Id == id))
                {
                    return Results.NotFound($"ID {id} olan yetki bulunamad�.");
                }

                await yetkiServices.silYetki(id);
                return Results.Ok($"ID {id} olan yetki silindi.");
            });

            app.Run();
        }
    }
}
