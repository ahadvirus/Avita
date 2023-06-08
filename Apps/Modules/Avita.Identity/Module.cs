using Avita.Commons.Contracts;

namespace Avita.Identity;

public class Module : IModule
{
    public string Name
    {
        get
        {
            return nameof(Identity);
        }
    }
}
