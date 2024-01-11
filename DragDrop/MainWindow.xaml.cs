using Microsoft.Win32;
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

namespace DragDrop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StackPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy;
            ButtonFile.Content = "Отпусти мышь";
        }

        private void StackPanel_DragLeave(object sender, DragEventArgs e)
        {
            ButtonFile.Content = "Перетащи файл или нажми";
        }

        private void StackPanel_Drop(object sender, DragEventArgs e)
        {
            ButtonFile.Content = "Перетащи файл или нажми";
            List<string> paths = new List<string>();
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string obj in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                if (Directory.Exists(obj))
                    paths.AddRange(Directory.GetFiles(obj, "*.*", SearchOption.AllDirectories));
                else
                    paths.Add(obj);
                LabelLineFile.Content = string.Join("\r\n", paths);
            }
            
        }

        private void ButtonFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Укажите какой-нибуль файл";
            file.InitialDirectory = @"C:\User\roman\Рабочий стол";
            if ((bool)file.ShowDialog())
                LabelLineFile.Content = file.FileName ;
            
        }

    }
}
