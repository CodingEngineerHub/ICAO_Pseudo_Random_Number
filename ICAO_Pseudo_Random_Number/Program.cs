using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ICAO_Pseudo_Random_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("k0 operation starts");
            byte[] myKey1 = Convert.FromHexString("5DD4CBFC96F5453B130D890A1CDBAE32");
           byte[] Input1 =  Convert.FromHexString("2923BE84E16CD6AE529049F1F1BBE9EB");
           
           
            byte[] key1 = new byte[16];
            Array.Copy(myKey1, 0, key1, 0, 16);
       

            Aes Aes1 = Aes.Create();
            Aes1.BlockSize = 128;
            Aes1.Key = key1;
            Aes1.Mode = CipherMode.CBC;
            Aes1.Padding = PaddingMode.None;
            Aes1.IV = new byte[16];


            // Padd the data with Padding Method 2 (Bit Padding)
            System.IO.MemoryStream out_Renamed = new System.IO.MemoryStream();
            //     Console.WriteLine(out_Renamed.Length);
           
          
            byte[] eIfd_padded = out_Renamed.ToArray();
            int N_bytes = eIfd_padded.Length / 8;  // Number of Bytes 

            
            byte[] dN = new byte[16];
            byte[] k0 = new byte[16];
            byte[] intN = new byte[16];

          
         //   Array.Copy(eIfd_padded, 0, input1, 0, 8);//d1 sets as first 8 element of data
         //   Console.WriteLine(" all data: " + Convert.ToHexString(eIfd_padded));
            Console.WriteLine("Aes1 encryption starts:" + " \nAes1.Key:" + Convert.ToHexString(Aes1.Key) + "\nAes1.IV:" + Convert.ToHexString(Aes1.IV) + "\nAes1 Input:" + Convert.ToHexString(Input1));
            k0 = Aes1.CreateEncryptor().TransformFinalBlock(Input1, 0, 16);


            Console.WriteLine("Result(k0):" + Convert.ToHexString(k0)) ;









            Console.WriteLine("\n\n\n\n\nk1 operation starts");

            byte[] key2and3 = new byte[16];
            byte[] c0 = Convert.FromHexString("a668892a7c41e3ca739f40b057d85904");
            byte[] k1 = new byte[16];

            Array.Copy(k0, 0, key2and3, 0, 16);

            Aes Aes2 = Aes.Create();
            Aes2.BlockSize = 128;
            Aes2.Key = key2and3;
            Aes2.Mode = CipherMode.CBC;
            Aes2.Padding = PaddingMode.None;
            Aes2.IV = new byte[16];

 
            Console.WriteLine("Aes2 encryption starts:" + " \nAes2.Key:" + Convert.ToHexString(Aes2.Key) + "\nAes2.IV:" + Convert.ToHexString(Aes2.IV) + "\nAes2 Input:" + Convert.ToHexString(c0));
            k1 = Aes2.CreateEncryptor().TransformFinalBlock(c0, 0, 16);

            Console.WriteLine("Result(k1):" + Convert.ToHexString(k1));




            Console.WriteLine("first iteration starts");

            Console.WriteLine("\n\n\n\n\nx1 operation starts");

            byte[] c1 = Convert.FromHexString("a4e136ac725f738b01c1f60217c188ad");
            byte[] x1 = new byte[16];

            Array.Copy(k0, 0, key2and3, 0, 16);

            Aes Aes3 = Aes.Create();
            Aes3.BlockSize = 128;
            Aes3.Key = key2and3;
            Aes3.Mode = CipherMode.CBC;
            Aes3.Padding = PaddingMode.None;
            Aes3.IV = new byte[16];

                
            Console.WriteLine("Aes3 encryption starts:" + " \nAes3.Key:" + Convert.ToHexString(Aes3.Key) + "\nAes3.IV:" + Convert.ToHexString(Aes3.IV) + "\nAes3 Input:" + Convert.ToHexString(c1));
            x1 = Aes3.CreateEncryptor().TransformFinalBlock(c1, 0, 16);

            Console.WriteLine("Result(x1):" + Convert.ToHexString(x1));
















            Console.WriteLine("\n\n\n\n\nk2 operation starts");

            
            
            byte[] k2 = new byte[16];

           

            Aes Aes4 = Aes.Create();
            Aes4.BlockSize = 128;
            Aes4.Key = k1;
            Aes4.Mode = CipherMode.CBC;
            Aes4.Padding = PaddingMode.None;
            Aes4.IV = new byte[16];


            Console.WriteLine("Aes4 encryption starts:" + " \nAes4.Key:" + Convert.ToHexString(Aes4.Key) + "\nAes4.IV:" + Convert.ToHexString(Aes4.IV) + "\nAes4 Input:" + Convert.ToHexString(c0));
            k2 = Aes4.CreateEncryptor().TransformFinalBlock(c0, 0, 16);

            Console.WriteLine("Result(k2):" + Convert.ToHexString(k2));




            

            Console.WriteLine("\n\n\n\n\nx2 operation starts");

           
            byte[] x2 = new byte[16];

           

            Aes Aes5 = Aes.Create();
            Aes5.BlockSize = 128;
            Aes5.Key = k1;
            Aes5.Mode = CipherMode.CBC;
            Aes5.Padding = PaddingMode.None;
            Aes5.IV = new byte[16];


            Console.WriteLine("Aes5 encryption starts:" + " \nAes5.Key:" + Convert.ToHexString(Aes5.Key) + "\nAes5.IV:" + Convert.ToHexString(Aes5.IV) + "\nAes5 Input:" + Convert.ToHexString(c1));
            x2 = Aes5.CreateEncryptor().TransformFinalBlock(c1, 0, 16);

            Console.WriteLine("Result(x2):" + Convert.ToHexString(x2));

















            Console.WriteLine("\n\n\n\n\nk3 operation starts");



            byte[] k3 = new byte[16];



            Aes Aes6 = Aes.Create();
            Aes6.BlockSize = 128;
            Aes6.Key = k2;
            Aes6.Mode = CipherMode.CBC;
            Aes6.Padding = PaddingMode.None;
            Aes6.IV = new byte[16];


            Console.WriteLine("Aes6 encryption starts:" + " \nAes6.Key:" + Convert.ToHexString(Aes6.Key) + "\nAes6.IV:" + Convert.ToHexString(Aes6.IV) + "\nAes6 Input:" + Convert.ToHexString(c0));
            k3 = Aes6.CreateEncryptor().TransformFinalBlock(c0, 0, 16);

            Console.WriteLine("Result(k3):" + Convert.ToHexString(k3));






            Console.WriteLine("\n\n\n\n\nx3 operation starts");


            byte[] x3 = new byte[16];



            Aes Aes7 = Aes.Create();
            Aes7.BlockSize = 128;
            Aes7.Key = k2;
            Aes7.Mode = CipherMode.CBC;
            Aes7.Padding = PaddingMode.None;
            Aes7.IV = new byte[16];


            Console.WriteLine("Aes7 encryption starts:" + " \nAes7.Key:" + Convert.ToHexString(Aes7.Key) + "\nAes7.IV:" + Convert.ToHexString(Aes7.IV) + "\nAes7 Input:" + Convert.ToHexString(c1));
            x3 = Aes7.CreateEncryptor().TransformFinalBlock(c1, 0, 16);

            Console.WriteLine("Result(x3):" + Convert.ToHexString(x3));




        }
    }
}

