using NUnit.Framework;
using UnityEngine;

public class NFTestUsability
{
    GameObject player;

    [SetUp]
    public void Setup()
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
         go.AddComponent<PlayerTorchInteractor>();

        player = go;
    }

    [Test]
    public void TutorialCompletionTime()
    {
        float start = Time.realtimeSinceStartup;
        player.GetComponent<PlayerTorchInteractor>().LitNearbyTorches();
        float duration = Time.realtimeSinceStartup - start;

        Assert.Less(duration, 60f); // Tutorial should finish under 1 minute
    }


}
