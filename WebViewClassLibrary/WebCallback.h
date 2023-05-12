#pragma once

#include "WebCallback.g.h"

namespace winrt::WebViewClassLibrary::implementation
{
    struct WebCallback : WebCallbackT<WebCallback>
    {
        WebCallback() = default;
        void DoWork();
    };
}

namespace winrt::WebViewClassLibrary::factory_implementation
{
    struct WebCallback : WebCallbackT<WebCallback, implementation::WebCallback>
    {
    };
}
