namespace ShellDotSp.Plugin.GelatoClubCore.Helpers
{
    public class ReturnValue
    {

        public ReturnValue()
        {
            Status = ReturnValueStatus.Ok;
            StatusMessage = "OK";
        }

        public string StatusMessage { get; set; } = string.Empty;
        public ReturnValueStatus Status { get; set; }
    }

    public enum ReturnValueStatus
    {
        Ok,
        Warning,
        Error
    }

}
