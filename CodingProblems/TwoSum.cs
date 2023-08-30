namespace CodingProblems;

public partial class CodingProblems
{
    /// <summary>
    /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
    ///
    ///     You can return the answer in any order.
    ///     Example 1:
    ///
    /// Input: nums = [2,7,11,15], target = 9
    /// Output: [0,1]
    /// Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
    /// Example 2:
    ///
    /// Input: nums = [3,2,4], target = 6
    /// Output: [1,2]
    /// Example 3:
    ///
    /// Input: nums = [3,3], target = 6
    /// Output: [0,1]
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <param name="result"></param>
    [Theory]
    [InlineData(new []{2,7,11},9,new []{0,1})]
    public void TwoSumProblem(int[] nums,int target,int[] result)
    {
        var res = TwoSum(nums, target);
        res.Should().Contain(result);
    }
    private int[] TwoSum(int[] nums, int target)
    {
        var map = new Dictionary<int, int>();
        for(var i = 0; i<nums.Length; i++){
            var current = nums[i];
            if (current == target) return new []{i};
            
            var remain = target - current;
            if (map.TryGetValue(remain, out var value)){
                return new[] {
                   value, i
                };
            }
            map.Add(current,i);
        }
        return Array.Empty<int>();
    }
}