using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
   public class WorkPerformedEventArgs : EventArgs
    {
        public int Hours { get; set; }
        public WorkType workType { get; set; }

        public WorkPerformedEventArgs(int hours,WorkType workType)
        {
            Hours = hours;
            this.workType = workType;
        }
    }
}
