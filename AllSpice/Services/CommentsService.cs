namespace AllSpice.Services;

public class CommentsService
{

  private readonly RecipesRepository _recipesRepo;

  private readonly CommentsRepository _commentsRepo;

  public CommentsService(RecipesRepository recipesRepo, CommentsRepository commentsRepo)
  {
    _recipesRepo = recipesRepo;
    _commentsRepo = commentsRepo;
  }

  internal Comment CreateComment(Comment newComment)
  {
    return _commentsRepo.CreateComment(newComment);
  }

  internal List<Comment> GetAllComments()
  {
    return _commentsRepo.GetAllComments();
  }

  internal void RemoveComment(int commentId, string accountId)
  {
    Comment foundComment = GetCommentById(commentId);
    if (foundComment == null)
    {
      throw new Exception("Invalid commentId");
    }

  }

  internal Comment GetCommentById(int commentId)
  {
    Comment foundComment = _commentsRepo.GetCommentById(commentId);

    if (foundComment == null)
    {
      throw new Exception("Invalid commentId");
    }
    // if (foundComment.Id == 0)
    // {
    //   throw new Exception("Invalid commentId");
    // }

    return foundComment;

  }
}