using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string filename = "adopční_smlouva.pdf";
            adoptionList.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }
    }
}
