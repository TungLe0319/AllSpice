namespace AllSpice.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{

  private readonly Auth0Provider _auth0provider;
  private readonly RecipesService _rs;
  private readonly CommentsService _cs;

  public CommentsController(Auth0Provider auth0provider, RecipesService rs, CommentsService cs)
  {
    _auth0provider = auth0provider;
    _rs = rs;
    _cs = cs;
  }


  [HttpPost]
  public async Task<ActionResult<Comment>> CreateComment([FromBody] Comment newComment)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      newComment.CreatorId = userInfo.Id;
      Comment createdComment = _cs.CreateComment(newComment);

      return Ok(createdComment);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpGet]
  public  ActionResult<List<Comment>> GetAllComments()
  {
    try
    {


      List<Comment> comments = _cs.GetAllComments();
      return Ok(comments);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }



  [HttpDelete("{commentId}")]
  public async Task<ActionResult<string>> RemoveComment(int commentId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      _cs.RemoveComment( commentId, userInfo.Id);
      return Ok("removed from favorites");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }



}