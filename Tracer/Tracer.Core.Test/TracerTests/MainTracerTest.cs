using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tracer.Core.Tracers;

namespace Tracer.Core.Test.TracerTests
{
    [TestClass]
    public class MainTracerTest
    {
        private MainTracer mainTracer;

        private void SetUp()
        {
            mainTracer = new MainTracer();
        }

        [TestMethod]
        public void TestGetException()
        {
            SetUp();
            Assert.ThrowsException<InvalidOperationException>(mainTracer.StopTrace);
        }

        [TestMethod]
        public void TestCheckStartStopFunction()
        {
            SetUp();

            Thread firstThread = new Thread(method);
            firstThread.Start();

            Thread secondThread = new Thread(method);
            secondThread.Start();

            while (secondThread.IsAlive || firstThread.IsAlive)
            {

            }

            var result = mainTracer.GetTraceResult();
            Assert.AreEqual(2,result.ThreadTraceResults.Count);

        }

        private void method()
        {
            mainTracer.StartTrace();
            Thread.Sleep(100);
            mainTracer.StopTrace();
        }

    }
}
