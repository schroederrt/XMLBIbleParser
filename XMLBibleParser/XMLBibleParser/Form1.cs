using System.IO;
using System.Xml;

namespace XMLBibleParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLookup_Click(object sender, EventArgs e)
        {
            dlgSelectFile.ShowDialog();

            txtInputFile.Text = dlgSelectFile.FileName;
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(txtInputFile.Text);

            string strTextToWrite = "";

            foreach (XmlNode ElementToProcess in xmlDocument)
            {
                foreach (XmlNode BookNode in ElementToProcess.ChildNodes)
                {
                    strTextToWrite += System.Environment.NewLine;
                    strTextToWrite += System.Environment.NewLine;
                    strTextToWrite += BookNode.Attributes[0].Value;
                    strTextToWrite += System.Environment.NewLine;
                    strTextToWrite += System.Environment.NewLine;

                    foreach (XmlNode chapterNode in BookNode.ChildNodes)
                    {
                        strTextToWrite += "Chapter: ";
                        strTextToWrite += chapterNode.Attributes[0].Value;
                        strTextToWrite += System.Environment.NewLine;

                        foreach (XmlNode verseNode in chapterNode.ChildNodes)
                        {
                            strTextToWrite += verseNode.Attributes[0].Value;
                            strTextToWrite += " ";
                            strTextToWrite += verseNode.InnerText;
                            strTextToWrite += " ";
                        }

                        strTextToWrite += System.Environment.NewLine;

                    }
                }
               
            }
            richTextBox1.Text = strTextToWrite;
        }
    }
}