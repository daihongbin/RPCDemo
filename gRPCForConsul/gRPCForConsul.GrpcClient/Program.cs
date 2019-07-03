using System;
using System.Collections.Generic;
using System.Linq;

namespace gRPCForConsul.GrpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var q = Enumerable.Repeat("abc",10);
            foreach (var item in q)
            {
                Console.WriteLine(item);
            }
        }
    }
}
