namespace AllSpice.Repositories;

public class IngredientsRepository : BaseRepository
{
  public IngredientsRepository(IDbConnection db) : base(db)
  {
  }

  internal Ingredient CreateIngredient(Ingredient newIngredient)
  {
   string sql = @"
           INSERT INTO ingredients(name,quantity,recipeId)
           VALUES(@Name,@Quantity,@RecipeId);
           SELECT LAST_INSERT_ID()
                ;";
                int id = _db.ExecuteScalar<int>(sql,newIngredient);
                newIngredient.Id = id;
                return newIngredient;
  }

  internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
  {

  string sql = @"
          SELECT 
          ing.*,
          rec.*
          FROM ingredients ing
          JOIN recipes rec ON rec.id = ing.recipeId
          WHERE ing.recipeId = @recipeId
               ;";
               return _db.Query<Ingredient, Profile, Ingredient>(sql, (ingredient,profile) =>{
                ingredient.Creator = profile;
                return ingredient;
               },new {recipeId}).ToList();
  }
}