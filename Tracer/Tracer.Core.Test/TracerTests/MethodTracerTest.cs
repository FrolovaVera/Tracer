using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Core.TraceResults;
using Tracer.Core.Tracers;

namespace Tracer.Core.Test.TracerTests
{
    [TestClass]
    public class MethodTracerTest
    {
        private const string ClassName = "Class1";
        private const string MethodName = "Method1";
        private const string ClassName2 = "Class2";
        private const string MethodName2 = "Method2";
        private const string InnerClassName = "InnerClass";
        private const string InnerMethodName = "InnerMethod";

        private MethodTracer methodTracer;

        private void SetUp()
        {
            methodTracer = new MethodTracer();
        }

        [TestMethod]
        public void TestGetException()
        {
            SetUp();
            Assert.ThrowsException<InvalidOperationException>(methodTracer.StopTrace);
        }

        [TestMethod]
        public void TestCheckIsAlive()
        {
            SetUp();
            methodTracer.StartTrace(ClassName, MethodName);
            Assert.IsTrue(methodTracer.IsActive());
            methodTracer.StartTrace(InnerClassName, InnerMethodName);
            methodTracer.StopTrace();
            Assert.IsTrue(methodTracer.IsActive());
            methodTracer.StopTrace();
            Assert.IsFalse(methodTracer.IsActive());
        }

        [TestMethod]
        public void TestCheckIsAlive2()
        {
            SetUp();
            methodTracer.StartTrace(ClassName, MethodName);
            methodTracer.StartTrace(InnerClassName, InnerMethodName);
            methodTracer.StartTrace(InnerClassName, InnerMethodName);
            methodTracer.StopTrace();
            methodTracer.StopTrace();
            methodTracer.StopTrace();
            Assert.IsFalse(methodTracer.IsActive());
        }

        [TestMethod]
        public void TestCheckIsAlive3()
        {
            SetUp();
            methodTracer.StartTrace(ClassName, MethodName);
            methodTracer.StopTrace();
            Assert.IsFalse(methodTracer.IsActive());
            methodTracer.StartTrace(InnerClassName, InnerMethodName);
            methodTracer.StartTrace(InnerClassName, InnerMethodName);
            methodTracer.StopTrace();
            methodTracer.StopTrace();
            Assert.IsFalse(methodTracer.IsActive());
        }

        [TestMethod]
        public void TestGetResult()
        {
            SetUp();
            methodTracer.StartTrace(ClassName, MethodName);
            methodTracer.StartTrace(InnerClassName, InnerMethodName);
            methodTracer.StopTrace();
            methodTracer.StartTrace(ClassName2, MethodName2);
            methodTracer.StopTrace();
            methodTracer.StopTrace();
            var result = methodTracer.GetTraceResult();
            Assert.AreEqual(result.ClassName, ClassName);
            Assert.AreEqual(result.MethodName, MethodName);
            var nestedResult = result.NestedMethodTraceResults[0];
            Assert.AreEqual(nestedResult.ClassName, InnerClassName);
            Assert.AreEqual(nestedResult.MethodName, InnerMethodName);
            nestedResult = result.NestedMethodTraceResults[1];
            Assert.AreEqual(nestedResult.ClassName, ClassName2);
            Assert.AreEqual(nestedResult.MethodName, MethodName2);
        }


    }
}
