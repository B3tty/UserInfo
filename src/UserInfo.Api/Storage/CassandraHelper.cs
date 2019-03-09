using System;
using System.IO;
using Cassandra;

namespace UserInfo.Storage
{
    public class CassandraHelper
    {
        private readonly ISession _session;

        public ISession Session => _session;


        public CassandraHelper(string host, int port, string scriptFile)
        {
            _session = BuildSession(host, port);
            InitWithScript(scriptFile);
        }

        private static ISession BuildSession(string host, int port)
        {
            var cluster = Cluster.Builder()
                .AddContactPoint(host)
                .WithPort(port)
                .Build();

            return cluster.Connect();
        }

        private void InitWithScript(string scriptFile)
        {
            foreach (var script in File.ReadAllText(scriptFile)
                .Replace("\n", string.Empty)
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                Session.Execute(script);
            }
        }
    }
}
