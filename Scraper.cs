using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoManipulation
{
    public partial class Scraper : Form
    {
        public Scraper()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        class ImageScrape
        {

            public byte[] GetImage(string url)
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                var response = (HttpWebResponse)request.GetResponse();

                using (Stream dataStream = response.GetResponseStream())
                {
                    if (dataStream == null)
                        return null;
                    using (var sr = new BinaryReader(dataStream))
                    {
                        byte[] bytes = sr.ReadBytes(100000000);

                        return bytes;
                    }
                }

                return null;
            }


            public string GetHtmlCode(string yourquery)
            {

                string url = "https://www.google.com/search?q=" + yourquery + "&tbm=isch";
                string data = "";

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";

                var response = (HttpWebResponse)request.GetResponse();

                using (Stream dataStream = response.GetResponseStream())
                {
                    if (dataStream == null)
                        return "";
                    using (var sr = new StreamReader(dataStream))
                    {
                        data = sr.ReadToEnd();
                    }
                }
                return data;
            }

            public List<string> GetUrls(string html)
            {
                var urls = new List<string>();

                int ndx = html.IndexOf("\"ou\"", StringComparison.Ordinal);

                while (ndx >= 0)
                {
                    ndx = html.IndexOf("\"", ndx + 4, StringComparison.Ordinal);
                    ndx++;
                    int ndx2 = html.IndexOf("\"", ndx, StringComparison.Ordinal);
                    string url = html.Substring(ndx, ndx2 - ndx);
                    urls.Add(url);
                    ndx = html.IndexOf("\"ou\"", ndx2, StringComparison.Ordinal);
                }
                return urls;
            }

            public void searchbuttonclick(string query)
            {
                string location = "";

                FolderBrowserDialog abc = new FolderBrowserDialog();
                DialogResult result = abc.ShowDialog();
                if (result == DialogResult.OK)
                {
                    location = abc.SelectedPath;
                }
                string @l = location;
                MessageBox.Show(location);
                string html = GetHtmlCode(query);
                List<string> urls = GetUrls(html);
                var rnd = new Random();
                for (int i = 0; i < 50; i++)
                {
                    int b = i;
                    b++;
                    int randomUrl = rnd.Next(i, b);
                    string luckyUrl = urls[randomUrl];
                    using (WebClient webClient = new WebClient())
                    {
                        byte[] data = webClient.DownloadData(luckyUrl);
                        using (MemoryStream mem = new MemoryStream(data))
                        {
                            using (var yourImage = Image.FromStream(mem))
                            {
                                yourImage.Save(l + "/" + i + ".jpg", ImageFormat.Jpeg);
                            }
                        }

                    }

                }
            }
        }
    }
}
