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
    public class JsonSerializerTest
    {
        private Json json;
        private const string SerializedResult = "{\"thread\":[]}";

        private void SetUp()
        {
            json = new Json();
        }

        [TestMethod]
        public void TestSerialize()
        {
            SetUp();
            var traceResult = new TraceResult();
            using (MemoryStream ms = new MemoryStream())
            {
                json.Serialize(traceResult,ms);
                Assert.AreEqual(SerializedResult, Encoding.ASCII.GetString(ms.ToArray()));
            }
        }
    }
}
