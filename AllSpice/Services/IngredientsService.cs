namespace AllSpice.Services;
public class IngredientsService
{
  private readonly IngredientsRepository _instructionsRepo;
  private readonly RecipesRepository _recipeRepo;

  public IngredientsService(IngredientsRepository ingredientsRepo, RecipesRepository recipeRepo)
  {
    _instructionsRepo = ingredientsRepo;
    _recipeRepo = recipeRepo;
  }


  internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
  {
    return _instructionsRepo.GetIngredientsByRecipe(recipeId);
  }

  internal Ingredient GetById(int ingredientId)
  {
    Ingredient foundIngredient = _instructionsRepo.GetIngredientById(ingredientId);

    if (foundIngredient == null)
    {
      throw new Exception("Ingredient does not exist");
    }
    return foundIngredient;

  }


  internal Ingredient CreateIngredient(Ingredient newIngredient, string accountId)
  {
    Recipe recipe = _recipeRepo.GetById(newIngredient.RecipeId);
    if (recipe.CreatorId != newIngredient.CreatorId)
    {
      throw new Exception("Unauthorized");
    }

    return _instructionsRepo.CreateIngredient(newIngredient);
  }

  internal void DeleteIngredient(int ingredientId, string accountId)
  {
    Ingredient foundIngredient = GetById(ingredientId);
    if (foundIngredient == null)
    {
      throw new Exception("Ingredient does not exist");
    }
    if (foundIngredient.CreatorId != accountId)
    {
      throw new Exception("Unauthorized");
    }

    _instructionsRepo.DeleteIngredient(foundIngredient);


  }



}