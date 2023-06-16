// See https://aka.ms/new-console-template for more information

using SampiyonlarLigi;

//Takımları Oluştur
List<Takim> takimlar = new List<Takim>()
            {
                new Takim("Bayern Munich","Almanya"),
                new Takim("Sevilla","İspanya"),
                new Takim("Real Madrid","İspanya"),
                new Takim("Liverpool","İngiltere"),
                new Takim("Juventus","İtalya"),
                new Takim("Paris Saint Germain","Fransa"),
                new Takim("Zenit", "Rusya"),
                new Takim("Porto", "Portekiz"),


                new Takim("Barcelona", "İspanya"),
                new Takim("Atletico Madrid", "İspanya"),
                new Takim("Manchester City", "İngiltere"),
                new Takim("Manchester United", "İngiltere"),
                new Takim("Borussia Dortmund", "Almanya"),
                new Takim("Shakhtar Donetsk", "Ukrayna"),
                new Takim("Chelsea", "İngiltere"),
                new Takim("Ajax", "Hollanda"),


                new Takim("Dynamo Kiev", "Ukrayna"),
                new Takim("Red Bull Salzburg", "Almanya"),
                new Takim("RB Leipzig", "Almanya"),
                new Takim("Internazionale", "İtalya"),
                new Takim("Olympiacos", "Yunanistan"),
                new Takim("Lazio", "İtalya"),
                new Takim("Krasnodar", "Rusya"),
                new Takim("Atalanta", "İtalya"),


                new Takim("Lokomotiv Moskova", "Rusya"),
                new Takim("Marseille", "Fransa"),
                new Takim("Club Brugge", "Belçika"),
                new Takim("Mönchengladbach", "Almanya"),
                new Takim("Galatasaray", "Türkiye"),
                new Takim("Midtjylland", "Danimarka"),
                new Takim("Rennes", "Fransa"),
                new Takim("Ferencvaros", "Macaristan")
                };


List<List<Takim>> torbalar = new List<List<Takim>>();
List<List<Takim>> gruplar = new List<List<Takim>>();

// Menü döngüsü

bool devamEt = true;
while (devamEt)
{
    Menu();
    string secim = Console.ReadLine();

    switch (secim)
    {
        case "1":
            //Torbadaki takımları oluştur ve yazdır
            torbalar = TorbalariOluştur(takimlar);
            TorbalariYazdır(torbalar);
            break;
        case "2":
            //Grupları oluştur ve grupları yazdır
            gruplar =GruplariOlustur(torbalar);
            GruplariYazdir(gruplar);
            break;
       
        case "3":
           //Maçları Oyna
            gruplar = MaclariOyna(gruplar);
            
            break;
        case "4":
            //Puan Tablosu
            gruplar = GrupSiralamaBelirle(gruplar);
            PuanTablosu(gruplar);
            break;
        case "5":
            //Son 16 Takımları
            Son16TakimlariYazdir(gruplar);
            break;
        case "6":
            devamEt = false;
            break;
        default:
            Console.WriteLine("Geçersiz bir seçim yaptınız. Lütfen tekrar deneyin.");
            break;
    }
}
Console.WriteLine("Çıkış");

static void Menu()
{
    Console.WriteLine("************ SIRASI İLE SEÇİM YAP  (1-5): ************");
    Console.WriteLine("1. Torbalardaki Takımları Göster");
    Console.WriteLine("2. Grupları Göster");
    Console.WriteLine("3. Maçları Göster");
    Console.WriteLine("4. Puan Tablosunu Göster");
    Console.WriteLine("5. Son 16'ya Yükselen Takımları Göster");
    Console.WriteLine("6. Çıkış");
}
static List<List<Takim>> TorbalariOluştur(List<Takim> takimlar)
{
    List<List<Takim>> torbalar = new List<List<Takim>>();
    Random random = new Random();

    for (int i = 0; i < 4; i++)
    {
        List<Takim> torba = new List<Takim>();

        for (int j = 0; j < 8; j++)
        {
            int randomNo = random.Next(takimlar.Count);
            Takim takim = takimlar[randomNo];
            torba.Add(takim);
            takimlar.RemoveAt(randomNo);
        }

        torbalar.Add(torba);
    }

    return torbalar;
}
static List<List<Takim>> GruplariOlustur(List<List<Takim>> torbalar)
{
    List<List<Takim>> gruplar = new List<List<Takim>>();//Grup listesi
    Random random = new Random();

    for (int i = 0; i < 8; i++) //Toplamda 8 grup olacak
    {
        List<Takim> grup = new List<Takim>(); //yeni bir grup

        for (int j = 0; j < 4; j++) //her grupta 4 takım olacak
        {
            List<Takim> torba = torbalar[j];//Şuanki torba (ilgili torba)
            List<Takim> uygunTakimlar = new List<Takim>();//Şartı sağlayan takımlar(Bir takım kendi torbasından ve ülkesinden bir takım ile eşleşemeyecektir)

            foreach (Takim takim in torba)//torbadaki takımlar
            {
                bool uygun = true;

                foreach (Takim g in grup)//gruptaki takımlar
                {
                    if (takim.Ulke == g.Ulke || takim.Ad == g.Ad)//Asıl şartımız yani gruplara seçilme şartı
                    {
                        uygun = false;//eğer eşleşirse takım gruba seçilemez
                        break;
                    }
                }

                if (uygun) //takım uygun
                    uygunTakimlar.Add(takim);//şartı sağlayan takımların listesi
            }

            int randomNo = random.Next(uygunTakimlar.Count);//şartı sağlayan takımlar listesinden bir numara seçiliyor
            Takim secilenTakim = uygunTakimlar[randomNo];//seçilen takım
            torba.Remove(secilenTakim);//Burada seçilen takımın silmemizin sebebi bir takım bir kez seçilebilir.
                                       //yani aynı takımın başka bir gruba veya aynı gruba tekrar eklenmemesini sağlar
            grup.Add(secilenTakim);
        }

        gruplar.Add(grup);//Oluşan gruplar ana listetedeki gruplar listesine ekleniyor
    }

    return gruplar;
}
static void TorbalariYazdır(List<List<Takim>> torbalar)
{

    for (int i = 0; i < 4; i++)
    {
        Console.WriteLine("Torba {0}:", i + 1);

        foreach (Takim takim in torbalar[i])
        {
            Console.WriteLine(takim.Ad + " - " + takim.Ulke);
        }

        Console.WriteLine();
    }
}
static void GruplariYazdir(List<List<Takim>> gruplar)
{
    Console.WriteLine("Gruplar");
    for (int i = 0; i < gruplar.Count; i++)
    {
        Console.WriteLine($"Grup {i + 1}");
        List<Takim> grup = gruplar[i];
        foreach (var takim in grup)
        {
            Console.WriteLine($"{takim.Ad} - {takim.Ulke}");
        }
        Console.WriteLine();
    }

}
static List<List<Takim>> MaclariOyna(List<List<Takim>> gruplar)
{
    Random random = new Random();

    foreach (var grup in gruplar)
    {
        for (int i = 0; i < grup.Count; i++)
        {
            for (int j = i + 1; j < grup.Count; j++)
            {
                // Takım i'nin ev sahibi olduğu maçlar
                int evGol = random.Next(9);
                int deplasmanGol = random.Next(9);
                grup[i].AtılanGol += evGol;
                grup[i].YenilenGol += deplasmanGol;
                grup[j].AtılanGol += deplasmanGol;
                grup[j].YenilenGol += evGol;

                if (evGol > deplasmanGol)
                {
                    grup[i].Puan += 3;
                }
                else if (evGol < deplasmanGol)
                {
                    grup[j].Puan += 3;
                }
                else
                {
                    grup[i].Puan += 1;
                    grup[j].Puan += 1;
                }


                // Takım j'nin ev sahibi olduğu maçlar
                int evGol1 = random.Next(9);
                int deplasmanGol1 = random.Next(9);
                grup[j].AtılanGol += evGol1;
                grup[j].YenilenGol += deplasmanGol1;
                grup[i].AtılanGol += deplasmanGol1;
                grup[i].YenilenGol += evGol1;

                if (evGol1 > deplasmanGol1)
                {
                    grup[j].Puan += 3;
                }
                else if (evGol1 < deplasmanGol1)
                {
                    grup[i].Puan += 3;
                }
                else
                {
                    grup[j].Puan += 1;
                    grup[i].Puan += 1;
                }
                // Maç sonuçlarını yazdır
                Console.WriteLine($"{grup[i].Ad} {evGol} - {deplasmanGol} {grup[j].Ad}");
                Console.WriteLine($"{grup[j].Ad} {evGol1} - {deplasmanGol1} {grup[i].Ad}");
                Console.WriteLine();
            }
        }

        // Averaj hesaplama
        foreach (var takim in grup)
        {
            takim.Averaj = takim.AtılanGol - takim.YenilenGol;
        }
    }

    return gruplar;
}

static List<List<Takim>> GrupSiralamaBelirle(List<List<Takim>> gruplar)
{
    foreach (var grup in gruplar)
    {
        grup.Sort((t1, t2) =>
        {
            if (t1.Puan != t2.Puan)
                return t2.Puan.CompareTo(t1.Puan);
            else if (t1.Averaj != t2.Averaj)
                return t2.Averaj.CompareTo(t1.Averaj);
            else if (t1.AtılanGol != t2.AtılanGol)
                return t2.AtılanGol.CompareTo(t1.AtılanGol);
            else
                return 0;
        });
    }

    return gruplar;
}
static List<Takim> Son16TakimlariBelirle(List<List<Takim>> gruplar)
{
    List<Takim> son16Takimlar = new List<Takim>();

    foreach (var grup in gruplar)
    {
        son16Takimlar.Add(grup[0]);
        son16Takimlar.Add(grup[1]);
    }

    return son16Takimlar;
}
static void Son16TakimlariYazdir(List<List<Takim>> gruplar)
{
    List<Takim> son16Takimlar = Son16TakimlariBelirle(gruplar);

    Console.WriteLine("Son 16'ya Yükselen Takımlar:");
    foreach (var takim in son16Takimlar)
    {
        Console.WriteLine(takim.Ad);
    }
}
static void PuanTablosu(List<List<Takim>> gruplar)
{
    Console.WriteLine("Puan Tablosu:");
    for (int i = 0; i < gruplar.Count; i++)
    {
        Console.WriteLine($"Grup {i + 1}:");
        foreach (var takim in gruplar[i])
        {
            Console.WriteLine($"Takım: {takim.Ad} ({takim.Ulke}) - Puan: {takim.Puan} - Averaj: {takim.Averaj} - Atılan Gol: {takim.AtılanGol} - Yenen Gol: {takim.YenilenGol}");
        }
        Console.WriteLine();
    }
}