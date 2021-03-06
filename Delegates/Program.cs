﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate int BizRulesDelegate(int x, int y);
    class Program
    {

        static void Main(string[] args)
        {

            var custs = new List<Customer>
            {
            new Customer{FirstName= "Simhachalam",LastName="Chintalapudi",Id=1,City="Tanuku"},
            new Customer{FirstName= "Annavaram",LastName="Meruduri",Id=2,City="Atthili"},
            new Customer{FirstName= "Tirupati",LastName="Tottempudi",Id=3,City="Ramvaram"},
            new Customer{FirstName= "Bhadrachalam",LastName="Relangi",Id=4,City="Tanuku"}
            };
            var Tancusts = custs.Where(c => c.City == "Tanuku");

            foreach (var item in Tancusts)
            {
                Console.WriteLine(item.FirstName +"-"+ item.City);
            }




            var worker = new Worker();
            // worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed);
            // worker.WorkPerformed += Worker_WorkPerformed;
            ///* Anonymous method call*/   worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
            //   {
            //       Console.WriteLine("Hours worked :" + e.Hours + " " + e.workType.ToString());
            //   };
            /*Lambda Expression*/
            worker.WorkPerformed += (s, e) =>
            {
                Console.WriteLine("Hours worked :" + e.Hours + " " + e.workType.ToString());
            };
            worker.WorkCompleted += (s, e) => Console.WriteLine("Work completed");

            /* Custom delegate*/
            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate mulDel = (x, y) => x * y;

            var data = new ProcessData();
            data.Process(5, 6, addDel);


            /*Action*/
            Action<int, int> myaction = (x, y) => Console.WriteLine(x / y);
            data.ProcessAction(56, 6, myaction);

            /* Func */
            Func<int, int, int> myAddFunc = (x, y) => x + y;
            data.ProcessFunc(5, 7, myAddFunc);

            // worker.WorkCompleted += Worker_WorkCompleted;
            worker.DoWork(7, WorkType.Cool);
            Console.Read();
        }

        private static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Work completed");
        }

        private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("Hours worked : " + e.Hours + " " + e.workType.ToString());
        }
    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        Cool
    }
}
