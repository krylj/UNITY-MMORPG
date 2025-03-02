using UnityEngine;

// Tento skript musí dìdit od MonoBehaviour, aby jej bylo možno použít s Object.FindObjectOfType<T>()
public class CraftingManager : MonoBehaviour
{
    // Pøidáme nìjakou ukázkovou promìnnou nebo metodu, abychom vidìli, že skript funguje.
    public string managerName = "Default Crafting Manager";

    public void PrintManagerName()
    {
        Debug.Log("CraftingManager: " + managerName);
    }
}

// Tento skript simuluje NPC, které pøi startu hledá CraftingManager ve scénì.
public class NPCCrafting : MonoBehaviour
{
    private CraftingManager craftingManager;

    void Start()
    {
        // Použijeme Object.FindObjectOfType<T>(), abychom našli instanci CraftingManager ve scénì
        craftingManager = Object.FindObjectOfType<CraftingManager>();

        if (craftingManager != null)
        {
            Debug.Log("CraftingManager nalezen!");
            craftingManager.PrintManagerName();
        }
        else
        {
            Debug.LogError("CraftingManager nebyl nalezen! Ujistìte se, že je pøidán jako komponenta na nìjaký GameObject ve scénì.");
        }
    }
}
