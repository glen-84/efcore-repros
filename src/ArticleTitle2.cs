namespace Api;

public sealed class ArticleTitle2 : ValueObject
{
    public string Value { get; }

    private ArticleTitle2(string title)
    {
        this.Value = title;
    }

    public static ArticleTitle2 From(string title)
    {
        return new ArticleTitle2(title);
    }

    public static bool operator ==(ArticleTitle2 one, string two)
    {
        return EqualOperator(one, two);
    }

    public static bool operator !=(ArticleTitle2 one, string two)
    {
        return NotEqualOperator(one, two);
    }

    public static bool EqualOperator(ValueObject left, string right)
    {
        if (left is null ^ right is null)
        {
            return false;
        }

        return ReferenceEquals(left, right) || (left?.Equals(right) == true);
    }

    public static bool NotEqualOperator(ValueObject left, string right)
    {
        return !EqualOperator(left, right);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
