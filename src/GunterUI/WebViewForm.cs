using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GunterUI
{
    public partial class WebViewForm : Form
    {

        public string CurrentUrl { get; set; }

        public string HtmlContent { get; set; }

        public WebViewForm()
        {
            InitializeComponent();
            CurrentUrl = string.Empty;
        }

        public WebViewForm(Uri url)
        {
            InitializeComponent();
            InitializeWebView();
            CurrentUrl = url.ToString();
        }

        public WebViewForm(string htmlContent)
        {
            InitializeComponent();
            InitializeWebView();
            HtmlContent = htmlContent;
            CurrentUrl = string.Empty;
        }


        private async Task InitializeWebView()
        {
            await webView21.EnsureCoreWebView2Async();
        }

        private void webView21_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CurrentUrl))
            {
                webView21.CoreWebView2.Navigate(CurrentUrl);
            }
            else if (!string.IsNullOrWhiteSpace(HtmlContent))
            {
                webView21.NavigateToString(HtmlContent);
            }
        }
    }
}
