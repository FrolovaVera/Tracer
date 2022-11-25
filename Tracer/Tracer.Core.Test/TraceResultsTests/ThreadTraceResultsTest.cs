using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tracer.Core.TraceResults;

namespace Tracer.Core.Test.TraceResultsTests
{
    [TestClass]
    public class ThreadTraceResultTest
    {
        private const int ThreadId = 1;
        private const double Time = 100;

        private MethodTraceResult methodTraceResult;
        private ThreadTraceResult threadTraceResult;

        private void SetUp()
        {
            threadTraceResult = new ThreadTraceResult(ThreadId);
            methodTraceResult = new MethodTraceResult("Class1", "Method1") { Time = Time };
            threadTraceResult.AddMethod(methodTraceResult);
        }

        [TestMethod]
        private void TestGetThreadId()
        {
            SetUp();
            var actual = threadTraceResult.ThreadId;
            Assert.AreEqual(ThreadId, actual);
        }

        [TestMethod]
        private void TestGetDuration()
        {
            SetUp();
            var actual = threadTraceResult.Time;
            Assert.AreEqual(Time, actual);
        }

        public void TestGetMethodTraceResult()
        {
            SetUp();
            var actual = methodTraceResult.NestedMethodTraceResults[0];
            Assert.AreEqual(methodTraceResult, actual);
        }
    }
}
