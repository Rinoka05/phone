using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phone
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            string text = formNumberToText(number);
            Console.WriteLine(text);
            Console.ReadLine();
        }

        private static string formNumberToText(string number)
        {
            char[] c = number.ToCharArray();
            int count = 0;
            char currentChar = c[0];
            string s="";
            int limit = 2;
            for (int i = 1; i < c.Length; i++){
                
                if(currentChar==c[i] && count < limit)
                {
                    count++;
                }
                else
                {
                    s+=translate(currentChar, count);
                    count = 0;
                    currentChar = c[i];
                }
                if (currentChar == '7' || currentChar == '9')
                    limit = 3;
                else limit = 2;
            }
            s += translate(currentChar, count);
            return s;
        }

        private static string translate(char currentChar, int count)
        {
            char[] alphbet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' ' };
            string letter = "";
            int number;
            if (currentChar != '0')
                if (Convert.ToInt32(currentChar.ToString()) <= 7)
                {
                    number = (Convert.ToInt32(currentChar.ToString()) - 2) * 3 + count;
                    letter = Convert.ToString(alphbet[number]);
                }
                else
                {
                    number = (Convert.ToInt32(currentChar.ToString()) - 2) * 3 + count + 1;
                    letter = Convert.ToString(alphbet[number]);
                }
            else
                letter = " ";
            return letter;
        }
    }
}
