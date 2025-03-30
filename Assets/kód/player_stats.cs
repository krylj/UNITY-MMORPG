using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int strength;      // S�la
    public int agility;       // Obratnost
    public int intelligence;  // Inteligence
    public int luck;          // �t�st�
    public int charisma;      // Charisma (nov�)
    public int endurance;     // Odolnost (nov�)

    // Aktualizace stat�
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
