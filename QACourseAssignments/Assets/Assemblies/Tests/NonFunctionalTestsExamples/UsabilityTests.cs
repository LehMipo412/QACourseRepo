using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class UsabilityTests : MonoBehaviour
{
    public UnityEngine.UI.Button testButton;


    [SetUp]
    public void Setup()
    {
        GameObject go = new GameObject("TestButton");
        testButton = go.AddComponent<Button>();
    }
    //Measures how long it takes from clicking a button to when it responds (should be under 0.5s).
    [Test]
    public void ButtonClickDelay()
    {
        var start = Time.realtimeSinceStartup;
        testButton.onClick.Invoke();
        var end = Time.realtimeSinceStartup;

        Assert.Less(end - start, 0.5f);
    }

    //Logs a message when a button is clicked — useful for tracking user actions during playtesting.

    [Test]
    public void LogButtonUsage()
    {
        testButton.onClick.AddListener(() => Debug.Log("Button clicked at: " + Time.time));
        testButton.onClick.Invoke();
        Assert.Pass();
    }

    //Times how long it takes to finish the tutorial (simulated here); helps identify if it's too long or too short.
    [Test]
    public void TutorialCompletionTime()
    {
        float start = Time.realtimeSinceStartup;
        SimulateTutorial();
        float duration = Time.realtimeSinceStartup - start;

        Assert.Less(duration, 60f); // Tutorial should finish under 1 minute
    }

    void SimulateTutorial()
    {
        // Simulate tutorial logic here
    }
}

