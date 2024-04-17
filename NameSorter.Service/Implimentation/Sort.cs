namespace NameSorter.Service.Implimentation
{
    public class Sort : ISort
    {
        public List<NameModel> SortByLastNameThenGivenNames(string namesString)
        {
            List<NameModel> models = new();
            List<string> namesList = ConvertStringToList(namesString);

            foreach (var name in namesList)
            {
                string lastName = name.Substring(name.LastIndexOf(' ') + 1);
                string givenName = name.Substring(0, name.LastIndexOf(" "));

                models.Add(CreateNewNameModel(lastName, givenName));
            }

            return models.OrderBy(name=> name.LastName).ToList();
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

        public void SaveOrderedNamesToNewFile(List<NameModel> names)
        {
            throw new NotImplementedException();
        }
    }
}
