using Name_Sorter_Console.Data;
using Name_Sorter_Console.Model;
using Name_Sorter_Console.Service;
using System;
using System.IO;
using System.Collections.Generic;
using Name_Sorter_Console.Services;

namespace Name_Sorter_Console
{
    public class Program
    {
        private IDataRepository _repo;
        private ISortService<Person> _sortPersonService;
        private string _inputPath;
        private string _outputPath;

        /// <summary>
        /// A constructor of Program, defining dependencies.
        /// </summary>
        /// <param name="inputPath">The path of the input file.</param>
        public Program(string inputPath, ISortService<Person> sortPersonService)
        {
            _repo = new LocalDataRepository(inputPath);
            _sortPersonService = sortPersonService;
            _inputPath = inputPath;
            _outputPath = "./sorted-names-list.txt";
        }
        /// <summary>
        /// A constructor of Program, defining dependencies with given output.
        /// </summary>
        /// <param name="inputPath">The path of the input.</param>
        /// <param name="outputPath">The path of the output.</param>
        public Program(string inputPath, string outputPath, ISortService<Person> sortPersonService)
        {
            _repo = new LocalDataRepository(inputPath);
            _sortPersonService = sortPersonService;
            _inputPath = inputPath;
            _outputPath = outputPath;
        }

        /// <summary>
        /// Prints the list of Person.
        /// </summary>
        /// <param name="personList">The list of Person model.</param>
        public void Print(List<Person> personList)
        {
            foreach (Person person in personList)
            {
                Console.WriteLine(person.FullName);
            }
        }
        /// <summary>
        /// Writing an output file on the given output path. 
        /// </summary>
        /// <param name="personList">A list of Person model.</param>
        public void Output(List<Person> personList) 
        {

            using (StreamWriter outputFile = new StreamWriter(_outputPath))
            {
                foreach (Person person in personList)
                {
                    outputFile.WriteLine(person.FullName);
                }
            }; 
        }
        /// <summary>
        /// The main method to run the program. 
        /// </summary>
        public void Run()
        {
            List<Person> unsortedPersonList = _repo.GetPeopleList();
            List<Person> sortedPersonList = _sortPersonService.Sort(unsortedPersonList);
            Print(sortedPersonList);
            Output(sortedPersonList);
        }
        /// <summary>
        /// The execution of the command line program.
        /// </summary>
        /// <param name="args">An array of command line arguments.</param>
        static void Main(string[] args)
        {
            string inputPath = args[0];
            string reversed = args[1];


            if (reversed == "--reversed")
            {
                new Program(inputPath, new ReverseSortPersonService()).Run();
            }
            else
            {
                new Program(inputPath, new SortPersonService()).Run();
            }


        }
    }
}
