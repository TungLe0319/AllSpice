namespace AllSpice.Models;

public class Instruction : ICreated, IRepoItem<int>
{
  public int Id { get; set; }
  public int RecipeId { get; set; }

  public string Step { get; set; }

  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}