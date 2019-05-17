using System;
using System.Collections.Generic;
using CfgDoc.Input;
using CfgDoc.CfgObjects;
using System.Reflection;

namespace CfgDoc.Output
{
    class TextOutput : ICfgOutput {
        int indent;

        private void w(string text, params object[] arg)
        {
            for (int i = 0; i < indent; i++)
                Console.Write('\t');

            Console.WriteLine(text, arg);
        }

        private bool writePropertyIfDbid(object obj, PropertyInfo prop)
        {
            bool write = prop.PropertyType.GetProperty("Dbid") != null;

            if (write)
            {
                object propValue = obj.GetType().InvokeMember(
                    prop.Name, BindingFlags.GetProperty, null, obj, null);

                w("{0}.Dbid={1}",
                    prop.Name,
                    prop.PropertyType.InvokeMember("Dbid", BindingFlags.GetProperty, null, propValue, null));
            }

            return write;
        }

        private void writeObject(object obj, int depth)
        {
            indent++;

            if (depth == 0)
            {
                if (obj.GetType().GetProperty("Dbid") == null)
                {
                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
                        writePropertyIfDbid(obj, prop);
                }
                else
                {
                    w("Dbid={0}", obj.GetType().InvokeMember(
                        "Dbid", BindingFlags.GetProperty, null, obj, null));
                }
            }
            else foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                string propName = prop.Name;
                Type propType = prop.PropertyType;
                object propValue = obj.GetType().InvokeMember(
                    propName, BindingFlags.GetProperty, null, obj, null);

                if (propType.IsGenericType &&
                    typeof(ICollection<>).IsAssignableFrom(propType.GetGenericTypeDefinition()))
                {
                    int i = 0;
                    foreach (object subObj in (System.Collections.ICollection)propValue)
                    {
                        w("{0}[{1}]:", propName, i);
                        writeObject(subObj, depth - 1);
                        i++;
                    }
                }
                else if (writePropertyIfDbid(obj, prop)) {}
                else
                {
                    w("{0}={1}", prop.Name, propValue);
                }
            }

            indent--;
        }

        public void Generate(CfgSystem system)
        {
            indent = 0;
            w("System:");
            writeObject(system, 2);
        }
    }
}
