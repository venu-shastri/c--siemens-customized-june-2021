using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhyDelegate
{
	//public class FunctionClass
	//{
	//	List<FunctionClass> _list = new List<FunctionClass>();
	//	public void Add(FunctionClass funObj) { _list.Add(funObj); }
	//	public void Remove(FunctionClass funObj) { _list.Remove(funObj); }
	//}
	//public class VoidFunctionZeroLengthArgumentFunctionClass:FunctionClass
	//{

	//	Type type;
	//	object target;
	//	string methodName;
	//	System.Reflection.MethodInfo methodMetadata;

	//	public VoidFunctionZeroLengthArgumentFunctionClass(Type type, object target,string methodName)
	//	{

	//		this.type = type;
	//		this.target = target;
	//		this.methodName = methodName;
	//		this.methodMetadata = this.type.GetMethod(this.methodName,
	//			System.Reflection.BindingFlags.NonPublic | 
	//			System.Reflection.BindingFlags.Public |
	//			System.Reflection.BindingFlags.Static);
	//	}
	//	public void Invoke()
	//	{

	//		if (this.methodMetadata.IsStatic)
	//		{

	//			this.methodMetadata.Invoke(this.type, new Object[] { });
	//		}
	//	}

	//}

	//public class VoidFunctionStringArgumentFunctionClass
	//{

	//	Type type;
	//	object target;
	//	string methodName;
	//	System.Reflection.MethodInfo methodMetadata;

	//	public VoidFunctionStringArgumentFunctionClass(Type type, object target, string methodName)
	//	{

	//		this.type = type;
	//		this.target = target;
	//		this.methodName = methodName;
	//		this.methodMetadata = this.type.GetMethod(this.methodName,
	//			System.Reflection.BindingFlags.NonPublic |
	//			System.Reflection.BindingFlags.Public |
	//			System.Reflection.BindingFlags.Static);
	//	}
	//	public void Invoke(string message)
	//	{

	//		if (this.methodMetadata.IsStatic)
	//		{

	//			this.methodMetadata.Invoke(this.type, new Object[] { message});
	//		}
	//	}

	//}


	public delegate void VoidFunctionZeroLengthArgumentFunctionClass();
	public delegate void VoidFunctionStringArgumentFunctionClass(string message);
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
				new VoidFunctionZeroLengthArgumentFunctionClass(Program.Fun);

			VoidFunctionZeroLengthArgumentFunctionClass _barObj =
				new VoidFunctionZeroLengthArgumentFunctionClass(Program.Bar);
			VoidFunctionStringArgumentFunctionClass _newFuncObj = 
				new VoidFunctionStringArgumentFunctionClass(Program.MoreFun);
			//VoidFunctionZeroLengthArgumentFunctionClass compositeFuncObj=	System.Delegate.Combine(_funObj, _barObj) as VoidFunctionZeroLengthArgumentFunctionClass;
			VoidFunctionZeroLengthArgumentFunctionClass compositeFuncObj = _funObj + _barObj;
			Program.Foo(compositeFuncObj, _newFuncObj);



		}
	}
}
