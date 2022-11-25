using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Core.TraceResults;

namespace Tracer.Core.Tracers
{
    public class MainTracer : ITracer 
    {
        private TraceResult result { get; }
        object locker = new();
        private Dictionary<int, ThreadTracer> ThreadTracers { get; }
        public MainTracer()
        {
            result = new TraceResult();
            ThreadTracers = new Dictionary<int, ThreadTracer>();
        }
        public TraceResult GetTraceResult()
        {
            foreach (var thread in ThreadTracers)
            {
                var threadTracer = thread.Value;
                var threadTraceResult = threadTracer.ThreadTraceResult;
                result.AddThread(threadTraceResult);
            }
            return result;
        }

        public void StartTrace()
        {
            lock (locker)
            {
                var threadId = Thread.CurrentThread.ManagedThreadId; 
                ThreadTracer threadTracer;
                
                if (ThreadTracers.ContainsKey(threadId))
                {
                    threadTracer = ThreadTracers[threadId];
                }
                else
                {
                    threadTracer = new ThreadTracer(threadId);
                    ThreadTracers.Add(threadId, threadTracer);
                }
                
                threadTracer.StartTrace();
            }
        }

        public void StopTrace()
        {
            lock (locker)
            {
                var threadId = Thread.CurrentThread.ManagedThreadId;
                if (ThreadTracers.ContainsKey(threadId))
                {
                    ThreadTracer threadTracer = ThreadTracers[threadId];
                    threadTracer.StopTrace();
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
