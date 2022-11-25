using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Tracer.Core;
using Tracer.Core.TraceResults;
using Tracer.Core.Tracers;

namespace Tracer.Example
{
    internal class Program
    {
        private static ITracer tracer = new MainTracer();
        static void Main(string[] args)
        {
            TraceResult traceResult = new TraceResult(); 

            Thread thread = new Thread(new ThreadStart(AnotherThreadMethod));
            thread.Start(); 

            classA.MethodA(ref tracer);
            classB.MethodB(ref tracer);

            while (thread.IsAlive)// ожидаем пока все потоки закончаться, чтобы программа не закрылась
            {

            }

            var res = tracer.GetTraceResult();

            JsonSerilaization(res);
            XmlSerilaization(res);
            YamlSerilaization(res);
        }

        private static void AnotherThreadMethod()
        {
            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();
        }

        private static void JsonSerilaization(TraceResult res)
        {
            MethodInfo myMethod = null;
            object obj = Tracer.Core.Plugin.getAddon("Tracer.Serialization.Json", "Serialize", ref myMethod);
            using (FileStream fs = new FileStream("methods.json", FileMode.Create))
            {
                myMethod.Invoke(obj, new object[] { res, fs });
            }
        }

        private static void XmlSerilaization(TraceResult res)
        {
            MethodInfo myMethod = null;
            object obj = Tracer.Core.Plugin.getAddon("Tracer.Serialization.Xml", "Serialize", ref myMethod);
            using (FileStream fs = new FileStream("methods.xml", FileMode.Create))
            {
                myMethod.Invoke(obj, new object[] { res, fs });
            }
        }

        private static void YamlSerilaization(TraceResult res)
        {
            MethodInfo myMethod = null;
            object obj = Tracer.Core.Plugin.getAddon("Tracer.Serialization.Yaml", "Serialize", ref myMethod);
            using (FileStream fs = new FileStream("methods.yaml", FileMode.Create))
            {
                myMethod.Invoke(obj, new object[] { res, fs });
            }
        }


    }
}
