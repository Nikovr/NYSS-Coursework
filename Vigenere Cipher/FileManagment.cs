using System;
using System.Reflection;
using Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace Vigenere_Cipher
{
    public static class FileManagement
    {
        public static void Save(string text)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt|Microsoft Word (.docx)|*.docx";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                if (Path.GetExtension(dlg.FileName) == ".docx")
                {
                    Application app = new Application();
                    Document doc = app.Documents.Add();

                    var paragraph = doc.Paragraphs.Add();
                    paragraph.Range.Text = text;
                    app.ActiveDocument.SaveAs(dlg.FileName, WdSaveFormat.wdFormatDocumentDefault);

                    doc.Close();
                    app.Quit();
                    Marshal.FinalReleaseComObject(app);
                }
                else
                {
                    File.WriteAllText(dlg.FileName, text);
                }
            }
        }

        public static string Upload()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt|Microsoft Word (.docx)|*.docx";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                if (Path.GetExtension(dlg.FileName) == ".docx")
                {
                    Application app = new Application();
                    Document doc = app.Documents.Open(dlg.FileName);

                    string text = doc.Content.Text;

                    doc.Close();
                    app.Quit();
                    Marshal.FinalReleaseComObject(app);

                    return text;

                }
                else
                {
                    string text = "";
                    using (StreamReader file = new StreamReader(dlg.FileName, true))
                    {
                        string line;

                        while ((line = file.ReadLine()) != null)
                        {
                            text += line;
                        }
                    }
                    return text;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
