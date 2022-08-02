
namespace LeetCode.Weekly.FoodRating;
public class FoodRatings
{
    List<Food> Foods;
    List<Cuisine> Cuisines;

    Dictionary<string, (string, int)> highestRatedCuisineFood = new Dictionary<string, (string, int)>();
    public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
    {
        Foods = new List<Food>();
        Cuisines = new List<Cuisine>();
        for (int i = 0; i < foods.Length; i++)
        {
            Food food = new Food();
            food.Name = foods[i];

            Cuisine cuisine = Cuisines.FirstOrDefault(c => c.Name == cuisines[i]);

            if (cuisine == null)
            {
                cuisine = new Cuisine();
                cuisine.Name = cuisines[i];
                Cuisines.Add(cuisine);
                highestRatedCuisineFood.Add(cuisines[i], (foods[i], ratings[i]));
            }

            food.Cuisine = cuisine;
            food.Ratings = ratings[i];

            if (highestRatedCuisineFood.ContainsKey(cuisines[i]))
            {
                if (highestRatedCuisineFood[cuisines[i]].Item1 == foods[i])
                {
                    highestRatedCuisineFood[cuisines[i]] = (foods[i], ratings[i]);
                }
                else if (ratings[i] > highestRatedCuisineFood[cuisines[i]].Item2)
                {
                    highestRatedCuisineFood[cuisines[i]] = (foods[i], ratings[i]);
                }
                else if (ratings[i] == highestRatedCuisineFood[cuisines[i]].Item2 && string.Compare(foods[i], highestRatedCuisineFood[cuisines[i]].Item1) < 0)
                {
                    highestRatedCuisineFood[cuisines[i]] = (foods[i], ratings[i]);
                }
            }
            Foods.Add(food);
        }
    }

    public void ChangeRating(string food, int newRating)
    {
        var foodVal = Foods.FirstOrDefault(f => f.Name == food);

        if (foodVal != null)
        {
            foodVal.Ratings = newRating;
        }

        string cuisine = foodVal.Cuisine.Name;

        if (highestRatedCuisineFood.ContainsKey(cuisine))
        {
            if (highestRatedCuisineFood[cuisine].Item1 == food)
            {
                if (newRating >= highestRatedCuisineFood[cuisine].Item2)
                {
                    highestRatedCuisineFood[cuisine] = (food, newRating);
                }
                else
                {
                    var f = Foods.Where(x => x.Cuisine.Name == cuisine).OrderBy(x => x.Name).OrderByDescending(x => x.Ratings).FirstOrDefault();
                    highestRatedCuisineFood[cuisine] = (f.Name, f.Ratings);
                }
            }
            else if (newRating > highestRatedCuisineFood[cuisine].Item2)
            {
                highestRatedCuisineFood[cuisine] = (food, newRating);
            }
            else if (newRating == highestRatedCuisineFood[cuisine].Item2 && string.Compare(food, highestRatedCuisineFood[cuisine].Item1) < 0)
            {
                highestRatedCuisineFood[cuisine] = (food, newRating);

            }
        }
    }

    public string HighestRated(string cuisine)
    {

        return highestRatedCuisineFood[cuisine].Item1;


    }
}
