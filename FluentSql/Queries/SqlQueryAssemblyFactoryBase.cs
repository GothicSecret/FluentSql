using System.IO;
using System.Reflection;

namespace FluentSql
{
    public class SqlQueryAssemblyFactoryBase : SqlQueryFactoryBase
    {
        protected string resourcePrefix;

        public SqlQueryAssemblyFactoryBase(Assembly assembly, string folder = null)
            : base(assembly)
        {
            if (folder == null)
            {
                resourcePrefix = $"{assembly.GetName().Name}.";
            }
            else
            {
                resourcePrefix = $"{assembly.GetName().Name}.{folder}.";
            }
        }

        public override string Get(string resourceName)
        {
            using (var stream = _assembly.GetManifestResourceStream(resourcePrefix + resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
