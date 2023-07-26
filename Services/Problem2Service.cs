namespace euler.Services
{
    public class Problem2Service : IProblem2Service
    {
        public int CalculateSumOfEvenFibonacciNumbers(int limit)
        {
            var sum = 0;
            var previous = 1;
            var current = 2;
            while (current < limit)
            {
                if (current % 2 == 0)
                    sum += current;

                var next = previous + current;
                previous = current;
                current = next;
            }

            return sum;
        }
    }
}
