namespace AllSpice.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;

  public AccountController(AccountService accountService, Auth0Provider auth0Provider)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpGet("recipes")]
  [Authorize]
  public async Task<ActionResult<List<Recipe>>> GetRecipesByAccountId([FromQuery]int offSet)
  {
    try
    {
      
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Recipe> recipes = _accountService.GetRecipesByAccountId(offSet,userInfo.Id);

      return Ok(recipes);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }







  [HttpGet("favorites/infiniteScroll")]
  [Authorize]
  public async Task<ActionResult<List<FavRecipe>>> GetFavoritesByAccountId([FromQuery]  int offSet)
  {
  try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<FavRecipe> favorites = _accountService.GetFavoritesByAccountIdInfiniteScroll(offSet,userInfo.Id);

      return Ok(favorites);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }








  [HttpGet("favorites")]
  [Authorize]
  public async Task<ActionResult<List<FavRecipe>>> GetFavoritesByAccountId()
  {
  try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<FavRecipe> favorites = _accountService.GetFavoritesByAccountId(userInfo.Id);

      return Ok(favorites);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }





  [HttpGet("favorites/ids")]
  [Authorize]
  public async Task<ActionResult<List<Favorite>>> GetFavoriteIdsByAccountId()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Favorite> favorites = _accountService.GetFavoriteIdsByAccountId(userInfo.Id);

      return Ok(favorites);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}
