using System.Threading.Tasks;

namespace ChannelDemo.Services
{
    public interface ITest
    {
        Task BackgroudTask();
        Task BackgroudTaskB();
    }
}
