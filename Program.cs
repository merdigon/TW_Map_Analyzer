using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var image = new Bitmap("map_old.png");
            var image_new = new Bitmap("map_new.png");

            var map = new int[image.Width, image.Height];
            var map_new = new int[image_new.Width, image_new.Height];

            for (int i=0; i<image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    var pixColor = image.GetPixel(i, j);
                    if (pixColor.B > 200 && pixColor.R < 100 && pixColor.G < 100)
                        map[i, j] = 1;
                    else if (pixColor.R > 200 && pixColor.B < 50 && pixColor.G < 50)
                        map[i, j] = 2;
                    else
                        map[i, j] = 0;
                }
            }

            for (int i = 0; i < image_new.Width; i++)
            {
                for (int j = 0; j < image_new.Height; j++)
                {
                    var pixColor = image_new.GetPixel(i, j);
                    if (pixColor.B > 200 && pixColor.R < 100 && pixColor.G < 100)
                        map_new[i, j] = 1;
                    else if (pixColor.R > 200 && pixColor.B < 50 && pixColor.G < 50)
                        map_new[i, j] = 2;
                    else
                        map_new[i, j] = 0;
                }
            }

            var resultImage = new Bitmap(image.Width, image.Height);
            int lost = 0;
            int got = 0;

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    if (map[i, j] == 1 && map_new[i, j] == 2)
                    {
                        resultImage.SetPixel(i, j, Color.FromArgb(255, 0, 0));
                        lost++;
                    }
                    else if (map[i, j] == 2 && map_new[i, j] == 1)
                    {
                        resultImage.SetPixel(i, j, Color.FromArgb(0, 0, 255));
                        got++;
                    }
                    else if (map_new[i, j] == 1)
                        resultImage.SetPixel(i, j, Color.FromArgb(190, 190, 255));
                    else if (map_new[i, j] == 2)
                        resultImage.SetPixel(i, j, Color.FromArgb(255, 190, 190));
                    else
                        resultImage.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                }
            }

            resultImage.Save("result.png");

            Console.WriteLine($"Utracone: {lost}");
            Console.WriteLine($"Zdobyte: {got}");
            Console.ReadKey();
        }
    }
}
