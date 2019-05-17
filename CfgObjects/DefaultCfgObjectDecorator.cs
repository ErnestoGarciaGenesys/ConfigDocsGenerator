using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.CfgObjects
{
    class DefaultCfgObjectDecorator : ICfgObject
    {
        private static readonly string defaultString = "N/A";
        private static readonly int defaultInt = -1;
        private static readonly ICfgObject defaultObject = new DefaultCfgObject();
        private static readonly ICollection<ICfgObject> defaultCollection =
            new List<ICfgObject>();

        private sealed class DefaultCfgObject : ICfgObject
        {
            public string GetString(string fieldName) { return defaultString; }
            public int GetInt(string fieldName) { return defaultInt; }
            public string GetEnum(string fieldName) { return defaultString; }
            public ICfgObject GetRef(string refName) { return defaultObject; }
            public ICollection<ICfgObject> GetMultiRefs(string refName)
            {
                return defaultCollection;
            }
        }

        private ICfgObject decorated;

        public DefaultCfgObjectDecorator(ICfgObject decorated)
        {
            this.decorated = decorated;
        }

        public string GetString(string fieldName)
        {
            try
            {
                string result = decorated.GetString(fieldName);
                return result.Length > 0 ? result : defaultString;
            }
            catch (Exception)
            {
                return defaultString;
            }
        }

        public int GetInt(string fieldName)
        {
            try
            {
                return decorated.GetInt(fieldName);
            }
            catch (Exception)
            {
                return defaultInt;
            }
        }

        public string GetEnum(string fieldName)
        {
            try
            {
                string result = decorated.GetEnum(fieldName);
                return result.Length > 0 ? result : defaultString;
            }
            catch (Exception)
            {
                return defaultString;
            }
        }

        public ICfgObject GetRef(string refName)
        {
            try
            {
                ICfgObject result = decorated.GetRef(refName);
                return result != null ? 
                    new DefaultCfgObjectDecorator(result) :
                    defaultObject;
            }
            catch (Exception)
            {
                return defaultObject;
            }
        }

        public ICollection<ICfgObject> GetMultiRefs(string refName)
        {
            try
            {
                ICollection<ICfgObject> result = decorated.GetMultiRefs(refName);

                if (result != null)
                {
                    ICollection<ICfgObject> decoratedResult = new List<ICfgObject>();
                    foreach (ICfgObject o in result)
                        decoratedResult.Add(new DefaultCfgObjectDecorator(o));
                    return decoratedResult;
                }
                else
                {
                    return defaultCollection;
                }
            }
            catch (Exception)
            {
                return defaultCollection;
            }
        }
    }
}
