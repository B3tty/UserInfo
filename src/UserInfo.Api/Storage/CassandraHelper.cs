using System;
using System.IO;
using Cassandra;

namespace UserInfo.Storage
{
    public class CassandraHelper
    {
        private readonly ISession _session;

        public CassandraHelper(string host, string scriptFile)
        {
            _session = BuildSession(host);
            InitWithScript(scriptFile);
        }


        public static ISession BuildSession(string host)
        {
            var cluster = Cluster.Builder()
                .AddContactPoint(host)
                .Build();

            return cluster.Connect();
        }

        private void InitWithScript(string scriptFile)
        {
            foreach (var script in File.ReadAllText(scriptFile)
                .Replace("\n", string.Empty)
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                _session.Execute(script);
            }
        }
    }
}
