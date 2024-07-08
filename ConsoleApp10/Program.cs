using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karışık_kütüphane_yönetimi
{

    public abstract class Medya
    {
        public string Baslik { get; set; }
        public string Yayinci { get; set; }
        public int YayinYili { get; set; }

        public Medya(string baslik, string yayinci, int yayinYili)
        {
            Baslik = baslik;
            Yayinci = yayinci;
            YayinYili = yayinYili;
        }
        public abstract void BilgileriGoster();
    }
    public interface IKitap
    {
        void KitapBilgisi();
    }
    public interface IDergi
    {
        void DergiBilgisi();
    }
    public interface IDijitalMedya
    {
        void DijitalMedyaBilgisi();
    }
    public class Kitap : Medya, IKitap
    {
        public string Yazar { get; set; }
        public int SayfaSayisi { get; set; }
        public Kitap(string yazar, string yayinci, int yayinYili, string baslik, int sayfa) : base(baslik, yayinci, yayinYili)
        {
            SayfaSayisi = sayfa;
            Yazar = yazar;
        }


        public override void BilgileriGoster()
        {
            Console.WriteLine($"Kitap: {Baslik} ,yazar: {Yazar}, Yayıncı: {Yayinci}, yayın yılı: {YayinYili}, sayfa sayisi: {SayfaSayisi}");
        }

        public void KitapBilgisi()
        {
            Console.WriteLine($"{Baslik} kitap bilgisi gösteriliyor..");
        }
    }
    public class Dergi : Medya, IDergi
    {
        public int Sayi { get; set; }
        public Dergi(string baslik, string yayinci, int yayinYili, int sayi) : base(baslik, yayinci, yayinYili)
        {
            Sayi = sayi;
        }
        public override void BilgileriGoster()
        {
            Console.WriteLine($"Dergi: {Baslik} , Sayı: {Sayi} ,Yayıncı: {Yayinci} , Yayın yılı: {YayinYili}");
        }

        public void DergiBilgisi()
        {
            Console.WriteLine($"{Baslik}  dergisi bilgisi gösteriliyor.");
        }
    }
    public class DigitalMedya : Medya, IDijitalMedya
    {
        public string DosyaFormatı { get; set; }
        public double DosyaBoyutu { get; set; }
        public DigitalMedya(string baslik, string yayinci, int yayinYili, string dosyaFormatı, double dosyaBoyutu) : base(baslik, yayinci, yayinYili)
        {
            DosyaFormatı = dosyaFormatı;
            DosyaBoyutu = dosyaBoyutu;
        }

        public override void BilgileriGoster()
        {
            Console.WriteLine($"Dijital Medya: {Baslik}, Dosya formatı: {DosyaFormatı}" +
                $",Yayıncı: {Yayinci} , Yayın yılı: {YayinYili},Dosya boyutu: {DosyaBoyutu} MB");
        }

        public void DijitalMedyaBilgisi()
        {
            Console.WriteLine($"{Baslik} dijital medyası gösteriliyor.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Kitap kitap = new Kitap("nesne", "yayınevi b", 2024, "bitiş", 1000);
            kitap.BilgileriGoster();
            kitap.KitapBilgisi();

            Dergi dergi = new Dergi("bilim ve teknik", "TÜBİTAK", 2021, 750);
            dergi.BilgileriGoster();
            dergi.DergiBilgisi();

            DigitalMedya diji = new DigitalMedya("e-kitap", "dijital yayınevi", 2020, "pdf", 1.5);
            diji.BilgileriGoster();
            diji.DijitalMedyaBilgisi();

            List<Medya> medyalist = new List<Medya> { kitap, dergi, diji };
            foreach (Medya medya in medyalist)
            {
                medya.BilgileriGoster();
            }
            IKitap kitaparayuz = kitap;
            kitaparayuz.KitapBilgisi();

            IDergi dergiarayuz = dergi;
            dergiarayuz.DergiBilgisi();

            IDijitalMedya dijiarayuz = diji;
            diji.DijitalMedyaBilgisi();
        }
    }
}

