using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine(new Solution().SmallestChair([[24710, 60469], [25295, 76256], [11088, 34742], [92605, 97746], [68272, 68682], [44286, 70033], [88703, 92573], [37394, 87075], [47741, 73042], [5603, 9454], [88970, 96339], [62904, 98525], [42743, 69814], [28999, 80490], [76263, 90116], [78042, 90721], [27856, 69492], [20067, 54704], [72177, 81840], [34951, 76201], [59089, 65862], [61102, 76554], [32726, 48272], [57683, 99972], [74537, 85162], [88161, 90916], [50114, 88989], [5170, 11173], [87698, 90284], [78856, 84320], [14517, 51015], [30757, 54925], [28234, 45768], [73177, 89666]], 3));
Console.ReadLine();

public class Solution
{
    public int SmallestChair(int[][] times, int targetFriend)
    {
        PriorityQueue<int, int> minHeapForArrivalTime = new(); //Minheap sorted by Arrival time, value is friend number
        PriorityQueue<(int departureTime, int chairToBeVacant), int> minHeapForDepartureTime = new();//Minheap sorted by Departure time, to check before every arrival whether or not there are friends who have left earlier than the arrival time and make their used chairs available
        PriorityQueue<int, int> availableSeats = new();

        for (int friendNumber = 0; friendNumber < times.Length; friendNumber++)
        {
            int arrivalTime = times[friendNumber][0];
            minHeapForArrivalTime.Enqueue(friendNumber, arrivalTime);

            availableSeats.Enqueue(friendNumber, friendNumber);//Filling up the available seats minHeap. Here friendNumber is actually the seat number. So when we take seat from this minHeap, we get the smallest available seat number
        }

        while (minHeapForArrivalTime.Count > 0)
        {
            int currentFriendNumber = minHeapForArrivalTime.Dequeue(), currentArrivalTime = times[currentFriendNumber][0], currentDepartureTime = times[currentFriendNumber][1];

            while (minHeapForDepartureTime.Count > 0 && minHeapForDepartureTime.Peek().departureTime <= currentArrivalTime)
            {
                (int departureTime, int chairToBeVacant) = minHeapForDepartureTime.Dequeue();
                availableSeats.Enqueue(chairToBeVacant, chairToBeVacant);
            }

            if (currentFriendNumber == targetFriend)
                return availableSeats.Peek();

            minHeapForDepartureTime.Enqueue((currentDepartureTime, availableSeats.Dequeue()), currentDepartureTime);
        }

        return -1;
    }
}