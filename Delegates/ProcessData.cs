using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class ProcessData
    {
        public void Process(int x,int y, BizRulesDelegate del)
        {
            var res = del(x, y);
            Console.WriteLine(res);
        }


        public void ProcessAction(int x,int y,Action<int,int> action)
        {
            action(x, y);
            Console.WriteLine("Action has been performed");
        }

        public void ProcessFunc(int x,int y,Func<int,int,int> func)
        {
            var res = func(x, y);
            Console.WriteLine(res);
        }
    }
}
