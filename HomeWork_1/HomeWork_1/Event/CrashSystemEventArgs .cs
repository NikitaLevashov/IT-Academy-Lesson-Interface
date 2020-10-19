using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_1
{
    class CrashSystemEventArgs : EventArgs
    {
        public string Message { get; }

        public DateTime Data { get; }

        public CrashSystemEventArgs(string mes, DateTime data)
        {
            Message = mes;

            Data = data;
        }

    }
}
