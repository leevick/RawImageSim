using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;


namespace RawImageSim
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new string[1];
            args[0] = "D://Project//data//lena.jpg";

            Image img = Image.FromFile(args[0]);
            if (args[0] == null)
            {
                Console.WriteLine("input file empty! please drag it on the icon!");
                Console.ReadKey();
            }
            Bitmap bmp = new Bitmap(img);
            //Random rdm = new Random();

            
            for (int j = 0; j < img.Height; j++)
            {
               
                FileStream fs = new FileStream(j.ToString() + ".raw", FileMode.Create);
                byte[] b = new byte[2048 * 160 * 2];
                Console.WriteLine("Output file:" + j.ToString() + ".raw");
                for (int i = 0; i < 2048; i++)
                {
                    
                    for (int k = 0; k < 160; k++)
                    {
                        
                        b[2 * 2048 * k + 2 * i+1] = 0;
                        switch (k%3)
                        {
                            case 0: b[2 * 2048 * k + 2 * i + 0] = bmp.GetPixel(i % img.Width, j).R;break;
                            case 1: b[2 * 2048 * k + 2 * i + 0] = bmp.GetPixel(i % img.Width, j).G; break;
                            case 2: b[2 * 2048 * k + 2 * i + 0] = bmp.GetPixel(i % img.Width, j).B; break;
                            default:break;
                        }
                    }
                }

                fs.Write(b, 0, 2048 * 160 * 2);

                fs.Close();

            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
