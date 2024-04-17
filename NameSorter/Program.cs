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

            string file = "C:\\unsorted-names-list.txt";

            try
            {
                if (File.Exists(file))
                {
                    string names = File.ReadAllText(file);
                    var orderedName = program._sort.SortByLastNameThenGivenNames(names);
                    program._sort.SaveOrderedNamesToNewFile(orderedName);
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