namespace AllSpice.Services;

public class AccountService
{
  private readonly AccountsRepository _repo;
  private readonly FavoritesRepository _favoritesRepo;
  private readonly RecipesRepository _recipeRepo;

  public AccountService(AccountsRepository repo, FavoritesRepository favoritesRepo, RecipesRepository recipeRepo)
  {
    _repo = repo;
    _favoritesRepo = favoritesRepo;
    _recipeRepo = recipeRepo;
  }

  internal Account GetProfileByEmail(string email)
  {
    return _repo.GetByEmail(email);
  }

  internal Account GetOrCreateProfile(Account userInfo)
  {
    Account profile = _repo.GetById(userInfo.Id);
    if (profile == null)
    {
      return _repo.Create(userInfo);
    }
    return profile;
  }

  internal Account Edit(Account editData, string userEmail)
  {
    Account original = GetProfileByEmail(userEmail);
    original.Name = editData.Name.Length > 0 ? editData.Name : original.Name;
    original.Picture = editData.Picture.Length > 0 ? editData.Picture : original.Picture;
    return _repo.Edit(original);
  }

  internal List<Recipe> GetRecipesByAccountId( int offSet, string accountId)
  {
   return _recipeRepo.GetRecipesByAccountId(offSet,accountId);
  }

  internal List<FavRecipe> GetFavoritesByAccountIdInfiniteScroll(int offSet,string accountId)

  {
    
    return _favoritesRepo.GetByAccountIdInfiniteScroll(offSet,accountId);
  }


  internal List<FavRecipe> GetFavoritesByAccountId(string accountId)
  {
  return _favoritesRepo.GetByAccountId(accountId);
  }

  internal List<Favorite> GetFavoriteIdsByAccountId(string accountId)
  {
    
    return _favoritesRepo.GetFavoriteIdsByAccountId(accountId);
  }
}
// internal List<Favorite> GetFavoriteIdsByAccountId(string accountId)
// {
//   List<Favorite> favorites = _favoritesRepo.GetFavoriteIdsByAccountId(accountId);
//   List<Recipe> recipes = _recipeRepo.GetAllRecipes();
//   recipes.ForEach(r =>
//   {
//     var fav = favorites.Find(f => f.RecipeId == r.Id)
//       if (fav)
//     {
//       f.favoriteId = fav.Id;
//     }

//   });
// }

