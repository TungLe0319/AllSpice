namespace AllSpice.Services;
public class FavoritesService
{
  private readonly FavoritesRepository _favoritesRepo;
  private readonly RecipesRepository _recipeRepo;

  public FavoritesService(FavoritesRepository favoritesRepo, RecipesRepository recipeRepo)
  {
    _favoritesRepo = favoritesRepo;
    _recipeRepo = recipeRepo;
  }

  internal Favorite CreateFavorite(Favorite newFavorite)
  {

    Favorite favoriteRecipe = _favoritesRepo.GetFavoriteByAccountAndRecipe(newFavorite);
    if (favoriteRecipe != null)
    {
      throw new Exception("already Favorited");
      //---------------------------------------------------------------------------------//

    }
    // -------------------------------------------------------------------------------------------------//
    // List<FavRecipe> favoriteRecipes = _favoritesRepo.GetByAccountId(newFavorite.AccountId);
    // foreach (var f in favoriteRecipes)
    // {
    //   if (f.RecipeId == newFavorite.RecipeId)
    //   {
    //     throw new Exception("already favorited");
    //   }
    // }
    Favorite favorite = _favoritesRepo.CreateFavorite(newFavorite);
    return favorite;
  }



  internal void RemoveFavorite(int favoriteId, string accountId)
  {
    Favorite foundFavorite = GetFavoriteById(favoriteId);
    if (foundFavorite == null)
    {
      throw new Exception("Invalid Id");
    }
    if (foundFavorite.AccountId != accountId)
    {
      throw new Exception("Unauthorized");
    }

    _favoritesRepo.RemoveFavorite(foundFavorite);

  }

  internal Favorite GetFavoriteById(int favoriteId)
  {
    Favorite foundFavorite = _favoritesRepo.GetFavoriteById(favoriteId);
    if (foundFavorite == null)
    {
      throw new Exception("Invalid Id");
    }
    if (foundFavorite.Id == 0)
    {
      throw new Exception("Invalid Id ");
    }

    return foundFavorite;
  }



}