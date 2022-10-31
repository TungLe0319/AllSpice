namespace AllSpice.Interfaces;

public interface IRepository<T, Tid>
{

  List<T> Get();
  T GetById(Tid id);
  T Create(T data);
  void Delete(Tid id);
  T Update(T data);

}