using Nudes.Retornator.Core;

namespace Noazul.Domain.Core;

public class BError : Error
{
    public string Message => base.Description;

    public BError()
    { }

    public BError(string name, string description) : base(name, description)
    { }
}
