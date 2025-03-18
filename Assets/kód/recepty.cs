using System.Collections;
using System.Collections.Generic;  // Pro List<>
using UnityEngine;  // Pro MonoBehaviour, Debug

public class RecipeDiscovery : MonoBehaviour
{
    public List<RecipeFragment> recipeFragments; // Fragmenty recept�, kter� hr�� nalezl

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
        // Zkontroluj, zda fragmenty tvo�� kompletn� recept
        return recipeFragments.Count >= 3; // Nap��klad 3 fragmenty pro jeden recept
    }

    void UnlockRecipe()
    {
        Debug.Log("New recipe unlocked!");
        // Zde p�idej nov� recept do invent��e
    }
}
