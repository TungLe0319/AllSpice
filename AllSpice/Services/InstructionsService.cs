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


  internal List<Instruction> GetInstructionsByRecipe(int recipeId)
  {
    return _instructionsRepo.GetInstructionsByRecipe(recipeId);
  }

  internal Instruction GetInstructionById(int instructionId)
  {
    Instruction foundInstruction = _instructionsRepo.GetInstructionById(instructionId);

    if (foundInstruction == null)
    {
      throw new Exception("Ingredient does not exist");
    }
    return foundInstruction;

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

  internal void DeleteInstruction(int instructionId, string accountId)
  {
    Instruction foundInstruction = _instructionsRepo.GetInstructionById(instructionId);
    if (foundInstruction.CreatorId != accountId)
    {
      throw new Exception("Unauthorized");
    }

    _instructionsRepo.CreateInstruction(foundInstruction);
  }

  internal void DeleteIngredient(int instructionId, string accountId)
  {
    Instruction foundInstruction = GetInstructionById(instructionId);
    if (foundInstruction == null)
    {
      throw new Exception("instruction does not exist");
    }
    if (foundInstruction.CreatorId != accountId)
    {
      throw new Exception("Unauthorized");
    }

    _instructionsRepo.DeleteInstruction(foundInstruction);


  }



}