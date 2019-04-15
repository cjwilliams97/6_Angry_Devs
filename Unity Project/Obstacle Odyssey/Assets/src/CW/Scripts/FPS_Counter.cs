using UnityEngine;
using UnityEngine.UI;

public class FPS_Counter : MonoBehaviour
{
    public static int avgFrameRate;
    public Text display_Text;
    public GameObject FPS_Counter_obj;
    private bool IsActive;

    public void Start()
    {
        IsActive = false;
        FPS_Counter_obj.SetActive(false);
    }
    public void Update()
    {
        //FPS Counter code (stolen)
        float current = 60;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        display_Text.text = avgFrameRate.ToString() + " FPS";

        //show or hide the FPS counter (mine)
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (IsActive == false)
            {
                IsActive = true;
                FPS_Counter_obj.SetActive(true);
            }
            else
            {
                IsActive = false;
                FPS_Counter_obj.SetActive(false);
            }
        }
    }
}
