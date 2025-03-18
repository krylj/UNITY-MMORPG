using UnityEngine;

// Tento skript mus� d�dit od MonoBehaviour, aby jej bylo mo�no pou��t s Object.FindObjectOfType<T>()
public class CraftingManager : MonoBehaviour
{
    // P�id�me n�jakou uk�zkovou prom�nnou nebo metodu, abychom vid�li, �e skript funguje.
    public string managerName = "Default Crafting Manager";

    public void PrintManagerName()
    {
        Debug.Log("CraftingManager: " + managerName);
    }
}

// Tento skript simuluje NPC, kter� p�i startu hled� CraftingManager ve sc�n�.
public class NPCCrafting : MonoBehaviour
{
    private CraftingManager craftingManager;

    void Start()
    {
        // Pou�ijeme Object.FindObjectOfType<T>(), abychom na�li instanci CraftingManager ve sc�n�
        craftingManager = Object.FindObjectOfType<CraftingManager>();

        if (craftingManager != null)
        {
            Debug.Log("CraftingManager nalezen!");
            craftingManager.PrintManagerName();
        }
        else
        {
            Debug.LogError("CraftingManager nebyl nalezen! Ujist�te se, �e je p�id�n jako komponenta na n�jak� GameObject ve sc�n�.");
        }
    }
}
