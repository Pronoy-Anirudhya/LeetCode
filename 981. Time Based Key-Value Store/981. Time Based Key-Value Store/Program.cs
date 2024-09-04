var timeMap = new TimeMap();
timeMap.Set("foo", "bar", 10);
timeMap.Set("foo", "ba2", 20);
timeMap.Set("foo", "ba3", 30);
Console.WriteLine(timeMap.Get("foo", 15));
Console.WriteLine(timeMap.Get("foo", 25));
Console.WriteLine(timeMap.Get("foo", 35));

Console.ReadLine();

public class TimeMap
{
    Dictionary<string, List<(int, string)>> map;

    public TimeMap()
    {
        map = [];
    }

    public void Set(string key, string value, int timestamp)
    {
        if (!map.ContainsKey(key))
            map[key] = [];

        map[key].Add((timestamp, value));
    }

    public string Get(string key, int timestamp)
    {
        if (!map.ContainsKey(key) || map[key] == null || map[key].Count == 0)
            return string.Empty;

        string mapValue = string.Empty;
        var mapValues = map[key];
        var left = 0;
        var right = mapValues.Count - 1;

        while (left <= right)
        {
            var mid = left + ((right - left) / 2);
            var timestampAtMid = mapValues[mid].Item1;

            if (timestampAtMid <= timestamp)
            {
                mapValue = mapValues[mid].Item2;
                left = mid + 1;
            }
            else
                right = mid - 1;
        }

        return mapValue;
    }
}