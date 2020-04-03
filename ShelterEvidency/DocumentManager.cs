using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
/*
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
*/
using ShelterEvidency.Models;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Caliburn.Micro;
using ShelterEvidency.WrappingClasses;
using ClosedXML.Excel;

namespace ShelterEvidency
{
    public class DocumentManager
    {
        /*
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
        */

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

        public static void DeleteDocument(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
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

        /*
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
        */

        public static void ExportDataPDF(List<List<string>> data, string dataName)
        {
            //configure save file dialog box
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Export"; //default file name
            dlg.DefaultExt = ".pdf"; //default file extension
            dlg.Filter = "PDF Files|*.pdf"; //filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            string fileName = string.Empty;

            // Process save file dialog box results
            if (result == true)
            {
                string FONT = "c:/windows/fonts/arial.ttf";
                BaseFont bf = BaseFont.CreateFont(
                    FONT, BaseFont.IDENTITY_H, BaseFont.EMBEDDED
                  );
                // Save document
                fileName = dlg.FileName;

                Document myDocument = new Document(iTextSharp.text.PageSize.A4.Rotate(), 10, 10, 42, 35);
                PdfWriter.GetInstance(myDocument, new FileStream(fileName, FileMode.Create));

                PdfPTable table = new PdfPTable(data.First().Count());
                PdfPCell name = new PdfPCell(new Phrase(dataName, new Font(bf)));
                name.Colspan = data.First().Count();
                name.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

                table.AddCell(name);

                foreach (List<string> record in data)
                {
                    foreach (string value in record)
                    {

                        table.AddCell(new PdfPCell(new Phrase(value?.ToString() ?? String.Empty, new Font(bf))));

                    }
                    
                }

                myDocument.Open();
                myDocument.Add(table);
                myDocument.Close();
            }
        }

        public static void ExportDataExcell(List<List<string>> data, string dataName)
        {
            var workbook = new XLWorkbook();
            workbook.AddWorksheet("sheetName");
            var ws = workbook.Worksheet("sheetName");

            int row = 1;
            int col = 1;

            foreach (List<string> record in data)
            {
                foreach (string value in record)
                {

                    ws.Cell(row, col).Value = value?.ToString() ?? String.Empty;
                    col++;

                }
                col = 1;
                row++;
            }


            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.Filter = "Excel|*.xls|Excel 2010|*.xlsx"; ;
            dlg.Title = "Save the Excel File";
            dlg.FileName = "Order25.xlsx";

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            string fileName = string.Empty;

            if (result == true)
            {
                workbook.SaveAs(dlg.FileName);
            }
        }

    }
}
