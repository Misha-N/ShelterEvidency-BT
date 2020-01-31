using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using ShelterEvidency.Models;

namespace ShelterEvidency
{
    public class DocumentManager
    {
        public static void CreateAdoptionList(AnimalModel animal, PersonModel owner, AdoptionModel adoption)
        {
            // Create a new PDF document
            PdfDocument adoptionList = new PdfDocument();

            // Create an empty page
            PdfPage page = adoptionList.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);

            // Draw the text
            gfx.DrawString("adopční smlouva!", font, XBrushes.Black,
              new XRect(0, 0, page.Width, page.Height),
              XStringFormats.Center);

            // Save the document...
            string documentName = string.Format("adopční_smlouva_{0}.pdf", DateTime.Now.ToShortDateString());
            string filename = Path.Combine(animal.FolderPath, documentName);
            adoptionList.Save(filename);

            // ...and start a viewer.
            Process.Start(filename);
        }

        public static FileInfo[] ReturnAnimalFolder(int animalID)
        {
            string folder = AnimalModel.ReturnFolder(animalID);
            return new DirectoryInfo(folder).GetFiles(); ;

        }

        public static void OpenDocument(string path)
        {
            System.Diagnostics.Process.Start(path);
        }

        public static void PrintDocument(string path)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                Verb = "print",
                FileName = path
            };
            p.Start();
        }

        public static void LoadNewAnimalDocument(int animalID)
        {
            string path = AnimalModel.ReturnFolder(animalID);
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                var fileNames = ofd.FileNames;

                foreach (var fileName in fileNames)
                {
                    File.Copy(fileName, Path.Combine(path, Path.GetFileName(fileName)));
                }
            }
        }

        public static void GenerateAnimalEvidencyCard(int animalID)
        {
            string path = AnimalModel.ReturnFolder(animalID);
            // Create a new PDF document
            PdfDocument adoptionList = new PdfDocument();

            // Create an empty page
            PdfPage page = adoptionList.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);

            // Draw the text
            gfx.DrawString(String.Format("evidenční karta zvířete s ID: {0}", animalID), font, XBrushes.Black,
              new XRect(0, 0, page.Width, page.Height),
              XStringFormats.Center);

            // Save the document...
            string documentName = string.Format("evidenční_karta_ID_{0}_{1}.pdf", animalID,  DateTime.Now.ToShortDateString());
            string filename = Path.Combine(path, documentName);
            adoptionList.Save(filename);

            // ...and start a viewer.
            Process.Start(filename);
        }

    }
}
