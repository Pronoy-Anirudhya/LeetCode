var strings = new string[] { "flower", "flow", "flight" }; //{ "aaa", "aa", "aaa" };
Console.WriteLine(new Solution().LongestCommonPrefix(strings));
Console.ReadLine();

public class Solution
{
    public class Trie
    {
        public Trie[] ChildNodes { get; set; }
        public bool IsEndOfTheWord { get; set; }

        public Trie()
        {
            ChildNodes = new Trie[26];
            IsEndOfTheWord = false;

            for (int i = 0; i < 26; i++)
                ChildNodes[i] = null;
        }
    }

    public void InsertIntoTrie(string word, Trie root)
    {
        Trie navigator = root;

        for (int i = 0; i < word.Length; i++)
        {
            var characterIndex = word[i] - 'a';

            if (navigator.ChildNodes[characterIndex] == null)
                navigator.ChildNodes[characterIndex] = new Trie();

            navigator = navigator.ChildNodes[characterIndex];
        }

        navigator.IsEndOfTheWord = true;
    }

    public string GetCommonPrefix(string prefix, Trie root)
    {
        Trie navigator = root;
        var commonPrefix = string.Empty;

        for (int i = 0; i < prefix.Length; i++)
        {
            var characterIndex = prefix[i] - 'a';

            if (navigator.ChildNodes[characterIndex] == null)
                break;

            navigator = navigator.ChildNodes[characterIndex];
            commonPrefix += prefix[i];
        }

        return commonPrefix;
    }

    public string LongestCommonPrefix(string[] strs)
    {
        var longestCommonPrefix = strs[0];

        for (int i = 1; i < strs.Length; i++)
        {
            var root = new Trie();
            InsertIntoTrie(strs[i], root);
            var commonPrefix = GetCommonPrefix(longestCommonPrefix, root);

            if (string.IsNullOrEmpty(commonPrefix))
            {
                longestCommonPrefix = "";
                break;
            }

            longestCommonPrefix = commonPrefix;
        }

        return longestCommonPrefix;
    }
}