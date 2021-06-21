using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhyDelegate
{
	public class VoidFunctionZeroLengthArgumentFunctionClass
	{

		Type type;
		object target;
		string methodName;
		System.Reflection.MethodInfo methodMetadata;

		public VoidFunctionZeroLengthArgumentFunctionClass(Type type, object target,string methodName)
		{

			this.type = type;
			this.target = target;
			this.methodName = methodName;
			this.methodMetadata = this.type.GetMethod(this.methodName,
				System.Reflection.BindingFlags.NonPublic | 
				System.Reflection.BindingFlags.Public |
				System.Reflection.BindingFlags.Static);
		}
		public void Invoke()
		{

			if (this.methodMetadata.IsStatic)
			{

				this.methodMetadata.Invoke(this.type, new Object[] { });
			}
		}

	}

	public class VoidFunctionStringArgumentFunctionClass
	{

		Type type;
		object target;
		string methodName;
		System.Reflection.MethodInfo methodMetadata;

		public VoidFunctionStringArgumentFunctionClass(Type type, object target, string methodName)
		{

			this.type = type;
			this.target = target;
			this.methodName = methodName;
			this.methodMetadata = this.type.GetMethod(this.methodName,
				System.Reflection.BindingFlags.NonPublic |
				System.Reflection.BindingFlags.Public |
				System.Reflection.BindingFlags.Static);
		}
		public void Invoke(string message)
		{

			if (this.methodMetadata.IsStatic)
			{

				this.methodMetadata.Invoke(this.type, new Object[] { message});
			}
		}

	}

	public class Program
	{
		static void MoreFun(string message)
        {
			Console.WriteLine("MoreFun Invoked "+message);
		}
		static void Fun()
		{

			Console.WriteLine("fun Invoked");
		}
		static void Bar() {

			Console.WriteLine("Bar Invoked");
		}

		static void Foo(VoidFunctionZeroLengthArgumentFunctionClass funcObj,
			VoidFunctionStringArgumentFunctionClass voidFuncObj)
		{

			funcObj.Invoke();
			
			voidFuncObj.Invoke("Hello");
		}

		public static void Main()
		{

			//System.Reflection.MethodInfo methodMetadata=typeof(Program).GetMethod("Fun",System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
			VoidFunctionZeroLengthArgumentFunctionClass _funObj =
				new VoidFunctionZeroLengthArgumentFunctionClass(typeof(Program), null, "Fun");

			VoidFunctionZeroLengthArgumentFunctionClass _barObj =
				new VoidFunctionZeroLengthArgumentFunctionClass(typeof(Program), null, "Bar");
			VoidFunctionStringArgumentFunctionClass _newFuncObj = new VoidFunctionStringArgumentFunctionClass(typeof(Program), null, "MoreFun");
			Program.Foo(_funObj / _barObj, _newFuncObj);



		}
	}
}
