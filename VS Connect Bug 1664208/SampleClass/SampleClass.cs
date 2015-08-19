using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAssembly
{
    public class SampleClass
    {
        public MemoryStream ReturnsAMemoryStream()
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write("SampleClass Memory Stream");
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
