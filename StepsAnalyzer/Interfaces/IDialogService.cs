using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepsAnalyzer.Interfaces
{
    public interface IDialogService
    {
        string? FilePath { get; set; }

        bool SaveFileDialog();

        void ShowMessage(string message);
    }
}
