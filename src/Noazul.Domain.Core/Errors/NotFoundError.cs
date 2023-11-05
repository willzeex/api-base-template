namespace Noazul.Domain.Core;

internal class NotFoundError : BError
{
    public NotFoundError() : base("NOT_FOUND", ErrorCodes.BAD_REQUEST)
    { }

    public NotFoundError(string code) : base("NOT_FOUND", code)
    { }
}