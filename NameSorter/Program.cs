using NameSorter.Service;
using NameSorter.Service.Implimentation;

namespace NameSorted
{
    internal class Program
    {
        private readonly ISort _sort;
        public Program(ISort sort)
        {
            _sort = sort;
        }

        static void Main(string[] args)
        {
            Program program = new Program(new Sort());

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
                    var orderedName = program._sort.SortByLastNameThenGivenNames(names);
                    program._sort.SaveOrderedNamesToNewFile(orderedName);
                }
                else
                {
                    Console.WriteLine("File does not exist: " + file);
                }
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
            }
            finally
            {
                //streamReader.Close();
            }
        }
    }
}