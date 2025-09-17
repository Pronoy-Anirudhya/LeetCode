string[] foods = ["kimchi", "miso", "sushi", "moussaka", "ramen", "bulgogi"];
string[] cuisines = ["korean", "japanese", "japanese", "greek", "japanese", "korean"];
int[] ratings = [9, 12, 8, 15, 14, 7];
FoodRatings foodRatings = new FoodRatings(foods, cuisines, ratings);
Console.WriteLine(foodRatings.HighestRated("korean")); // return "kimchi" with rating 9
Console.WriteLine(foodRatings.HighestRated("japanese")); // return "ramen" with rating 14
foodRatings.ChangeRating("sushi", 16); // sushi now has a rating of 16
Console.WriteLine(foodRatings.HighestRated("japanese")); // return "sushi" with rating 16
foodRatings.ChangeRating("ramen", 16); // ramen now has a rating of 16
Console.WriteLine(foodRatings.HighestRated("japanese")); // return "ramen" with rating 16. "ramen" is lexicographically smaller than "sushi".

Console.ReadLine();

public class FoodRatings
{
    private Dictionary<string, FoodInfo> foodNameToFoodInfoMap;
    private Dictionary<string, SortedSet<FoodInfo>> cuisineHighestRatedFoodMap;

    public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
    {
        foodNameToFoodInfoMap = [];
        cuisineHighestRatedFoodMap = [];
        Prepare(foods, cuisines, ratings);
    }

    public void ChangeRating(string food, int newRating)
    {
        // Update the rating in food info map. Remove and re-add the food info in the cuisine max-heap to maintain heap property.
        FoodInfo foodInfo = foodNameToFoodInfoMap[food];
        cuisineHighestRatedFoodMap[foodInfo.Cuisine].Remove(foodInfo);
        foodInfo.UpdateRating(newRating);
        cuisineHighestRatedFoodMap[foodInfo.Cuisine].Add(foodInfo);
    }

    // Return the food with the highest rating for the given cuisine. If there is a tie, return the lexicographically smaller food name.
    public string HighestRated(string cuisine)
    {
        return cuisineHighestRatedFoodMap[cuisine].Max.FoodName;
    }

    private FoodInfo CreateFoodIfo(string food, string cuisine, int rating)
    {
        return new FoodInfo(food, cuisine, rating);
    }

    // Using SortedSet to maintain a max-heap based on custom comparison logic in FoodInfo class
    private void Prepare(string[] foods, string[] cuisines, int[] ratings)
    {
        for (int index = 0; index < foods.Length; index++)
        {
            FoodInfo foodInfo = CreateFoodIfo(foods[index], cuisines[index], ratings[index]);
            foodNameToFoodInfoMap.Add(foodInfo.FoodName, foodInfo);

            // Add to cuisine max-heap
            if (cuisineHighestRatedFoodMap.TryGetValue(foodInfo.Cuisine, out var maxHeap))
            {
                maxHeap.Add(foodInfo);
                cuisineHighestRatedFoodMap[foodInfo.Cuisine] = maxHeap;
            }
            else
            {
                SortedSet<FoodInfo> newMaxHeap = [foodInfo];
                cuisineHighestRatedFoodMap.Add(foodInfo.Cuisine, newMaxHeap);
            }
        }
    }
}

public class FoodInfo : IComparable<FoodInfo>
{
    public string FoodName { get; set; }
    public string Cuisine { get; set; }
    public int Rating { get; set; }

    public FoodInfo(string foodName, string cuisine, int rating)
    {
        FoodName = foodName;
        Cuisine = cuisine;
        Rating = rating;
    }

    public void UpdateRating(int newRating)
    {
        Rating = newRating;
    }

    // Custom comparison logic: Higher rating first, if tie then lexicographically smaller food name first. This is to maintain a max-heap based on rating and food name.
    public int CompareTo(FoodInfo comparingFood)
    {
        // Compare by rating in descending order
        if (Rating != comparingFood.Rating)
            return Rating.CompareTo(comparingFood.Rating);

        // If ratings are the same, compare by food name lexicographically in reverse order for max-heap behavior
        return comparingFood.FoodName.CompareTo(FoodName);
    }
}