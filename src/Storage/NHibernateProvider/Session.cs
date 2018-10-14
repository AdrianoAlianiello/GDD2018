using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Storage
{
    public class Session : IDisposable
    {
        private SessionFactory _sessionFactory;

        public Session OpenSession()
        {
            if(_sessionFactory == null)
                _sessionFactory = new SessionFactory();               
            return this;
        }
        public void Dispose()
        {
            _sessionFactory.Dispose();
            _sessionFactory = null;
        }

        public IQueryable<T> Query<T>()
        {
            return _sessionFactory.Session().Query<T>();
        }

        public T Read<T>(int id) where T: EditableEntity
        {
            return _sessionFactory.Session().Get<T>(id);
        }

        public IList<T> ReadAll<T>() where T : EditableEntity
        {
            return _sessionFactory.Session().Query<T>().ToList();
        }

        public void Flush()
        {
            _sessionFactory.Session().Flush();
        }

        public void Delete<T>(T entity) where T: EditableEntity
        {
            _sessionFactory.Session().Delete(entity);
            Flush();
        }

        public void DeleteCollection<T>(IList<T> entities) where T : EditableEntity
        {
            using (var transaction = BeginTransaction())
            {
                try
                {
                    foreach (var entity in entities)
                        _sessionFactory.Session().Delete(entity);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }

        public void SaveOrUpdate<T>(T entity) where T : EditableEntity
        {
            _sessionFactory.Session().SaveOrUpdate(entity);
            Flush();
        }

        public void SaveOrUpdateCollection<T>(IList<T> entities) where T : EditableEntity
        {
            using (var transaction = BeginTransaction())
            {
                try
                {
                    foreach (var entity in entities)
                        _sessionFactory.Session().SaveOrUpdate(entity);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }

        public ITransaction BeginTransaction()
        {
            return _sessionFactory.Session().BeginTransaction();
        }
    }
}
