using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe
{
    public string itemName;            // Název výsledného předmětu
    public List<string> requiredItems; // Seznam ID nebo názvů potřebných surovin

    public Recipe(string name, List<string> items)
    {
        itemName = name;
        requiredItems = items;
    }
}
