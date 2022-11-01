namespace AllSpice.Repositories;

public class InstructionsRepository : BaseRepository
{
  public InstructionsRepository(IDbConnection db) : base(db)
  {
  }

 

  internal List<Instruction> GetInstructionsByRecipe(int recipeId)
  {

    string sql = @"
          SELECT 
      i.*,
      a.*
          FROM instructions i
          JOIN accounts a ON a.id = i.creatorId
          WHERE recipeId = @recipeId
               ;";
    return _db.Query<Instruction,Profile,Instruction>(sql,(instruction,profile)=>{
      instruction.Creator = profile;
      return instruction;
    }, new { recipeId }).ToList();
  }

  internal Instruction GetInstructionById(int instructionId)
  {
    string sql = @"
            SELECT 
            *
            FROM instructions 
            WHERE id = @instructionId
                 ;";
    return _db.Query<Instruction>(sql, new { instructionId }).FirstOrDefault();
  }


  internal Instruction CreateInstruction(Instruction newInstruction)
  {
    string sql = @"
           INSERT INTO instructions(step,creatorId,recipeId)
           VALUES(@Step,@CreatorId,@RecipeId);
           SELECT LAST_INSERT_ID()
                ;";
    int id = _db.ExecuteScalar<int>(sql, newInstruction);
    newInstruction.Id = id;
    return newInstruction;
  }


  internal void DeleteInstruction(Instruction foundInstruction)
  {
    string sql = @"
          DELETE 
          FROM instructions
          WHERE id = @id
              ; ";

    int rowsAffected = _db.Execute(sql, foundInstruction);
    if (rowsAffected == 0)
    {
      throw new Exception("Unable to delete ingredient");
    }



  }

}