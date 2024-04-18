using System.IO;

namespace NameSorter.Service.Implimentation
{
    public class Sort : ISort
    {
        private StreamWriter _writer;

        public List<NameModel> SortByLastNameThenGivenNames(string namesString)
        {
            List<NameModel> models = new();
            List<string> namesList = ConvertStringToList(namesString);

            foreach (var name in namesList)
            {
                string lastName = name.Substring(name.LastIndexOf(' ') + 1);
                string givenName = name.Substring(0, name.LastIndexOf(" "));

                var givenNames = givenName.Split(' ');
                if (givenNames.Length > 3) continue;

                models.Add(CreateNewNameModel(lastName, givenName));
            }

            return models.OrderBy(name=> name.LastName).ToList();
        }
        
        public void SaveOrderedNamesToNewFile(List<NameModel> names)
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(executablePath, "name-sorter.txt");

            try
            {
                if (File.Exists(path))
                { 
                    WriteRecordsToFile(path, names);
                }else
                {
                    File.Create(path);
                    WriteRecordsToFile(path, names);
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

        private static List<string> ConvertStringToList(string namesString)
        {
            string[] namesArray = namesString.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            return new List<string>(namesArray);
        }

        private NameModel CreateNewNameModel(string lastName, string givenName)
        {
            return new NameModel()
            {
                LastName = lastName,
                GivenNames = givenName
            };
        }

        private void WriteRecordsToFile(string path, List<NameModel> models)
        {
            File.WriteAllText(path, String.Empty);

            _writer = new StreamWriter(path);

            foreach (var model in models)
            {
                _writer.WriteLine(model.FullName());
                Console.WriteLine(model.FullName());
            }

            _writer.Close();
        }
    }
}
