namespace NameSorter.Service
{
    public interface INameProcessor
    {
        List<NameModel> SortByLastName(string names);
        void SaveSortedNames(List<NameModel> names, string path);
    }
}