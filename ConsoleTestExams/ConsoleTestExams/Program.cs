using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestExams
{
    class Program
    {

        #region RESULT  " 8 "
        delegate int mydel(int aa, int bb);
        static void Main(String[] args)
        {
            mydel d = (a, b) => a + 2 * b;
            Console.WriteLine(d(2, 3));
            Console.Read();
        }

        #endregion

        #region Changes format to return

        //delegate int mydel(int aa);
        //int myfunc(int a) { return a * a; }
        //int myfunc2(int a) { return a + a; }
        //static void Main(String[] args)
        //{
        //    Program p = new Program();
        //    mydel d = p.myfunc;
        //    Console.WriteLine(d(5));

        //    d = p.myfunc2;
        //    Console.WriteLine(d(5));
        //    Console.ReadLine();
        //}

        #endregion
        //static void Main(string[] args)
        //{
        //    Console.WriteLine(Palindrome("OLLO"));
        //    Console.ReadLine();
        //}

        #region palindrome
        //public static string palindrome(string word)
        //{
        //    string rev = "";
        //    for (int i = word.length - 1; i >= 0; i--)
        //    {
        //        rev += word[i];
        //    }
        //    rev = (rev == word ? "palindrome" : "not palindrome");
        //    return rev;
        //} 
        #endregion
    }
    #region overrite
    //interface interface1 { void showMe(); }
    //interface interface2 { void showYou(); }
    //class BaseClass
    //{
    //    public virtual void show()
    //    {
    //        System.Console.WriteLine("base class");
    //    }
    //}
    //class DerivedAndImplemented : BaseClass, interface1, interface2
    //{
    //    public void showMe()
    //    {
    //        System.Console.WriteLine("Me!");
    //    }
    //    public void showYou()
    //    {
    //        System.Console.WriteLine("You!");
    //    }
    //    public override void show()
    //    {
    //        Console.WriteLine("im in derived class");
    //    }
    //    static void main(String[] args)
    //    {
    //        DerivedAndImplemented de = new DerivedAndImplemented();
    //        de.show();
    //        System.Console.Read();
    //    }
    //} 
    #endregion

}