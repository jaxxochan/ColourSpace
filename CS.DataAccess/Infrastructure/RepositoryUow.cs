using AuthApp.Repository;
using CS.Core.EFModel.Models;
using System;

namespace CS.Core.DataAccess.Infrastructure
{
    public interface IRepositoryUow
    {
        iRepository<T> Repository<T>() where T : class;
    }

    public class RepositoryUow : IRepositoryUow
    {
        public RepositoryUow(iRepositoryProvider repositoryProvider)
        {
            CreateDBContext();
            repositoryProvider.DbContext = DBContext;
            //repositoryProvider.DbContext.Database.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["dbConnectionTimeOut"]);
            RepositoryProvider = repositoryProvider;

        }

        protected void CreateDBContext()
        {
            DBContext = new CSAppContext();
            DBContext.Configuration.ProxyCreationEnabled = true;
            DBContext.Configuration.LazyLoadingEnabled = true;
            DBContext.Configuration.ValidateOnSaveEnabled = true;
            DBContext.Database.CommandTimeout = 80;
        }

        protected iRepositoryProvider RepositoryProvider { get; set; }

        public iRepository<T> Repository<T>() where T : class
        {
            return RepositoryProvider.Repository<T>();
        }

        private CSAppContext DBContext { get; set; }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DBContext != null)
                {
                    DBContext.Dispose();
                }
            }
        }

        #endregion
    }
}
