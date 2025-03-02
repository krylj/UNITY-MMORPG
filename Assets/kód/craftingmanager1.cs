using UnityEngine;
using System.Collections.Generic;
using static UnityEditor.Progress;

public class CraftingManager2 : MonoBehaviour
{
    public PlayerStats playerStats;
    public List<Recipe> availableRecipes;

    public void CraftItem(Recipe recipe)
    {
        if (HasRequiredItems(recipe))
        {
            float successChance = CalculateCraftingChance(recipe);
            bool success = Random.Range(0f, 1f) <= successChance;

            if (success)
            {
                Item craftedItem = new Item(recipe.itemName, success ? "Masterpiece" : "Normal");
                Debug.Log("Crafted item: " + craftedItem.itemName);
            }
            else
            {
                Debug.Log("Crafting failed.");
            }
        }
    }

    private bool HasRequiredItems(Recipe recipe)
    {
        // Zkontroluj, zda má hráè všechny potøebné suroviny
        return true; // Placeholder
    }

    private float CalculateCraftingChance(Recipe recipe)
    {
        // Zohlední Luck pøi výpoètu šance na úspìch
        return 0.5f + (playerStats.GetLuck() * 0.01f);
    }
}
