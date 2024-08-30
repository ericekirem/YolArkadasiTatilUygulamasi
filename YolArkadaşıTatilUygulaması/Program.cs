using System;

class Program
{
    static void Main()
    {
        bool devam = true;

        while (devam)
        {
            // Lokasyonlar ve başlangıç fiyatları
            var lokasyonlar = new (string Ad, int Fiyat)[]
            {
                ("Bodrum", 4000),
                ("Marmaris", 3000),
                ("Çeşme", 5000)
            };

            // Kullanıcıdan lokasyon seçimini alma
            string secilenLokasyon = "";
            int lokasyonFiyati = 0;

            while (true)
            {
                Console.WriteLine("Lütfen gitmek istediğiniz lokasyonu seçin: Bodrum, Marmaris, Çeşme");
                secilenLokasyon = Console.ReadLine().Trim();

                // Büyük-küçük harf duyarlılığını kaldırma ve lokasyon doğrulama
                var lokasyon = Array.Find(lokasyonlar, l => l.Ad.Equals(secilenLokasyon, StringComparison.OrdinalIgnoreCase));

                if (lokasyon.Ad != null)
                {
                    secilenLokasyon = lokasyon.Ad;
                    lokasyonFiyati = lokasyon.Fiyat;
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı bir lokasyon girdiniz. Geçerli lokasyonlar: Bodrum, Marmaris, Çeşme");
                }
            }

            // Kullanıcıdan kişi sayısını alma
            Console.WriteLine("Kaç kişi için tatil planlamak istiyorsunuz?");
            int kisiSayisi = int.Parse(Console.ReadLine());

            // Lokasyon ve özet bilgiyi yazdırma
            Console.WriteLine($"Seçtiğiniz Lokasyon: {secilenLokasyon}");
            Console.WriteLine($"{secilenLokasyon} için başlangıç fiyatı: {lokasyonFiyati} TL");

            // Kullanıcıdan ulaşım yöntemi seçimini alma
            int ulasimTutari = 0;
            while (true)
            {
                Console.WriteLine("Tatiline ne şekilde gitmek istiyorsunuz?");
                Console.WriteLine("1 - Kara yolu (Kişi başı ulaşım tutarı gidiş-dönüş 1500 TL)");
                Console.WriteLine("2 - Hava yolu (Kişi başı ulaşım tutarı gidiş-dönüş 4000 TL)");
                Console.WriteLine("Lütfen yukarıdaki seçeneklerden bir tanesini seçiniz: ");
                string ulasimSecimi = Console.ReadLine();

                if (ulasimSecimi == "1")
                {
                    ulasimTutari = 1500;
                    break;
                }
                else if (ulasimSecimi == "2")
                {
                    ulasimTutari = 4000;
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı bir değer girdiniz, lütfen 1 ya da 2 seçeneklerinden birini seçiniz.");
                }
            }

            // Toplam fiyat hesaplama
            int toplamFiyat = lokasyonFiyati + (ulasimTutari * kisiSayisi);
            Console.WriteLine($"Toplam Fiyat: {toplamFiyat} TL");

            // Kullanıcıya başka bir tatil planlamak isteyip istemediğini sorma
            Console.WriteLine("Başka bir tatil planlamak ister misiniz? (E/H)");
            string devamCevap = Console.ReadLine().Trim().ToUpper();

            if (devamCevap != "E")
            {
                devam = false;
                Console.WriteLine("İyi günler!");
            }
        }
    }
}
