using System.ComponentModel;

namespace projectApi.Enums
{
    public enum TaskStatus
    {
        [Description("To do")]
        ToDo = 1,
        [Description("OnGoing")]
        OnGoing = 2,
        [Description("Concluded")]
        Concluded = 3,
    }
}
