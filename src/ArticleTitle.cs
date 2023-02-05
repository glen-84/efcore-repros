using Vogen;

namespace Api;

[ValueObject<string>]
public readonly partial struct ArticleTitle
{
    private static Validation Validate(string value)
        => value.Length > 0 ? Validation.Ok : Validation.Invalid("Invalid");
}
