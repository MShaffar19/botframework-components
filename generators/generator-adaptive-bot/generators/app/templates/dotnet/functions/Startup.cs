﻿using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Bot.Builder.Runtime.Extensions;

[assembly: FunctionsStartup(typeof(<%= botName %>.Startup))]

namespace <%= botName %>
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddBotRuntime(builder.GetContext().Configuration);
        }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder configurationBuilder)
        {
            string applicationRoot = configurationBuilder.GetContext().ApplicationRootPath;
            string settingsDirectory = <%- settingsDirectory %>;
            bool isDevelopment = string.Equals(
                configurationBuilder.GetContext().EnvironmentName,
                Microsoft.Extensions.Hosting.Environments.Development,
                StringComparison.OrdinalIgnoreCase);

            configurationBuilder.ConfigurationBuilder.AddBotRuntimeConfiguration(
                applicationRoot,
                settingsDirectory,
                isDevelopment);
        }
    }
}
