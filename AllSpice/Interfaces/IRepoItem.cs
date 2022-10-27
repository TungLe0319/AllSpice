namespace AllSpice.Interfaces;
//NOTE T will server as a placeholder T for Type T is subject to change according to what I want it to be
public interface IRepoItem<T>
{
  T Id { get; set; }
  DateTime CreatedAt { get; set; }

  DateTime UpdatedAt { get; set; }
}