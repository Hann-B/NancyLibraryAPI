using StructureMap;
using StructureMap.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NancyLibraryAPI.BootStrapper
{
    public class Container
    {
        public static void Configure(IContainer container)
        {
            container.Configure(config => config.Scan(c =>
              {
                  c.TheCallingAssembly();
                  c.WithDefaultConventions();
              }));
        }
    }
}