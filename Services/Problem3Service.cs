namespace euler.Services
{
    public class Problem3Service : IProblem3Service
    {
        public int CalculateLargestPrimeFactor(long number)
        {
            var largestPrimeFactor = 0;
            var i = 2;

            while (i <= number)
            {
                if (number % i == 0)
                {
                    number /= i;
                    largestPrimeFactor = i;
                }
                else
                {
                    i++;
                }
            }

            return largestPrimeFactor;
        }
    }
}
