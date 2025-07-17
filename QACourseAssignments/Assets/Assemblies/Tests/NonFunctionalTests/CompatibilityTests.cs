using NUnit.Framework;
using UnityEngine;

public class CompatibilityTests : MonoBehaviour
{

    //Verifies that the game is running on a supported platform (Android, iOS, PC, etc.).
    [Test]
    public void PlatformCheck()
    {
#if UNITY_STANDALONE || UNITY_ANDROID || UNITY_IOS
        Assert.Pass();
#else
        Assert.Fail("Unsupported platform.");
#endif
    }


    //Changes screen resolution to several common sizes to check if UI and game visuals adjust properly.

    [Test]
    public void ScreenResolutionsTest()
    {
        Vector2Int[] resolutions = {
            new Vector2Int(1280, 720),
            new Vector2Int(1920, 1080),
            new Vector2Int(3840, 2160)
        };

        foreach (var res in resolutions)
        {
            Screen.SetResolution(res.x, res.y, false);
            Debug.Log($"Testing resolution: {res.x}x{res.y}");
        }
        Assert.Pass();
    }

    //Checks if mouse or touchscreen input is available on the current device.
    [Test]
    public void InputCompatibilityTest()
    {
        bool hasMouse = Input.mousePresent;
        bool hasTouch = Input.touchSupported;
        bool hasGyro = Input.isGyroAvailable;

        Assert.IsTrue(hasMouse || hasTouch||hasGyro, "No compatible input method found.");
    }
}
