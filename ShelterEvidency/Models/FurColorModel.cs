using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    public class FurColorModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public string FurColorName { get; set; }
        #endregion
        public static List<FurColors> ReturnFurColors()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            return db.FurColors.ToList();
        }
        public void SaveFurColor()
        {
            if (FurColorName != null)
            {

                ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
                FurColors furColor = new FurColors
                {
                    FurColorName = FurColorName
                };
                db.FurColors.InsertOnSubmit(furColor);
                db.SubmitChanges();

                ID = furColor.Id;
            }

        }
    }
}
