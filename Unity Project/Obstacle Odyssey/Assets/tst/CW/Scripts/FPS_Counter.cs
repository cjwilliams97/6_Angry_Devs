using UnityEngine;
using UnityEngine.UI;

public class FPS_Counter : MonoBehaviour
{
    public static int avgFrameRate;
    public Text display_Text;

    public void Update()
    {
        float current = 60;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        display_Text.text = avgFrameRate.ToString() + " FPS";
    }
}
