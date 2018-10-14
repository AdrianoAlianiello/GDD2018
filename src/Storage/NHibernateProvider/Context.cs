using System;

namespace Storage
{
    public class Context : IDisposable
    {
        private static Session _session;

        public static Session Session
        {
            get { return GetSession(); }
        }

        private static Session GetSession()
        {
            if(_session == null)
                _session = new Session();
            return _session.OpenSession();
        }

        public void Dispose()
        {
            _session.Dispose();
            _session = null;
        }

    }
}
