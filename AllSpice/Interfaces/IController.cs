namespace AllSpice.Interfaces;

public interface IController<T, Tid>
{

  [HttpGet]
  List<T> Get();
  [HttpGet("{id}")]
  T GetById(Tid id);
  [HttpPost]
  
  T Create(T data);
  [HttpDelete("{id}")]
  [Authorize]
  void Delete(Tid id);

  [HttpPut("{id}")]
  [Authorize]
  T Update(T data);

}