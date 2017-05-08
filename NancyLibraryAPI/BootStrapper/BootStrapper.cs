using Nancy.Bootstrappers.StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;

namespace NancyLibraryAPI.BootStrapper
{
    public class BootStrapper: StructureMapNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(IContainer existingContainer)
        {
            Container.Configure(existingContainer);
        }
    }
}