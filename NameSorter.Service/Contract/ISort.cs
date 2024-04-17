namespace NameSorter.Service
{
    public interface ISort
    {
        List<NameModel> SortByLastNameThenGivenNames(string names);
        void SaveOrderedNamesToNewFile(List<NameModel> names);
    }
}