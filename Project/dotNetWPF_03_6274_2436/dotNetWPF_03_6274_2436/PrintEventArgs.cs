using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetWPF_03_6274_2436
{
    public class PrintEventArgs
    {
        internal bool CriticalEvent;
        internal DateTime TimeOfTheEvent;
        internal string MessageEvent;
        internal string PrinterName;

        public PrintEventArgs(bool criticalEvent, string messageEvent, string printerName)
        {
            CriticalEvent = criticalEvent;
            TimeOfTheEvent = DateTime.Now;
            MessageEvent = messageEvent;
            PrinterName = printerName;
        }
    }
}
