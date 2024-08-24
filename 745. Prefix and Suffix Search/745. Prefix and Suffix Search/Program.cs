var dictionary = new WordFilter(new string[] { "pronoy", "shamma", "lulu", "vutu", "exclusive", "abrupt", "ludlu", "apple" });
//Console.WriteLine($"Prefix: pr, suffix: y -> {dictionary.F("pr", "y")}");
//Console.WriteLine($"Prefix: pr, suffix: iy -> {dictionary.F("pr", "iy")}");
//Console.WriteLine($"Prefix: l, suffix: u -> {dictionary.F("l", "u")}");
//Console.WriteLine($"Prefix: e, suffix: e -> {dictionary.F("e", "e")}");
Console.WriteLine($"Prefix: a, suffix: a -> {dictionary.F("a", "a")}");
Console.ReadLine();

public class WordFilter
{
    private static readonly Trie rootOfTheDictionaryTrie = new();

    public WordFilter(string[] words)
    {
        for (int i = 0; i < words.Length; i++)
            Insert(words[i], i);
    }

    public class Trie
    {
        public Trie[] childrenNodes;
        public List<string> wordsRelatedWithTheNode;
        public bool isLastNode;
        public int wordIndex;

        public Trie()
        {
            childrenNodes = new Trie[26];
            wordsRelatedWithTheNode = new List<string>();
            isLastNode = false;
            wordIndex = 0;

            for (int i = 0; i < childrenNodes.Length; i++)
                childrenNodes[i] = null;
        }
    }

    public int F(string pref, string suff)
    {
        return Search(pref, suff);
    }

    public void Insert(string word, int indexOfTheWord)
    {
        var currentDictionaryNode = rootOfTheDictionaryTrie;

        for (int i = 0; i < word.Length; i++)
        {
            var alphabetIndex = word[i] - 'a';

            if (currentDictionaryNode.childrenNodes[alphabetIndex] == null)
                currentDictionaryNode.childrenNodes[alphabetIndex] = new Trie();

            currentDictionaryNode.childrenNodes[alphabetIndex].wordsRelatedWithTheNode.Add(word);
            currentDictionaryNode = currentDictionaryNode.childrenNodes[alphabetIndex];
        }

        currentDictionaryNode.isLastNode = true;
        currentDictionaryNode.wordIndex = indexOfTheWord;
    }

    public int Search(string prefix, string suffix)
    {
        var currentDictionaryNode = rootOfTheDictionaryTrie;

        for (int i = 0; i < prefix.Length; i++)
        {
            var alphabetIndex = prefix[i] - 'a';

            if (currentDictionaryNode.childrenNodes[alphabetIndex] == null)
                return -1;

            currentDictionaryNode = currentDictionaryNode.childrenNodes[alphabetIndex];
        }

        var words = currentDictionaryNode?.wordsRelatedWithTheNode.Select(x => x).Where(x => x.EndsWith(suffix));

        if (words == null)
            return -1;

        var maxIndex = -1;

        foreach (var word in words)
        {
            var index = GetMatchedWordIndex(word);
            maxIndex = Math.Max(index, maxIndex);
        }

        return maxIndex != -1 ? maxIndex : -1;
    }

    public int GetMatchedWordIndex(string word)
    {
        var currentDictionaryNode = rootOfTheDictionaryTrie;

        for (int i = 0; i < word.Length; i++)
        {
            var alphabetIndex = word[i] - 'a';

            if (currentDictionaryNode.childrenNodes[alphabetIndex] == null)
                return -1;

            currentDictionaryNode = currentDictionaryNode.childrenNodes[alphabetIndex];
        }

        return currentDictionaryNode.isLastNode ? currentDictionaryNode.wordIndex : -1;
    }
}