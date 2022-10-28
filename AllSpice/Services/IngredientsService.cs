namespace AllSpice.Services;
public class IngredientsService{
  private readonly IngredientsRepository _ingredientsRepo;

  public IngredientsService(IngredientsRepository ingredientsRepo)
  {
    _ingredientsRepo = ingredientsRepo;
  }

  internal Ingredient CreateIngredient(Ingredient newIngredient)
  {
  return _ingredientsRepo.CreateIngredient(newIngredient);
  }

  internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
  {
  return _ingredientsRepo.GetIngredientsByRecipe(recipeId);
  }

  internal void DeleteIngredient(int ingredientId, string accountId)
  {
   Ingredient foundIngredient = GetById(ingredientId);
   if( foundIngredient == null)
   {
   throw new Exception("Ingredient does not exist");
   }
   if( foundIngredient.CreatorId != accountId)
   {
   throw new Exception("Unauthorized");
   }
   
_ingredientsRepo.DeleteIngredient(foundIngredient);


  }


  internal Ingredient GetById(int ingredientId)
  {
    Ingredient foundIngredient = _ingredientsRepo.GetIngredientById(ingredientId);

    if (foundIngredient == null)
    {
      throw new Exception("Ingredient does not exist");
    }
return foundIngredient;

  }
}