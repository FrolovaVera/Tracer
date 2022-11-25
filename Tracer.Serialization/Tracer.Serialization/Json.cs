using System.Text.Json;
using Tracer.Core;
using Tracer.Core.TraceResults;

namespace Tracer.Serialization
{
    public class Json : Tracer.Serialization.Abstractions.ITraceResultSerializer
    {

        public void Serialize(TraceResult traceResult, Stream to)
        {
            JsonSerializer.Serialize<TraceResult>(to, traceResult);
        }
    }
}