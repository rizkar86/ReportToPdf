using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportToPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ClassDataBase db = new ClassDataBase();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.LoadGridView();
           
            string loc = @"c:\test\sample300.pdf";
            db.ExportHtmlToPDF(buildReport(), loc);

        }
        public string buildReport()
        {
            StringBuilder sb = new StringBuilder();
            string HeaderT = ReadheaderhtmlFile("Header.html");
            sb.Append(HeaderT);
            string BdyHeaderT = LoadRepotTable();
            sb.Append(BdyHeaderT);
            string futer = ReadhtmlFile("Foter.html");
            sb.Append(futer);

            return sb.ToString();
        }
        public string ReadhtmlFile(string filename)

        {
            string text = File.ReadAllText(filename);
            return text;

        }
        public string ReadheaderhtmlFile(string filename)

        {
            StringBuilder sb = new StringBuilder();
            string text = File.ReadAllText(filename);
            sb.Append(text.Replace("[[NA]]", DateTime.Now.ToString("yyyy-MM-dd")));

            return sb.ToString();

        }
        public string LoadRepotTable()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" <tr>");
            for (int i = 0; i <dataGridView1.Columns.Count ; i++)
            {
                string th= ReadhtmlFile("Bodyhead.html");

                sb.Append(th.Replace("[[NA]]", dataGridView1.Columns[i].Name));
            }
            sb.Append("</tr>");
           
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sb.Append("<tr>");

                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    
                    string TH = ReadhtmlFile("Body.html");
                    
                    sb.Append(TH.Replace("[[NA]]", dataGridView1.Rows[i].Cells[j].Value.ToString()));
                }
                sb.Append("</tr>");
            }
            
            return sb.ToString();



        }
    }
}
