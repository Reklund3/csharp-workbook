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
        // Function called when there is a vowel present in the
        // current word. 
        public static void TranslateWord(ref string word, int position)
        {
            // your code goes here
            string punct = "";
            string temp = System.String.Empty;
            // Condition to check if the first letter is a Y
            // if the first letter is a y it is not treated as
            // a vowel so we need to move the position off of 
            // zero
            if (word[0] == 'y')
            {
                position++;
            }
            string firstWord = word.Substring(0, position);
            string restWord = word.Substring(position);
            // conditional check for punctuation, if there is punctuation
            // the punctuation gets moved to the punct variable and removed
            // from the end of the word for appending YAY or AY
            if (char.IsPunctuation(restWord[restWord.Length-1]))
            {
                punct += restWord[restWord.Length-1];
                restWord = restWord.Substring(0,restWord.Length-1);
            }
            // if the first vowel is the first letter of the word
            // then this condition will execute
            if (position == 0)
            {
                word += "yay" + punct;
            }
            else
            {
                word = restWord + firstWord + "ay" + punct;
            }
        }
        // Function called when there are no vowels in a word
        // this will only check for a punctuation at the end and
        // if there is one move it to the end after adding the 
        // ay to the end of the word
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