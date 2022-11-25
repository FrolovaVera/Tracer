using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Core.Tracers;

namespace Tracer.Core.Test.TracerTests
{
    [TestClass]
    public class ThreadTracerTest
    {
        ThreadTracer threadTracer;
        private void SetUp()
        {
            threadTracer = new ThreadTracer(1);
        }

        [TestMethod]
        public void TestGetException()
        {
            SetUp();
            Assert.ThrowsException<InvalidOperationException>(threadTracer.StopTrace);
        }

        [TestMethod]
        public void TestCheckStartStopFunction()
        {
            SetUp();
            threadTracer.StartTrace();
            threadTracer.StopTrace();
            var result = threadTracer.ThreadTraceResult;
            Assert.IsNotNull(result.Methods);

        }
    }
}
