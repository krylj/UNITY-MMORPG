using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CraftingUI : MonoBehaviour
{
    public GameObject craftingUI;
    public Text recipeListText;
    public Button craftButton;
    public Slider luckSlider; // Luck pro ovlivnìní úspìšnosti craftingu

    private List<string> learnedRecipes = new List<string>(); // Seznam nauèených receptù

    void Start()
    {
        craftButton.onClick.AddListener(CraftItem);
    }

    public void OpenCraftingMenu()
    {
        craftingUI.SetActive(true);
        UpdateRecipeList();
    }

    void CraftItem()
    {
        // Implementuj crafting logiku
        int luck = (int)luckSlider.value;
        bool success = CraftSuccess(luck);
        if (success)
        {
            // Crafting byl úspìšný, pøidej pøedmìt
            Debug.Log("Crafting successful!");
        }
        else
        {
            // Crafting neúspìšný, ztráta materiálu
            Debug.Log("Crafting failed.");
        }
    }

    void UpdateRecipeList()
    {
        recipeListText.text = "Known Recipes:\n";
        foreach (var recipe in learnedRecipes)
        {
            recipeListText.text += recipe + "\n";
        }
    }

    bool CraftSuccess(int luck)
    {
        // Luck ovlivòuje šanci na úspìch
        return Random.Range(0, 100) < (luck + 10); // Luck + 10 šance na úspìch
    }
}
