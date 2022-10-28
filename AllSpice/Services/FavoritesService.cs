namespace AllSpice.Services;
public class FavoritesService
{
  private readonly FavoritesRepository _favoritesRepo;

  public FavoritesService(FavoritesRepository favoritesRepo)
  {
    _favoritesRepo = favoritesRepo;
  }

  internal Favorite CreateFavorite(Favorite newFavorite)
  {
    return _favoritesRepo.CreateFavorite(newFavorite);
  }

  internal Favorite GetByAccountId(string accountId)
  {
    Favorite foundFavorite = _favoritesRepo.GetByAccountId(accountId);
    if (foundFavorite == null)
    {
      throw new Exception("Favorite not found");
    }
    return foundFavorite;
  }

  internal void RemoveFavorite(int favoriteId, string accountId)
  {
    Favorite foundFavorite = _favoritesRepo.GetByAccountId(accountId);
    if (foundFavorite == null)
    {
      throw new Exception("Favorite not found");
    }

    if (foundFavorite.AccountId != accountId)
    {
      throw new Exception("Unauthorized");
    }

    _favoritesRepo.RemoveFavorite(foundFavorite);
  }
}