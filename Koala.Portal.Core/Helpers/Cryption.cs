using System.Globalization;
using System.Text;
using SysCryptCore;


namespace Koala.Portal.Core.Helpers
{
    //TODO: Static class dan çıkarılıp dp eklenecek
    public static class Cryption
    {
        private static readonly byte[] sKey = new byte[] { 0x13, 0x4D, 0xD4, 0x06, 0xA5, 0xF8, 0xAC, 0x4D, 0x83, 0x83, 0x86, 0xE0, 0xFB, 0x6F, 0x70, 0xF2 };
   
        //private static readonly Logger<> _logger = LogManager.GetCurrentClassLogger();

        public static string Encryption(this string data)
        {

            var r = new Random();
            var key = new byte[16];
            r.NextBytes(key);
            var lenght = data.Length;

            var sifrelenecek = data.Ascii2ByteArray().ToList();
            while (sifrelenecek.Count % 16 != 0)
            {
                sifrelenecek.Add(0x00);
            }
            var partCount = sifrelenecek.Count / 16;

            var sb = new StringBuilder();
            var sfa = sifrelenecek.ToArray();
            var cKey = new byte[16];
            try
            {
                var crypt = new Crypt(Crypt.KeySize.Bits128, sKey);
                crypt.Cipher(key, cKey);
                for (int i = 0; i < partCount; i++)
                {
                    var chiperText = new byte[16];
                    var plain = new byte[16];
                    Array.Copy(sfa, (i * 16), plain, 0, 16);
                    crypt = new Crypt(Crypt.KeySize.Bits128, key);
                    crypt.Cipher(plain, chiperText);
                    sb.Append(chiperText.ByteArray2HexStr(""));
                }
            }
            catch (Exception ex)
            {
                
                return "Şifreleme işlemi gerçekleştirilemedi";
            }

            var res = sb.ToString();
            var l = ~lenght;
            res = cKey.ByteArray2HexStr("") + res;
            var ls = l.ToString("X8");
            res = ls + res;
            var cs = CheckSum(res);
            res += cs;
            return res;
        }

        public static string Decryption(this string data)
        {

            var cs = CheckSum(data.Substring(0, data.Length - 2));
            if (!(data.Substring(data.Length - 2) == cs))
            {
                return "Invalid Term";
            }

            var datalength = ~(int.Parse(data.Substring(0, 8), NumberStyles.HexNumber, CultureInfo.InvariantCulture));

            var ckey = data.Substring(8, 32).HexStr2ByteArray();

            var key = new byte[16];
            var crypt = new Crypt(Crypt.KeySize.Bits128, sKey);
            var sb = new StringBuilder();
            try
            {
                crypt.InvCipher(ckey, key);
                data = data.Remove(0, 40);
                var partCount = ((data.Length - 2) / 2) / 16;


                for (int i = 0; i < partCount; i++)
                {
                    var cT = data.Substring(i * 32, 32).HexStr2ByteArray();
                    var iT = new byte[16];
                    crypt = new Crypt(Crypt.KeySize.Bits128, key);
                    crypt.InvCipher(cT, iT);
                    sb.Append(iT.ByteArray2Ascii());
                }
            }
            catch (Exception ex)
            {
                //TODO: Log Eklenecek
                //_logger.Error(ex, "Şifreleme Çözülemedi");
                return "Şifre açılamadı";
            }

            var res = sb.ToString();
            return res.Substring(0, (int)datalength);
        }

        private static string CheckSum(string data)
        {
            var x = data.Aggregate(0, (current, t) => current + t);
            var res = ((byte)x).ToString("X2");
            return res;
        }
    }
}
