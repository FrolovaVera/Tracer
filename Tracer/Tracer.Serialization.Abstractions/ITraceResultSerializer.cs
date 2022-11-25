using Tracer.Core.TraceResults;

namespace Tracer.Serialization.Abstractions
{
    public interface ITraceResultSerializer
    {
        void Serialize(TraceResult traceResult, Stream to);
    }
}