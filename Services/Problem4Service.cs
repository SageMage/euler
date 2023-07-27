namespace euler.Services
{
    public class Problem4Service : IProblem4Service
    {
        public int CalculateLargestPalindromeProduct(int number)
        {
                                    var largestPalindromeProduct = 0;
            var largestNumber = FindLargestNumber(number);
            var smallestNumber = FindSmallestNumber(number);
            for (var i = largestNumber; i >= smallestNumber; i--)
            {
                for (var j = largestNumber; j >= smallestNumber; j--)
                {
                    var product = i * j;
                    if (IsPalindrome(product) && product > largestPalindromeProduct)
                    {
                        largestPalindromeProduct = product;
                    }
                }
            }
            return largestPalindromeProduct;
        }
        public int FindLargestNumber(int number)
        {
            var largestNumber = 0;
            for (var i = 0; i < number; i++)
            {
                largestNumber += 9 * (int)Math.Pow(10, i);
            }
            return largestNumber;
        }
        public int FindSmallestNumber(int number)
        {
            var smallestNumber = 1;
            for (var i = 0; i < number - 1; i++)
            {
                smallestNumber += 9 * (int)Math.Pow(10, i);
            }
            return smallestNumber;
        }

        public bool IsPalindrome(int product)
        {
            var productString = product.ToString();
            var reversedProductString = new string(productString.Reverse().ToArray());
            return productString == reversedProductString;
        }
    }
}
