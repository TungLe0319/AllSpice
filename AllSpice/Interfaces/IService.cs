namespace AllSpice.Interfaces;

public interface IService<T, Tid>
{


  List<T> Get();

  T GetById(Tid id);


  T Create(T data,Tid id);


  void Delete(Tid id);



  T Update(T data);

}