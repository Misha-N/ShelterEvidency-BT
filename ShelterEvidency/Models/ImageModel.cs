using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ShelterEvidency.Models
{
    public class ImageModel
    {
        #region Properties/Atributes
        public BitmapImage Image { get; set; }
        public int ID { get; set; }
        public int? AnimalID { get; set; }
        public string ImagePath { get; set; }
        #endregion

        public void SaveImage()
        {
            if (ImagePath != null)
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    Images img = new Images
                    {
                        AnimalID = AnimalID,
                    };
                    db.Images.InsertOnSubmit(img);
                    db.SubmitChanges();

                    string fileName = img.Id.ToString() + ".jpg";
                    string path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "AnimalImages", fileName);

                    System.IO.File.Copy(ImagePath, path, true);

                    img.ImagePath = path;

                    db.SubmitChanges();

                    ID = img.Id;
                }
            }
        }

        public void GetImage(int animalID)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var img = db.Images.OrderByDescending(x => x.Id).FirstOrDefault(i => i.AnimalID == animalID);
                if (img != null)
                {
                    Image = new BitmapImage(new Uri(img.ImagePath));
                    ImagePath = img.ImagePath;
                    AnimalID = img.AnimalID;
                    ID = img.Id;
                }
            }

        }

        public void UpdateImage()
        {
            if (ImagePath != null)
            {
                SaveImage();

            }
        }
    }
}
