using System.Collections.Generic;
using UnityEngine;

public class FactionSystem : MonoBehaviour
{
    public string factionName; // Název frakce
    public List<string> availableRecipes; // Recepty, které lze získat od frakce

    public void GiveRewardForQuest(string questName)
    {
        // Pøedání odmìny za dokonèení úkolu
        string reward = availableRecipes[Random.Range(0, availableRecipes.Count)];
        Debug.Log($"Quest {questName} completed. Reward: {reward}");
    }
}
