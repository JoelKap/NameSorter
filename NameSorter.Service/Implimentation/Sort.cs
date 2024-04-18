namespace NameSorter.Service.Implimentation
{
    public class Sort : ISort
    {
        public List<NameModel> SortByLastName(string namesString)
        {
            List<NameModel> models = new();
            List<string> namesList = ConvertStringToList(namesString);

            foreach (var name in namesList)
            {
                var (lastName, givenNames) = ExtractLastNameAndGivenNames(name);

                if (givenNames.Split(' ').Length > 3) continue;

                models.Add(CreateNameModel(lastName, givenNames));
            }

            return models.OrderBy(name => name.LastName).ToList();
        }

        public void SaveSortedNames(List<NameModel> names)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "name-sorter.txt");

            try 
            {
                using (StreamWriter writer = new(path, false))
                {
                    foreach (var name in names)
                    {
                        writer.WriteLine(name.FullName());
                        Console.WriteLine(name.FullName());
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error while writing to file: " + exception.Message);
            }
        }

        private static List<string> ConvertStringToList(string namesString)
        {
            string[] namesArray = namesString.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            return new List<string>(namesArray);
        }

        private (string lastName, string givenNames) ExtractLastNameAndGivenNames(string name)
        {
            string lastName = name.Substring(name.LastIndexOf(' ') + 1);
            string givenNames = name.Substring(0, name.LastIndexOf(" "));

            return (lastName, givenNames);
        }

        private NameModel CreateNameModel(string lastName, string givenNames)
        {
            return new NameModel()
            {
                LastName = lastName,
                GivenNames = givenNames
            };
        }
    }
}
