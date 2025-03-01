namespace ProjeEkibiOneriSistemiApi.Models
{
    public class Ogrenci
    {
        public Guid Id { get; set; } 
        public string Ad { get; set; } 
        public string Soyad { get; set; } 
        public string Email { get; set; } 
        public string Telefon { get; set; } 
        public string Bolum { get; set; } 
        public int Sinif { get; set; } 

    }
}
