namespace WebTestBDD.Helpers;

public static class GenerateUniqueRandomData
{
    public static int GetUniqueNumber(int count)
    {
        var random = new Random();

        List<int> randomList = new List<int>();

        int MyNumber = random.Next(1, count);
        if (!randomList.Contains(MyNumber))
        {
            randomList.Add(MyNumber);
        }
        return MyNumber;
    }
}