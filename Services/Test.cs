using ChannelDemo.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ChannelDemo.Services
{
    public class Test : ITest
    {
        private readonly Channel<string> _channel;
        private readonly ITestData _testData;

        public Test(Channel<string> channel, ITestData testData)
        {
            _channel = channel;
            _testData = testData;
        }

        public async Task BackgroudTask()
        {           
            foreach(int item in Enumerable.Range(0, 5))
            {                
                await _channel.Writer.WriteAsync(item.ToString());
            }
        }

        public async Task BackgroudTaskB()
        {         
            foreach (int item in Enumerable.Range(0, 5))
            {
                await _channel.Writer.WriteAsync(item.ToString());
            }

            _ = Task.Run(() => _testData.GetDataB());
        }
    }
}
