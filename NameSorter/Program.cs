using NameSorter.Service;

namespace NameSorter
{
    internal class Program
    { 
        private readonly INameProcessor _sort;
        public Program(INameProcessor sort)
        {
            _sort = sort;
        }

        static void Main(string[] args)
        {
            Program program = new Program(new NameProcessor());

            if (args.Length == 0)
            {
                Console.WriteLine("Usage: name-sorter <path-to-file>");
                Console.WriteLine("Please provide the file path as an argument when executing the application.");
                Console.WriteLine("Example: name-sorter ./unsorted-names-list.txt");
                return;
            }

            string file = args[0];

            try
            {
                if (File.Exists(file))
                {
                    string names = File.ReadAllText(file);
                    var orderedName = program._sort.SortByLastName(names);
                    program._sort.SaveSortedNames(orderedName);
                }
                else
                {
                    Console.WriteLine($"The specified file does not exist: {file}");
                    Console.WriteLine("Ensure that the file path is correct and the file is accessible.");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("An error occurred while processing the file:");
                Console.WriteLine(exception.Message);
            }
        }
    }
}