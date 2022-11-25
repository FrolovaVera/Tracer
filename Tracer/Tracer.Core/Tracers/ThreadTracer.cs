using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Core.TraceResults;

namespace Tracer.Core.Tracers
{
    public class ThreadTracer //обработка потока
    {
        public ThreadTraceResult ThreadTraceResult { get; } 
        private MethodTracer _currentMethodTracer; 

        public ThreadTracer(int id)
        {
            ThreadTraceResult = new ThreadTraceResult(id);
            _currentMethodTracer = null;
        }
        public void StartTrace()
        {
            var stackTrace = new StackTrace();
            var method = stackTrace.GetFrame(2).GetMethod();
            var methodName = method.Name; 
            var className = method.DeclaringType.FullName;

            
            if (_currentMethodTracer == null)
            {
                _currentMethodTracer = new MethodTracer();
            }

            _currentMethodTracer.StartTrace(className, methodName);//
        }

        public void StopTrace()
        {
            if (_currentMethodTracer != null)
            {
                _currentMethodTracer.StopTrace();
                  if (_currentMethodTracer.IsActive()==false)
                  {
                    var methodTraceResult = _currentMethodTracer.GetTraceResult();
                    ThreadTraceResult.AddMethod(methodTraceResult);
                    _currentMethodTracer = null;
                    }  
            }
           else
            {
                throw new InvalidOperationException();
            }
        }


    }
}
