using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Removeo
{
    public partial class FormDownload : Form
    {
        WebClient client = new WebClient();

        public FormDownload(string url, string downloadedFilePath)
        {
            InitializeComponent();
            fileName.Text = "Downloading " + Path.GetFileName(downloadedFilePath);
            DownloadFile(url, downloadedFilePath);
        }

        public void DownloadFile(string url, string downloadedFilePath)
        {
            using (client)
            {
                client.DownloadProgressChanged += DownloadProgressChanged;
                client.DownloadFileCompleted += DownloadFileCompleted;
                client.DownloadFileAsync(new Uri(url), downloadedFilePath);
            }
        }

        private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            downloadBar.Value = downloadBar.Maximum;
            Close();
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            string text;
            double k = 1024, m = k * 1024, g = m * 1024;
            double total = e.TotalBytesToReceive, received = e.BytesReceived;

            downloadBar.Value = e.ProgressPercentage;
            if (total > g)
                text = string.Format($"{received / g:0.0}/{total / g:0.0} GB downloaded");
            else if (total > m)
                text = string.Format($"{received / m:0.0}/{total / m:0.0} MB downloaded");
            else if (total > k)
                text = string.Format($"{received / k:0.0}/{total / k:0.0} KB downloaded");
            else
                text = string.Format($"{received:0.0}/{total:0.0} Bytes downloaded");
            downloadStatus.Text = text;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            client.CancelAsync();
        }
    }
}
