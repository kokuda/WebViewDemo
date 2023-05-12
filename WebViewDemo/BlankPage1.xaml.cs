// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml.Controls;
using System;
using System.Diagnostics;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WebViewDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
            InitializeAsync();
        }

        public void AppFunction()
        {
            Debug.WriteLine("AppFunction");
        }

        private async void InitializeAsync()
        {
            await WebViewControl.EnsureCoreWebView2Async();
            StorageFile f = await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///demo.html"));
            HtmlBox.Text = await FileIO.ReadTextAsync(f);
            var dispatchAdapter = new WinRTAdapter.DispatchAdapter();
            WebViewControl.CoreWebView2.AddHostObjectToScript("WebViewClassLibraryCS2", dispatchAdapter.WrapNamedObject("WebViewClassLibraryCS2", dispatchAdapter));
            WebViewControl.CoreWebView2.AddHostObjectToScript("WebViewClassLibrary", dispatchAdapter.WrapNamedObject("WebViewClassLibrary", dispatchAdapter));
            WebViewControl.CoreWebView2.AddHostObjectToScript("Windows", dispatchAdapter.WrapNamedObject("Windows", dispatchAdapter));

            var class1 = new WebViewClassLibraryCS2.Class1();
            WebViewControl.CoreWebView2.AddHostObjectToScript("class1", dispatchAdapter.WrapObject(class1, dispatchAdapter));

            WebViewControl.CoreWebView2.OpenDevToolsWindow();
        }

        private void LoadHtml()
        {
            // Grab the HTML from the text box and load it into the WebView.
            WebViewControl.NavigateToString(HtmlBox.Text);
        }

        private async void InvokeScript()
        {
            // Invoke the javascript function called 'doSomething' that is loaded into the WebView.
            try
            {
                string result = await WebViewControl.ExecuteScriptAsync("doSomething(\"test\")");
                Debug.WriteLine($"Script returned \"{result}\"");
            }
            catch (Exception ex)
            {
                string errorText = ex.HResult switch
                {
                    unchecked((int)0x80020006) => "There is no function called doSomething",
                    unchecked((int)0x80020101) => "A JavaScript error or exception occured while executing the function doSomething",
                    unchecked((int)0x800a138a) => "doSomething is not a function",
                    _ => ex.Message,// Some other error occurred.
                };
                Debug.WriteLine(errorText);
            }
        }

    }
}
