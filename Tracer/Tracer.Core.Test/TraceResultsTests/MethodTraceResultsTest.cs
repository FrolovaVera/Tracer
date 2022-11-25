using Tracer.Core.TraceResults;

namespace Tracer.Core.Test.MethodTraceResultsTest
{
    [TestClass]
    public class MethodTraceResultsTest
    {
        private MethodTraceResult methodTraceResult;

        private const string ClassName = "Class1";
        private const string MethodName = "Method1";
        private const double Time = 400;

        private void SetUp()
        {
            methodTraceResult = new MethodTraceResult(ClassName, MethodName);
        }

        [TestMethod]
        public void TestGetMethodName()
        {
            SetUp();
            var actual = methodTraceResult.MethodName;
            Assert.AreEqual(MethodName, actual);
        }

        [TestMethod]
        public void TestGetClassName()
        {
            SetUp();
            var actual = methodTraceResult.ClassName;
            Assert.AreEqual(ClassName, actual);
        }

        [TestMethod]
        public void TestGetTime()
        {
            SetUp();
            methodTraceResult.Time = Time;
            var actual = methodTraceResult.Time;
            Assert.AreEqual(Time, actual);
        }
    }
}