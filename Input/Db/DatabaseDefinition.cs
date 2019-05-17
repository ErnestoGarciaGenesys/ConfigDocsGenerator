using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.Input.Db
{
    abstract class DatabaseDefinition
    {
        public enum EnumType
        {
            Enum_CfgObjectState = 0,
            Enum_CfgSwitchType = 1,
            Enum_CfgLinkType = 2,
            Enum_CfgTargetType = 3,
            Enum_CfgRouteType = 4,
            Enum_CfgDNType = 5,
            Enum_CfgAppType = 6,
            Enum_CfgRank = 7,
            Enum_CfgDNGroupType = 8,
            Enum_CfgOSType = 11,
            Enum_CfgSolutionType = 26,
        }

        private static IDictionary<string, TableDefinition> tables =
            new Dictionary<string, TableDefinition>();

        static DatabaseDefinition()
        {
            var cfgLocale = new CfgLocaleTableDefinition();
            cfgLocale.KeyColumns = new string[] { "lcid", "lc_class", "lc_type", "lc_subtype" };
            tables.Add(cfgLocale.TableName, cfgLocale);

            var cfgHost = new TableDefinition("cfg_host");
            // TODO: constructors of foreign keys should not need the source table name
            cfgHost.ForeignKeys.Add(new EnumForeignKey("cfg_host", "os_type", EnumType.Enum_CfgOSType));
            tables.Add(cfgHost.TableName, cfgHost);

            var cfgApplication = new TableDefinition("cfg_application");
            cfgApplication.ForeignKeys.Add(new EnumForeignKey("cfg_application", "type", EnumType.Enum_CfgAppType));
            tables.Add(cfgApplication.TableName, cfgApplication);

            var cfgServer = new TableDefinition("cfg_server");
            cfgServer.KeyColumns = new string[] { "app_dbid", "host_dbid" };
            cfgServer.ForeignKeys.Add(new DbidForeignKey("cfg_server", "app_dbid", "cfg_application"));
            cfgServer.ForeignKeys.Add(new DbidForeignKey("cfg_server", "host_dbid", "cfg_host"));
            tables.Add(cfgServer.TableName, cfgServer);
            
            var cfgService = new TableDefinition("cfg_service");
            cfgService.ForeignKeys.Add(new EnumForeignKey("cfg_service", "solution_type", EnumType.Enum_CfgSolutionType));
            tables.Add(cfgService.TableName, cfgService);

            var cfgSolutionComp = new TableDefinition("cfg_solution_comp");
            cfgSolutionComp.KeyColumns = new string[] { "solution_dbid", "app_dbid" };
            cfgSolutionComp.ForeignKeys.Add(new DbidForeignKey("cfg_solution_comp", "solution_dbid", "cfg_service"));
            cfgSolutionComp.ForeignKeys.Add(new DbidForeignKey("cfg_solution_comp", "app_dbid", "cfg_application"));
            tables.Add(cfgSolutionComp.TableName, cfgSolutionComp);

            var cfgSwitch = new TableDefinition("cfg_switch");
            tables.Add(cfgSwitch.TableName, cfgSwitch);

            var cfgDn = new TableDefinition("cfg_dn");
            cfgDn.ForeignKeys.Add(new DbidForeignKey("cfg_dn", "switch_dbid", "cfg_switch"));
            cfgDn.ForeignKeys.Add(new EnumForeignKey("cfg_dn", "type", EnumType.Enum_CfgDNType));
            tables.Add(cfgDn.TableName, cfgDn);

            var cfgTenant = new TableDefinition("cfg_tenant");
            tables.Add(cfgTenant.TableName, cfgTenant);

            var cfgAppOption = new TableDefinition("cfg_app_option");
            cfgAppOption.KeyColumns = new string[] { "object_dbid", "object_type", "section", "opt", "part" };
            cfgAppOption.ForeignKeys.Add(new AppOptionForeignKey("cfg_app_option", "object_dbid", "cfg_application", Enum_CfgObjectType.Application));
            tables.Add(cfgAppOption.TableName, cfgAppOption);

            var cfgFlexProp = new TableDefinition("cfg_flex_prop");
            cfgFlexProp.AllowsRepetitiveKey = true;
            cfgFlexProp.ForeignKeys.Add(new DbidForeignKey("cfg_flex_prop", "parent_dbid", "cfg_flex_prop"));
            cfgFlexProp.ForeignKeys.Add(new AppOptionForeignKey("cfg_flex_prop", "object_dbid", "cfg_application", Enum_CfgObjectType.Application));
            cfgFlexProp.ForeignKeys.Add(new AppOptionForeignKey("cfg_flex_prop", "object_dbid", "cfg_dn", Enum_CfgObjectType.DN));
            cfgFlexProp.ForeignKeys.Add(new AppOptionForeignKey("cfg_flex_prop", "object_dbid", "cfg_tenant", Enum_CfgObjectType.Tenant));
            tables.Add(cfgFlexProp.TableName, cfgFlexProp);
        }

        private DatabaseDefinition() { }

        /// <returns>null if the tableName does not exist.</returns>
        public static TableDefinition getTableDefinition(string tableName)
        {
            TableDefinition result;
            tables.TryGetValue(tableName, out result);
            return result;
        }
    }
}
