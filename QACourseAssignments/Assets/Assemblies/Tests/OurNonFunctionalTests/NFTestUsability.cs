using System.Collections;
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
    public void TestTorchResponseTime()
    {
        float lightTorch = Time.realtimeSinceStartup;
        player.GetComponent<PlayerTorchInteractor>().LitNearbyTorches();
        float time = Time.realtimeSinceStartup - lightTorch;

        Assert.Less(time, 0.5f); // does it take the torch longer than 0.5s to activate?
    }
}
