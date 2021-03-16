using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constant
{
    public static class Message
    {
        public static string ProductAdded = "Araba eklendi";
        public static string ProductNameInvalid = "Araba ismi geçersiz";
        public static string MaintenanceTime = "Sistemde Bakım var";
        public static string ProductListed = "Arabalar listelendi";
        public static string UnitPriceInvalid = "Fiyat Geçersiz";
        public static string CarPriceNotZero = "Araba Fiyatı 0'dan Büyük Olmadılır.----";
        public static string CarNameEnoughCharacter = "Araba İsmi 2 Karakterden Az Olamaz.----";
        public static string ProductUpdated = "Ürün Güncellendi";
        public static string ProductDeleted = "Ürün Silindi";
        public static string CarImageLimitExceded = "Resim Ekleme Limiti Aşıldı";
        public static string CarImagePathTypeIsFalse = "Farklı türde resim eklendi";
        public static string CarImagesListed = "Araç Resimleri Listelendi";
        public static string UserRegistered = "Üyelik Kabul Edildi";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfulLogin = "Başarılı Giriş";
        public static string UserAlreadyExists = "Bu Mail Adresi Zaten Kayıtlı";
        public static string AccessTokenCreated = "Token Üretildi";
    }
}

