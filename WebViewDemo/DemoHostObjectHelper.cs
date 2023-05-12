// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.Web.WebView2.Core;

namespace WebViewDemo
{
    internal class DemoHostObjectHelper : ICoreWebView2DispatchAdapter
    {
        public void Clean()
        {
            throw new System.NotImplementedException();
        }

        public object UnwrapObject(object wrapped)
        {
            throw new System.NotImplementedException();
        }

        public object WrapNamedObject(string name, ICoreWebView2DispatchAdapter adapter)
        {
            throw new System.NotImplementedException();
        }

        public object WrapObject(object unwrapped, ICoreWebView2DispatchAdapter adapter)
        {
            throw new System.NotImplementedException();
        }
    }
}