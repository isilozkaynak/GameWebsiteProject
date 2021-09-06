﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //Product
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductDeleted = "Ürün silindi";
        public static string ProductUpdated = "Ürün güncellendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
        public static string MaintenanceTime = "Bakım zamanı.";
        public static string ProductsListed = "Ürünler Listelendi.";

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
        public static string GameAdded = "Oyun eklendi.";
        public static string GameDeleted = "Oyun silindi";
        public static string GameUpdated = "Oyun güncellendi.";
        public static string GameNameInvalid = "Oyun ismi geçersiz.";
        public static string GamesListed = "Oyunlar Listelendi.";

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

        public static string ProductImageLimitExceeded { get; internal set; }
        public static string ProductImageUpdated { get; internal set; }
        public static string ProductImageDeleted { get; internal set; }
        public static string ProductImageAdded { get; internal set; }
        public static string ProductImagesListed { get; internal set; }
    }
}
