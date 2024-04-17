namespace NameSorted
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string data;
            StreamReader streamReader = null;
            try
            {
                streamReader = new("C:\\unsorted-names-list.txt");
                data = streamReader.ReadLine();

                while (data != null)
                {
                    Console.WriteLine(data);
                    data = streamReader.ReadLine();
                }
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
            }
            finally
            {
                streamReader.Close();
            }
        }
    }
}