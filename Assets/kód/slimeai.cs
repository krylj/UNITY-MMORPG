using UnityEngine;

public class SlimeAI : MonoBehaviour
{
    public enum SlimeType { Normal, Tank, Healer, Ranger }
    public SlimeType slimeType;

    private void Update()
    {
        switch (slimeType)
        {
            case SlimeType.Normal:
                // Standardn� chov�n�
                break;
            case SlimeType.Tank:
                // Tankovac� chov�n�
                break;
            case SlimeType.Healer:
                // Healer chov�n�
                break;
            case SlimeType.Ranger:
                // Ranger chov�n�
                break;
        }
    }
}
