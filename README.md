## Proje Ekibi Oneri Sistemi Api
ProjeEkibiOneriSistemiApi, öğrenci profillerini analiz ederek yetkinliklerine göre dinamik ve verimli proje ekipleri öneren, .NET 6 ile geliştirilmiş bir RESTful Web API uygulamasıdır.
Bu API; kullanıcı kayıtları, yetenek derecelendirmeleri, kategori bazlı analizler ve proje eşleştirme işlemlerini yönetmek üzere tasarlanmıştır.
Proje ile birlikte entegre çalışacak olan istemciler (örneğin .NET MAUI uygulaması) için güçlü bir backend hizmeti sunar.

## 🚀 Kurulum Adımları

✅ Gereksinimler

- .NET 6 SDK

- SQL Server (LocalDB veya tam sürüm)

- Visual Studio 2022+ veya terminal

## 🔧 Bağlantı Ayarları (appsettings.json)

Aşağıdaki gibi DefaultConnection bağlantı cümlesini düzenleyin:

"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=ProjeEkibiOneriDb;Trusted_Connection=True;TrustServerCertificate=True;"
}

- SQL Server Kimlik Doğrulama:

"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=ProjeEkibiOneriDb;User Id=KULLANICI_ADI;Password=ŞİFRE;TrustServerCertificate=True;"
}

## 🗄️ Veritabanı Migrasyonları

- Add-Migration IlkOlusturma

- Update-Database

## ⚙️ Geliştirme Ortamı

- Uygulama varsayılan olarak Development modunda başlatılır.

- Ortam ve port ayarları Properties/launchSettings.json dosyasından değiştirilebilir.

## 🛠️ Kullanılan Teknolojiler

- ASP.NET Core 6 Web API

- Entity Framework Core

- SQL Server
 
- Swagger / Swashbuckle

## Ekran Görüntüleri

<img width="1450" height="861" alt="image" src="https://github.com/user-attachments/assets/fe5eb0a5-aa54-4a4e-816d-02c8d1e4e966" />

<img width="1463" height="868" alt="image" src="https://github.com/user-attachments/assets/c584bffd-41a0-4a19-91ac-128fbbd64c5d" />

<img width="1476" height="527" alt="image" src="https://github.com/user-attachments/assets/e9a7d0de-0a79-4f33-ad39-0034db8275af" />

<img width="1319" height="724" alt="image" src="https://github.com/user-attachments/assets/c0a4bff7-eee0-4194-8c36-6da139a3ecef" />

<img width="1401" height="775" alt="image" src="https://github.com/user-attachments/assets/353bd035-df68-420c-afd3-be764ba1af6b" />

<img width="1392" height="729" alt="image" src="https://github.com/user-attachments/assets/234d47bc-3604-4af1-b34e-516cf617829e" />


