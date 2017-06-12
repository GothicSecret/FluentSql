using System.IO;
using System.Reflection;

namespace FluentSql
{
    public class SqlQueryFactoryBase
    {
        protected Assembly _assembly;

        public SqlQueryFactoryBase(Assembly assembly)
        {
            _assembly = assembly;
        }

        public virtual string Get(string resourceName)
        {
            using (var stream = _assembly.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
