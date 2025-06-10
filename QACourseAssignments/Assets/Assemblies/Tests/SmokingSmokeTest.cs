using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
public class SmokingSmokeTest
{
    GameObject player;
    GameObject torch;

    [SetUp]

    public void SetupScene()
    {
        SceneManager.LoadScene("MainScene");
       player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
       torch = GameObject.CreatePrimitive(PrimitiveType.Cube);

        player.AddComponent<PlayerTorchInteractor>();
        torch.AddComponent<Torch>();
    }

    [Test]
    public void SmokeTest()
    {
        PlayerTorchInteractor playerComp = player.GetComponent<PlayerTorchInteractor>();
        Torch torchComp = torch.GetComponent<Torch>();
        Assert.IsTrue( playerComp && torchComp);
    }
}
