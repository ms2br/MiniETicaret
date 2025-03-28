using ETicaretAPI.Application.Repositories.Interfaces.Files;
using ETicaretAPI.Persistence.Contexts;
using ETicaretAPI.Persistence.Repositories.Implements.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.Implements.Files
{
    public class FileReadRepository : ReadRepository<Domain.Entities.File>,
        IFileReadRepository
    {
        public FileReadRepository(PostgreSQLDbContext pdb) : base(pdb)
        {
        }
    }
}
