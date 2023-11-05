namespace Noazul.Domain.Core;

public class BadRequestError : BError
{
    public BadRequestError() : base("BAD_REQUEST", ErrorCodes.BAD_REQUEST)
    { }

    public BadRequestError(string code) : base("BAD_REQUEST", code)
    { }
}
