using Microsoft.Win32;
using StepsAnalyzer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StepsAnalyzer.Presentation.Services
{
    public class DialogService : IDialogService
    {
        public string FilePath { get; set; }

        public bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new();
            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
                return true;
            }

            return false;
        }

        public void ShowMessage(string message)
        {
            if (message is null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            MessageBox.Show(message, "Notification", MessageBoxButton.OK);
        }
    }
}
