using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceAutomatedTest
{
    public class NotImplementedBrowserException : Exception
    {
        public NotImplementedBrowserException() { }

        public NotImplementedBrowserException(string message) : base(message) { }

        public NotImplementedBrowserException(string message, Exception inner) : base(message, inner) { }
    }
}
