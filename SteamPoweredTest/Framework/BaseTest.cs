using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamPoweredTest
{
    public class BaseTest
    {
        protected Logger logger = new Logger();
        protected XMLReader reader = new XMLReader();
        protected BrowserConfig config = new BrowserConfig();
        
        protected void LogStep(int step)
        {
            logger.LogStep(step);
        }
    }
}
