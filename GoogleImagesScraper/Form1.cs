namespace GoogleImageScraper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            string query = textBoxQuery.Text;
            int amount = (int)numericUpDownCount.Value;

            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Please enter a query.");
                return;
            }

            progressBar.Value = 0;
            progressBar.Maximum = amount;

            await ScrapeImagesAsync(query, amount);
        }

        private async Task ScrapeImagesAsync(string query, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                // Simulate image download
                await Task.Delay(1000);
                progressBar.Value++;
                Console.WriteLine($"Scraping image {i + 1} of {amount}");
            }

            MessageBox.Show("Scraping completed!");
        }
    }
}