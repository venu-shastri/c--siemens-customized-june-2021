using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhyDelegate
{
	public class FunctionClass
	{

		Type type;
		object target;
		System.Reflection.MethodInfo method;

		public FunctionClass(Type type, object target, System.Reflection.MethodInfo method)
		{

			this.type = type;
			this.target = target;
			this.method = method;
		}
		public void Invoke()
		{

			if (this.method.IsStatic)
			{

				this.method.Invoke(this.type, new Object[] { });
			}
		}

	}

	public class Program
	{
		static void Fun()
		{

			Console.WriteLine("fun Invoked");
		}

		static void Foo(FunctionClass funcObj)
		{

			funcObj.Invoke();
		}

		public static void Main()
		{

			//System.Reflection.MethodInfo methodMetadata=typeof(Program).GetMethod("Fun",System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
			FunctionClass _funcObj = new FunctionClass(typeof(Program), null, typeof(Program).GetMethod("Fun", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static));
			Program.Foo(_funcObj);



		}
	}
}
