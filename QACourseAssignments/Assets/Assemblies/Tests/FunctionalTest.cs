using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using NUnit.Framework;


public class FunctionalTest
{
    public const string requiredSceneName = "MainScene";

    public GameObject player;
    public GameObject torch;

    [SetUp]
    public void SetUpFunctionalTest()
    {
        SceneManager.LoadScene(requiredSceneName);
        player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        torch = GameObject.CreatePrimitive(PrimitiveType.Cube);


        player.AddComponent<PlayerTorchInteractor>();
        torch.AddComponent<Torch>();
        torch.AddComponent<CapsuleCollider>();

    }

    [Test]
    public void ScenarioFunctionalTest()
    {
        IsRequiredSceneLoaded();
        CheckThatPlayerCanInteractWithATorch();
        IsSetupTorchCanBeLit();
    }

    public IEnumerator IsRequiredSceneLoaded()
    {
        yield return new WaitForSeconds(1);
        Assert.IsTrue(SceneManager.GetActiveScene().name == requiredSceneName);
    }

    public IEnumerator IsSetupTorchCanBeLit()
    {
        torch.GetComponent<Torch>().LightUp();
        yield return new WaitForSeconds(1);
        Assert.IsTrue(torch.GetComponent<Torch>().isLit);
    }

    public void CheckThatPlayerCanInteractWithATorch()
    {
        GameObject tempTorch = torch;

        player.transform.position = Vector3.zero;

        tempTorch.transform.position = new Vector3(0, 0, 0.5f);
        SimulateEPressed();

    }


    public IEnumerator SimulateEPressed()
    {
        player.GetComponent<PlayerTorchInteractor>().LitNearbyTorches();

        yield return new WaitForSeconds(1);

        Assert.IsTrue(torch.GetComponent<Torch>().isLit);

    }
}
