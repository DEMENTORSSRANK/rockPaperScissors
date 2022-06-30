using System.Threading.Tasks;
using Sources.Model.Fists;

namespace Sources.Model.Players
{
    public abstract class BasePlayer
    {
        public abstract Task<FistType> MakeChoiceAsync();
    }
}