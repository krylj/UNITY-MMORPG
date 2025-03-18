using System.Collections.Generic;
using UnityEngine;

public class FactionSystem : MonoBehaviour
{
    public string factionName; // N�zev frakce
    public List<string> availableRecipes; // Recepty, kter� lze z�skat od frakce

    public void GiveRewardForQuest(string questName)
    {
        // P�ed�n� odm�ny za dokon�en� �kolu
        string reward = availableRecipes[Random.Range(0, availableRecipes.Count)];
        Debug.Log($"Quest {questName} completed. Reward: {reward}");
    }
}
