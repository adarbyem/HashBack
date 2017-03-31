using System.Text;
using System.Security.Cryptography;
using System.IO;
using System;

namespace HashBack
{
    class Crypto
    {
        public string buildString(byte[] buffer)
        {
            //local variables
            StringBuilder builder = new StringBuilder();
            for (int x = 0; x < buffer.Length; x++)
            {
                builder.Append(buffer[x].ToString("x2"));
            }
            string returnString = builder.ToString();
            return returnString;
        }

        //Hash Types
        //1 = MD5
        //2 = SHA256
        //3 = SHA512
        public string doHash(int hashType, string file)
        {
            try
            {
                //local variables
                FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read);

                byte[] buffer;

                switch (hashType)
                {
                    case 1:
                        //Create Instance of MD5
                        MD5 md5Hash = MD5.Create();
                        buffer = md5Hash.ComputeHash(stream);
                        Console.WriteLine(buildString(buffer));
                        stream.Close();
                        //Hash Output
                        return (buildString(buffer));
                    case 2:
                        //Create Instance of SHA256
                        SHA256 sha256Hash = SHA256.Create();
                        buffer = sha256Hash.ComputeHash(stream);
                        stream.Close();
                        //Hash Output
                        return (buildString(buffer));
                    case 3:
                        //Create Instance of SHA512
                        SHA512 sha512Hash = SHA512.Create();
                        buffer = sha512Hash.ComputeHash(stream);
                        stream.Close();
                        //Hash Output
                        return (buildString(buffer));
                }
            }
            catch
            {
            }
            return "Invalid File";
        }
    }
}