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
            // Form yüklendiğinde, dosya gezgini açılacak
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Dosya gezgini ayarları
            openFileDialog1.InitialDirectory = "c:\\"; // Başlangıç dizini
            openFileDialog1.Filter = "C# Dosyaları (*.cs)|*.cs|CSHTML Dosyaları (*.cshtml)|*.cshtml|Tüm Dosyalar (*.*)|*.*"; // Dosya filtresi
            openFileDialog1.Multiselect = true; // Çoklu dosya seçimine izin ver

            // Dosya gezginiyle dosya seçildiğinde gerçekleşecek olay
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Seçilen dosyaların içeriklerini toplamak için bir dize oluştur
                string[] fileContents = new string[openFileDialog1.FileNames.Length];

                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                {
                    string selectedFile = openFileDialog1.FileNames[i];

                    // Seçilen dosyanın uzantısını kontrol et
                    if (selectedFile.EndsWith(".cs") || selectedFile.EndsWith(".cshtml") || selectedFile.EndsWith(".html"))
                    {
                        // Dosyanın içeriğini al
                        fileContents[i] = System.IO.File.ReadAllText(selectedFile);
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz dosya uzantısı. Lütfen bir .cs, .cshtml veya .html dosyası seçin.");
                        return;
                    }
                }

                // Dosya içeriklerini birleştirerek tek bir metin oluştur
                string combinedContent = string.Join(Environment.NewLine + " " + Environment.NewLine, fileContents);

                // Dosyayı proje dizininde bir dosyaya yaz
                string fileName = "kodlarinTamami.txt";
                string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

                // Dosya varsa üzerine yaz, yoksa yeni dosya oluştur
                File.AppendAllText(outputPath, Environment.NewLine + " " + Environment.NewLine + combinedContent);

                MessageBox.Show($"Seçilen dosyaların içerikleri başarıyla '{fileName}' adlı bir metin dosyasına yazıldı.\nDosya yolu: {outputPath}");
                this.label2.Text = "Dosyaya yazdırıldı: " + outputPath;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
