using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestExams
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine(Palindrome("OLLO"));

            Console.ReadLine();
        }

        public static string Palindrome(String word)
        {
            string rev = "";
            for (int i = word.Length - 1; i >= 0; i--)
            {
                rev += word[i];
            }
            rev = (rev == word ? "PALINDROME" : "NOT PALINDROME");
            return rev;
        }

//        A company named ACME wants to modify one of its system named ACMEPlus to be able to
//communicate with another existing system named Jewel.Jewel transmits data by XML, and
//numerical values are represented in hexadecimal.
//Unfortunately, there is a known bug in Jewel.Instead of following the standard hexadecimal
//representation, Jewel represents some hexadecimal values using different characters.This
//table shows the differences:
//Decimal Standard Hexadecimal
//Representation
//Jewel Hexadecimal
//Representation

//0 0 0
//1 1 1
//2 2 2
//3 3 3
//4 4 4
//5 5 5
//6 6 6
//7 7 7
//8 8 8
//9 9 9
//10 A Q
//11 B W
//12 C E
//13 D R
//14 E T
//15 F Y

//For example, the standard hexadecimal representation of the the Jewel hexadecimal
//“QWERTY” is “ABCDEF”. The decimal representation of the standard hexadecimal “ABCDEF”
//is 11259375.
//Using the sample code below, your job is to implement the method “parseJewelHex” using
//Java that parses Jewel’s numeric data, into a Java integer.
 
       public static string parseJewelHex(string jewelHex)
        {
            return "";
        }
    }
}
