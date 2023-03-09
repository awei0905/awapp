using FluentValidation;

namespace ProductCatalog.Models.Validators;

public static class CustomValidators
{
    public static IRuleBuilder<T, string> ValidateUri<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        // 參考此網站的 URL Regex 表達式
        // https://uibakery.io/regex-library/url-regex-csharp
        var options = ruleBuilder
        .Matches("^https?:\\/\\/(?:www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b(?:[-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)$")
        .WithMessage("不正確的 URL。");

        return options;
    }
}