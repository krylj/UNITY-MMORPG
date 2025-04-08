using UnityEngine;
using TMPro;

public class MoveText : MonoBehaviour
{
    public float moveSpeed = 5f;  // Rychlost pohybu
    public float stopPositionX = 10f;  // Po dosa�en� t�to pozice text zastav� pohyb
    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>(); // nebo TextMeshPro pokud pou��v� 3D text
    }

    void Update()
    {
        // Zkontrolujeme, zda text je�t� nen� na stop pozici
        if (transform.position.x < stopPositionX)
        {
            // Pohyb textu
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            // Zastavit pohyb, kdy� je text na po�adovan� pozici
            transform.position = new Vector3(stopPositionX, transform.position.y, transform.position.z);
        }
    }
}
