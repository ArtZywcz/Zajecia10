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
using System.Windows.Shapes;

namespace Zajecia10
{
    /// <summary>
    /// Interaction logic for FileWatcher.xaml
    /// </summary>
    public partial class FileWatcher : Window
    {
        public FileWatcher()
        {
            InitializeComponent();

            TextBox1.DataContext = fileContent;
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Changed += Watcher_Changed;
        }

        private Files fileContent = new Files();
        private FileSystemWatcher watcher = new FileSystemWatcher();
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Title = "Wybierz plik",
                Filter = "TextFile|*txt"
            };

            var result = fileDialog.ShowDialog(this);
            if (!result.HasValue || !result.Value)
            {
                return;
            }

            fileContent.path = fileDialog.FileName;
            watcher.Path = fileDialog.FileName.Replace(fileDialog.SafeFileName, string.Empty);
            watcher.EnableRaisingEvents = true;
            LoadFilePath();

        }

        private void LoadFilePath()
        {
            var text = File.ReadAllText(fileContent.path);
            fileContent.Content = text;
            TextBox1.DataContext = fileContent;
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            LoadFilePath();
        }
    }
}
