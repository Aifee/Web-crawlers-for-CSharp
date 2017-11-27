using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.Example;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            //NodeClassFilterExample example = new NodeClassFilterExample();
            //example.Start();
            //TagNameFilterExample example = new TagNameFilterExample();
            //StringFilterExample example = new StringFilterExample();
            //OrFilterExample example = new OrFilterExample();
            XPathExample example = new XPathExample();
            example.Start();

            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }
    }
}
