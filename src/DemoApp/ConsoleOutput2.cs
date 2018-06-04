using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    class ConsoleOutput2: IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine(content+".2");
        }
    }
}
