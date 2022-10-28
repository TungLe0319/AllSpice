namespace AllSpice.Services;
public class RecipesService
{
  private readonly RecipesRepository _recipesRepo;
  private readonly FavoritesRepository _favoritesRepo;

  public RecipesService(RecipesRepository recipesRepo, FavoritesRepository favoritesRepo)
  {
    _recipesRepo = recipesRepo;
    _favoritesRepo = favoritesRepo;
  }

  internal Recipe CreateRecipe(Recipe newRecipe)
  {
return _recipesRepo.CreateRecipe(newRecipe);
  }

  internal List<Recipe> GetAllRecipes()
  {
return _recipesRepo.GetAllRecipes();
  }
}