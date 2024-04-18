namespace NameSorter.Service
{
    public interface ISort
    {
        List<NameModel> SortByLastName(string names);
        void SaveSortedNames(List<NameModel> names);
    }
}