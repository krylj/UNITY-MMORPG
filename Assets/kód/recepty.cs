using System.Collections;
using System.Collections.Generic;  // Pro List<>
using UnityEngine;  // Pro MonoBehaviour, Debug

public class RecipeDiscovery : MonoBehaviour
{
    public List<RecipeFragment> recipeFragments; // Fragmenty receptù, které hráè nalezl

    public void CombineFragments()
    {
        bool isComplete = CheckFragmentsForCompletion();
        if (isComplete)
        {
            UnlockRecipe();
        }
        else
        {
            Debug.Log("Recipe is incomplete, keep looking for more fragments.");
        }
    }

    bool CheckFragmentsForCompletion()
    {
        // Zkontroluj, zda fragmenty tvoøí kompletní recept
        return recipeFragments.Count >= 3; // Napøíklad 3 fragmenty pro jeden recept
    }

    void UnlockRecipe()
    {
        Debug.Log("New recipe unlocked!");
        // Zde pøidej nový recept do inventáøe
    }
}
