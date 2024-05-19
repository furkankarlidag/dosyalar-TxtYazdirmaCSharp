namespace dosyalarıTxtYazdirma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            
            openFileDialog1.InitialDirectory = "c:\\"; 
            openFileDialog1.Filter = "C# Dosyaları (*.cs)|*.cs|CSHTML Dosyaları (*.cshtml)|*.cshtml|Tüm Dosyalar (*.*)|*.*"; 
            openFileDialog1.Multiselect = true; 

          
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
              
                string[] fileContents = new string[openFileDialog1.FileNames.Length];

                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                {
                    string selectedFile = openFileDialog1.FileNames[i];

                   
                    if (selectedFile.EndsWith(".cs") || selectedFile.EndsWith(".cshtml") || selectedFile.EndsWith(".html"))
                    {
                        
                        fileContents[i] = System.IO.File.ReadAllText(selectedFile);
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz dosya uzantısı. Lütfen bir .cs, .cshtml veya .html dosyası seçin.");
                        return;
                    }
                }

                try
                {
                    
                    string combinedContent = string.Join(Environment.NewLine + " " + Environment.NewLine, fileContents);

                   
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                   
                    string fileName = "kodlarinTamami.txt";
                    string outputPath = Path.Combine(desktopPath, fileName);

                    File.AppendAllText(outputPath, Environment.NewLine + " " + Environment.NewLine + combinedContent);

                    MessageBox.Show($"Seçilen dosyaların içerikleri başarıyla '{fileName}' adlı bir metin dosyasına yazıldı.\nDosya yolu: {outputPath}");
                    this.label2.Text = "Dosyaya yazdırıldı: " + outputPath;
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("Dosyaya yazma izniniz yok. Lütfen uygulamayı yönetici olarak çalıştırmayı deneyin veya farklı bir konum seçin.\n\n" + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
