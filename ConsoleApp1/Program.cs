using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{


    class Program
    {
        public static string vowelCharacter = "aiueo";
        public static string procVowel(string param)
        {
            //your code here
            var listinput = param.ToLower().ToList();
            listinput.Sort();
            string listVowel = "";

            foreach (var item in listinput)
            {
                if (vowelCharacter.ToString().Contains(item))
                {
                    listVowel += item;
                }
            }


            return listVowel;
        }

        public static string procConsonant(string param)
        {
            //your code here
            var listinput = param.ToLower().ToList();
            //listinput.Sort();
            string listConsonant = "";

            foreach (var item in listinput)
            {
                if (!vowelCharacter.ToString().Contains(item))
                {
                    if (listConsonant.Contains(item))
                    {
                        StringBuilder sb = new StringBuilder(listConsonant);
                        sb.Insert(listConsonant.IndexOf(item), item);

                        listConsonant = sb.ToString();
                    }
                    else
                    {
                        

                        listConsonant += item;
                    }
                }
            }

            return listConsonant;
        }

        static void Main(string[] args)
        {
            var input2 = Console.ReadLine();

            var a = input2.Split();
            var b = Array.ConvertAll(a, s => int.Parse(s));
            
            Array.Sort(b);
            Array.Reverse(b);
            List<int> c = b.OfType<int>().ToList();


            int num = 0;
            int totalBus = 0;

            for(int i=0; i < c.Count; i++)
            {

                if (num + c[i] == 4)
                {
                    if(num == 0) {
                        totalBus++;
                    }
                    c.RemoveAt(i);
                    num = 0;
                    i = -1;
                }
                else if (num + c[i] < 4)
                {
                    num += c[i];
                    c.RemoveAt(i);
                    totalBus++;
                    i--;
                }

                if (i == c.Count() - 1)
                {
                    c.RemoveAt(i);
                    num = 0;
                    i = -1;
                    totalBus++;
                    
                }

            }

            if((input2.Replace(" ", "").Length - 1).ToString() != a.LastOrDefault())
            {
                Console.WriteLine("Total Numbers of family must be balance");
            }
            else { 
                Console.WriteLine("total Bus needed: " + totalBus);
            }

            Console.WriteLine("Input one line of words (S) : ");
            string input = Console.ReadLine().Replace(" ", "");
            //WRITE YOUR CODE HERE
            string charVowel = procVowel(input);
            string charConsonant = procConsonant(input);

            Console.WriteLine("Vowel Characters : ");
            Console.WriteLine(charVowel);
            Console.WriteLine("Consonant Characters : ");
            Console.WriteLine(charConsonant);

        }
    }
}
