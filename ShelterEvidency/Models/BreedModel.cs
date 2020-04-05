using Caliburn.Micro;
using ShelterEvidency.Database;
using System;
using System.Linq;
using System.Windows;

namespace ShelterEvidency.Models
{
    public class BreedModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public string BreedName { get; set; }
        public int? SpeciesID { get; set; }
        #endregion
        public static BindableCollection<Breeds> ReturnBreeds(int? speciesID)
        {
            try
            {

                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    if (speciesID is null)
                        return new BindableCollection<Breeds>(db.Breeds.Where(x => x.IsDeleted.Equals(false)));
                    else
                        return new BindableCollection<Breeds>(db.Breeds.Where(x => x.SpeciesID.Equals(speciesID) && x.IsDeleted.Equals(false)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<Breeds>();
            }
        }
        public void SaveBreed()
        {
            try
            {
                if (BreedName != null)
                {
                    using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                    {
                        Breeds breed = new Breeds
                        {
                            BreedName = BreedName,
                            SpeciesID = SpeciesID,
                            IsDeleted = false
                        };
                        db.Breeds.InsertOnSubmit(breed);
                        db.SubmitChanges();

                        ID = breed.Id;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void MarkAsDeleted(int id)
        {
            try
            {

                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var breed = db.Breeds.Single(x => x.Id == id);
                    breed.IsDeleted = true;
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
