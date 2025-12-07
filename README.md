# JahitPintar 🧵✨

> **Inovasi AI: Mendorong Usaha Lokal dengan AI Inklusif**
> *Diajukan untuk Hackathon IMPHNEN bersama Kolosal.ai*

**JahitPintar** adalah platform manajemen cerdas yang dirancang khusus untuk penjahit rumahan dan UMKM konveksi. Aplikasi ini mendigitalkan pencatatan pelanggan yang selama ini manual, serta memanfaatkan kecerdasan buatan (AI) untuk mempermudah input data dan memberikan konsultasi teknis menjahit.

## 🌟 Latar Belakang

Penjahit lokal sering kesulitan mengelola ribuan catatan ukuran pelanggan yang tertulis di buku tulis atau kertas usang. Data sering hilang, sulit dicari, dan tidak terstandarisasi. **JahitPintar** hadir sebagai solusi inklusif yang menjembatani kebiasaan tradisional dengan teknologi modern.

## 🎬 Video Demo

<iframe width="560" height="315" src="https://www.youtube.com/embed/o-wB-zI1Ufs?si=JX0sVUL6prz-z0Jp" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" referrerpolicy="strict-origin-when-cross-origin" allowfullscreen></iframe>

## 🚀 Fitur Unggulan

### 1. 📸 Smart OCR & Input Catatan Lama
Tidak perlu mengetik ulang ribuan data! Cukup foto catatan tangan lama Anda, dan AI kami (didukung oleh **Kolosal.ai OCR**) akan otomatis mengekstrak nama, nomor telepon, dan puluhan titik ukuran badan ke dalam database digital.

### 2. 💬 Input via Natural Chat
Malas mengisi formulir panjang? Cukup ketik atau bicara seperti kepada asisten:
> *"Buatkan data untuk Pak Budi, LD 100, Panjang Baju 70, Alamat di Jalan Mawar No 5."*

AI akan memilah informasi tersebut ke kolom yang tepat secara otomatis.

### 3. 🤖 AI Virtual Assistant
Asisten cerdas yang siap membantu penjahit:
- Konsultasi pola dan teknik jahit.
- Analisis proporsi ukuran badan pelanggan.
- Rekomendasi bahan dan estimasi kebutuhan kain.

### 4. 📊 Manajemen Pelanggan Terpadu
- Penyimpanan data identitas, sosial media, dan alamat.
- Pencatatan detail ukuran (Atasan & Bawahan).
- Riwayat preferensi gaya dan warna.

## 🛠️ Teknologi yang Digunakan

Proyek ini dibangun menggunakan teknologi terbaru untuk performa dan skalabilitas maksimal:

- **Framework:** .NET 10 (Blazor Web App - Interactive Server)
- **Bahasa:** C# 14
- **Database:** PostgreSQL
- **UI/UX:** Bootstrap 5, Bootstrap Icons
- **AI & LLM:** [Kolosal.ai](https://kolosal.ai) (OCR & Chat Completions APIs)
- **Containerization:** Docker

## 📂 Struktur Proyek

Kami menerapkan struktur folder berbasis fitur (Feature-based) untuk kemudahan maintenance:

```
jahitpintar/
├── Components/       # UI Components (Pages, Layouts, Auth)
├── Features/         # Modul Fitur Utama
│   ├── Chat/         # Komponen & Logika AI Chat Assistant
│   ├── Customer/     # Manajemen Data Pelanggan
│   └── Ocr/          # Integrasi Smart OCR
├── Services/         # Layanan Integrasi (KolosalService, dll)
├── Data/             # Konfigurasi Database & Identity
└── wwwroot/          # Aset Statis
```

## 🏁 Cara Menjalankan

### Prasyarat
- .NET 10 SDK
- Docker (Opsional, untuk database/deployment)
- PostgreSQL Database

### Langkah-langkah

1. **Clone Repository**
   ```bash
   git clone https://github.com/suryami62/jahitpintar.git
   cd jahitpintar/jahitpintar
   ```

2. **Konfigurasi Database & API Key**
   Update `appsettings.json` dengan connection string PostgreSQL dan API Key Kolosal.ai Anda:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=jahitpintar;Username=postgres;Password=password"
     },
     "kolosal_api_key": "YOUR_KOLOSAL_API_KEY"
   }
   ```

3. **Jalankan Migrasi Database**
   ```bash
   dotnet ef database update
   ```

4. **Jalankan Aplikasi**
   ```bash
   dotnet run
   ```
   Akses aplikasi di `https://localhost:7060` atau `http://localhost:5020`.

## 🤝 Kontribusi

Proyek ini dikembangkan untuk Hackathon IMPHNEN. Masukan dan saran sangat kami hargai untuk pengembangan fitur di masa depan.

---
*Dibuat dengan ❤️ oleh Tim "dotnet run --project ./Hackathon/NasiPadang.csproj" untuk UMKM Indonesia.*
