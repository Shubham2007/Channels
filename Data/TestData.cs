using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ChannelDemo.Data
{
    public class TestData : ITestData
    {
        private IList<int> data = new List<int>();
        private IList<string> dataB = new List<string>();
        private readonly Channel<string> _channel;

        public TestData(Channel<string> channel)
        {
            _channel = channel;
        }

        public async Task GetData()
        {
            while(!_channel.Reader.Completion.IsCompleted)
            {
                Task<int> t = Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(3000);
                    Random random = new Random();
                    return random.Next();
                });

                data.Add(await t);
            }            
        }

        public async Task GetDataB()
        {
            while (!_channel.Reader.Completion.IsCompleted)
            {
                string id = await _channel.Reader.ReadAsync();
                Task<int> t = Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(3000);
                    Random random = new Random();
                    return random.Next();
                });

                dataB.Add(id + " - " + Convert.ToString(await t));
            }
        }
    }
}
