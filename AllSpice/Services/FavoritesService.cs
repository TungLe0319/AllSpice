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

    if (newFavorite.Favorited)
    {
      throw new Exception("Invalid Id [example]");
    }



    Favorite favorite = _favoritesRepo.CreateFavorite(newFavorite);
    favorite.Favorited = true;

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

  private Favorite GetFavoriteById(int favoriteId)
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