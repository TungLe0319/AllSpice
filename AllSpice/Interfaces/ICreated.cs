namespace AllSpice.Interfaces;


public interface ICreated

{
  #region 
  string CreatorId { get; set; }

  Profile Creator { get; set; }
  #endregion
}