using NUnit.Framework;

using UnityEngine;

public class NFTestCompatibility : MonoBehaviour
{
    
    [Test]
    public void InputCompatibilityTest()
    {
        bool isMousPresent = Input.mousePresent; //check if the mouse input is available to the player
        bool isTouchSuported = Input.touchSupported; //check if the touch input is available to the player
        bool isGyroAvailable = Input.isGyroAvailable; // check if the gyro input is available to the player

        Assert.IsTrue(isMousPresent || isTouchSuported || isGyroAvailable, "At least one input is missing");
    }
}
