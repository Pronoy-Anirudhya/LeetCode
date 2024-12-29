Console.WriteLine(new Solution().FindCheapestPrice(4, [[0, 1, 1], [0, 2, 5], [1, 2, 1], [2, 3, 1]], 0, 3, 1));
Console.ReadLine();

public class Solution
{
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
        //Bellman-Ford Algorithm is being used to find the cheapest price from SOURCE to DESTINATION with one twist to the original algorithm. Since we are only allowed to have AT MOST K stops, so we will be running the going for up to K+1 times. There will be a price array to indicate the current price it requires for it to reach there starting from the SOURCE. For each iteration, we will make a copy of the price array and update that locally. After the iteration is completed, we will copy that back to main price array.

        int[] priceFromSource = new int[n];
        Array.Fill(priceFromSource, int.MaxValue);
        priceFromSource[src] = 0; //We are making it 0 so that our algorithm starts calculating the prices from SOURCE.

        //The twist in the original algorithm where we are iterating for K+1 times and updating the price from SOURCE to other cities
        for (int stops = 0; stops <= k; stops++)
        {
            int[] tempPriceFromSource = new int[n];
            priceFromSource.CopyTo(tempPriceFromSource, 0);

            foreach (var flight in flights)
            {
                (int fromCity, int toCity, int price) = (flight[0], flight[1], flight[2]);

                if (priceFromSource[fromCity] == int.MaxValue)
                    continue;

                int fromCityPriceTillNow = priceFromSource[fromCity];
                int toCityPrice = fromCityPriceTillNow + price;
                tempPriceFromSource[toCity] = Math.Min(tempPriceFromSource[toCity], toCityPrice);
            }

            tempPriceFromSource.CopyTo(priceFromSource, 0);
        }

        return priceFromSource[dst] == int.MaxValue ? -1 : priceFromSource[dst]; //This check prevents the corner case where it is neither possible to travel to any cities from the source or we didn't reach the destination before K-stops
    }
}