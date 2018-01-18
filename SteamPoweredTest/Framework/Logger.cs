using System.Diagnostics;

namespace SteamPoweredTest
{
    public class Logger
    {
        public void LogStep(int step)
        {
            Debug.WriteLine(string.Format("Шаг номер {0} пройден успешно",step));
        }
    }
}
