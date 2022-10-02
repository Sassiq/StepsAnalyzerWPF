namespace StepsAnalyzer.Interfaces
{
    public interface IDialogService
    {
        string? FilePath { get; set; }

        bool SaveFileDialog();

        void ShowMessage(string message);
    }
}
