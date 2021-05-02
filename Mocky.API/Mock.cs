using System;
using System.Collections.Generic;

namespace Mocky.API
{
    public class Mock
    {
        public string Content { get; set; }
        public int Status { get; set; }
        public string ContentType { get; set; }
        public string Charset { get; set; }
        public Dictionary<string, string> Headers { get; set; }
    }
}
