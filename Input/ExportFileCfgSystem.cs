using System;
using System.Collections.Generic;
using System.Text;
using CfgDoc.CfgObjects;
using CfgDoc.Input.Db;

namespace CfgDoc.Input
{
    class ExportFileCfgSystem : ICfgObject
    {
        private DatabaseContents db;
        private ICollection<ICfgObject> hosts;
        private ICollection<ICfgObject> servers;
        private ICollection<ICfgObject> applications;
        private ICollection<ICfgObject> services;
        private ICollection<ICfgObject> switches;
        private ICollection<ICfgObject> tenants;

        public ExportFileCfgSystem(DatabaseContents db)
        {
            this.db = db;
            hosts = new List<ICfgObject>();
            foreach (Row row in db.GetTable("cfg_host").GetRows())
                hosts.Add(new ExportFileCfgObject(row));

            servers = new List<ICfgObject>();
            foreach (Row row in db.GetTable("cfg_server").GetRows())
                servers.Add(new ExportFileCfgObject(row));

            applications = new List<ICfgObject>();
            foreach (Row row in db.GetTable("cfg_application").GetRows())
                applications.Add(new ExportFileCfgObject(row));

            services = new List<ICfgObject>();
            foreach (Row row in db.GetTable("cfg_service").GetRows())
                services.Add(new ExportFileCfgObject(row));

            switches = new List<ICfgObject>();
            foreach (Row row in db.GetTable("cfg_switch").GetRows())
                switches.Add(new ExportFileCfgObject(row));

            tenants = new List<ICfgObject>();
            foreach (Row row in db.GetTable("cfg_tenant").GetRows())
                tenants.Add(new ExportFileCfgObject(row));
        }

        public string GetString(string fieldName)
        {
            if (fieldName == "gathered_date")
                return db.GatheredDate;
            else
                throw new ApplicationException("field does not exist: " + fieldName);
        }

        public int GetInt(string fieldName)
        {
            throw new ApplicationException("field does not exist: " + fieldName);
        }

        public string GetEnum(string fieldName)
        {
            throw new ApplicationException("field does not exist: " + fieldName);
        }

        public ICfgObject GetRef(string refName)
        {
            throw new ApplicationException("reference does not exist: " + refName);
        }

        public ICollection<ICfgObject> GetMultiRefs(string refName)
        {
            switch (refName)
            {
                case "hosts": return hosts;
                case "servers": return servers;
                case "applications": return applications;
                case "services": return services;
                case "switches": return switches;
                case "tenants": return tenants;
                default:
                    throw new ApplicationException("reference does not exist: " + refName);
            }
        }
    }
}
