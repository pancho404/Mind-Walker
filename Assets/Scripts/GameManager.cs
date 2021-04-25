using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager self;
    public bool isPlaying;
    public bool isStartingGame = true;
    public bool firstSceneFadeOut, whiteLogoFadedIn;

    public UnityEngine.UI.Image whiteLogo;
    public UnityEngine.UI.Image firstPanelFadeOut;
    // Start is called before the first frame update
    void Start()
    {
        isStartingGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (whiteLogo.color.a < 1f && !AudioManager.self.isCrashCarSoundPlaying)
        {
            whiteLogo.color = new Color(255f, 255f, 255f, whiteLogo.color.a + Time.deltaTime * 0.2f);
        }
        else
        {
            whiteLogoFadedIn = true;
        }
        if (whiteLogoFadedIn && firstPanelFadeOut.color.a > 0)
        {
            firstPanelFadeOut.color = new Color(0, 0, 0, firstPanelFadeOut.color.a - Time.deltaTime * 0.2f);
            whiteLogo.color = new Color(255f, 255f, 255f, whiteLogo.color.a - Time.deltaTime * 0.2f);
        }
    }
}
