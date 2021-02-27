using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages //static yaptığımızda newleyemiyoruz ve sabitler olduğu için bu şekilde tanımlıyoruz.
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün İsmi Geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductListed="Ürünler Listelendi";         
        public static string ProductCountOfCategoryError="Kategoride yayınlanan ürün sayısını aştınız";
        public static string ProductNameAlreadyExists="Aynı isimli bir ürün daha mevcut. İsmi kontrol ediniz!";
        public static string CategoryLimitExceded="Kategori limiti aşılamadı. 15 kategoriyi geçemez.";
        public static string ProductUpdated="Ürün güncellendi";
        public static string AuthorizationDenied="Yetkiniz bulunmamaktadır!";
        internal static string UserRegistered="Kullanıcı Kaydı Oluşturuldu";
        internal static string UserNotFound="Kullanıcı bulunamadı";
        internal static string PasswordError="Hatalı Parola";
        internal static string SuccessfulLogin="Giriş Başarılı";
        internal static string UserAlreadyExists="Böyle bir kullanıcı mevcut.";
        internal static string AccessTokenCreated="Access Token oluşturuldu.";
    }
}
