WordDictionary wordDictionary = new();
wordDictionary.AddWord("bad");
wordDictionary.AddWord("dad");
wordDictionary.AddWord("mad");
Console.WriteLine(wordDictionary.Search("pad")); // return False
Console.WriteLine(wordDictionary.Search("bad")); // return True
Console.WriteLine(wordDictionary.Search(".ad")); // return True
Console.WriteLine(wordDictionary.Search("b..")); // return True

Console.ReadLine();

public class WordDictionary
{
    private TrieNode Root;

    public WordDictionary()
    {
        Root = new();
    }

    public void AddWord(string word)
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
        return DFS(word.ToCharArray(), 0, Root);
    }

    private bool DFS(char[] characters, int currentIndex, TrieNode node)
    {
        TrieNode current = node;

        for (int index = currentIndex; index < characters.Length; index++)
        {
            int childrenIndex = characters[index] - 'a';

            if (childrenIndex >= 0 && childrenIndex < 26)
            {
                if (current.Children[childrenIndex] == null)
                    current.Children[childrenIndex] = new();

                current = current.Children[childrenIndex];
            }
            else
            {
                /*This block is for '.' which means any of the 26 children of the current node can be a match if it matches with the word. For this, we would havle to recursively run a DFS with all the children and if we find a TRUE match then we return TRUE immediately. Else, if we went through all the 26 children and didn't find a TRUE match, it means there's no word in the Trie that matches so we return FALSE at the end of the for loop.
                */
                for (int child = 0; child < 26; child++)
                {
                    if (current.Children[child] != null && DFS(characters, index + 1, current.Children[child]))
                        return true;
                }

                return false;
            }
        }

        //After each recursive run, the code will return from here. Current will be at the end of the word for the current children node. So if it's actually an IsEndOfAWord, then we found a match, otherwise not. So the call goes back to else block and goes to the next children at that level.
        return current.IsEndOfAWord;
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