namespace euler.Services
{
    public class Problem1Service : IProblem1Service
    {
        public int CalculateSumOfMultiples(int limit)
        {
            var sum = 0;
            for (var i = 1; i < limit; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
            }

            return sum;
        }
    }
}