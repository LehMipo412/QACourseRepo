using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
public class PlayerInteractionIntegrationTest
{
    public GameObject player;
    public GameObject torch;


    [SetUp]

    public void SetupForIntegration()
    {
        player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        torch = GameObject.CreatePrimitive(PrimitiveType.Cube);
        

        player.transform.position = Vector3.zero;
        torch.transform.position = new Vector3(0.5f, 0, 0);

        player.AddComponent<PlayerTorchInteractor>();
        torch.AddComponent<Torch>();
        torch.AddComponent<CapsuleCollider>();
    }

    [UnityTest]
    public IEnumerator SimulateE()
    {
        player.GetComponent<PlayerTorchInteractor>().LitNearbyTorches();

        yield return new WaitForSeconds(1);

        Assert.IsTrue(torch.GetComponent<Torch>().isLit);
        
    }
}
