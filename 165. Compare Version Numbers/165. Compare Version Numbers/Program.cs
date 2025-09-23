Console.WriteLine(new Solution().CompareVersion("1.0", "1.0.0.0"));
Console.ReadLine();

public class Solution
{
    public int CompareVersion(string version1, string version2)
    {
        string[] version1Revisions = version1.Split("."), version2Revisions = version2.Split("."); // Split versions into revisions.
        int revision1Length = version1Revisions.Length, revision2Length = version2Revisions.Length;
        int maxRevisionLength = Math.Max(revision1Length, revision2Length); // Get the maximum length of revisions. This will be the number of iterations we need to perform. If one version has fewer revisions, we will treat the missing revisions as 0.

        for (int index = 0; index < maxRevisionLength; index++)
        {
            // Get the current revision for each version and parse it to an integer to ignore leading zeros. If the version has fewer revisions, treat the missing revision as 0.
            int revision1 = index < revision1Length ? int.Parse(version1Revisions[index]) : 0;
            int revision2 = index < revision2Length ? int.Parse(version2Revisions[index]) : 0;

            if (revision1 < revision2)
                return -1;
            else if (revision1 > revision2)
                return 1;
        }

        return 0;
    }
}