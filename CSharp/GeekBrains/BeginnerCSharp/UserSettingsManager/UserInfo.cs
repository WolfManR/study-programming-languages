using System.Configuration;

namespace UserSettingsManager;

public sealed class UserInfo : SectionExtension
{
    [ConfigurationProperty(nameof(Name), DefaultValue = "", IsRequired = true)]
    public string Name
    {
        get => (string)this[nameof(Name)];
        set => SetWithThrowIfReadOnly(value);
    }

    [ConfigurationProperty(nameof(Age), DefaultValue = 0, IsRequired = true)]
    [IntegerValidator(MinValue = 0, MaxValue = 140)]
    public int Age
    {
        get => (int)this[nameof(Age)];
        set => SetWithThrowIfReadOnly(value);
    }


    [ConfigurationProperty(nameof(Career), DefaultValue = "", IsRequired = false)]
    public string Career
    {
        get => (string)this[nameof(Name)];
        set => SetWithThrowIfReadOnly(value);
    }

    public override string ToString() => $"{Name} in {Age} age ,with career of {Career}";
}