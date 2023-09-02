namespace CodingProblems;

public partial class CodingProblems
{
    /// Some random intervals are given
    /// Also, all the interval's end point, will be a start point to some other interval
    /// We need to return all the intervals
    /// in a correct order.
    ///     Input:
    /// (5,7) , (15, 29) (7, 9), (1, 5) (12, 15) (29, 34) (9, 12)
    ///     Output:
    /// (1, 5) (5, 7) (7, 9) (9, 12) (12, 15) (15, 29) (29, 34)
    [Theory]
    [MemberData(nameof(Data))]
    public void ReturnIntervalsInCorrectOrder(KeyValuePair<int,int>[] nums,KeyValuePair<int,int>[] target)
    {
        var result = new KeyValuePair<int,int>[nums.Length];
        var map = new Dictionary<int, int>();
        var min = int.MaxValue;
        var max = int.MinValue;
        foreach (var num in nums){
            min = Math.Min(min, num.Key);
            max = Math.Max(max, num.Value);
            map.Add(num.Key,num.Value);
        }
        Recurssion(min,max,map,result);
        result.Should().ContainInOrder(target);
    }
    private void Recurssion(int key,int last,Dictionary<int, int> map, KeyValuePair<int, int>[] result,int index = 0)
    {
        if (key == last)
            return;
        
        result[index] = new KeyValuePair<int, int>(key, map[key]);
        Recurssion(map[key],last, map, result,++index);
    }
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[]
            {
                new object[] {
                    new KeyValuePair<int,int>(5,7),
                    new KeyValuePair<int,int>(15,29),
                    new KeyValuePair<int,int>(7,9),
                    new KeyValuePair<int,int>(1,5),
                    new KeyValuePair<int,int>(12,15),
                    new KeyValuePair<int,int>(29,34),
                    new KeyValuePair<int,int>(9,12),
                },
                new object[] {
                    new KeyValuePair<int,int>(1,5),
                    new KeyValuePair<int,int>(5,7),
                    new KeyValuePair<int,int>(7,9),
                    new KeyValuePair<int,int>(9,12),
                    new KeyValuePair<int,int>(12,15),
                    new KeyValuePair<int,int>(15,29),
                    new KeyValuePair<int,int>(29,34),
                },
                
            },
        };
}
        