namespace SDD_assg2
{
    class Building
    {
        // name of buidling
        public string BuildingName { get; set; }

        // short name of buidling shown on board
        public string BuildingAcronym { get; set; }

        public Building()
        {

        }

        public Building(string buildingName, string buildingAcronym)
        {
            BuildingName = buildingName;
            BuildingAcronym = buildingAcronym;
        }
    }
}
