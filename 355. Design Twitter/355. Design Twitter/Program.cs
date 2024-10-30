/*
Input
["Twitter","postTweet","getNewsFeed","follow","getNewsFeed","unfollow","getNewsFeed"]
[[],        [1,1],       [1],         [2,1],    [2],         [2,1],       [2]]
Output
[null,      null,        [1],         null,     [1],         null,        []]
*/

var twitter = new Twitter();
twitter.PostTweet(1, 1);
Console.WriteLine("getNewsFeed for 1: " + string.Join(", ", twitter.GetNewsFeed(1)));
twitter.Follow(2, 1);
Console.WriteLine("getNewsFeed for 2: " + string.Join(", ", twitter.GetNewsFeed(2)));
twitter.Unfollow(2, 1);
Console.WriteLine("getNewsFeed for 2: " + string.Join(", ", twitter.GetNewsFeed(2)));

Console.ReadLine();

public class Twitter
{
    int time = 0; //Time will just be an int for simplicity
    private Dictionary<int, HashSet<int>> followings;
    private Dictionary<int, List<(int tweetId, int time)>> tweets;

    public Twitter()
    {
        followings = [];
        tweets = [];
    }

    public void PostTweet(int userId, int tweetId)
    {
        if (!tweets.ContainsKey(userId))
            tweets[userId] = [];

        tweets[userId].Add((tweetId, time++));
    }

    public IList<int> GetNewsFeed(int userId)
    {
        LinkedList<int> newsFeed = [];

        if (!followings.ContainsKey(userId))
            followings[userId] = [];

        if (!followings[userId].Contains(userId))
            followings[userId].Add(userId);

        var following = followings[userId];
        PriorityQueue<int, int> minHeapTweets = new();

        //TODO: Improve the algorith. This is a very naive approach, every time building the news feed from scratch for each user.
        foreach (var followingId in following)
        {
            if (tweets.TryGetValue(followingId, out var tweetOfThisUser))
            {
                foreach (var tweet in tweetOfThisUser)
                {
                    minHeapTweets.Enqueue(tweet.tweetId, tweet.time);

                    if (minHeapTweets.Count > 10)
                        minHeapTweets.Dequeue();
                }
            }
        }

        while (minHeapTweets.Count > 0)
            newsFeed.AddFirst(minHeapTweets.Dequeue());

        return newsFeed.ToList();
    }

    public void Follow(int followerId, int followeeId)
    {
        if (!followings.ContainsKey(followerId))
            followings[followerId] = [followeeId];
        
        followings[followerId].Add(followeeId);
    }

    public void Unfollow(int followerId, int followeeId)
    {
        if (followings.ContainsKey(followerId))
            followings[followerId].Remove(followeeId);
    }
}