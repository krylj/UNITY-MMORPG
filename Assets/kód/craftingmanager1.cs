using UnityEngine;
using System.Collections.Generic;

public class CraftingManager2 : MonoBehaviour
{
    public PlayerStats playerStats;
    public List<Recipe> availableRecipes; // Používá existující Recipe

    public void CraftItem(Recipe recipe)
    {
        if (HasRequiredItems(recipe))
        {
            float successChance = CalculateCraftingChance(recipe);
            bool success = Random.Range(0f, 1f) <= successChance;

            if (success)
            {
                Item craftedItem = new Item(recipe.itemName, "Masterpiece");
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
        return true; // Placeholder
    }

    private float CalculateCraftingChance(Recipe recipe)
    {
        if (playerStats == null)
        {
            Debug.LogError("PlayerStats is not assigned!");
            return 0.5f;
        }
        return 0.5f + (playerStats.GetLuck() * 0.01f);
    }
}

// Definice Item, pokud ještì neexistuje
public class Item
{
    public string itemName;
    public string quality;

    public Item(string name, string quality)
    {
        this.itemName = name;
        this.quality = quality;
    }
}
