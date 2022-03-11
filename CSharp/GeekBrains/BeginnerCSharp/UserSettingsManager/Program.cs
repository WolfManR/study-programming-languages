using System.Configuration;

using UserSettingsManager;

using static System.Console;

var config = ConfigurationManager.OpenMappedExeConfiguration(
    new() { ExeConfigFilename = "App.config" },
    ConfigurationUserLevel.None);

var userInfo = config.GetSection(nameof(UserInfo)) as UserInfo;
var welcome = string.IsNullOrEmpty(userInfo?.Name)
    ? config.AppSettings.Settings["Welcome"].Value
    : $"Welcome {userInfo}";

WriteLine(welcome);

WriteLine("Enter new name");
var name = ReadLine();
WriteLine("Enter new Age");
var age = ReadLine().AsSpan();
if (!int.TryParse(age, out var ageNumber))
{
    WriteLine("Incorrect number");
    return;
}
WriteLine("Enter new career");
var career = ReadLine();

userInfo ??= new();
userInfo.Name = name;
userInfo.Age = ageNumber;
userInfo.Career = career;

config.Save(ConfigurationSaveMode.Minimal);

// for check that values changes
// ConfigurationManager.RefreshSection(nameof(userInfo));
// var result = config.GetSection(nameof(UserInfo));