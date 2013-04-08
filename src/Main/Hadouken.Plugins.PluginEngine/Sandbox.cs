﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Security;

namespace Hadouken.Plugins.PluginEngine
{
    public static class Sandbox
    {
        public static PluginManifest ReadManifest(IEnumerable<byte[]> assemblies)
        {
            var domain = AppDomain.CreateDomain("temp");

            var manifestReader =
                (PluginManifestReader)
                domain.CreateInstanceFromAndUnwrap(typeof (PluginManifestReader).Assembly.Location,
                                                   typeof (PluginManifestReader).FullName);

            manifestReader.Load(assemblies);

            var manifest = manifestReader.ReadManifest();

            AppDomain.Unload(domain);

            return manifest;
        }

        internal static PluginSandbox CreatePluginSandbox(PluginManifest manifest, IEnumerable<byte[]> assemblies)
        {
            var domain =
                AppDomain.CreateDomain(String.Format("{0}-{1}", manifest.Name, manifest.Version).ToLowerInvariant());


            var ps = (PluginSandbox) domain.CreateInstanceFromAndUnwrap(typeof (PluginSandbox).Assembly.Location,
                                                                        typeof (PluginSandbox).FullName);
            ps.AddAssemblies(assemblies);

            return ps;
        }
    }
}
