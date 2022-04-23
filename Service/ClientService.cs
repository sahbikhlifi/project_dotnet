using System;
using System.Collections.Generic;
using System.Text;
using ServicePattern;
using Domain.Entities;
using PS.Data.Infrastructure;

namespace Service
{
    public class ClientService : Service<Client>, IClientService
    {
        public ClientService(IUnitOfWork ui) : base(ui)
        {
        }
    }
}

