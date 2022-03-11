using System.Configuration;
using System.Runtime.CompilerServices;

namespace UserSettingsManager;

public class SectionExtension : ConfigurationSection
{
    protected static bool _isReadOnly;
    private new bool IsReadOnly => _isReadOnly;
    private void ThrowIfReadOnly([CallerMemberName] string propertyName = null)
    {
        if (IsReadOnly)
            throw new ConfigurationErrorsException("The property " + propertyName + " is read only.");
    }

    protected void SetWithThrowIfReadOnly<T>(T value, [CallerMemberName] string propertyName = null)
    {
        ThrowIfReadOnly(propertyName);
        this[propertyName] = value;
    }
}