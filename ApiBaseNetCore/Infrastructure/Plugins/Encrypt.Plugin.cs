


using Infrastructure.Interfaces;

namespace Infrastructure.Plugins
{
    public class Encrypt64: IEncrypt
    {
        public string Encrypt(string data)
        {
            string pError = string.Empty;
            try
            {
                string result = string.Empty;
                byte[] encryted = System.Text.Encoding.Unicode.GetBytes(data);
                result = Convert.ToBase64String(encryted);
                return result;
            }
            catch (Exception ex)
            {
                pError = ex.Message;
                return pError;
            }
        }

        public string Decrypt(string data)
        {
            string pError = string.Empty;
            try
            {
                string result = string.Empty;
                byte[] decryted = Convert.FromBase64String(data);
                //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
                result = System.Text.Encoding.Unicode.GetString(decryted);
                return result;
            }
            catch (Exception ex)
            {
                pError = ex.Message;
                return pError;
            }
        }
    }
}