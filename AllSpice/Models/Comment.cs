

namespace AllSpice.Models;

public class Comment : ICreated, IRepoItem<int>
{
  public int Id { get; set; }
  public string CreatorId { get; set; }

  public string Body { get; private set; }
  public Profile Creator { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}