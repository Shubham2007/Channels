using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ChannelDemo.BackgroundServices
{
    public class DataProcessingService : BackgroundService
    {
        private readonly Channel<string> _channel;
        private readonly IList<string> data = new List<string>();

        public DataProcessingService(Channel<string> channel)
        {
            _channel = channel;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!_channel.Reader.Completion.IsCompleted)
            {
                string id = await _channel.Reader.ReadAsync();
                Task<int> t = Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(3000);
                    Random random = new Random();
                    return random.Next();
                });

                int temp = await t;
                data.Add(id.ToString() + " - " + temp);
            }
        }
    }
}
