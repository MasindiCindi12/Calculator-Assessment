using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CBSAfrica_Calculator
{
  class Program
  {
    static void Main(string[] args)
    {


      string folder = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
      string fileName = @"\CBSAfrica_Calculator\calculator.txt";

      string fullPath = folder + fileName;


      //Part 2 : Show the last 5 valid calculator operations when the console application loads or start
      Console.WriteLine("================");
      Console.WriteLine("Last Session: ");
      Console.WriteLine("================");
      Console.WriteLine();
      int i, l, m = 1;
      var lineCount = File.ReadLines(fullPath).Count();

      l = 5;
      m = l;
      if (l >= 1 && l <= 10)
      {
        if (File.Exists(fullPath))
        {
          for (i = lineCount - l; i < lineCount; i++)
          {
            string[] lines = File.ReadAllLines(fullPath);
            Console.Write("{0} \n", lines[i]);
            m--;
          }
        }
      }
      else
      {
        Console.WriteLine(" Please input the correct line no.");
      }

      Console.ReadLine();
      Console.Clear();


      //Part one  :A simple calculator  that returns  results of addition, subtraction, ,multiplecation or division of any two numbers.

      double answer = 0;
      string opSymbol;

      double num1, num2;

      while (true)
      {
        Console.Write("Please Enter First Number: ");
        if (double.TryParse(Console.ReadLine(), out num1))
        {
          Console.Write("Please Enter Second Number: ");
          if (double.TryParse(Console.ReadLine(), out num2))
          {

            Console.Write("Please Enter an operation '(+ , - , * , / )': ");
            opSymbol = Console.ReadLine();

            Console.WriteLine();

            using (StreamWriter writer = new StreamWriter(fullPath, true))
            {
              switch (opSymbol)
              {
                case "/":
                  answer = num1 / num2;
                  Console.WriteLine("Calculator(" + num1 + "," + num2 + "," + opSymbol + "); " + "// => result will be " + answer);
                  break;
                case "+":
                  answer = num1 + num2;
                  Console.WriteLine("Calculator(" + num1 + "," + num2 + "," + opSymbol + "); " + "// => result will be " + answer);
                  break;
                case "-":
                  answer = num1 - num2;
                  Console.WriteLine("Calculator(" + num1 + "," + num2 + "," + opSymbol + "); " + "// => result will be " + answer);
                  break;
                case "*":
                  answer = num1 * num2;
                  Console.WriteLine("Calculator(" + num1 + "," + num2 + "," + opSymbol + "); " + "// => result will be " + answer);
                  break;

                default:
                  Console.WriteLine("Calculator(" + num1 + "," + num2 + "," + opSymbol + "); " + "// => result will be unknown");
                  break;
              }
              Console.ReadLine();
              writer.WriteLine("[Inputs: " + num1 + "," + num2 + "][Operation : " + opSymbol + "][ Result:" + answer + "]");
              Console.WriteLine();
              Console.Clear();
            }
          }
          else
          {
            Console.WriteLine("Value Unknown - Please re-enter a valid number");
            Console.ReadLine();
            Console.Clear();
          }
        }
        else
        {
          Console.WriteLine("Value Unknown - Please re-enter a valid number");
          Console.ReadLine();
          Console.Clear();
        }
      }
    }
  }
}
