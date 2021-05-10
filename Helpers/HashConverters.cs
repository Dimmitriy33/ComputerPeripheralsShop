using System.Security.Cryptography;
using System.Text;

namespace ComputerPeripheralsShop.Helpers
{
    public static class HashConverters
    {
        public static byte[] GetHashEncryption(string s)
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            return byteHash;
        }

        public static string GetHashString(byte[] byteHash)
        {
            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }
    }
}
