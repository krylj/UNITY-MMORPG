using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class XPManager : NetworkBehaviour 
{ 
    public int currentXP = 0;  // Aktuální XP hráèe 
    public int maxXP = 100; // Maximální XP pro aktuální level     
    public int level = 1; // Aktuální level hráèe
    public void AddXP(int amount) 
    { 
        currentXP += amount; // Pøidání XP // Kontrola, zda hráè získal dostatek XP pro další level 
        while (currentXP >= maxXP) { LevelUp(); // Zvyšení levelu
        }
    } 
    private void LevelUp() 
    { 
        currentXP -= maxXP; // Odeèti potøebné XP (pøebytek zùstává) 
        level++;    // Zvyšení levelu 
        Debug.Log($"Level Up! Nový level: {level}");    // Zvýšení požadavku na XP pro další level
        if (level < 10) 
        {
            maxXP += 50; // Levely 1-9: každé navýšení +50 XP
        }
        else 
        { 
            maxXP += 200; // Level 10 a vyšší:
        }
    }
}