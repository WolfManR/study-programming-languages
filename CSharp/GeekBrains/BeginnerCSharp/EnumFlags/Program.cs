using static DayOfWeekFlag;
using static System.Console;

const DayOfWeekFlag office1WorkDaysMask = Tuesday |
                                          Wednesday |
                                          Thursday |
                                          Friday;

const DayOfWeekFlag office2WorkDaysMask = Monday |
                                      Tuesday |
                                      Wednesday |
                                      Thursday |
                                      Friday |
                                      Saturday;

WriteLine("Please input your work days, splitting it's with ','");
var input = ReadLine();

// mask only for debug
var mask = Enum.TryParse(input, out DayOfWeekFlag days);

var userWorkday = (DayOfWeekFlag)0b_0111000;
if (mask) userWorkday = days;

var userOffice1WorkDays = userWorkday & office1WorkDaysMask;
var userOffice2WorkDays = userWorkday & office2WorkDaysMask;

if (userOffice2WorkDays == office2WorkDaysMask)
    WriteLine("Work in Office 2");
else if (userOffice1WorkDays == office1WorkDaysMask)
    WriteLine("Work in Office 1");
else
    WriteLine("Work somewhere else");

[Flags]
internal enum DayOfWeekFlag
{
    Monday = 0b_0000001,
    Tuesday = 0b_0000010,
    Wednesday = 0b_0000100,
    Thursday = 0b_0001000,
    Friday = 0b_0010000,
    Saturday = 0b_0100000,
    Sunday = 0b_1000000
}