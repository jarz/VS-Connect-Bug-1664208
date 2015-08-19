using System;
using System.IO;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleAssembly;
using SampleAssembly.Fakes;

namespace SampleTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (ShimsContext.Create())
            {
                const string fakeStr = "Faked Memory Stream";

                ShimSampleClass.AllInstances.ReturnsAMemoryStream = (@this) =>
                    {
                        var stream = new MemoryStream();
                        var writer = new StreamWriter(stream);
                        writer.Write(fakeStr);
                        writer.Flush();
                        stream.Position = 0;
                        return stream;
                    };

                var sampleObj = new SampleClass();
                using (var sampleStream = sampleObj.ReturnsAMemoryStream())
                using (var reader = new StreamReader(sampleStream))
                {
                    var returnedString = reader.ReadToEnd();
                    Assert.AreEqual(fakeStr, returnedString);
                }
            }
        }
    }
}
