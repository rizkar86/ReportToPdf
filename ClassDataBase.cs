using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SelectPdf;

namespace ReportToPDF
{
    class ClassDataBase
    {
        DataClassesDataContext dbconnect = new DataClassesDataContext();
        public List<Worker> LoadGridView()
        {
            List<Worker> listworker = new List<Worker>();
            listworker = dbconnect.Workers.ToList();
            return listworker;
        }
        public void ExportHtmlToPDF(string htmlstring,string loc)
        {
            HtmlToPdf converter = new HtmlToPdf();
            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
            PdfDocument doc = converter.ConvertHtmlString(htmlstring);
            doc.Save(loc);
            doc.Close();

        }
        //bild report
        
    }
}
