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
            using HttpClient client = new HttpClient();
            string baseImageUrl = "https://www.google.com/search?q={query}&tbm=isch";
            string html = await client.GetStringAsync(baseImageUrl);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            var imageNodes = doc.DocumentNode.SelectNodes("//a[contains(@href, '/imgres')]");
            if (imageNodes == null)
            {
                MessageBox.Show("No images found.");
                return;
            }

            int count = 0;
            foreach (var node in imageNodes)
            {
                if (count >= amount)
                {
                    break;
                }

                string href = node.GetAttributeValue("href", string.Empty);
                if (!string.IsNullOrEmpty(href))
                {
                    string imageUrl = ExtractImageUrl(href);
                    if (!string.IsNullOrEmpty(imageUrl))
                    {
                        Console.WriteLine($"Image URL: {imageUrl}");
                        count++;
                        progressBar.Value = count;
                    }
                }
            }

            //for (int i = 0; i < amount; i++)
            //{
            //    // Simulate image download
            //    await Task.Delay(1000);
            //    progressBar.Value++;
            //    Console.WriteLine($"Scraping image {i + 1} of {amount}");
            //}

            MessageBox.Show("Scraping completed!");
        }

        private string ExtractImageUrl(string href)
        {
            var uri = new Uri("https://www.google.com" + href);
            var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
            return query.Get("imgurl")!;
        }
    }
}