# ProjeEkibiOneriSistemiApi

# Swagger Ekranı

![image](https://github.com/user-attachments/assets/d98bddd7-640f-4046-b54f-378ce415eae9)


# Kurulum

ProjeEkibiOneriSistemiApi projesini çalıştırmak için öncelikle bilgisayarınızda .NET 6 SDK (veya üzeri) ile birlikte SQL Server kurulu olmalıdır. Proje klasörü açıldıktan sonra appsettings.json dosyasında yer alan bağlantı cümlesi (ConnectionString) düzenlenmelidir. Örneğin: "Server=.;Database=ProjeEkibiOneriDb;Trusted_Connection=True;TrustServerCertificate=True;" şeklinde yerel SQL Server bağlantısı yapılabilir. Eğer SQL kimlik doğrulaması kullanılacaksa bu ifade "User Id=...;Password=...;" şeklinde güncellenmelidir. Bağlantı ayarları tamamlandıktan sonra API projesi terminal veya Visual Studio üzerinden açılır. Ardından Entity Framework Core kullanılarak ilk migration işlemi gerçekleştirilir. Bunun için Add-Migration [İsim] komutu çalıştırılır. Migration işlemi tamamlandıktan sonra update-database komutu ile veritabanı oluşturulur ve ilgili tablolar otomatik olarak eklenir. Tüm bu işlemler başarıyla tamamlandıktan sonra API dotnet run komutu ile çalıştırılır. Uygulama açıldığında varsayılan olarak Swagger arayüzü aktif olur ve tarayıcı üzerinden https://localhost:.../swagger adresinden API uç noktalarına erişim sağlanabilir. Bu sayede sistem test edilebilir ve diğer servislerle entegrasyon gerçekleştirilebilir. Proje geliştirme ortamı varsayılan olarak Development modunda çalışmaktadır ve ihtiyaç halinde launchSettings.json dosyasından port ya da ortam ayarları güncellenebilir.
