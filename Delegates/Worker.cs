using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    // Type 1
   // public delegate int WorkPerformHandler(object sender,WorkPerformedEventArgs e);
    class Worker
    {
        //(Type 1) Event definition
        //  public event WorkPerformHandler WorkPerformed;
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours,WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                // Raise event on work
                System.Threading.Thread.Sleep(1000);
                OnWorkPerformed(i + 1, workType);
            }

            // Raise event completed
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours,WorkType workType)
        {
            // Other way of calling the event
            //if(WorkPerformed !=null)
            //{
            //    WorkPerformed(hours, workType);
            //}

            // Type1  WorkPerformHandler del = WorkPerformed as WorkPerformHandler;
            var del = WorkPerformed as EventHandler<WorkPerformedEventArgs>;
            if (del!= null)
            {
                // Raise Event
                del(this, new WorkPerformedEventArgs(hours,workType));
            }
        }

        protected virtual void OnWorkCompleted()
        {
            // Other way of calling the event
            //if(WorkCompleted !=null)
            //{
            //    WorkCompleted(this, EventArgs.Empty);
            //}

            var del = WorkCompleted as EventHandler;
            if (del != null)
            {
                // Raise Event
                del(this,EventArgs.Empty);
            }
        }
    }
}
