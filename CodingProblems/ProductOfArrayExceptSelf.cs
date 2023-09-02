namespace CodingProblems;

public partial class CodingProblems
{
    /// <summary>
    /// Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].
    /// The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
    /// 
    ///     You must write an algorithm that runs in O(n) time and without using the division operation.
    ///     
    ///     Example 1:
    /// 
    /// Input: nums = [1,2,3,4]
    /// Output: [24,12,8,6]
    /// Example 2:
    /// 
    /// Input: nums = [-1,1,0,-3,3]
    /// Output: [0,0,9,0,0]
    /// </summary>
    [Theory]
    [InlineData(new []{1,2,3,4},new []{24,12,8,6})]
    public void ProductOfArrayExceptSelf(int[] nums,int[] target)
    {
        var result = new int[nums.Length];
        int pre = 1, post = 1;
        for (int i = 0; i < nums.Length; i++){
            result[i] = pre;
            pre = nums[i] * pre;
        }
        for (int i = nums.Length - 1; i >= 0; i--){
            result[i] = result[i] * post;
            post = nums[i] * post;
        }
        result.Should().Contain(target);
    }
}