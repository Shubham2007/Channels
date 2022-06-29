using System.Threading.Tasks;

namespace ChannelDemo.Data
{
    public interface ITestData
    {
        Task GetData();
        Task GetDataB();
    }
}
