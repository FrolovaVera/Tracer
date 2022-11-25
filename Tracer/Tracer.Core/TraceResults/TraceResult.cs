using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tracer.Core.TraceResults
{
    [Serializable]
    public class TraceResult
    {

        [XmlElement("thread")]
        [JsonPropertyName("thread")]
        [YamlDotNet.Serialization.YamlMember(Alias = "thread")]
        //list of threads
        public List<ThreadTraceResult> ThreadTraceResults { get; }

        public TraceResult()
        {
            ThreadTraceResults = new List<ThreadTraceResult>(); 
        } 

        public void AddThread(ThreadTraceResult thread)
        {
            ThreadTraceResults.Add(thread); 
        }
    }
}
