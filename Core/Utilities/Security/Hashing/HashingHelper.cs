using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper//hash oluşturmaya ve onu doğrulama yapıyoruz.
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)//bir password vericez dışarı out ile 2 parametre çıkartacaz
        {
            using(var hmac= new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; //her kullanıcı için Key oluşturur.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //parametre olarak vereceğimiz password ü byte a dönüştürerek veriyoruz
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)//kullanıcının hashlenen password bilgilerini griiş yapması için doğrulama yapıyoruz
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {                
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //giriş yaparken girdiği passwordünü hashleyip ilk belirttiği password hash i ile karşılaştıracağız
                for (int i = 0; i < computedHash.Length; i++)//hesaplanan hashin her öğesini ilk passwordHashin her öğesi ile kıyaslayıp eşleşiyorsa true eşleşmiyorsa false döndürüyoruz.
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
