using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //Product
        public static string ProductAdded = "Oyun eklendi.";
        public static string ProductDeleted = "Oyun silindi";
        public static string ProductUpdated = "Oyun güncellendi.";
        public static string ProductNameInvalid = "Oyun ismi geçersiz.";
        public static string MaintenanceTime = "Sistem bakımda.";
        public static string ProductsListed = "Oyunlar Listelendi.";

        //Category
        public static string CategoryAdded = "Kategori eklendi.";
        public static string CategoryDeleted = "Kategori silindi";
        public static string CategoryUpdated = "Kategori güncellendi.";
        public static string CategoryNameInvalid = "Kategori ismi geçersiz.";
        public static string CategoriesListed = "Kategoriler Listelendi.";

        //Customer
        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CustomerNameInvalid = "Müşteri ismi geçersiz.";
        public static string CustomersListed = "Müşteriler Listelendi.";

        //Game
        public static string GameAdded = "Yayıncı eklendi.";
        public static string GameDeleted = "Yayıncı silindi";
        public static string GameUpdated = "Yayıncı güncellendi.";
        public static string GameNameInvalid = "Yayıncı ismi geçersiz.";
        public static string GamesListed = "Yayıncılar Listelendi.";

        //Order
        public static string OrderAdded = "Sipariş eklendi.";
        public static string OrderDeleted = "Sipariş silindi";
        public static string OrderUpdated = "Sipariş güncellendi.";
        public static string OrderNameInvalid = "Sipariş ismi geçersiz.";
        public static string OrdersListed = "Siparişler Listelendi.";

        //User
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UserNameInvalid = "Kullanıcı ismi geçersiz.";
        public static string UsersListed = "Kullanıcılar Listelendi.";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";

        public static string ProductImageLimitExceeded = "Resim sınırını aştınız.";
        public static string ProductImageUpdated = "Resim güncellendi.";
        public static string ProductImageDeleted = "Resim silindi.";
        public static string ProductImageAdded = "Resim eklendi.";
        public static string ProductImagesListed = "Resim listelendi.";

        public static string ImageLimitExceded = "Resim sınırı aşıldı.";

        public static string ProductImageMustBeExists = "Bir ürün resmi olmalı.";
        public static string InvalidImageExtension = "Geçersiz resim uzantısı.";
        public static string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };
        public static string OverLimit = "Limit aşıldı.";
        public static string ImageNotFound = "Resim bulunamadı.";
        public static string SuccessImageDeleted = "Resim başarıyla silindi.";
        public static string AllImagesDeleted = "Tüm resimler silindi.";
        public static string ProductHaveNoImage = "Ürünün bir resmi yok.";
    }
}
