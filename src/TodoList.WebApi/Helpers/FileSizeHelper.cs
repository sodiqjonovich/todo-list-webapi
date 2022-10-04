namespace TodoList.WebApi.Helpers
{
    public class FileSizeHelper
    {
        public static double ByteToMB(double @byte)
        {
            return @byte / 1024 / 1024;
        }

        public static double ByteToKB(double @byte)
        {
            return @byte / 1024;
        }

        public static double KBToMB(double @byte)
        {
            return @byte / 1024;
        }

        public static double ByteToGB(double @byte)
        {
            return @byte / 1024 / 1024 / 1024;
        }
    }
}
