using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace PS.Data.Infrastructure
{
    public class DataBaseFactory : Disposable, IDataBaseFactory

    {
        public DataBaseFactory()
        {
            dataContext = new Context();
        }
        private DbContext dataContext;
        public DbContext DataContext
        {
            get { return dataContext; }
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                 dataContext.Dispose();
        }
    }

}
