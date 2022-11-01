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



  internal List<Comment> GetAllComments()
  {
    return _commentsRepo.GetAllComments();
  }

  internal Comment GetCommentById(int commentId)
  {
    Comment foundComment = _commentsRepo.GetCommentById(commentId);

    if (foundComment == null)
    {
      throw new Exception("Invalid commentId");
    }

    return foundComment;

  }


  internal Comment CreateComment(Comment newComment, string accountId)
  {
 
    
    return _commentsRepo.CreateComment(newComment);
  }


  internal void RemoveComment(int commentId, string accountId)
  {
    Comment foundComment = GetCommentById(commentId);
    if (foundComment == null)
    {
      throw new Exception("Invalid commentId");
    }
    if (foundComment.CreatorId != accountId)
    {
      throw new Exception("Unauthorized to remove comment");
    }

_commentsRepo.RemoveComment(foundComment);
  }

  internal List<Comment> GetCommentsByRecipe(int recipeId)
  {
 return _commentsRepo.GetCommentsByRecipe(recipeId);
  }
}