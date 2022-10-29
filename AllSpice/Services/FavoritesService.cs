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
    
    // Recipe recipe = _recipeRepo.GetById(newFavorite.RecipeId);

    
    // if( newFavorite.RecipeId == recipe.Id )
    // {
    // throw new Exception("Already favorited");
    // }
    

   Favorite favorite= _favoritesRepo.CreateFavorite(newFavorite);
  favorite.FavoritedAlready = true;
   
    return favorite;


    
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