using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp8Features
{
    /*
     * What you gain with the Non-Nullable Reference types – you protect yourself from bugs,
     * which lead to Null Reference exceptions.
     * The compiler now reminds you that you’re using nullable code and that you need to check it explicitly. 
     * 
     */
    class Author
    {
        //Null-Conditional operator
        public string? Name { get; set; }
        public void BeforeCSharp8()
        {
            int x = null;
            int? y = null;
            Nullable<int> z = null;
            String? msg = null;

        }

        public static void InvokePassNull()
        {
            var result = PassNull(true)!;
            string copy = result; //The exclamation mark at the end of the expression is equal to claiming you know the method may return null, but you’re sure it’s safe , asking the compiler to allow you to use the returned variable
        }

        #nullable disable
        public static void InvokePassNull_v2()
        {
            var result = PassNull(true);
            string copy = result;
        }
        #nullable restore
        public static void PassNull(string? msg)
        {
            Console.WriteLine($"Uppercase of Msg is {msg.ToUpper()}");
        }
        public static void PassNullUsingAttribute([AllowNull] string msg,[DisallowNull] string content) { }
        public static string? PassNull(bool returnNullIfTrue)
        {
            return returnNullIfTrue ? "Not null" : null;
        }
        [return:NotNullIfNotNull("parameter")]
        public static string PassNullNewVersion(string parameter)
        {
            return parameter ?? "NotNull";

        }
    }
}
