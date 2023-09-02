namespace CodingProblems;

public partial class CodingProblems
{
    /// <summary>
    /// Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.
    /// Example 1:
    /// 
    /// Input: nums = [1,2,3,1]
    /// Output: true
    /// Example 2:
    /// 
    /// Input: nums = [1,2,3,4]
    /// Output: false
    /// Example 3:
    /// 
    /// Input: nums = [1,1,1,3,3,4,3,2,4,2]
    /// Output: true
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <param name="result"></param>
    [Theory]
    [InlineData(new []{1,2,3,1},true)]
    public void ContainsDuplicate(int[] nums,bool target)
    {
        var result = false;
        var hash = new HashSet<int>();
        foreach (var num in nums){
            if (hash.Contains(num)){
                result = true;
                break;
            }
            else{
                hash.Add(num);
            }
        }
        result.Should().Be(target);
    }
   
}