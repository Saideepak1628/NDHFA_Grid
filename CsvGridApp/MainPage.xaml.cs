using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Microsoft.Maui.Controls;

namespace CsvGridApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Row> Rows { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Rows = new ObservableCollection<Row>();
            LoadCsv();
            CsvGrid.ItemsSource = Rows;

            CsvGrid.SelectionChanged += OnRowSelected;
        }

        private void LoadCsv()
        {
            try
            {
                // Path where data.csv is stored inside the app container
                var filePath = Path.Combine(FileSystem.AppDataDirectory, "data.csv");

                // If file doesn’t exist, create one with sample data
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, "1,2,3\n4,5,6\n7,8,9");
                }

                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 3)
                    {
                        Rows.Add(new Row
                        {
                            Col1 = parts[0],
                            Col2 = parts[1],
                            Col3 = parts[2]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        private async void OnRowSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Row row)
            {
                await DisplayAlert("Cell Value",
                    $"Selected: {row.Col1}, {row.Col2}, {row.Col3}", "OK");
            }
        }

        private void LogError(Exception ex)
        {
            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "error_log.txt"
            );
            File.AppendAllText(path, $"{DateTime.Now}: {ex.Message}{Environment.NewLine}");
        }
    }

    // Model class for CSV rows
    public class Row
    {
        public string Col1 { get; set; }
        public string Col2 { get; set; }
        public string Col3 { get; set; }
    }
}
