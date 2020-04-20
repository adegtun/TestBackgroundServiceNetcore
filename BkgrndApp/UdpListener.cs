using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BkgrndApp
{
    public class UdpListener : BackgroundService
    {
        private UdpClient client;
        private readonly IMemoryCache memoryCache;

        public UdpListener(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            client = new UdpClient(9000);
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var result = await client.ReceiveAsync();
                    var message = Encoding.ASCII.GetString(result.Buffer);
                    memoryCache.Set("UdpMessage", message);
                }
                catch (Exception ex)
                {
                    await Task.Delay(TimeSpan.FromSeconds(3), stoppingToken);
                }
            }
        }

        public override void Dispose()
        {
            if(client != null)
            {
                client.Dispose();
            }
            base.Dispose(); 
        }
    }
}
