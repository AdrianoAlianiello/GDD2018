using NHibernate;
using Support;
using System;
using System.Reflection;

namespace Storage
{
    internal class SessionFactory : IDisposable
    {
        private ISessionFactory _sessionFactory;
        private ISession _session;
        private string GetConectionString()
        {
            return "Data Source=" + Configuration.Server +
                   ";Initial Catalog=" + Configuration.Database +
                   ";User ID=" + Configuration.User +
                   ";Password=" + Configuration.Password +
                   ";Connection Timeout=" + Configuration.Timeout;
        }

        internal ISession Session()
        {
            if (_sessionFactory == null)
            {
                var configuration = new NHibernate.Cfg.Configuration();
                configuration.SetProperty(NHibernate.Cfg.Environment.ProxyFactoryFactoryClass,
                        typeof(NHibernate.Bytecode.DefaultProxyFactoryFactory).AssemblyQualifiedName);
                configuration.SetProperty(
                  NHibernate.Cfg.Environment.Dialect,
                  typeof(NHibernate.Dialect.MsSql2012Dialect).AssemblyQualifiedName);
                configuration.SetProperty(
                  NHibernate.Cfg.Environment.ConnectionString, GetConectionString());
                configuration.SetProperty(
                  NHibernate.Cfg.Environment.FormatSql, "true");
                configuration.AddAssembly(Assembly.GetCallingAssembly());
                _sessionFactory = configuration.BuildSessionFactory();
                _session = _sessionFactory.OpenSession();
            }
            return _session;
        }
        public void Dispose()
        {
            _session.Close();
            _session.Dispose();
            _sessionFactory = null;
        }

    }
}
