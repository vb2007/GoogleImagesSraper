using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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
            var options = new ChromeOptions();
            //options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--window-size=1920,1080");

            using ChromeDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl($"https://www.google.com/search?q={query}&tbm=isch");

            //ignores cookie consent popup, continues if it's not present
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                var rejectButton = driver.FindElement(By.XPath("//button[contains(., 'elutasítása')]"));
                rejectButton.Click();
                await Task.Delay(2000);
            }
            catch (NoSuchElementException)
            {
                
            }

            //scrolls for more images
            //int scrollAttempts = Math.Min(amount / 20 + 1, 10); // Adjust scrolling based on amount needed
            //for (int i = 0; i < scrollAttempts; i++)
            //{
            //    ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            //    await Task.Delay(1000);  // Wait for images to load
            //}

            var imageElements = driver.FindElements(By.CssSelector("a[href*='/imgres']"));
            if (imageElements.Count == 0)
            {
                MessageBox.Show("No images found.");
                return;
            }

            int count = 0;
            foreach (var element in imageElements)
            {
                if (count >= amount)
                    break;

                string href = element.GetDomAttribute("href");
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