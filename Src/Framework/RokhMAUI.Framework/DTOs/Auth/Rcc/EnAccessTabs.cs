using System.Text.Json.Serialization;

namespace RokhMAUI.Framework.DTOs.Auth.Rcc
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnAccessTabs
    {
        Voice = 1,
        ExternalChat = 2,
        InternalChat = 3,
        Sms = 4,
        Email = 5,
        Fax = 6,
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnAccessSetting
    {
        Users = 1,
        Queue = 2,
        CommunicationSetting = 3,
        InboundRoute = 4,
        AgentOutcome = 5,
        Group = 6,
        BreakReasons = 7,
        ChatSetting = 8,
        EmailSetting = 9,
        SmsSetting = 10,
        FaxSetting = 11,
        SoundFile = 12
    }
}
