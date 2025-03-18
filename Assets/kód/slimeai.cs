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
                // Standardní chování
                break;
            case SlimeType.Tank:
                // Tankovací chování
                break;
            case SlimeType.Healer:
                // Healer chování
                break;
            case SlimeType.Ranger:
                // Ranger chování
                break;
        }
    }
}
