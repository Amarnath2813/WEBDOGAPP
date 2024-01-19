using Microsoft.AspNetCore.Mvc;

namespace EXAMAPPLICATION.Models
{
    public interface IDOGREPOSITRY
    {
        Task<ActionResult<DOG>?> GetDOG(int Id);
        Task<ActionResult<IEnumerable<DOG>>> GetAllDOG();
        Task<ActionResult<DOG>> Add(DOG DOG);
        Task<DOG> Update(int id, DOG DOGChanges);
        Task<DOG> Delete(int Id);
    }
}
