using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class XPManager : NetworkBehaviour 
{ 
    public int currentXP = 0;  // Aktu�ln� XP hr��e 
    public int maxXP = 100; // Maxim�ln� XP pro aktu�ln� level     
    public int level = 1; // Aktu�ln� level hr��e
    public void AddXP(int amount) 
    { 
        currentXP += amount; // P�id�n� XP // Kontrola, zda hr�� z�skal dostatek XP pro dal�� level 
        while (currentXP >= maxXP) { LevelUp(); // Zvy�en� levelu
        }
    } 
    private void LevelUp() 
    { 
        currentXP -= maxXP; // Ode�ti pot�ebn� XP (p�ebytek z�st�v�) 
        level++;    // Zvy�en� levelu 
        Debug.Log($"Level Up! Nov� level: {level}");    // Zv��en� po�adavku na XP pro dal�� level
        if (level < 10) 
        {
            maxXP += 50; // Levely 1-9: ka�d� nav��en� +50 XP
        }
        else 
        { 
            maxXP += 200; // Level 10 a vy���:
        }
    }
}