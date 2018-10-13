using NHibernate;
using System;
using System.Reflection;

namespace DataAccess
{
    public class Context : IDisposable
    {
        private static ISessionFactory _sessionFactory;
        private static ISession _session;

        private static string GetConectionString()
        {
            return "Data Source=" + Configuration.Server +
                   ";Initial Catalog=" + Configuration.Database +
                   ";User ID=" + Configuration.User +
                   ";Password=" + Configuration.Password +
                   ";Connection Timeout=" + Configuration.Timeout;
        }

        public static ISession Session
        {
            get { return OpenSession(); }
        }

        private static ISession OpenSession()
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
            Session.Close();
            Session.Dispose();
            _sessionFactory = null;
        }
    }
}
