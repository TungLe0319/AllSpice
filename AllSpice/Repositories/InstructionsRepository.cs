namespace AllSpice.Repositories;

public class InstructionsRepository : BaseRepository
{
  public InstructionsRepository(IDbConnection db) : base(db)
  {
  }

  internal Ingredient CreateIngredient(Ingredient newIngredient)
  {
    string sql = @"
           INSERT INTO ingredients(name,quantity,creatorId,recipeId)
           VALUES(@Name,@Quantity,@CreatorId,@RecipeId);
           SELECT LAST_INSERT_ID()
                ;";
    int id = _db.ExecuteScalar<int>(sql, newIngredient);
    newIngredient.Id = id;
    return newIngredient;
  }

  internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
  {

    string sql = @"
          SELECT 
          *
          FROM ingredients 
          WHERE recipeId = @recipeId
               ;";
    return _db.Query<Ingredient>(sql, new { recipeId }).ToList();
  }


  internal Ingredient GetIngredientById(int ingredientId)
  {

    string sql = @"
            SELECT 
            *
            FROM ingredients 
            WHERE id = @ingredientId
                 ;";
    return _db.Query<Ingredient>(sql, new { ingredientId }).FirstOrDefault();
  }

  internal Instruction CreateInstruction(Instruction newInstruction)
  {
    throw new NotImplementedException();
  }

  internal void DeleteIngredient(Ingredient foundIngredient)
  {
    string sql = @"
          DELETE 
          FROM ingredients
          WHERE id = @id
              ; ";

    int rowsAffected = _db.Execute(sql, foundIngredient);
    if (rowsAffected == 0)
    {
      throw new Exception("Unable to delete ingredient");
    }



  }

}