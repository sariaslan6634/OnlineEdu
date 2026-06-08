# 🎓 OnlineEdu

OnlineEdu, ASP.NET Core teknolojileri kullanılarak geliştirilmiş kapsamlı bir online eğitim platformudur.

Bu proje; öğrencilerin kurslara kayıt olabildiği, öğretmenlerin kurs ve blog yönetebildiği, yöneticilerin ise tüm sistemi kontrol edebildiği çok katmanlı bir eğitim yönetim sistemidir.

---

## 🚀 Özellikler

### 👨‍🎓 Öğrenci Paneli

- Kursları görüntüleme
- Kurs detaylarını inceleme
- Kurs kayıt işlemleri
- Öğrenciye ait kursların listelenmesi

### 👨‍🏫 Öğretmen Paneli

- Kurs yönetimi (CRUD)
- Blog yönetimi
- Sosyal medya hesap yönetimi
- Öğretmen profil işlemleri

### 👨‍💼 Admin Paneli

- Kullanıcı yönetimi
- Rol yönetimi
- Kurs yönetimi
- Blog yönetimi
- Kategori yönetimi
- Referans/Testimonial yönetimi
- Sosyal medya yönetimi
- Abone yönetimi
- İletişim mesajları yönetimi

### 🌐 Genel Özellikler

- JWT Authentication
- Role Based Authorization
- Blog Sistemi
- İletişim Formu
- Abonelik Sistemi
- Eğitim Kategorileri
- Öğretmen Profilleri
- Kurs Videoları
- Responsive Tasarım
- Swagger API Dökümantasyonu

---

# 🛠️ Kullanılan Teknolojiler

## Backend

- ASP.NET Core 9.0
- ASP.NET Web API
- Entity Framework Core 9
- SQL Server
- ASP.NET Identity
- JWT Authentication
- AutoMapper
- Repository Design Pattern
- N-Tier Architecture

## Frontend

- ASP.NET Core MVC
- Razor View Engine
- Bootstrap
- JavaScript
- jQuery

## Validation & Mapping

- FluentValidation
- AutoMapper

## API Documentation

- Swagger / Swashbuckle

---

# 🏗️ Proje Mimarisi

Proje katmanlı mimari yapısına uygun olarak geliştirilmiştir.

```text
OnlineEdu
│
├── OnlineEdu.API
├── OnlineEdu.Business
├── OnlineEdu.DataAccess
├── OnlineEdu.DTO
├── OnlineEdu.Entity
└── OnlineEdu.WebUI
