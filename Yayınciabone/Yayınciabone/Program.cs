using System;
using System.Collections.Generic;

// IYayinci Arayüzü
interface IYayinci
{
    void AboneEkle(IAbone abone);
    void AboneCikar(IAbone abone);
    void BildirimGonder(string mesaj);
}

// IAbone Arayüzü
interface IAbone
{
    void BilgiAl(string mesaj);
}

// Yayinci Sınıfı
class Yayinci : IYayinci
{
    private List<IAbone> aboneler = new List<IAbone>();

    public void AboneEkle(IAbone abone)
    {
        aboneler.Add(abone);
        Console.WriteLine("Abone eklendi.");
    }

    public void AboneCikar(IAbone abone)
    {
        aboneler.Remove(abone);
        Console.WriteLine("Abone çıkarıldı.");
    }

    public void BildirimGonder(string mesaj)
    {
        Console.WriteLine("Yayıncıdan mesaj: " + mesaj);
        foreach (var abone in aboneler)
        {
            abone.BilgiAl(mesaj);
        }
    }
}

// Abone Sınıfı
class Abone : IAbone
{
    public string Ad { get; set; }

    public Abone(string ad)
    {
        Ad = ad;
    }

    public void BilgiAl(string mesaj)
    {
        Console.WriteLine($"{Ad} adlı abone bilgilendirildi: {mesaj}");
    }
}

// Program
class Program
{
    static void Main(string[] args)
    {
        Yayinci yayinci = new Yayinci();

        Abone abone1 = new Abone("YİĞİT");
        Abone abone2 = new Abone("HELİN");
        Abone abone3 = new Abone("HİVİ");

        yayinci.AboneEkle(abone1);
        yayinci.AboneEkle(abone2);
        yayinci.AboneEkle(abone3);

        yayinci.BildirimGonder("Yeni bir makale yayınlandı!");

        yayinci.AboneCikar(abone2);

        yayinci.BildirimGonder("Yeni bir video yayınlandı!");
    }
}