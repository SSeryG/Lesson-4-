public class PrimeGenerator
{
    private static bool[] f;
    private static int[] result;
    public static int[] GeneratePrimeNumbers(int maxValue)
    {
        if (maxValue < 2)
            return new int[0];
        else
        {
            InitializeArrayOfIntegers(maxValue);
            CrossOutMultiples();
            PutUncrossedIntegersIntoResult();
            return result;
        }
    }
    private static void InitializeArrayOfIntegers(int maxValue)
    {
        // объявления
        f = new bool[maxValue + 1];
        f[0] = f[1] = false; //не простые числа и не кратные
        for (int i = 2; i < f.Length; i++)
            f[i] = true;
    }
}