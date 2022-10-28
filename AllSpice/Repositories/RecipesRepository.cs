namespace AllSpice.Repositories;

public class RecipesRepository : BaseRepository
{
  public RecipesRepository(IDbConnection db) : base(db)
  {
  }

  internal Recipe CreateRecipe(Recipe newRecipe)
  {
    string sql = @"
          INSERT INTO recipes(title,img,instructions,category,creatorId)
          VALUES(@Title,@Img,@Instructions,@Category,@CreatorId);
          SELECT LAST_INSERT_ID()
          ;";
    int recipeId = _db.ExecuteScalar<int>(sql, newRecipe);
    newRecipe.Id = recipeId;
    return newRecipe;
  }

  internal List<Recipe> GetAllRecipes()
  {
    string sql = @"
            SELECT
            rec.*,
            COUNT(fav.id) AS FavoriteCount,
            a.*
            FROM recipes rec
            JOIN accounts a ON a.id = rec.creatorId
            LEFT JOIN favorites fav ON fav.recipeId = fav.id
            GROUP BY fav.id
            ;";
    return _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
    {
      recipe.Creator = profile;
      return recipe;
    }).ToList();
  }
}