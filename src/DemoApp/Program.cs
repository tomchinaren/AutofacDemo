using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    class Program
    {
        private static IContainer Container { get; set; }
        private static IContainer Container2 { get; set; }
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleOutput>().As<IOutput>();
            builder.RegisterType<TodayWriter>().As<IDateWriter>();
            Container = builder.Build();

            var builder2 = new ContainerBuilder();
            builder2.RegisterType<ConsoleOutput2>().As<IOutput>();
            builder2.RegisterType<TodayWriter>().As<IDateWriter>();
            Container2 = builder2.Build();

            // 我们将在这个方法里使用依赖注入，后面我们会定义它
            WriteDate();

            Console.WriteLine("-----");
            WriteDate2();
        }

        public static void WriteDate()
        {
            // 创建作用域，解析IDateWriter，使用，然后释放
            using (var scope = Container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IDateWriter>();
                writer.WriteDate();
            }
        }

        public static void WriteDate2()
        {
            // 创建作用域，解析IDateWriter，使用，然后释放
            using (var scope = Container2.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IDateWriter>();
                writer.WriteDate();
            }
        }
    }
}
