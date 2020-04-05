using ShelterEvidency.Helpers;
using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace ShelterEvidency.Models
{
    public class ImageModel
    {
        #region Properties/Atributes
        public BitmapImage Image { get; set; }
        public string ImagePath { get; set; }
        #endregion

        public string SaveImage()
        {
            if (ImagePath != null)
            {
                string path, fileName;

                while (true)
                {
                    try
                    {
                        fileName = RandomStringGenerator.RandomString(10) + ".jpg";
                        System.IO.Directory.CreateDirectory(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "AnimalImages"));
                        path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "AnimalImages", fileName);
                        System.IO.File.Copy(ImagePath, path);
                        return path;
                    }
                    catch (IOException)
                    {
                        SaveImage();
                    }
                }

            }
            else
                return null;
        }

        public void GetImage(string imagePath)
        {
            if(imagePath != null)
            {
                ImagePath = imagePath;
                Image = new BitmapImage(new Uri(ImagePath));
            }
        }
    }
}
