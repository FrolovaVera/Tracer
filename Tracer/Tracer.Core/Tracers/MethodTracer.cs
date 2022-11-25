using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tracer.Core.TraceResults;

namespace Tracer.Core.Tracers
{
    public class MethodTracer
    {
        private Stopwatch stopWatch;
        private MethodTraceResult result;
        MethodTracer InnerMethod;


        bool isActive; 
        public Stack<MethodTracer>? NestedMethod { get; }
        public MethodTracer()
        {
            stopWatch = new Stopwatch();
            InnerMethod = null; // внешний метод
            bool isActive = false; // вложен ли метод
        }
        public MethodTraceResult GetTraceResult()
        {
            StackTrace stackTrace = new StackTrace();
            return result;
        }

        public void StartTrace(string className, string methodName)
        {
            if (isActive == false) //является ли метод вложенным: нет - true, да - false
            {
                isActive = true; 
                stopWatch.Start();
                result = new MethodTraceResult(className, methodName);
            }
            else
            {
                if (InnerMethod == null)
                {
                    InnerMethod = new MethodTracer();//
                }
                InnerMethod.StartTrace(className, methodName);
            }
        }

        public void StopTrace()
        {
            if (isActive==true)//если метод не вложеный
            {
                if (InnerMethod != null) // если не во внешнем методе
                {
                    InnerMethod.StopTrace();
                    if (InnerMethod.IsActive()==false)
                    {
                        var innerMethodTraceResult = InnerMethod.GetTraceResult();// получене информации о вложенных методах
                        InnerMethod = null;
                        result.AddNestedMethodTraceResult(innerMethodTraceResult);
                    }
                }
                else
                {
                    stopWatch.Stop();
                    result.Time = getTime();
                    isActive = false;
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public bool IsActive()
        {
            return isActive;
        }

        private double getTime()
        {
            var time = stopWatch.Elapsed.TotalMilliseconds;
            return time;
        }

    }
}
