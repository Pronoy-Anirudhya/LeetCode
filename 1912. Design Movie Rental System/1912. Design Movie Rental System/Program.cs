//MovieRentingSystem movieRentingSystem = new MovieRentingSystem(3, [[0, 1, 5], [0, 2, 6], [0, 3, 7], [1, 1, 4], [1, 2, 7], [2, 1, 5]]);
//Console.WriteLine(string.Join(", ", movieRentingSystem.Search(1)));  // return [1, 0, 2], Movies of ID 1 are unrented at shops 1, 0, and 2. Shop 1 is cheapest; shop 0 and 2 are the same price, so order by shop number.
//movieRentingSystem.Rent(0, 1); // Rent movie 1 from shop 0. Unrented movies at shop 0 are now [2,3].
//movieRentingSystem.Rent(1, 2); // Rent movie 2 from shop 1. Unrented movies at shop 1 are now [1].
//Console.WriteLine(string.Join(", ", movieRentingSystem.Report()));   // return [[0, 1], [1, 2]]. Movie 1 from shop 0 is cheapest, followed by movie 2 from shop 1.
//movieRentingSystem.Drop(1, 2); // Drop off movie 2 at shop 1. Unrented movies at shop 1 are now [1,2].
//Console.WriteLine(string.Join(", ", movieRentingSystem.Search(2)));  // return [0, 1]. Movies of ID 2 are unrented at shops 0 and 1. Shop 0 is cheapest, followed by shop 1.

MovieRentingSystem movieRentingSystem = new MovieRentingSystem(1, [[0, 1, 3], [0, 5, 3], [0, 7, 3], [0, 6, 3], [0, 2, 3], [0, 3, 3], [0, 4, 3], [0, 8, 3]]);
movieRentingSystem.Rent(0, 1);
Console.WriteLine(movieRentingSystem.Report());
movieRentingSystem.Rent(0, 4);
Console.WriteLine(movieRentingSystem.Report());
movieRentingSystem.Rent(0, 3);
Console.WriteLine(movieRentingSystem.Report());
movieRentingSystem.Rent(0, 2);
movieRentingSystem.Rent(0, 6);
movieRentingSystem.Rent(0, 7);
Console.WriteLine(movieRentingSystem.Report());

/*
["MovieRentingSystem","rent","report","rent","report","rent","report","rent","rent","rent","report"]
[[1,[[0,1,3],[0,5,3],[0,7,3],[0,6,3],[0,2,3],[0,3,3],[0,4,3],[0,8,3]]],[0,1],[],[0,4],[],[0,3],[],[0,2],[0,6],[0,7], []]
[null,null,[[0,1]],null,[[0,1],[0,4]],null,[[0,1],[0,3],[0,4]],null,null,null,[[0,1],[0,2],[0,3],[0,4],[0,6]]]
*/

Console.ReadLine();

public class MovieRentingSystem
{
    private const int MaxRentedMoviesToReport = 5;

    private readonly Dictionary<int, SortedSet<RentEntry>> movieToRentMap; // movieId -> SortedSet of RentEntry (shopId, movieId, price). Sorted by price, then shopId, then movieId. Used for Search operation. Can contain rented movies. We will filter them out during Search operation.
    private readonly Dictionary<Movie, RentEntry> movieRecordToRentEntryMap; // (shopId, movieId) -> RentEntry (shopId, movieId, price). Used for Rent and Drop operations to get the RentEntry object in O(1) time. This is needed because we need to remove the RentEntry from the rentedMovieRecords SortedSet during Drop operation, and we need the exact object reference to do that efficiently.
    private readonly SortedSet<RentEntry> rentedMovieRecords; // SortedSet of RentEntry (shopId, movieId, price). Sorted by price, then shopId, then movieId. Used for Report operation. Contains only rented movies.
    private readonly HashSet<Movie> rentedMovies; // Set of (shopId, movieId) for rented movies. Used to check if a movie is rented in O(1) time during Search operation.

    public MovieRentingSystem(int n, int[][] entries)
    {
        movieToRentMap = [];
        movieRecordToRentEntryMap = [];
        rentedMovieRecords = [];
        rentedMovies = [];

        Initialize(entries);
    }

    // Returns the 5 cheapest shop IDs that have an unrented copy of the movie with the given ID. If there are fewer than 5 such shops, return all of them. The returned list should be sorted by price, and if there is a tie, by shop ID.
    public IList<int> Search(int movie)
    {
        // If there are no entries for this movie, return an empty list.
        if (movieToRentMap.Count == 0 || !movieToRentMap.TryGetValue(movie, out var rentEntriesForThisMovie))
            return [];

        // If there are no unrented entries for this movie, return an empty list.
        if (rentEntriesForThisMovie == null || rentEntriesForThisMovie.Count == 0)
            return [];

        List<int> cheapestShopIds = [];
        int count = 0;

        // Iterate through the sorted set of rent entries for this movie and collect the shop IDs of unrented movies until we have 5 or we run out of entries.
        foreach (var rentEntry in rentEntriesForThisMovie)
        {
            if (count >= MaxRentedMoviesToReport)
                break;

            // If this movie is rented, skip it. We check this using the rentedMovies HashSet for O(1) time complexity.
            if (IsRented(rentEntry.ShopId, rentEntry.MovieId))
                continue;

            cheapestShopIds.Add(rentEntry.ShopId);
            count++;
        }

        return cheapestShopIds;
    }

    // Rents the movie with the given ID from the shop with the given ID. It is guaranteed that this shop has an unrented copy of this movie. After this operation, the movie is considered rented.
    public void Rent(int shop, int movie)
    {
        var movieRecord = CreateMovie(shop, movie);
        var rentEntry = movieRecordToRentEntryMap[movieRecord]; // Get the RentEntry object for this (shop, movie) pair in O(1) time.

        // If the movie is not already rented, add it to the rentedMovies HashSet.
        if (!IsRented(shop, movie))
            rentedMovies.Add(movieRecord);

        rentedMovieRecords.Add(rentEntry); // Add the rent entry to the rentedMovieRecords SortedSet to keep it sorted by price, then shopId, then movieId.
    }

    // Drops off (returns) the movie with the given ID to the shop with the given ID. It is guaranteed that this shop has a rented copy of this movie. After this operation, the movie is considered unrented.
    public void Drop(int shop, int movie)
    {
        var movieRecord = CreateMovie(shop, movie);
        var rentEntry = movieRecordToRentEntryMap[movieRecord]; // Get the RentEntry object for this (shop, movie) pair in O(1) time.

        // If the movie is currently rented, remove it from the rentedMovies HashSet.
        if (IsRented(shop, movie))
            rentedMovies.Remove(movieRecord);

        rentedMovieRecords.Remove(rentEntry); // Remove the rent entry from the rentedMovieRecords SortedSet.
    }

    // Returns the 5 cheapest rented movies as a list of (shop ID, movie ID) pairs. If there are fewer than 5 rented movies, return all of them. The returned list should be sorted by price, and if there is a tie, by shop ID, and if there is still a tie, by movie ID.
    public IList<IList<int>> Report()
    {
        IList<IList<int>> cheapestRentedMovieRecords = [];
        int count = 0;

        // Iterate through the sorted set of rented movie records and collect the (shopId, movieId) pairs until we have 5 or we run out of entries. The rentedMovieRecords SortedSet is already sorted by price, then shopId, then movieId. So we can just take the first 5 entries.
        foreach (var rentedMovieRecord in rentedMovieRecords)
        {
            if (count >= MaxRentedMoviesToReport)
                break;

            cheapestRentedMovieRecords.Add([rentedMovieRecord.ShopId, rentedMovieRecord.MovieId]); // Add the (shopId, movieId) pair to the result list.
            count++;
        }

        return cheapestRentedMovieRecords;
    }

    private RentEntry CreateRentEntry(int shopId, int movieId, int price)
    {
        return new RentEntry(shopId, movieId, price);
    }

    private Movie CreateMovie(int shopId, int movieId)
    {
        return new Movie(shopId, movieId);
    }

    // Initialize the data structures with the given entries. Each entry is of the form [shopId, movieId, price]. This method populates the movieToRentMap and movieRecordToRentEntryMap dictionaries. The rentedMovieRecords SortedSet and rentedMovies HashSet are initially empty. This method is called only once during the construction of the MovieRentingSystem object. Time complexity: O(NlogN), where N is the number of entries. This is because we are inserting each entry into a SortedSet, which takes O(logN) time.
    private void Initialize(int[][] entries)
    {
        foreach (var entry in entries)
        {
            int shopId = entry[0], movieId = entry[1], price = entry[2];
            var rentEntry = CreateRentEntry(shopId, movieId, price);
            var movieRecord = CreateMovie(shopId, movieId);

            // Add the rent entry to the movieToRentMap dictionary. If the movieId already exists, add the rent entry to the existing SortedSet. Otherwise, create a new SortedSet and add the rent entry to it.
            if (movieToRentMap.TryGetValue(movieId, out var currentRentEntries))
            {
                currentRentEntries.Add(rentEntry);
                movieToRentMap[movieId] = currentRentEntries;
            }
            else
            {
                movieToRentMap[movieId] = [rentEntry];
            }

            movieRecordToRentEntryMap[movieRecord] = rentEntry; // Map the (shopId, movieId) pair to the RentEntry object for O(1) access during Rent and Drop operations.
        }
    }

    private bool IsRented(int shopId, int movieId)
    {
        return rentedMovies.Contains(CreateMovie(shopId, movieId));
    }
}

public class RentEntry : IComparable<RentEntry>
{
    public int ShopId;
    public int MovieId;
    public int Price;

    public RentEntry(int shopId, int movieId, int price)
    {
        ShopId = shopId;
        MovieId = movieId;
        Price = price;
    }

    // Compare first by Price, then by ShopId, then by MovieId.
    public int CompareTo(RentEntry? rentToCompare)
    {
        if (Price != rentToCompare?.Price)
            return Price.CompareTo(rentToCompare?.Price);

        if (ShopId != rentToCompare.ShopId)
            return ShopId.CompareTo(rentToCompare.ShopId);

        return MovieId.CompareTo(rentToCompare.MovieId); // This will only be reached if Price and ShopId are the same, so we compare by MovieId to ensure uniqueness in the SortedSet.
    }
}

public record Movie(int shopId, int movieId)
{
}