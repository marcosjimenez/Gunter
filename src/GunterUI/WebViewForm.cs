using Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GunterUI
{
    public partial class WebViewForm : Form, IDataWindow
    {

        public string CurrentUrl { get; set; }

        public string HtmlContent { get; set; }

        public Form Form { get => this; }

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

        public new void Update()
        {
            webView21.Refresh();
            base.Update();
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

        public bool SetExtraData(object data)
        {
            if (Uri.TryCreate(data.ToString(), UriKind.Absolute, out var resultUri))
            {
                CurrentUrl = resultUri.ToString();
                webView21.CoreWebView2.Navigate(CurrentUrl);
            }
            else
            {
                
                webView21.NavigateToString(data.ToString());
            }

            return true;
        }
    }
}
