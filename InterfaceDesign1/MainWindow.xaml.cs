using DocumentFormat.OpenXml.Office2013.Word;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InterfaceDesign1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string path = "1.txt";

        private void Bwrite_Click(object sender, RoutedEventArgs e)
        {
            string dop = "";
            if (CBlazy.IsChecked == true)
            {
                dop += CBlazy.Content + ";";
            }
            if (CBenvy.IsChecked == true)
            {
                dop += CBenvy.Content + ";";
            }
            if (CBgreed.IsChecked == true)
            {
                dop += CBgreed.Content;
            }

            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Append)))
            {
                bw.Write(TBName.Text);
                bw.Write(DPdt.SelectedDate.ToString());
                bw.Write(dop);
                if (RBmen.IsChecked == true)
                {
                    bw.Write("Мужской");
                }
                if (RBwomen.IsChecked == true)
                {
                    bw.Write("Женский");
                }
                ListBoxItem lb = (ListBoxItem)LBsp.SelectedItem;
                string sp;
                sp = (string)lb.Content;
                bw.Write(sp);
            }
        }

        private void Bread_Click(object sender, RoutedEventArgs e)
        {
            List<Peoples> ListAnketa = new List<Peoples>();
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (br.PeekChar() > -1)
                {
                    Peoples p = new Peoples { Name = br.ReadString(), DR = br.ReadString(), Osob = br.ReadString(), Gender = br.ReadString(), SP = br.ReadString() };
                    ListAnketa.Add(p);
                }
            }
            dgPeoples.ItemsSource = ListAnketa;
        }
    }
}