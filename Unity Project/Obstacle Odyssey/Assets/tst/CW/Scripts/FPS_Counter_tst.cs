using UnityEngine;
using UnityEngine.UI;

public class FPS_Counter_tst : MonoBehaviour
{
    public static int avgFrameRate;
    public Text display_Text;

    public void FixedUpdate()
    {
        float current = 60;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        display_Text.text = avgFrameRate.ToString() + " FPS";
    }
}
