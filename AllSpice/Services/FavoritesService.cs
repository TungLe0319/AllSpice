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



  internal void RemoveFavorite(int favoriteId, string accountId)
  {
    Favorite foundFavorite = GetFavoriteById(favoriteId);
    if( foundFavorite == null)
    {
    throw new Exception("Invalid Id");
    }
    if( foundFavorite.AccountId != accountId)
    {
    throw new Exception("Unauthorized");
    }
    
    _favoritesRepo.RemoveFavorite(foundFavorite);
    
  }

  private Favorite GetFavoriteById(int favoriteId)
  {
  Favorite foundFavorite = _favoritesRepo.GetFavoriteById(favoriteId);
  if( foundFavorite == null)
  {
  throw new Exception("Invalid Id");
  }
  if( foundFavorite.Id == 0)
  {
  throw new Exception("Invalid Id ");
  }
  
  return foundFavorite;
  }
}