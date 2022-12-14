namespace AllSpice.Repositories;

public class RecipesRepository : BaseRepository
{


  public RecipesRepository(IDbConnection db) : base(db)
  {
  }

  internal Recipe CreateRecipe(Recipe newRecipe)
  {
    string sql = @"
          INSERT INTO recipes(
            title,
            img,
            instructions,
            category,
            creatorId
            )
          VALUES(
            @Title,
            @Img,
            @Instructions,
            @Category,
            @CreatorId
            );
          SELECT LAST_INSERT_ID()
          ;";
    newRecipe.Id = _db.ExecuteScalar<int>(sql,newRecipe);

    return newRecipe;
  }


  internal List<Recipe> GetAllRecipes()
  {
    var sql = @"
         SELECT 
         rec. *,
         COUNT(fav.id) AS FavoriteCount,
         a.*
         FROM recipes rec
         JOIN accounts a ON a.id = rec.creatorId
         LEFT JOIN favorites fav ON fav.recipeId = rec.id
         GROUP BY rec.id
         
      
              ; ";
    return _db.Query<Recipe, Profile, Recipe>(sql, (recipes, profile) =>
     {
       recipes.Creator = profile;

       return recipes;
     }).ToList();

  }

  internal List<Recipe> GetRecipesInfiniteScroll(int offSet)
  {
    string sql = @"
            SELECT
            rec.*,
            COUNT(fav.id) AS FavoriteCount,
            a.*
            FROM recipes rec
            JOIN accounts a ON a.id = rec.creatorId
            LEFT JOIN favorites fav ON fav.recipeId = rec.id
            GROUP BY rec.id
            LIMIT 12
            OFFSET @offSet
            
            ;";
    return _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
    {
      recipe.Creator = profile;

      return recipe;
    }, new { offSet }).ToList();
  }

  internal List<Recipe> GetRecipesByAccountId(int offSet, string accountId)
  {
    var sql = @"
           SELECT 
           rec. *,
           a.*
           FROM recipes rec
           JOIN accounts a ON a.id = rec.creatorId
         WHERE rec.creatorId = @accountId
           GROUP BY rec.id
           LIMIT 12 OFFSET @offSet
        
                ; ";
    return _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
     {
       recipe.Creator = profile;

       return recipe;
     }, new { offSet, accountId }).ToList();

  }

  internal Recipe GetById(int recipeId)
  {
    string sql = @"
            SELECT
            rec.*,
            a.*
            FROM recipes rec
            JOIN accounts a ON a.id = rec.creatorId
            LEFT JOIN favorites fav ON fav.recipeId = rec.id
            WHERE rec.id = @recipeId
            ;";
    return _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
    {
      recipe.Creator = profile;
      return recipe;
    }, new { recipeId }).First();
  }

  internal void DeleteRecipe(Recipe foundRecipe)
  {
    string sql = @"
            DELETE FROM recipes
               WHERE id = @id
                   ;";
    int rowsAffected = _db.Execute(sql, foundRecipe);
    if (rowsAffected == 0)
    {
      throw new Exception("Unable to delete recipe");
    }

  }

  internal Recipe EditRecipe(Recipe recipeData)
  {
    string sql = @"
              UPDATE recipes SET
              instructions = @instructions,
              title = @title,
              category = @category,
              img = @img
              WHERE id = @Id
                   ;";
    int recipeRow = _db.Execute(sql, recipeData);
    if (recipeRow == 0)
    {
      throw new Exception("Unable to update this recipe");
    }

    return recipeData;
  }


}