#include "pch.h"
#include "WebCallback.h"
#include "WebCallback.g.cpp"

namespace winrt::WebViewClassLibrary::implementation
{
    void WebCallback::DoWork()
    {
        ::OutputDebugStringA("Working!\n");
    }
}
