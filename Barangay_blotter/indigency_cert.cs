using Spire.Doc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barangay_blotter
{
    public partial class indigency_cert : Form
    {
        string filename = "";
        public indigency_cert()
        {
            InitializeComponent();
            status.Items.Add("Single");
            status.Items.Add("Married");
            status.Text = "Single";
            gender.Items.Add("Male");
            gender.Items.Add("Female");
            gender.Text = "Male";
        }

        private void print_Click(object sender, EventArgs e)
        {
            process_docx();
            print_indigency();
            this.Hide();
        }

        private void process_docx()
        {
            var application = new Microsoft.Office.Interop.Word.Application();
            var document = new Microsoft.Office.Interop.Word.Document();
            document = application.Documents.Add(Template: @"C:\Users\Fzkn4\Documents\Certificate  of Indigency.docx");
            application.Visible = true;
            application.Activate();

            try
            {
                foreach (Microsoft.Office.Interop.Word.Field field in document.Fields)
                {
                    if (field.Code.Text.Contains("date"))
                    {
                        field.Select();
                        application.Selection.TypeText(DateTime.Now.Date.ToString("MMMM dd, yyyy"));
                    }
                    else if (field.Code.Text.Contains("fname"))
                    {
                        field.Select();
                        application.Selection.TypeText(first_letter_capital(fname.Text));
                    }

                    else if (field.Code.Text.Contains("mname"))
                    {
                        field.Select();
                        application.Selection.TypeText(first_letter_capital(mname.Text));
                    }
                    else if (field.Code.Text.Contains("lname"))
                    {
                        field.Select();
                        application.Selection.TypeText(first_letter_capital(lname.Text));
                    }
                    else if (field.Code.Text.Contains("age"))
                    {
                        field.Select();
                        application.Selection.TypeText(age.Text);
                    }

                    else if (field.Code.Text.Contains("status"))
                    {
                        field.Select();
                        application.Selection.TypeText(status.Text);
                    }
                    else if (field.Code.Text.Contains("gender"))
                    {
                        field.Select();
                        application.Selection.TypeText(gender.Text);
                    }
                }
                filename = "INDIGENCYCert-" + lname.Text + fname.Text + mname.Text;
                document.SaveAs2(FileName: @"C:\Users\Fzkn4\Documents\" + filename + ".docx");
                document.Close();
                application.Quit();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void print_indigency()
        {
            //Create a Document object
            Document doc = new Document();

            //Load a Word document
            doc.LoadFromFile("C:\\Users\\Fzkn4\\Documents\\" + filename + ".docx");

            //Get the PrintDocument object
            PrintDocument printDoc = doc.PrintDocument;

            //Specify the printer name
            printDoc.PrinterSettings.PrinterName = "EPSON L120 Series";

            //Specify the range of pages to print
            printDoc.PrinterSettings.FromPage = 1;
            printDoc.PrinterSettings.ToPage = 5;

            //Set the number of copies to print
            printDoc.PrinterSettings.Copies = 1;

            //Print the document
            printDoc.Print();
        }
        private string first_letter_capital(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }
    }
}
