using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Xps.Packaging;
using System.Windows.Xps;
using System.IO.Packaging;
using System.Collections.ObjectModel;
using System.Data;

namespace PiccoloGroup
{
    /// <summary>
    /// Interaction logic for PrintWindow.xaml
    /// </summary>
    public partial class PrintWindow : Window
    {
        public PrintWindow(DataTable PrintDT)
        {
            InitializeComponent();

            PrintDT.Columns.Remove("ShowID");
            PrintDT.Columns.Remove("Excel");
            PrintDT.Columns.Remove("Length");
            PrintDT.Columns.Remove("Credits");
            PrintDT.Columns.Remove("Censor");
            PrintDT.Columns.Remove("Publisher");

            DataGrid DGToUse = new DataGrid();
            DGToUse.HeadersVisibility = DataGridHeadersVisibility.Column;
            DGToUse.ItemsSource = PrintDT.DefaultView;

            FixedDocument fix = new FixedDocument();
            PageContent pc = new PageContent();
            FixedPage fp = new FixedPage();
            fp.Width = fix.DocumentPaginator.PageSize.Width;
            fp.Height = fix.DocumentPaginator.PageSize.Height;

            fp.Children.Add(DGToUse);
            ((System.Windows.Markup.IAddChild)pc).AddChild(fp);

            fix.Pages.Add(pc);


            XpsDocument YourXpsDoc;
            MemoryStream ms = new MemoryStream();
            Uri DocumentUri = new Uri("pack://document.xps");
            Package p = Package.Open(ms, FileMode.Create, FileAccess.ReadWrite);
            PackageStore.AddPackage(DocumentUri, p);
            YourXpsDoc = new XpsDocument(p, CompressionOption.NotCompressed, DocumentUri.AbsoluteUri);

            XpsDocumentWriter dw = XpsDocument.CreateXpsDocumentWriter(YourXpsDoc);
            dw.Write(fix);
            FixedDocumentSequence fixedDocumentSequence = YourXpsDoc.GetFixedDocumentSequence();

            PrintView.Document = fixedDocumentSequence;

            YourXpsDoc.Close();
            PackageStore.RemovePackage(DocumentUri);
            ms.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

