using System.Diagnostics;

namespace WebViewClassLibraryCS2
{
    sealed public class Thing
    {
        public Thing()
        {

        }

        public string prop { get => "Thing string";  }

    }

    sealed public class Class1
    {
        public Class1()
        {
        }

        public void RunMe()
        {
            Debug.WriteLine("Hello from WebViewClassLibraryCS2");
        }

        public IList<string> GetNumbers()
        {
            return new List<string>() { "A", "B", "C" };
        }

        public IList<Thing> GetThings()
        {
            return new List<Thing>() { new Thing() };
        }
    }
}