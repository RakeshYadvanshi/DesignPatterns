using System;
using System.Collections.Generic;
using System.IO;

namespace CorrectWay_SRP
{
    /// <summary>
    /// this class have only reponsibility 
    /// 1. maintaining Journal
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



    }

    /// <summary>
    /// this class have only reponsibility 
    /// 1. Persisting Journal data in File system
    /// </summary>
    public class Persistance
    {
        // functionality for persistance the data 
        public void Save(Journal journal, string filename)
        {
            if (!File.Exists(filename))
                File.Create(filename).Close();

            File.WriteAllText(filename, journal.ToString());
        }

        public void Load(Journal journal, string fileName)
        {
            var entries = File.ReadAllLines(fileName);
            foreach (var entry in entries)
                journal.AddEntry(entry);

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

            Persistance persistance = new Persistance();
            persistance.Save(journal, "journal.txt");
        }
    }
}

