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
    public class YamlSerializerTest
    {
        private Yaml yaml;
        private const string SerializedResult = "thread: []\r\n";
        private void SetUp()
        {
            yaml = new Yaml();
        }

        [TestMethod]
        public void TestSerialize()
        {
            SetUp();
            var traceResult = new TraceResult();
            using (MemoryStream ms = new MemoryStream())
            {
                yaml.Serialize(traceResult, ms);
                Assert.AreEqual(SerializedResult, Encoding.ASCII.GetString(ms.ToArray()));
            }
        }
    }
}
