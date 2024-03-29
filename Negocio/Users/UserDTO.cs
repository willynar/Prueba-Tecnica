﻿using DataAcces.DataSixdegreesit;
using Entities.Services;
using Entities.Users;
using System.Collections.Generic;
using System.Linq;

namespace Busines.Users
{
    public class UserDTO : IUserService
    {
        private PruebaSDContext Context;

        public UserDTO(PruebaSDContext Context)
        {
            this.Context = Context;
        }

        public List<EUsers> Consulta() => Context.Usuario.Select(x =>
                                                        new EUsers
                                                        {
                                                            Id = x.UsuId,
                                                            Nombre = x.Nombre,
                                                            Apellido = x.Apellido
                                                        }).ToList();
    }
}
