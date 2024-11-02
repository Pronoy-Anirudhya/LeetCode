Trie trie = new Trie();
trie.Insert("apple");
Console.WriteLine(trie.Search("apple"));   // return True
Console.WriteLine(trie.Search("app"));     // return False
Console.WriteLine(trie.StartsWith("app")); // return True
trie.Insert("app");
Console.WriteLine(trie.Search("app"));     // return True

Console.ReadLine();

public class Trie
{
    private TrieNode Root;

    public Trie()
    {
        Root = new();
    }

    public void Insert(string word)
    {
        TrieNode current = Root;

        foreach (char character in word.ToCharArray())
        {
            int index = character - 'a';

            if (current.Children[index] == null)
                current.Children[index] = new();

            current = current.Children[index];
        }

        current.IsEndOfAWord = true;
    }

    public bool Search(string word)
    {
        TrieNode current = Root;

        foreach (char character in word.ToCharArray())
        {
            int index = character - 'a';

            if (current.Children[index] == null)
                return false;

            current = current.Children[index];
        }

        return current.IsEndOfAWord;
    }

    public bool StartsWith(string prefix)
    {
        TrieNode current = Root;

        foreach (char character in prefix.ToCharArray())
        {
            int index = character - 'a';

            if (current.Children[index] == null)
                return false;

            current = current.Children[index];
        }

        return true;
    }
}

public class TrieNode
{
    public TrieNode()
    {
        Children = new TrieNode[26];
        IsEndOfAWord = false;
    }

    public TrieNode[] Children { get; set; }
    public bool IsEndOfAWord { get; set; }
}