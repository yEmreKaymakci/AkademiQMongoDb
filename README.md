# 🥗 Chick Chick - .NET 9 & MongoDB Dinamik Restoran Yönetim Sistemi

![.NET 9](https://img.shields.io/badge/.NET-9.0-512bd4?style=for-the-badge&logo=dotnet)
![MongoDB](https://img.shields.io/badge/MongoDB-%234ea94b.svg?style=for-the-badge&logo=mongodb&logoColor=white)
![Architecture](https://img.shields.io/badge/Architecture-Clean_Folder_Structure-blue?style=for-the-badge)

## 📖 Projenin Amacı ve Kapsamı
Bu proje, **Foodu - Organic Food & Restaurant** HTML şablonunu, **.NET 9** ve **MongoDB** kullanarak dinamik bir web uygulamasına dönüştürmek amacıyla geliştirilmiştir. Proje süresince Clean Architecture prensiplerine uygun bir klasör yapısı izlenmiş, veri güvenliği için DTO kullanımı önceliklendirilmiş ve gerçek zamanlı SMTP servisleri entegre edilmiştir.

---

## 🏗️ Teknik Gereksinimler ve Mimari
Proje, kurumsal standartlara uygun olarak aşağıdaki teknolojilerle inşa edilmiştir:

* **Framework:** .NET 9.0 (ASP.NET Core MVC)
* **Veritabanı:** MongoDB (NoSQL)
* **Mimari:** Tek Katmanlı Mantıksal Klasör Yapısı (Folder Structure)
* **Veri Transferi:** DTO (Data Transfer Objects) kullanımı zorunludur.
* **Mapping:** Mapster (Entity-DTO Dönüşümü)
* **Güvenlik:** Cookie Authentication & BCrypt Password Hashing
* **E-Posta Servisi:** MailKit & SMTP Entegrasyonu

---

## 🚀 Geliştirme Fazları

### 🔹 FAZ 1: Entity ve Veritabanı Tasarımı
MongoDB koleksiyonlarına karşılık gelen varlıklar (Entities) oluşturulmuştur. ID yönetimi için ortak bir `BaseEntity` kullanılmıştır:
* **Ürün & Kategori:** Product, Category
* **Ekip:** Chef
* **Kurumsal:** About, Contact, Banner
* **Etkileşim:** Message, Subscriber (Bülten), Testimonial, Booking

### 🔹 FAZ 2: Servis Katmanı ve DTO Yönetimi
İş mantığı (Business Logic) Controller'lardan arındırılarak servis katmanına taşınmıştır:
* **DTO'lar:** Her entity için `Create`, `Update` ve `Result` DTO'ları tanımlanmıştır.
* **Services:** `IProductService`, `ISubscriberService` gibi arayüzler ve bunların `Manager` sınıfları üzerinden veri erişimi sağlanmıştır.

### 🔹 FAZ 3 & 4: Dinamik UI ve ViewComponents
Statik şablon parçalanarak modüler hale getirilmiştir:
* **Layout:** `_UILayout` ile merkezi bir görünüm yönetimi sağlanmıştır.
* **ViewComponents:** Ana sayfa; `_MainSlider`, `_Category`, `_MenuView`, `_Chef`, `_Booking` gibi bağımsız bileşenlerle dinamik hale getirilmiştir.

### 🔹 FAZ 5: Admin Paneli ve CRUD
Sistemin tüm içeriğini yönetmek için gelişmiş bir yönetim paneli hazırlanmıştır:
* Tüm varlıklar için ekleme, silme, güncelleme ve listeleme (CRUD) işlemleri.
* Mesaj kutusu yönetimi (Okundu/Okunmadı durumu kontrolü).

### 🔹 FAZ 6: SMTP İndirim Maili Servisi
Projenin en kritik özelliklerinden biri olan bu fazda;
* **MailKit** kütüphanesi entegre edilmiştir.
* Admin paneli üzerinden tek tıkla tüm e-bülten abonelerine **%20 İndirim Kodu** içeren HTML e-postalar gönderilmektedir.

---

## 📂 Klasör Yapısı
```text
MongoDB-RestaurantProject
├── Areas/Admin          # Yönetim Paneli Modülleri
├── Controllers          # Kullanıcı Arayüzü Controller'ları
├── DTOs                 # Veri Transfer Nesneleri
├── Entities             # MongoDB Koleksiyon Modelleri
├── Services             # İş Mantığı (Business Layer)
├── Settings             # MongoDB Bağlantı Ayarları
├── ViewComponents       # Dinamik UI Bileşenleri
└── Views                # Razor Sayfaları
```

## 📸 Ekran Görüntüleri
### Kullanıcı Paneli
![HomeBanner](https://github.com/user-attachments/assets/ab0abd34-cef1-456e-8f16-cb6cf59ee75e)

![About](https://github.com/user-attachments/assets/1ebee4f3-f497-47f6-b35f-d1ce667453d1)

![Menu](https://github.com/user-attachments/assets/3e14a96e-0a3b-4788-a20a-2aaa497eb412)

![Booking](https://github.com/user-attachments/assets/cf87a4c6-0e1c-4ccb-b233-2763ac41d735)

![ContactSendMessage](https://github.com/user-attachments/assets/0ac513d4-64e6-4dd5-b5d9-2244660f3006)

### Admin Paneli

#### Kayıt Olma
![Register](https://github.com/user-attachments/assets/de6759d6-0e9d-4c06-ad66-f2f91b7363eb)

#### Giriş Yapma
![Login](https://github.com/user-attachments/assets/173a1e2b-d24b-47c6-aab7-80c61ab16a44)

#### Ürünler 
![Product](https://github.com/user-attachments/assets/a2c9869a-778d-4c43-b1ad-e06cac289152)
###### Ekleme
![ProductCreate](https://github.com/user-attachments/assets/caa25c81-901f-4c90-8cc1-031c994b0d49)
##### Güncelleme
![ProductUpdate](https://github.com/user-attachments/assets/c3b3d85a-6532-41f0-b589-50654eb61290)


#### Mesajlar
![SendBox](https://github.com/user-attachments/assets/abb14bba-80b2-4d28-bc24-8b653d42ee0f)

#### Abonelik
![Subscriber](https://github.com/user-attachments/assets/f673ad5c-09a3-45b3-9a6b-8ca4955d2795)
##### İndirim Kodu
![Mail](https://github.com/user-attachments/assets/8a6c8735-65b2-4562-95fb-01e5b27ed86a)





