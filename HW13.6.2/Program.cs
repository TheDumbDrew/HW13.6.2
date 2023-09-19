using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace HW._13._6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            string[] words;
            string path = @"H:\11Downloads\HW13.6.2.txt";

            using (var sr = new StreamReader(path))
            {
                var text = sr.ReadToEnd().ToLower();

                text = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

                words = text.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }


            var result = words.GroupBy(x => x)
                .Where(x => x.Count() > 1)
                .Select(x => new { Word = x.Key, Frequency = x.Count() });


            foreach (var item in result)
            {
                if (item.Frequency > 1)
                {
                    dictionary.Add(item.Word, item.Frequency);
                }
            }


            var orderedWords = dictionary.OrderByDescending(n => n.Value);
            int i = 1;
            foreach (var item in orderedWords)
            {
                Console.WriteLine($"{i}) Слово \"{item.Key}\" встречается {item.Value} раз");

                if (i == 10)
                    break;
                i++;
            }
        }
    }
}