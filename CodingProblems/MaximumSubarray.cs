namespace CodingProblems;

public partial class CodingProblems
{
    /// <summary>
    /// Given an integer array nums, find the subarray with the largest sum, and return its sum.
    /// Example 1:
    /// 
    /// Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
    /// Output: 6
    /// Explanation: The subarray [4,-1,2,1] has the largest sum 6.
    /// Example 2:
    /// 
    /// Input: nums = [1]
    /// Output: 1
    /// Explanation: The subarray [1] has the largest sum 1.
    /// Example 3:
    /// 
    /// Input: nums = [5,4,-1,7,8]
    /// Output: 23
    /// Explanation: The subarray [5,4,-1,7,8] has the largest sum 23.
    [Theory]
    [InlineData(new []{-2,1,-3,4,-1,2,1,-5,4},6)]
    public void MaximumSubarray(int[] nums,int target)
    {
        var maxSum = 0;
        var currentSum = nums[0];
        foreach (var n in nums){
            if (currentSum < 0){
                currentSum = 0;
            }
            currentSum = currentSum + n;
            maxSum = Math.Max(maxSum, currentSum);
        }
        maxSum.Should().Be(target);
    }
}