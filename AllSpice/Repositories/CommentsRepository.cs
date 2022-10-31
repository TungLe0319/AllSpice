namespace AllSpice.Repositories;

public class CommentsRepository : BaseRepository
{
  public CommentsRepository(IDbConnection db) : base(db)
  {
  }

  internal Comment CreateComment(Comment newComment)
  {
    string sql = @"
          INSERT INTO
          comments (body,creatorId)
          VALUES (@Body,@CreatorId);
          SELECT LAST_INSERT_ID()
              ; ";

    int commentId = _db.ExecuteScalar<int>(sql, newComment);
    newComment.Id = commentId;
    return newComment;
  }


  internal void RemoveComment(Comment foundComment)
  {
    string sql = @"
             REMOVE FROM
             comments
            WHERE id = @Id LIMIT 1
                  ";
    int rowsAffected = _db.Execute(sql, foundComment);

    if (rowsAffected == 0)
    {
      throw new Exception("Unable to delete comment");
    }

  }


  internal List<Comment> GetAllComments()
  {
    string sql = @"
            SELECT
            c.*,
            a.*
            FROM comments c
            JOIN accounts a ON a.id = c.creatorId
  
            GROUP BY c.id
            ;";
    return _db.Query<Comment, Profile, Comment>(sql, (comment, profile) =>
    {
      comment.Creator = profile;

      return comment;
    }).ToList();
  }

  internal Comment GetCommentById(int commentId)
  {
    string sql = @"
            SELECT * 
            FROM comments 
            WHERE id = @commentId
                 ;";
    return _db.QueryFirstOrDefault<Comment>(sql, new { commentId });
  }

}
