using System;
using System.Collections.Generic;
using System.IO;

namespace Issue
{
    /// <summary>
    /// this class have muliple reponsibility 
    /// 1. maintaining Journal 
    /// 2. Persisting Journal data in File system
    /// </summary>
    public class Journal
    {
        private readonly List<string> Entries = new List<string>();
        private int count;

        public int AddEntry(string entry)
        {
            Entries.Add($"{++count}: {entry}");
            return count; //memento Pattern
        }

        public void RemoveEntry(int index)
        {
            Entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, Entries);
        }

        // functionality for persistance the data 

        public void Save(string filename)
        {
            if (!File.Exists(filename))
                File.Create(filename).Close();

            File.WriteAllText(filename, ToString());
        }

        public void Load(string fileName)
        {
            var entries = File.ReadAllLines(fileName);
            this.Entries.AddRange(entries);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var journal = new Journal();
            journal.AddEntry("this is very sad journal");
            journal.AddEntry("2nd journal to achieve success");

            Console.WriteLine(journal);

            journal.Save("journal.txt");
        }
    }
}
