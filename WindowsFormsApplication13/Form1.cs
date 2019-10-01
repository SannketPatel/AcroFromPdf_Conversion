using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Xfa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string location = "../../Data/CustomInvoice.pdf";
            //Load the PDF document             
            PdfLoadedDocument page1Document = new PdfLoadedDocument(location);
            
           //Created new Pdf Document
            PdfDocument doc = new PdfDocument();
            //Gets the form from Loaded document
            PdfLoadedForm form = page1Document.Form;
            //Gets the Form fields
            PdfLoadedFormFieldCollection field = form.Fields;

            // fill the form fields.
            for (int i = 0; i < field.Count;i++ )
            {
                string name = (form.Fields[i].Name);
                (form.Fields[name]).Flatten = true;
                (form.Fields[name]).ToolTip = "sample";                
            }
        
            //flattens the whole form.
            form.Flatten = true;
            //Append the loaded document
            doc.Append(page1Document);
            //Save the document and dispose it
            doc.Save("Converted-"+ DateTime.Now.ToString("mmssddMMyyyy") +".pdf");
            doc.Close();

            label1.Text = "Done. Please check Bin folder.";
        }
    }
}
