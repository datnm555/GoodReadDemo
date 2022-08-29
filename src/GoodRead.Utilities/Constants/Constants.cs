using System.ComponentModel;

namespace GoodRead.Utilities.Constants;

public class Constants
{
    public enum BookStatus
    {
        [Description("not reading book yet")]
        NotReadYet,
        [Description("reading book")]
        Reading,
        [Description("read book")]
        Completed,
    }
}