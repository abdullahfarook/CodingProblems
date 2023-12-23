namespace CodingProblems;

public partial class CodingProblems
{
    // get all the prime numbers from 1 to 12
    [Theory]
    [InlineData(1, 12, new []{2,3,5,7,11})]
    public void PrimeNumbers(int lower, int upper, int[] result)
    {
        var primeNumbers = new List<int>();

        // find prime numbers from lower to upper limits
        for (int i = lower; i <= upper; i++){
            var number = i;
            if (IsPrime(number)){
                primeNumbers.Add(number);
            }

        }
        primeNumbers.Should().BeEquivalentTo(result);
    }
    bool IsPrime(int number)
    {
        if (number == 1) return false;
        if (number == 2) return true;

        // remove all even numbers
        if (number % 2 == 0) return false;

        // check if number is prime i.e 9 is divisible by 3 so it is not prime
        for (int j = 3; j < number; j += 2){
            if (number % j == 0){
                return false;
            }
        }
        return true;
    }
}