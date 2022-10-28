namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]

public class RecipesController : ControllerBase
{

  private readonly Auth0Provider _auth0provider;
  private readonly RecipesService _rs;
  private readonly IngredientsService _is;

  public RecipesController(Auth0Provider auth0provider, RecipesService rs, IngredientsService @is)
  {
    _auth0provider = auth0provider;
    _rs = rs;
    _is = @is;
  }


  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe newRecipe)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      newRecipe.creatorId = userInfo.Id;
      Recipe createdRecipe = _rs.CreateRecipe(newRecipe);
      createdRecipe.Creator = userInfo;
      return Ok(createdRecipe);

    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet]

  public ActionResult<List<Recipe>> GetAllRecipes()
  {
 try
    {
      List<Recipe> recipes = _rs.GetAllRecipes();
      return Ok(recipes);
    }
    catch(Exception e)
    {
    return BadRequest(e.Message);
    }
  }


}