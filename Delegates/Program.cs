using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();
            worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed);
            worker.WorkCompleted += Worker_WorkCompleted;
            worker.DoWork(7, WorkType.Cool);
            Console.Read();
        }

        private static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Work completed");
        }

        private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("Hours worked : "+  e.Hours + " " + e.workType.ToString());
        }
    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        Cool
    }
}
