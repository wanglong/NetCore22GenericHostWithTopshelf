﻿using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsServiceGenericHostWithTopshelf
{
    public class TopshelfLifetime : IHostLifetime
    {
        public TopshelfLifetime(IApplicationLifetime applicationLifetime, IServiceProvider serviceProvider)
        {
            ApplicationLifetime = applicationLifetime ?? throw new ArgumentNullException(nameof(applicationLifetime));
        }

        private IApplicationLifetime ApplicationLifetime { get; }

        public Task WaitForStartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
