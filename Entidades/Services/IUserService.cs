using Entities.Users;
using System.Collections.Generic;

namespace Entities.Services
{
    public interface IUserService
    {
        List<EUsers> Consulta();
    }
}
