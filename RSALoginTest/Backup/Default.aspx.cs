using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;

namespace RSALoginTest
{
    public partial class _Default : System.Web.UI.Page
    {
        private string BytesToHexString(byte[] input)
        {
            StringBuilder hexString = new StringBuilder(64);

            for (int i = 0; i < input.Length; i++)
            {
                hexString.Append(String.Format("{0:X2}", input[i]));
            }
            return hexString.ToString();
        }

        public static byte[] HexStringToBytes(string hex)
        {
            if (hex.Length == 0)
            {
                return new byte[] { 0 };
            }

            if (hex.Length % 2 == 1)
            {
                hex = "0" + hex;
            }

            byte[] result = new byte[hex.Length / 2];

            for (int i = 0; i < hex.Length / 2; i++)
            {
                result[i] = byte.Parse(hex.Substring(2 * i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }
            
            return result;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoginResult = "";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            if (string.Compare(Request.RequestType, "get", true)==0)
            {
                //将私钥存Session中
                Session["private_key"] = rsa.ToXmlString(true);
            }
            else
            {
                bool bLoginSucceed = false;
                try
                {
                    string strUserName = Request.Form["txtUserName"];
                    postbackUserName = strUserName;
                    string strPwdToDecrypt = Request.Form["encrypted_pwd"];
                    rsa.FromXmlString((string)Session["private_key"]);
                    byte[] result = rsa.Decrypt(HexStringToBytes(strPwdToDecrypt), false);
                    System.Text.ASCIIEncoding enc = new ASCIIEncoding();
                    string strPwdMD5 = enc.GetString(result);
                    if (string.Compare(strUserName, "user1", true)==0 && string.Compare(strPwdMD5, "14e1b600b1fd579f47433b88e8d85291", true)==0)
                        bLoginSucceed = true;
                }
                catch (Exception)
                {

                }
                if (bLoginSucceed)
                    LoginResult = "登录成功";
                else
                    LoginResult = "登录失败";
            }

            //把公钥适当转换，准备发往客户端
            RSAParameters parameter = rsa.ExportParameters(true);
            strPublicKeyExponent = BytesToHexString(parameter.Exponent);
            strPublicKeyModulus = BytesToHexString(parameter.Modulus);
        }

        protected string strPublicKeyExponent = "";
        protected string strPublicKeyModulus = "";
        protected string LoginResult = "";
        protected string postbackUserName = "";
    }
}
