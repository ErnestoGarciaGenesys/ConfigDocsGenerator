using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.CfgObjects
{
    class AbstractCfgObjectDecorator : ICfgObject
    {
        protected ICfgObject decorated;
        
        public string GetString(string fieldName)
        {
            return decorated.GetString(fieldName);
        }

        public int GetInt(string fieldName)
        {
            return decorated.GetInt(fieldName);
        }

        public string GetEnum(string fieldName)
        {
            return decorated.GetEnum(fieldName);
        }

        public ICfgObject GetRef(string refName)
        {
            return decorated.GetRef(refName);
        }

        public ICollection<ICfgObject> GetMultiRefs(string refName)
        {
            return decorated.GetMultiRefs(refName);
        }

        protected T GetRef<T>(string refName)
        where T : AbstractCfgObjectDecorator, new()
        {
            T cfgObject = new T();
            cfgObject.decorated = decorated.GetRef(refName);
            return cfgObject;
        }

        protected ICollection<T> GetMultiRef<T>(string refName)
        where T : AbstractCfgObjectDecorator, new()
        {
            ICollection<ICfgObject> refs = decorated.GetMultiRefs(refName);
            ICollection<T> refCfgObjects = new List<T>();

            foreach (ICfgObject ref_ in refs)
            {
                T refCfgObject = new T();
                refCfgObject.decorated = ref_;
                refCfgObjects.Add(refCfgObject);
            }

            return refCfgObjects;
        }
    }
}
