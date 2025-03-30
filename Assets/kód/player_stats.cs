using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int strength;      // Síla
    public int agility;       // Obratnost
    public int intelligence;  // Inteligence
    public int luck;          // Štìstí
    public int charisma;      // Charisma (nové)
    public int endurance;     // Odolnost (nové)

    // Aktualizace statù
    public void UpdateLuck(int amount)
    {
        luck += amount;
    }

    public int GetLuck()
    {
        return luck;
    }

    public void UpdateCharisma(int amount)
    {
        charisma += amount;
    }

    public int GetCharisma()
    {
        return charisma;
    }

    public void UpdateEndurance(int amount)
    {
        endurance += amount;
    }

    public int GetEndurance()
    {
        return endurance;
    }
}
