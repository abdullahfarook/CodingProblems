namespace CodingProblems;

public partial class CodingProblems
{
    // Given a string s, find the length of the longest 
    // substring
    //  without repeating characters.



    // Example 1:

    // Input: s = "abcabcbb"
    // Output: 3
    // Explanation: The answer is "abc", with the length of 3.
    // Example 2:

    // Input: s = "bbbbb"
    // Output: 1
    // Explanation: The answer is "b", with the length of 1.
    // Example 3:

    // Input: s = "pwwkew"
    // Output: 3
    // Explanation: The answer is "wke", with the length of 3.
    // Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.


    //     Constraints:

    // 0 <= s.length <= 5 * 104
    // s consists of English letters, digits, symbols and spaces.
    [Theory]
    [InlineData("abcabcbb", 3)]
    [InlineData("bbbbb", 1)]
    public void LongestSubstring(string s, int result)
    {
        Dictionary<char, int> windowChars = new Dictionary<char, int>();
        int maxLength = 0;
        int start = 0;

        for (int end = 0; end < s.Length; end++)
        {
            char currentChar = s[end];

            if (windowChars.ContainsKey(currentChar))
            {
                start = windowChars[currentChar] + 1;
            }

            windowChars[currentChar] = end;
            maxLength = Math.Max(maxLength, end - start + 1);
        }
        maxLength.Should().Be(result);
    }















    //     5. Longest Palindromic Substring
    // Given a string s, return the longest 
    // palindromic

    // substring
    //  in s.



    // Example 1:

    // Input: s = "babad"
    // Output: "bab"
    // Explanation: "aba" is also a valid answer.
    // Example 2:

    // Input: s = "cbbd"
    // Output: "bb"


    // Constraints:

    // 1 <= s.length <= 1000
    // s consist of only digits and English letters.
    [Theory]
    [InlineData("babad", "bab")]
    [InlineData("cbbd", "bb")]
    public void LongestPalindromicSubstring(string s, string result)
    {
        var longestPalindrome = LongestPalindrome(s);
        longestPalindrome.Should().Be((result, result.Length));
    }
    public (string, int) LongestPalindrome(string s)
    {
        string longestPalindrome = "";
        int maxLength = 0;
        for (int i = 0; i < s.Length; i++)
        {
            // find a palindrome with odd length
            string oddPalindrome = FindPalindromeFrom(s, i, i);
            if (oddPalindrome.Length > longestPalindrome.Length)
            {
                maxLength = oddPalindrome.Length;
                longestPalindrome = oddPalindrome;
            }
            // find a palindrome with even length
            string evenPalindrome = FindPalindromeFrom(s, i, i + 1);
            if (evenPalindrome.Length > longestPalindrome.Length)
            {
                maxLength = evenPalindrome.Length;
                longestPalindrome = evenPalindrome;
            }
        }
        return (longestPalindrome, maxLength);
    }
    private string FindPalindromeFrom(string s, int left, int right)
    {
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            left--;  // expand to the left
            right++; // expand to the right
        }
        // return the longest palindromic substring
        return s.Substring(left + 1, right - left - 1);
    }
    // A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

    // Given a string s, return true if it is a palindrome, or false otherwise.



    // Example 1:

    // Input: s = "A man, a plan, a canal: Panama"
    // Output: true
    // Explanation: "amanaplanacanalpanama" is a palindrome.
    // Example 2:

    // Input: s = "race a car"
    // Output: false
    // Explanation: "raceacar" is not a palindrome.
    // Example 3:

    // Input: s = " "
    // Output: true
    // Explanation: s is an empty string "" after removing non-alphanumeric characters.
    // Since an empty string reads the same forward and backward, it is a palindrome.

    [Theory]
    [InlineData("A man, a plan, a canal: Panama", true)]
    [InlineData("A man, a plan, a canal: Panama1", false)]
    public void IsPalindrome(string s, bool result)
    {
        bool output = true;
        for (int start = 0, end = s.Length - 1 ; end > start ; )
        {
            if ( !char.IsLetterOrDigit(s[start]) )
            {
                start++;
                continue;
            }

            if ( !char.IsLetterOrDigit(s[end]) )
            {
                end--;
                continue;
            }

            if ( char.ToLower(s[start++]) != char.ToLower(s[end--]) )
            {
                output = false;
                break;
            }
        }
        output.Should().Be(result);
    }


//     Given a string, the task is to reverse the order of the words in the given string. 

// Examples:

// Input: s = “geeks quiz practice code” 
// Output: s = “code practice quiz geeks”

// Input: s = “i love programming very much” 
// Output: s = “much very programming love i” 
// gen test
    [Theory]
    [InlineData("geeks quiz practice code", "code practice quiz geeks")]
    [InlineData("i love programming very much", "much very programming love i")]
    public void ReverseWords(string s, string result)
    {
        string output = "";
        string[] words = s.Split(' ');
        for (int i = words.Length - 1; i >= 0; i--)
        {
            output += words[i] + " ";
        }
        output = output.Trim();
        output.Should().Be(result);
    }


// Problem Statement: Given a set of strings, find the longest common prefix.
// Examples:

// Input: {“geeksforgeeks”, “geeks”, “geek”, “geezer”}
// Output: “gee”

// Input: {“apple”, “ape”, “april”}
// Output: “ap”
// gen test
    [Theory]
    [InlineData(new[] { "geeksforgeeks", "geeks", "geek", "geezer" }, "gee")]
    [InlineData(new[] { "apple", "ape", "april" }, "ap")]
    public void LongestCommonPrefix(string[] words, string result)
    {
        string output = "";
        int minLength = words.Min(w => w.Length);
        for (int i = 0; i < minLength; i++)
        {
            char currentChar = words[0][i];
            if (words.All(w => w[i] == currentChar))
            {
                output += currentChar;
            }
            else
            {
                break;
            }
        }
        output.Should().Be(result);
    }


//         Given a list of words followed by two words, the task is to find the minimum distance between the given two words in the list of words.

// Examples:

// Input: S = { “the”, “quick”, “brown”, “fox”, “quick”}, word1 = “the”, word2 = “fox”
// Output: 3
// Explanation: Minimum distance between the words “the” and “fox” is 3

// Input: S = {“geeks”, “for”, “geeks”, “contribute”,  “practice”}, word1 = “geeks”, word2 = “practice”
// Output: 2
// Explanation: Minimum distance between the words “geeks” and “practice” is 2
// gen test
    [Theory]
    [InlineData(new string[] { "the", "quick", "brown", "fox", "quick" }, "the", "fox", 3)]
    [InlineData(new string[] { "geeks", "for", "geeks", "contribute", "practice" }, "geeks", "practice", 2)]
    public void MinimumDistance(string[] words, string word1, string word2, int result)
    {
        int output = int.MaxValue;
        int word1Index = -1;
        int word2Index = -1;
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i] == word1)
            {
                word1Index = i;
            }
            if (words[i] == word2)
            {
                word2Index = i;
            }
            if (word1Index != -1 && word2Index != -1)
            {
                output = Math.Min(output, Math.Abs(word1Index - word2Index));
            }
        }
        output.Should().Be(result);
    }

    // find duplicates i.e "aabcdde" => "ad"
    [Theory]
    [InlineData("aabcdde", "ad")]
    [InlineData("aabcddeeff", "adef")]
    public void FindDuplicates(string s, string result)
    {
        var output = "";
        var cache = new HashSet<char>();
        for (int i = 0; i < s.Length; i++)
        {
                var current= s[i];
                if (cache.Contains(current))
                {
                   output += current; 
                }
                cache.Add(current);
        }
        output.Should().Be(result);
    }

    // Input: str1 = “listen”  str2 = “silent”
    // Output: “Anagram”
    // Explanation: All characters of “listen” and “silent” are the same.
    //
    //     Input: str1 = “gram”  str2 = “arm”
    // Output: “Not Anagram”
    [Theory]
    [InlineData("listen", "silent", true)]
    [InlineData("gram", "arm", false)]
    [InlineData("api", "app", true)]
    public void IsAnagram(string s1, string s2, bool result)
    {
        var output = true;
        var cache = new HashSet<char>();
        if (s1.Length != s2.Length)
        {
            output = false;
        }
        else
        {

            for (int i = 0; i < s1.Length; i++)
            {
                var current = s1[i];
                cache.Add(current);
                
            }

            for (int i = 0; i < s2.Length; i++)
            {
                var current = s2[i];
                if (!cache.Contains(current) )
                {
                    output = false;
                    break;
                }
            }
        }
        
        output.Should().Be(result);
        
        
    }







}
