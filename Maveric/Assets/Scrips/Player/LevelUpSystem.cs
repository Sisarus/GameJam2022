using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpSystem : MonoBehaviour
{
    public List<int> energyLevels = new List<int>();

    public int GetNextLevelEnergyLevel(int playerLevel){
        return 30;
    }

}
