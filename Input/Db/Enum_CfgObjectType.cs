using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CfgDoc.Input.Db
{
    enum Enum_CfgObjectType
    {
        UnknownObject = 0,
        Switch = 1,
        DN = 2,
        Person = 3,
        Place = 4,
        AgentGroup = 5,
        PlaceGroup = 6,
        Tenant = 7,
        Service = 8,
        Application = 9,
        Host = 10,
        PhysicalSwitch = 11,
        Script = 12,
        Skill = 13,
        ActionCode = 14,
        AgentLogin = 15,
        Transaction = 16,
        DNGroup = 17,
        StatDay = 18,
        StatTable = 19,
        AppPrototype = 20,
        AccessGroup = 21,
        Folder = 22,
        Field = 23,
        Format = 24,
        TableAccess = 25,
        CallingList = 26,
        Campaign = 27,
        Treatment = 28,
        Filter = 29,
        TimeZone = 30,
        VoicePrompt = 31,
        IVRPort = 32,
        IVR = 33,
        AlarmCondition = 34,
        Enumerator = 35,
        EnumeratorValue = 36,
        ObjectiveTable = 37,
        CampaignGroup = 38,
        GVPReseller = 39,
        GVPCustomer = 40,
        GVPIVRProfile = 41,
        ScheduledTask = 42,
        Role = 43,
        PersonLastLogin = 44,
    }
}
