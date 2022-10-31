namespace AllSpice.Services;
public class InstructionsService
{
  private readonly InstructionsRepository _instructionsRepo;
  private readonly RecipesRepository _recipeRepo;

  public InstructionsService(InstructionsRepository instructionsRepo, RecipesRepository recipeRepo)
  {
    _instructionsRepo = instructionsRepo;
    _recipeRepo = recipeRepo;
  }


  // internal List<Ingredient> GetInstructionsByRecipe(int recipeId)
  // {
  //   return _instructionsRepo.GetInstructionsByRecipe(recipeId);
  // }

  internal Ingredient GetById(int ingredientId)
  {
    Ingredient foundIngredient = _instructionsRepo.GetIngredientById(ingredientId);

    if (foundIngredient == null)
    {
      throw new Exception("Ingredient does not exist");
    }
    return foundIngredient;

  }


  internal Instruction CreateInstruction(Instruction newInstruction, string accountId)
  {
    Recipe recipe = _recipeRepo.GetById(newInstruction.RecipeId);
    if (recipe.CreatorId != newInstruction.CreatorId)
    {
      throw new Exception("Unauthorized");
    }

    return _instructionsRepo.CreateInstruction(newInstruction);
  }

//   internal void DeleteInstruction(int instructionId, string accountId)
//   {
//     Instruction foundInstruction = _instructionsRepo.GetIngredientById(instructionId);
//     if (foundInstruction.CreatorId != accountId)
//     {
//       throw new Exception("Unauthorized");
//     }

//  _instructionsRepo.CreateInstruction(foundInstruction);
//   }

  // internal void DeleteIngredient(int instructionId, string accountId)
  // {
  //   Instruction foundInstruction = GetById(instructionId);
  //   if (foundInstruction == null)
  //   {
  //     throw new Exception("instruction does not exist");
  //   }
  //   if (foundInstruction.CreatorId != accountId)
  //   {
  //     throw new Exception("Unauthorized");
  //   }

  //   _instructionsRepo.DeletenIstruction(foundInstruction);


  // }



}