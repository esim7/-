using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ReflectionLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFile(@"C:\Users\МакишевЕ.CORP\source\repos\ReflectionPract\ReflectionPract\bin\Debug\ReflectionPract.exe");
            Console.WriteLine($"{assembly.EntryPoint}, {assembly.FullName}, {assembly.IsFullyTrusted}");
            foreach (var type in assembly.GetTypes())
            {
                Console.WriteLine($"{type.BaseType}, {type.FullName}");

                foreach(var memberInfo in type.GetMembers())
                {
                    Console.WriteLine($"{memberInfo.Name} - {memberInfo.GetType()}");

                    if(memberInfo is MethodInfo)  //memberInfo is MethodInfo
                    {
                        var methodInfo = memberInfo as MethodInfo;
                        foreach(var argument in methodInfo.GetParameters())
                        {
                            Console.WriteLine($"{argument.Name} - {argument.ParameterType}");
                        }

                        if(type.Name == "MessageService" && memberInfo.Name == "PrintMessage")
                        {
                            var messageService = Activator.CreateInstance(type, new object[] { "Soobwenie ot nas"});
                            methodInfo.Invoke(messageService, new object[] { });

                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
