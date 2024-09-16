namespace PAMNotes
{
    public partial class MainPage : ContentPage
    {
        string filePath = Path.Combine(FileSystem.AppDataDirectory, "Notes.txt");
        public MainPage()
        {
            InitializeComponent();
            if (File.Exists(filePath))
            {
                NoteEditor.Text = File.ReadAllText(filePath);
            }
            else
            {
                
            }
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            string textoNota = NoteEditor.Text;
            SemanticScreenReader.Announce(textoNota);
            Labeltxt.Text = $"Arquivo salvo em {filePath}";
            DisplayAlert("Alerta", "Arquivo salvo com sucesso!", "OK");
            File.WriteAllText(filePath, textoNota);
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                DisplayAlert("Alerta", "Arquivo deletado com sucesso!", "OK");
                NoteEditor.Text = string.Empty;
                Labeltxt.Text = "";
            }
            else
            {
                NoteEditor.Text = string.Empty;
                DisplayAlert("Alerta", "Arquivo não encontrado", "Ok");
                
            }
        }
    }

}
