using System.ComponentModel;

Router router = new Router(3);
Console.WriteLine(router.AddPacket(1, 4, 90)); // Packet is added. Return True.
Console.WriteLine(router.AddPacket(2, 5, 90)); // Packet is added. Return True.
Console.WriteLine(router.AddPacket(1, 4, 90)); // This is a duplicate packet. Return False.
Console.WriteLine(router.AddPacket(3, 5, 95)); // Packet is added. Return True
Console.WriteLine(router.AddPacket(4, 5, 105)); // Packet is added, [1, 4, 90] is removed as number of packets exceeds memoryLimit. Return True.
Console.WriteLine(string.Join(", ", router.ForwardPacket())); // Return [2, 5, 90] and remove it from router.
Console.WriteLine(router.AddPacket(5, 2, 110)); // Packet is added. Return True.
Console.WriteLine(router.GetCount(5, 100, 110)); // The only packet with destination 5 and timestamp in the inclusive range [100, 110] is [4, 5, 105]. Return 1.

Console.ReadLine();

public class Router
{
    private readonly int memoryLimit;
    private readonly HashSet<Packet> packets; // To check for duplicates
    private readonly Dictionary<int, List<Packet>> destinationToPacketMap; // To store packets by destination. Key: destination, Value: List of packets with that destination. Sorted by timestamp.
    private readonly Queue<Packet> queue; // To maintain the order of packets for forwarding and removal of oldest packet.

    public Router(int memoryLimit)
    {
        this.memoryLimit = memoryLimit;
        packets = [];
        destinationToPacketMap = [];
        queue = [];
    }

    public bool AddPacket(int source, int destination, int timestamp)
    {
        Packet packet = CreatePacket(source, destination, timestamp);

        if (packets.Contains(packet))
            return false;

        if (packets.Count == memoryLimit)
            RemoveOldestPacket();

        packets.Add(packet);
        queue.Enqueue(packet);
        AddToDestinamtionMap(packet);

        return true;
    }

    public int[] ForwardPacket()
    {
        if (queue.Count == 0)
            return [];

        Packet packetToRemove = queue.Peek();
        RemoveOldestPacket();

        return [packetToRemove.source, packetToRemove.destination, packetToRemove.timestamp];
    }

    public int GetCount(int destination, int startTime, int endTime)
    {
        if (destinationToPacketMap.Count == 0 || !destinationToPacketMap.TryGetValue(destination, out var packets))
            return 0;

        int startIndex = BinarySearchToFindStartIndex(packets, startTime); // First index with timestamp >= startTime
        int endIndex = BinarySearchToFindEndIndex(packets, endTime); // First index with timestamp > endTime

        return endIndex - startIndex; // Count of packets in the range [startTime, endTime] is endIndex - startIndex
    }

    private Packet CreatePacket(int source, int destination, int timestamp)
    {
        return new Packet(source, destination, timestamp);
    }

    // Add packet to the destinationToPacketMap, maintaining sorted order by timestamp
    private void AddToDestinamtionMap(Packet packet)
    {
        if (destinationToPacketMap.TryGetValue(packet.destination, out var currentPacket))
        {
            currentPacket.Add(packet);
            destinationToPacketMap[packet.destination] = currentPacket;
            return;
        }

        destinationToPacketMap[packet.destination] = [packet];
    }

    // Remove the oldest packet from packets, queue, and destinationToPacketMap
    private void RemoveOldestPacket()
    {
        if (queue.Count == 0)
            return;

        Packet packetToRemove = queue.Dequeue();
        packets.Remove(packetToRemove);
        var currentPackets = destinationToPacketMap[packetToRemove.destination];
        currentPackets.RemoveAt(0); // Oldest packet is always at index 0 since we maintain sorted order by timestamp.
        destinationToPacketMap[packetToRemove.destination] = currentPackets;
    }

    // Binary search to find the first index with timestamp >= target
    private int BinarySearchToFindStartIndex(List<Packet> packets, int target)
    {
        if (packets.Count == 0)
            return 0;

        int left = 0, right = packets.Count; // right is exclusive. If target is greater than all timestamps, we should return packets.Count.

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            Packet midPacket = packets[mid];

            // If midPacket.timestamp < target, we need to search in the right half, so we move left to mid + 1.
            if (midPacket.timestamp < target)
                left = mid + 1;
            else
                right = mid; // midPacket.timestamp >= target, so we can still have a potential answer at mid, hence we move right to mid.
        }

        return left;
    }

    // Binary search to find the first index with timestamp > target
    private int BinarySearchToFindEndIndex(List<Packet> packets, int target)
    {
        if (packets.Count == 0)
            return 0;

        int left = 0, right = packets.Count; // right is exclusive. If target is greater than or equal to all timestamps, we should return packets.Count.

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            Packet midPacket = packets[mid];

            // If midPacket.timestamp <= target, we need to search in the right half, so we move left to mid + 1.
            if (midPacket.timestamp <= target)
                left = mid + 1;
            else
                right = mid; // midPacket.timestamp > target, so we can still have a potential answer at mid, hence we move right to mid.
        }

        return left;
    }
}

// Using record to get value-based equality and immutability
public record Packet(int source, int destination, int timestamp)
{
}