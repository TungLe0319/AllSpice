namespace AllSpice.Models;

public class FavRecipe : Recipe
{
  public int FavoriteId { get; set; }
  public int RecipeId { get; set; }
  public string AccountId { get; set; }
  public bool alreadyFavorited {get;set;}
}