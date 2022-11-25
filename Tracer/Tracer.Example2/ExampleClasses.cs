using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Core.Tracers;

namespace Tracer.Example
{
    public static class classA
    {
        public static void MethodA(ref ITracer tracer)
        {
            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();
        }
    }
    public static class classB
    {
        public static void MethodB(ref ITracer tracer)
        {
            tracer.StartTrace();
            classA.MethodA(ref tracer);
            Thread.Sleep(100);
            tracer.StopTrace();
        }
    }

}
