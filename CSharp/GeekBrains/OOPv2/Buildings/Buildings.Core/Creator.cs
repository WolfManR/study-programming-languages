using System.Collections;

namespace Buildings.Core;

public static class Creator
{
    private static readonly Hashtable Buildings = new();

    public static Building CreateBuild() => CreateBuild(0);
    public static Building CreateBuild(double height) => CreateBuild(height, 0);
    public static Building CreateBuild(double height, int countOfStoreys) => CreateBuild(height, countOfStoreys, 0);
    public static Building CreateBuild(double height, int countOfStoreys, int countOfEntrances) => CreateBuild(height, countOfStoreys, countOfEntrances, 0);
    public static Building CreateBuild(double height, int countOfStoreys, int countOfEntrances, int countOfApartments)
    {
        Building building = new()
        {
            Height = height,
            NumberOfStoreys = countOfStoreys,
            CountOfApartments = countOfApartments,
            CountOfEntrances = countOfEntrances
        };

        Buildings.Add(building.Id, building);

        return building;
    }

    public static bool RemoveCachedBuildingById(int id)
    {
        if (!Buildings.ContainsKey(id)) return false;
        Buildings.Remove(id);
        return true;
    }
}