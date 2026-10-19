using System;
using System.Collections.Generic;

class Item
{
    public string Judul { get; set; }
    public int Tahun { get; set; }

    public Item(string judul, int tahun)
    {
        Judul = judul;
        Tahun = tahun;
    }

    public virtual string Deskripsi()
    {
        return $"Item: {Judul}, Tahun: {Tahun}";
    }

    public void InfoItem()
    {
        Console.WriteLine(Deskripsi());
    }
}

class Buku : Item
{
    public string Penulis { get; set; }

    public Buku(string judul, int tahun, string penulis)
        : base(judul, tahun)
    {
        Penulis = penulis;
    }

    public void CekPenulis()
    {
        Console.WriteLine($"Penulis: {Penulis}");
    }

    public override string Deskripsi()
    {
        return $"Buku: {Judul}, Tahun: {Tahun}, Penulis: {Penulis}";
    }
}

class Majalah : Item
{
    public int Edisi { get; set; }

    public Majalah(string judul, int tahun, int edisi)
        : base(judul, tahun)
    {
        Edisi = edisi;
    }

    public void InfoEdisi()
    {
        Console.WriteLine($"Edisi: {Edisi}");
    }

    public override string Deskripsi()
    {
        return $"Majalah: {Judul}, Tahun: {Tahun}, Edisi: {Edisi}";
    }
}

class Novel : Buku
{
    public Novel(string judul, int tahun, string penulis)
        : base(judul, tahun, penulis) { }

    public void BacaSinopsis()
    {
        Console.WriteLine($"Sinopsis novel {Judul}: kisah yang menyentuh dan penuh makna.");
    }

    public override string Deskripsi()
    {
        return $"Novel: {Judul}, Tahun: {Tahun}, Penulis: {Penulis}";
    }
}

class Komik : Buku
{
    public Komik(string judul, int tahun, string penulis)
        : base(judul, tahun, penulis) { }

    public void TampilkanIlustrasi()
    {
        Console.WriteLine($"Ilustrasi komik {Judul}");
    }

    public override string Deskripsi()
    {
        return $"Komik: {Judul}, Tahun: {Tahun}, Penulis: {Penulis}";
    }
}

class MajalahAnak : Majalah
{
    public MajalahAnak(string judul, int tahun, int edisi)
        : base(judul, tahun, edisi) { }

    public void KategoriAnak()
    {
        Console.WriteLine($"{Judul} adalah majalah anak.");
    }

    public override string Deskripsi()
    {
        return $"Majalah Anak: {Judul}, Tahun: {Tahun}, Edisi: {Edisi}";
    }
}

class MajalahTeknologi : Majalah
{
    public MajalahTeknologi(string judul, int tahun, int edisi)
        : base(judul, tahun, edisi) { }

    public void TopikTeknologi()
    {
        Console.WriteLine($"{Judul} membahas tentang teknologi.");
    }

    public override string Deskripsi()
    {
        return $"Majalah Teknologi: {Judul}, Tahun: {Tahun}, Edisi: {Edisi}";
    }
}

class Perpustakaan
{
    private List<Item> koleksi = new List<Item>();

    public void TambahItem(Item item)
    {
        koleksi.Add(item);
    }

    public void DaftarItem()
    {
        foreach (Item item in koleksi)
        {
            item.InfoItem();
        }
    }
}

class Program
{
    static void Main()
    {
        Perpustakaan perpustakaan = new Perpustakaan();

        Buku buku = new Buku("Pemrograman Dasar", 2022, "Budi Santoso");
        Novel novel = new Novel("Laskar Pelangi", 2005, "Andrea Hirata");
        Komik komik = new Komik("Doraemon", 1970, "Fujiko F. Fujio");
        Majalah majalah = new Majalah("Kawanku", 2022, 3);
        MajalahAnak majalahAnak = new MajalahAnak("Bobo", 2020, 15);
        MajalahTeknologi majalahTeknologi = new MajalahTeknologi("Chip", 2025, 20);

        perpustakaan.TambahItem(buku);
        perpustakaan.TambahItem(novel);
        perpustakaan.TambahItem(komik);
        perpustakaan.TambahItem(majalah);
        perpustakaan.TambahItem(majalahAnak);
        perpustakaan.TambahItem(majalahTeknologi);

        Console.WriteLine("=== DAFTAR ITEM ===");
        perpustakaan.DaftarItem();

        Console.WriteLine("\n=== POLYMORPHISM ===");
        List<Item> semua = new List<Item>
        {
            buku, novel, komik, majalah, majalahAnak, majalahTeknologi
        };
        foreach (Item item in semua)
        {
            Console.WriteLine(item.Deskripsi());
        }

        Console.WriteLine("\n=== METHOD KHUSUS ===");
        buku.CekPenulis();
        majalah.InfoEdisi();
        novel.BacaSinopsis();
        komik.TampilkanIlustrasi();
        majalahAnak.KategoriAnak();
        majalahTeknologi.TopikTeknologi();

        Console.WriteLine("\n=== SOAL 1 ===");
        Console.WriteLine(novel.Deskripsi());
        Console.WriteLine(majalah.Deskripsi());

        Console.WriteLine("\n=== SOAL 2 ===");
        novel.BacaSinopsis();

        Console.WriteLine("\n=== SOAL 3 ===");
        Console.WriteLine($"Judul: {novel.Judul}, Tahun: {novel.Tahun}, Penulis: {novel.Penulis}");
        novel.InfoItem();

        Console.WriteLine("\n=== SOAL 4 ===");
        majalahTeknologi.TopikTeknologi();

        Console.WriteLine("\n=== SOAL 5 ===");
        Item itemKomik = new Komik("One Piece", 1997, "Eiichiro Oda");
        Console.WriteLine(itemKomik.Deskripsi());
              
        ((Komik)itemKomik).TampilkanIlustrasi(); 

        Console.ReadKey();
    }
}