using System;
using System.Text.RegularExpressions;

namespace PigLatin
{
    class Program
    {
        public static void Main()
        {
            // your code goes here
            int wordCount = 0;
            string repeat = System.String.Empty;
            string finalWord = System.String.Empty;
            Console.WriteLine("Enter a word or phrase!");
            string[] pigWord = Console.ReadLine().Split(' ');
            
            for (int i = 0; i < pigWord.Length; i++)
            {
                pigWord[i] = pigWord[i].ToLower();
                wordCount = pigWord[i].IndexOfAny(new char[] { 'a', 'e', 'i', 'o', 'u', 'y' });
                if (wordCount >= 0)
                {
                    TranslateWord(ref pigWord[i], wordCount);
                    finalWord += pigWord[i] + ' ';
                }
                else 
                {
                    TranslateWord(ref pigWord[i]);
                    finalWord += pigWord[i] + ' ';
                }
            }
            Console.WriteLine(finalWord.ToLower());
            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
        }
        
        public static void TranslateWord(ref string word, int position)
        {
            // your code goes here
            string punct = "";
            string temp = System.String.Empty;
            if (word[0] == 'y')
            {
                position++;
            }
            string firstWord = word.Substring(0, position);
            string restWord = word.Substring(position);
            if (char.IsPunctuation(restWord[restWord.Length-1]))
            {
                punct += restWord[restWord.Length-1];
                restWord = restWord.Substring(0,restWord.Length-1);
            }
            if (position == 0)
            {
                word += "yay" + punct;
            }
            else
            {
                word = restWord + firstWord + "ay" + punct;
            }
        }
        public static void TranslateWord(ref string word)
        {
            string punct = "";
            if (char.IsPunctuation(word[word.Length-1]))
            {
                punct += word[word.Length-1];
                word = word.Substring(0,word.Length-1);
            }
            word = word + "ay" + punct;
        }
    }
}
// Test Cases
// child = ildchay     works
// yellow = ellowyay   works
// dye = yeday         works
// bx = bxay           works
// eat = eatyay        works