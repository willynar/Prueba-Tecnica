using Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Services
{
  public  interface IUserService
    {
        List<EUsers> Consulta();
    }
}
