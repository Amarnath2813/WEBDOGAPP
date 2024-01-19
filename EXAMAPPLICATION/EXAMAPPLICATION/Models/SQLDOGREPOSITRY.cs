using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EXAMAPPLICATION.Models
{
    public class SQLDOGREPOSITRY : IDOGREPOSITRY
    {
        private readonly Appdbcontext context;
        public SQLDOGREPOSITRY(Appdbcontext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<DOG>> Add(DOG DOG)
        {
            context.DOGs.Add(DOG);
            await context.SaveChangesAsync();
            return DOG;
        }

        public async Task<DOG> Delete(int Id)
        {
            DOG DOG = context.DOGs.Find(Id);
            if (DOG != null)
            {
                context.DOGs.Remove(DOG);
                await context.SaveChangesAsync();
            }
            return DOG;
        }
        public async Task<ActionResult<IEnumerable<DOG>?>> GetAllDOG()
        {
            if (context.DOGs == null)
            {
                return null;
            }
            return await context.DOGs.ToListAsync();

        }

        public async Task<ActionResult<DOG>?> GetDOG(int Id)
        {
            if (context.DOGs == null)
            {
                return null;
            }
            var DOG = await context.DOGs.FindAsync(Id);

            if (DOG == null)
            {
                return null;
            }

            return DOG;

        }

        public async Task<DOG?> Update(int id, DOG DOG)
        {
            if (id != DOG.Id)
            {
                return null;
            }

            context.Entry(DOG).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DOGExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return null;

        }
        private bool DOGExists(int id)
        {
            return (context.DOGs?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
