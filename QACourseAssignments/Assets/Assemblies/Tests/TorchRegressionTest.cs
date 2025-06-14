using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TorchRegressionTest
{
    GameObject torch;

    [SetUp]
    public void SetUpRegression()
    {
        torch = GameObject.CreatePrimitive(PrimitiveType.Cube);
        torch.AddComponent<Torch>();
    }

    [UnityTest]

    public  IEnumerator CheckLitBugFixed()
    {
        torch.GetComponent<Torch>().LightUp();

       yield return new WaitForSeconds(1f);

        Assert.IsTrue(torch.GetComponent<Torch>().rend.sharedMaterial.color == Color.yellow);
    }
}
