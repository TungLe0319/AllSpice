namespace AllSpice.Repositories;

public class FavoritesRepository : BaseRepository
{
  public FavoritesRepository(IDbConnection db) : base(db)
  {
  }

  internal Favorite CreateFavorite(Favorite newFavorite)
  {
    string sql = @"
              INSERT INTO favorites(recipeId,accountId)
              VALUES(@RecipeId,@AccountId);
              SELECT LAST_INSERT_ID()
                   ;";
    int id = _db.ExecuteScalar<int>(sql, newFavorite);
    newFavorite.Id = id;
    return newFavorite;
  }

  internal Favorite GetByAccountId(string accountId)
  {
    string sql = @"
           SELECT 
           fav.*,
           a.*
           FROM favorites fav
           JOIN accounts a ON a.id = fav.accountId
           WHERE fav.accountId = @favoriteId
                ;";
    return _db.QueryFirstOrDefault<Favorite>(sql, new { accountId });
  }

  internal void RemoveFavorite(Favorite foundFavorite)
  {
    string sql = @"
            DELETE FROM
            favorites 
            WHERE id = @Id LIMIT 1
                 ;";
    _db.Execute(sql, foundFavorite);
  }
}