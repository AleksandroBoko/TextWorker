using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest3009
{
    class TextWorker
    {
        const string Letters = "AaEeIiOoUuYy";

        string _text;
        string _targetString;


        public void SetText(string value)
        {
            _text = value;
        }

        public void SetTargetString(string value)
        {
            _targetString = value;
        }

        public string ChangeTheLongetString()
        {
            if (_text == null || _text.Length == 0)
                return _text;

            if (_targetString == null || _text.Length == 0)
                return _text;

            string[] words = SeparateText(_text);

            int maxLength = FindMaxLength(words);

            return ChangeString(words, maxLength);
        }

        int FindMaxLength(string[] arr)
        {

            if (arr.Length == 1)
            {
                return arr[0].Length;
            }
            else
            {
                int maxLength = arr[0].Length;
                for (int i = 1; i < arr.Length; i++)
                {
                    maxLength = maxLength < arr[i].Length ? arr[i].Length : maxLength;
                }
                return maxLength;
            }
        }

        int FindMinLength(string[] arr)
        {

            if (arr.Length == 1)
            {
                return arr[0].Length;
            }
            else
            {
                int minLength = arr[0].Length;
                for (int i = 1; i < arr.Length; i++)
                {
                    minLength = minLength > arr[i].Length ? arr[i].Length : minLength;
                }
                return minLength;
            }
        }

        string ChangeString(string[] arr, int maxLen)
        {
            string[] temp = arr;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].Length == maxLen)
                    ChangeCharInConcreteString(ref temp[i]);
            }

            return GetResultText(temp);
        }

        void ChangeCharInConcreteString(ref string str)
        {
            string newString = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (Letters.Contains(str[i]))
                    newString += _targetString;
                else
                    newString += str[i];
            }
            str = newString;
        }

        string GetResultText(string[] arr)
        {
            string res = "";
            for (int i = 0; i < arr.Length; i++)
            {
                res += arr[i] + " ";
            }
            return res;
        }

        string[] SeparateText(string text)
        {
            if (text == null || text.Length == 0)
                return null;

            return text.Split(' ');
        }

        public void ShowDuplicateWords()
        {

            string[] words = SeparateText(_text);
            FindDuplicateWords(words);

        }

        void FindDuplicateWords(string[] arr)
        {
            List<string> list = new List<string>();
            int countWords = 0;

            for(int i = 0; i < arr.Length; i++)
            {
                if (list.Contains(arr[i]))
                    continue;

                countWords = 0;

                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                        countWords++;
                }

                Console.WriteLine("{0} - {1}", arr[i], countWords);
                list.Add(arr[i]);
            }

        }

        public string ToCamelCaseLongestShortestWord()
        {
            if (_text == null || _text.Length == 0)
                return _text;

            string[] words = _text.Split(' ');
            int maxLength = FindMaxLength(words);
            int minLength = FindMinLength(words);
            words = ChangeLongestAndShortestWords(words, minLength, maxLength);

            return GetResultText(words);
        }

        string[] ChangeLongestAndShortestWords(string[] arr, int minLen, int maxLen)
        {
            string[] temp = arr;
            for(int i = 0; i < temp.Length; i++)
            {
                if (temp[i].Length == minLen)
                    ToCamelCase(ref temp[i]);
                else if (temp[i].Length == maxLen)
                    ToPascalCase(ref temp[i]);
            }

            return temp;
        }

        void ToCamelCase(ref string word)
        {
            string newWord = "";
            for(int i = 0; i < word.Length; i++)
            {
                newWord += i % 2 == 0 ? (word[i].ToString()).ToLower() : (word[i].ToString()).ToUpper();
            }
            word = newWord;
        }

        void ToPascalCase(ref string word)
        {
            string newWord = "";
            for(int i= 0; i < word.Length; i++)
            {
                if(i == 0)
                    newWord += (word[i].ToString()).ToUpper();
                else
                    newWord += i % 2 != 0 ? (word[i].ToString()).ToLower() : (word[i].ToString()).ToUpper();
            }
            word = newWord;
        }
            
    }

    class Program
    {
        static void Main()
        {
            TextWorker tw = new TextWorker();
            string text = "one underground three four five twenty one beautiful football three second";
            tw.SetText(text);
            tw.SetTargetString("*");
            Console.WriteLine("The changed string:\n{0}",tw.ChangeTheLongetString());
            Console.WriteLine("\nThe list of words:");
            tw.ShowDuplicateWords();

            Console.WriteLine("\nChanged the shortest and the longest words:");
            Console.WriteLine(tw.ToCamelCaseLongestShortestWord());


            Console.ReadKey();
        }
    }
}
