using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Win32;
using ShelterEvidency.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ClosedXML.Excel;
using System.Windows;

namespace ShelterEvidency
{
    public class DocumentManager
    {
       
        public static void CreateAdoptionList(AnimalModel animal, PersonModel owner, AdoptionModel adoption)
        {
            try
            {
                AnimalInfo animalInfo = AnimalModel.GetAnimalInfo(animal.ID);
                PersonInfo personInfo = PersonModel.GetPersonInfo(owner.ID);
                AdoptionInfo adoptionInfo = AdoptionModel.GetAdoptionInfo(adoption.ID);

                string FONT = "c:/windows/fonts/arial.ttf";
                BaseFont bf = BaseFont.CreateFont(
                    FONT, BaseFont.IDENTITY_H, BaseFont.EMBEDDED
                  );

                Font czFont = new Font(bf, 14);
                // Save document
                string documentName = string.Format("adopční_smlouva_{0}.pdf", DateTime.Now.ToShortDateString());
                string fileName = Path.Combine(animalInfo.FolderPath, documentName);

                Document myDocument = new Document(iTextSharp.text.PageSize.A4, 10, 10, 42, 35);
                PdfWriter.GetInstance(myDocument, new FileStream(fileName, FileMode.Create));

                myDocument.Open();

                ////////////////////////


                myDocument.Add(new Paragraph("Adopční smlouva", czFont));
                myDocument.Add(new Paragraph("Zvíře: " + animalInfo.Name, czFont));
                myDocument.Add(new Paragraph("Nový majitel: " + personInfo.FirstName + " " + personInfo.LastName, czFont));
                myDocument.Add(new Paragraph("FINÁLNÍ PODOBA DOKUMENTU BUDE JEŠTĚ S ÚTULKEM DOHODNUTA", czFont));


                /////////////////////////////

                myDocument.Close();
                Process.Start(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       

        public static FileInfo[] ReturnAnimalFolder(int animalID)
        {
            try
            {
                string folder = AnimalModel.ReturnFolder(animalID);
                return new DirectoryInfo(folder).GetFiles(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }

        public static void OpenDocument(string path)
        {
            try
            {
                System.Diagnostics.Process.Start(path);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void PrintDocument(string path)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void DeleteDocument(string path)
        {
            try
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void LoadNewAnimalDocument(int animalID)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        public static void GenerateAnimalEvidencyCard(int animalID)
        {
            try
            {
                AnimalInfo animal = AnimalModel.GetAnimalInfo(animalID);
                string path = AnimalModel.ReturnFolder(animalID);
                string FONT = "c:/windows/fonts/arial.ttf";
                BaseFont bf = BaseFont.CreateFont(
                    FONT, BaseFont.IDENTITY_H, BaseFont.EMBEDDED
                  );

                Font czFont = new Font(bf, 14);
                // Save document

                string documentName = string.Format("evidenční_karta_ID_{0}_{1}.pdf", animalID, DateTime.Now.ToShortDateString());
                string fileName = Path.Combine(path, documentName);

                Document myDocument = new Document(iTextSharp.text.PageSize.A4, 10, 10, 42, 35);
                PdfWriter.GetInstance(myDocument, new FileStream(fileName, FileMode.Create));

                myDocument.Open();

                ////////////////////////


                myDocument.Add(new Paragraph(String.Format("evidenční karta zvířete s ID: {0}", animalID), czFont));
                myDocument.Add(new Paragraph("Jméno: " + animal.Name, czFont));
                myDocument.Add(new Paragraph("Druh: " + animal.Species, czFont));
                myDocument.Add(new Paragraph("Plemeno: " + animal.Breed, czFont));
                myDocument.Add(new Paragraph("FINÁLNÍ PODOBA DOKUMENTU BUDE JEŠTĚ S ÚTULKEM DOHODNUTA", czFont));


                /////////////////////////////

                myDocument.Close();
                Process.Start(fileName);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        

        public static void ExportDataPDF(List<List<string>> data, string dataName)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ExportDataExcell(List<List<string>> data, string dataName)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
