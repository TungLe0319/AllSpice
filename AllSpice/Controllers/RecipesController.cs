namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]

public class RecipesController : ControllerBase
{

  private readonly Auth0Provider _auth0provider;
  private readonly RecipesService _rs;
  private readonly IngredientsService _is;
  private readonly CommentsService _cs;

  private readonly InstructionsService _instructS;

  public RecipesController(Auth0Provider auth0provider, RecipesService rs, IngredientsService @is, CommentsService cs, InstructionsService instructS)
  {
    _auth0provider = auth0provider;
    _rs = rs;
    _is = @is;
    _cs = cs;
    _instructS = instructS;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe newRecipe)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      newRecipe.CreatorId = userInfo.Id;
      Recipe createdRecipe = _rs.CreateRecipe(newRecipe);
      createdRecipe.Creator = userInfo;
      return Ok(createdRecipe);

    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{offSet}")]
  public async Task<ActionResult<List<Recipe>>> GetAllRecipes(int offSet)
  {
    try
    {
      
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);


      List<Recipe> recipes = _rs.GetAllRecipes(offSet);
      return Ok(recipes);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{recipeId}/one")]

  public ActionResult<Recipe> GetById(int recipeId)
  {
    try
    {
      Recipe foundRecipe = _rs.GetById(recipeId);
      return Ok(foundRecipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpGet("{recipeId}/ingredients")]
 
  public ActionResult<List<Ingredient>> GetIngredientsByRecipe(int recipeId)
  {
    try
    {

      List<Ingredient> ingredients = _is.GetIngredientsByRecipe(recipeId);
      return Ok(ingredients);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpGet("{recipeId}/instructions")]
 
  public ActionResult<List<Instruction>> GetInstructionsByRecipe(int recipeId)
  {
    try
    {

      List<Instruction> instructions = _instructS.GetInstructionsByRecipe(recipeId);
      return Ok(instructions);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }






  [HttpGet("{recipeId}/comments")]

  public ActionResult<List<Comment>> GetCommentsByRecipe(int recipeId)
  {
    try
    {

      List<Comment> comments = _cs.GetCommentsByRecipe(recipeId);
      return Ok(comments);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }



  [HttpDelete("{recipeId}")]
  [Authorize]
  public async Task<ActionResult<string>> DeleteRecipe(int recipeId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      _rs.DeleteRecipe(recipeId, userInfo.Id);
      return Ok("Recipe successfully archived");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{recipeId}")]
  [Authorize]
  public async Task<ActionResult<Recipe>> EditRecipe([FromBody] Recipe recipeData, int recipeId)
  {
    try
    {

      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      recipeData.Creator = userInfo;
      recipeData.CreatorId = userInfo.Id;
      recipeData.Id = recipeId;
      Recipe recipe = _rs.EditRecipe(recipeData, userInfo.Id);
      return Ok(recipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }





}