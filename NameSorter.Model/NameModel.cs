namespace NameSorter
{
    public class NameModel
    {
        public string LastName { get; set; }
        public string GivenNames { get; set; }

        public string FullName()
        {
            return $"{GivenNames} {LastName}";
        }
    }
}