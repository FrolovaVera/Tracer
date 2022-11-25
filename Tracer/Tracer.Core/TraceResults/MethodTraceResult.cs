using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tracer.Core.TraceResults
{
    [Serializable]
    public class MethodTraceResult
    {
        [XmlAttribute]
        public string ClassName { get; set; }
        [XmlAttribute]
        public string MethodName { get; set; }
        [XmlAttribute]
        public double Time { get; set; }

        [XmlElement("method")]
        [JsonPropertyName("method")]
        [YamlDotNet.Serialization.YamlMember(Alias = "method")]
        public List<MethodTraceResult> NestedMethodTraceResults { get; }//список информации о вложенныз методов

        public MethodTraceResult(string className, string methodName)
        {
            Time = 0;
            ClassName = className;
            MethodName = methodName;
            NestedMethodTraceResults = new List<MethodTraceResult>();
        }

        public void AddNestedMethodTraceResult(MethodTraceResult method)
        {
            NestedMethodTraceResults.Add(method);
        }
    }
}
