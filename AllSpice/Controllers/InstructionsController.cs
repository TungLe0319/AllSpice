namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]

public class InstructionsController : ControllerBase
{

  private readonly Auth0Provider _auth0provider;

  private readonly InstructionsService _is;

  public InstructionsController(Auth0Provider auth0provider, InstructionsService @is)
  {
    _auth0provider = auth0provider;
    _is = @is;
  }



  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Instruction>> CreateInstruction([FromBody] Instruction newInstruction)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      newInstruction.CreatorId = userInfo.Id;
      // newInstruction.Creator = userInfo;
      Instruction createdInstruction = _is.CreateInstruction(newInstruction, userInfo.Id);

      return Ok(createdInstruction);

    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }



  // [HttpDelete("{ingredientId}")]
  // [Authorize]
  // public async Task<ActionResult<string>> DeleteInstruction(int instructionId)
  // {
  //   try
  //   {
  //     Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
  //     // _rs.DeleteRecipe(recipeId, userInfo.Id);
  //     _is.DeleteInstruction(instructionId, userInfo.Id);
  //     return Ok("Instruction deleted");
  //   }
  //   catch (Exception e)
  //   {
  //     return BadRequest(e.Message);
  //   }
  // }


}