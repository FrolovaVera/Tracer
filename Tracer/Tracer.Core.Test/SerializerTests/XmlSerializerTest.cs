using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Core.TraceResults;
using Tracer.Serialization;

namespace Tracer.Core.Test.SerializerTests
{
    [TestClass]
    public class XmlSerializerTest
    {
        private Xml xml;
        private const string SerializedResult = "???<?xml version=\"1.0\" encoding=\"utf-8\"?><TraceResult xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" />";
        private void SetUp()
        {
            xml = new Xml();
        }

        [TestMethod]
        public void TestSerialize()
        {
            SetUp();
            var traceResult = new TraceResult();
            using (MemoryStream ms = new MemoryStream())
            {
                xml.Serialize(traceResult, ms);
                Assert.AreEqual(SerializedResult, Encoding.ASCII.GetString(ms.ToArray()));
            }
        }
    }
}
