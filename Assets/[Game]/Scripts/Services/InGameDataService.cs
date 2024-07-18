using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InGameDataService
{
    private List<BuildingData> _buildingsData;

    public InGameDataService()
    {
        _buildingsData = new();
    }

    public List<BuildingData> GetAllBuildingData()
    {
        if (_buildingsData.Any())
            return _buildingsData;

        return _buildingsData = Resources.LoadAll<BuildingData>(GlobalVariables.BUILDINGS_DATA_RESOURCE_PATH).ToList();
    }
}
