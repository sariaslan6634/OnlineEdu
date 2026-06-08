# 🎓 OnlineEdu

![.NET](https://img.shields.io/badge/.NET-9.0-purple)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-9.0-blue)
![EF Core](https://img.shields.io/badge/Entity_Framework_Core-9.0-green)
![SQL Server](https://img.shields.io/badge/SQL_Server-red)
![JWT](https://img.shields.io/badge/JWT-Authentication-orange)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5-purple)

## 📌 Proje Hakkında

OnlineEdu, ASP.NET Core teknolojileri kullanılarak geliştirilmiş kapsamlı bir online eğitim platformudur.

Bu proje; öğrencilerin kurslara kayıt olabildiği, öğretmenlerin kurs ve blog içerikleri oluşturabildiği, yöneticilerin ise tüm sistemi merkezi olarak yönetebildiği çok katmanlı bir eğitim yönetim sistemi olarak geliştirilmiştir.

Proje modern yazılım geliştirme prensipleri ve N-Tier Architecture yaklaşımı kullanılarak oluşturulmuştur.

---

# 🚀 Özellikler

## 👨‍🎓 Öğrenci Paneli

* Kursları listeleme ve görüntüleme
* Kurs detaylarını inceleme
* Kurs kayıt işlemleri
* Kayıt olunan kursları görüntüleme

## 👨‍🏫 Öğretmen Paneli

* Kurs yönetimi (CRUD)
* Blog yönetimi
* Profil yönetimi
* Sosyal medya hesap yönetimi

## 👨‍💼 Admin Paneli

* Kullanıcı yönetimi
* Rol yönetimi
* Kurs yönetimi
* Blog yönetimi
* Kategori yönetimi
* Referans/Testimonial yönetimi
* Sosyal medya yönetimi
* Abone yönetimi
* İletişim mesajları yönetimi

## 🌐 Genel Özellikler

* JWT Authentication
* ASP.NET Identity
* Role Based Authorization
* Blog Sistemi
* İletişim Formu
* Abonelik Sistemi
* Eğitim Kategorileri
* Öğretmen Profilleri
* Kurs Videoları
* Responsive Tasarım
* Swagger API Dökümantasyonu

---

# 🛠️ Kullanılan Teknolojiler

## Backend

* ASP.NET Core 9
* ASP.NET Web API
* Entity Framework Core 9
* SQL Server
* ASP.NET Identity
* JWT Authentication

## Frontend

* ASP.NET Core MVC
* Razor View Engine
* Bootstrap 5
* JavaScript
* jQuery

## Validation & Mapping

* FluentValidation
* AutoMapper

## Documentation

* Swagger / OpenAPI

---

# 🏗️ Mimari Yapı

Proje N-Tier Architecture yaklaşımı ile geliştirilmiştir.

```text
OnlineEdu
│
├── OnlineEdu.API
├── OnlineEdu.Business
├── OnlineEdu.DataAccess
├── OnlineEdu.DTO
├── OnlineEdu.Entity
└── OnlineEdu.WebUI
```

| Katman     | Açıklama                |
| ---------- | ----------------------- |
| API        | RESTful servisler       |
| Business   | İş kuralları            |
| DataAccess | Veritabanı işlemleri    |
| DTO        | Veri transfer nesneleri |
| Entity     | Veritabanı modelleri    |
| WebUI      | Kullanıcı arayüzü       |

---

# 🔐 Kimlik Doğrulama ve Yetkilendirme

Sistemde ASP.NET Identity ve JWT Authentication teknolojileri kullanılmaktadır.

### Roller

* Admin
* Teacher
* Student

### Yetkilendirme Yapısı

* JWT Token Authentication
* Role Based Authorization
* Identity User Management
* Protected API Endpoints

Her kullanıcı yalnızca kendi rolüne ait ekranlara ve işlemlere erişebilir.

---

# 🎯 Kullanılan Tasarım Desenleri

Projede sürdürülebilir, okunabilir ve ölçeklenebilir bir mimari oluşturmak amacıyla aşağıdaki tasarım desenleri kullanılmıştır.

### Repository Pattern

Veri erişim katmanının soyutlanmasını sağlar.

### Dependency Injection

Bağımlılıkların gevşek bağlı şekilde yönetilmesini sağlar.

### N-Tier Architecture

Uygulamanın katmanlı yapıda geliştirilmesini sağlar.

### DTO Pattern

Katmanlar arasında güvenli veri transferi sağlar.

### Service Layer Pattern

İş kurallarının merkezi olarak yönetilmesini sağlar.

---

# ⚙️ Kurulum

## 1. Projeyi Klonlayın

```bash
git clone https://github.com/sariaslan6634/OnlineEdu.git
```

## 2. Veritabanı Bağlantısını Güncelleyin

`appsettings.json` dosyasında Connection String bilgisini düzenleyin.

```json
"ConnectionStrings": {
  "DefaultConnection": "YOUR_CONNECTION_STRING"
}
```

## 3. Migration İşlemlerini Gerçekleştirin

```bash
dotnet ef database update
```

veya

```bash
Update-Database
```

## 4. API Projesini Çalıştırın

```bash
dotnet run --project OnlineEdu.API
```

## 5. WebUI Projesini Çalıştırın

```bash
dotnet run --project OnlineEdu.WebUI
```

# 👨‍💻 Geliştirici

**İbrahim SARIASLAN**

**GitHub:** https://github.com/sariaslan6634

**LinkedIn:** https://www.linkedin.com/in/ibrahimsariaslan/

---

# 📄 Lisans

Bu proje eğitim, öğrenim ve portföy amaçlı geliştirilmiştir.
