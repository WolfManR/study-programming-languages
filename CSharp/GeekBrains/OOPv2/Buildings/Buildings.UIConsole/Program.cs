using Buildings.Core;

Building building0 = Creator.CreateBuild();
Building building1 = Creator.CreateBuild(14);
Building building2 = Creator.CreateBuild(25, 32);
Building building3 = Creator.CreateBuild(43, 45, 45);
Building building4 = Creator.CreateBuild(54, 54, 12, 23);

bool isRemoved = Creator.RemoveCachedBuildingById(building1.Id);