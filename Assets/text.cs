using UnityEngine;
using TMPro;

public class MoveText : MonoBehaviour
{
    public float moveSpeed = 5f;  // Rychlost pohybu
    public float stopPositionX = 10f;  // Po dosažení této pozice text zastaví pohyb
    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>(); // nebo TextMeshPro pokud používáš 3D text
    }

    void Update()
    {
        // Zkontrolujeme, zda text ještì není na stop pozici
        if (transform.position.x < stopPositionX)
        {
            // Pohyb textu
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            // Zastavit pohyb, když je text na požadované pozici
            transform.position = new Vector3(stopPositionX, transform.position.y, transform.position.z);
        }
    }
}
