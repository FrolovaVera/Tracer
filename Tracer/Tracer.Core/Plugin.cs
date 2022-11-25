using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Core
{
    public static class Plugin
    {
        static string path = "..\\..\\..\\..\\..\\Tracer.Serialization\\Tracer.Serialization\\bin\\Debug\\net6.0\\Tracer.Serialization.dll";
        public static object getAddon(string className, string methodName, ref MethodInfo methodInfo)
        {
            // application domain.
            Assembly a = Assembly.LoadFrom(path);

            var types = a.GetTypes();

            // Get the type to use.
            Type myType = a.GetType(className);
            // Get the method to call.
            methodInfo = myType.GetMethod(methodName);

            // Create an instance.
            object obj = Activator.CreateInstance(myType);
            // Execute the method.

            return obj;
        }
    }
}
