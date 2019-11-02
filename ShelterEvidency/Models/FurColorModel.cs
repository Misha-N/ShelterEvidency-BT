using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    class FurColorModel
    {
        public string FurColorName { get; set; }
        public List<string> ReturnFurColorList()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            return db.FurColors.Select(x => x.FurColor).ToList();
        }

        public List<FurColors> ReturnFurColors()
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
                    FurColor = FurColorName
                };
                db.FurColors.InsertOnSubmit(furColor);
                db.SubmitChanges();
            }

        }
    }
}
