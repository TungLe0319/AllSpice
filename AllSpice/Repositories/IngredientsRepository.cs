namespace AllSpice.Repositories;

public class IngredientsRepository : BaseRepository
{
  public IngredientsRepository(IDbConnection db) : base(db)
  {
  }

  internal Ingredient CreateIngredient(Ingredient newIngredient)
  {
   string sql = @"
           INSERT INTO ingredients(name,quantity,creatorId,recipeId)
           VALUES(@Name,@Quantity,@CreatorId,@RecipeId);
           SELECT LAST_INSERT_ID()
                ;";
                int ingredientId = _db.ExecuteScalar<int>(sql,newIngredient);
                newIngredient.Id = ingredientId;
                return newIngredient;
  }
}