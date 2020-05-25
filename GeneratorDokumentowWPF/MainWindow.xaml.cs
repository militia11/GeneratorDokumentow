using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace GeneratorDokumentowWPF
{  
    class SaveFileManager
    {
        public void saveToFile(string text, string filter)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = filter;
            saveFileDialog1.Title = "Save document";
           
            if (saveFileDialog1.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog1.FileName, text);
            }

            //FileStream fileStream = new FileStream("result.txt", FileMode.Create);
            //StreamWriter sw = new StreamWriter(fileStream);
            //sw.Write(text);
            //sw.Close();
            //fileStream.Close();
        }
    }

    interface ILabel
    {
        string DoLabel();
    }

    class SimpleLabel : ILabel
    {
        public string DoLabel()
        {
            return "<p>  </p>";
        }
    }

    class DateLabel : ILabel
    {
        public string DoLabel()
        {
            return "<p class=\"date\"> Date:  </p>";
        }
    }

    class ImageLabel : ILabel
    {
        public string DoLabel()
        {
            return "<p >< img src =\" [IMAGE_PATH] \"/>\" </p>";
        }
    }
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DocumentGenerator documentGenerator = new HTMLDocGenerator();
        ILabel labelGenerator = new SimpleLabel();
        string filter = "HTML|*.html";
        // pole generator tableComponent

        public MainWindow()
        {
            InitializeComponent();
            buttonSave.IsEnabled = false;
        }

        private void buttonGenerate_Click(object sender, RoutedEventArgs e)
        {
           buttonSave.IsEnabled = true;
           documentGenerator.DocumentDetails = textBoxData.Text;
           documentGenerator.Header = textBoxHeader.Text; 
           textBoxResult.Text = documentGenerator.GenerateDocument();
        }

        private void radioHtml_Checked(object sender, RoutedEventArgs e)
        {
            filter = "HTML|*.html";
            documentGenerator = new HTMLDocGenerator();
        }

        private void radioXml_Checked(object sender, RoutedEventArgs e)
        {
            filter = "XML|*.xml";
            documentGenerator = new XMLDocGenerator();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            labelGenerator = new DateLabel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string labelText = labelGenerator.DoLabel();

            var selectionIndex = textBoxResult.SelectionStart;
            textBoxResult.Text = textBoxResult.Text.Insert(selectionIndex, labelText);
            textBoxResult.SelectionStart = selectionIndex + labelText.Length;
        }

        private void simpleLabel_Checked(object sender, RoutedEventArgs e)
        {
           labelGenerator = new SimpleLabel();
        }

        private void imageLabel_Checked(object sender, RoutedEventArgs e)
        {
            labelGenerator = new ImageLabel();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileManager exporter = new SaveFileManager();
            exporter.saveToFile(textBoxResult.Text, filter);            
        }
    }
}