using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TorchIsLitCheck
{

    GameObject torch;
    // A Test behaves as an ordinary method
    [Test]
    public void TorchIsLitCheckSimplePasses()
    {
        torch.GetComponent<Torch>().LightUp();
        Assert.IsTrue(torch.GetComponent<Torch>().isLit);
    }

    //[Test]
    //public void CheckChangeVisuals()
    //{

    //    torch.GetComponent<Torch>().LightUp();
    //    Assert.IsTrue(torch.GetComponent<Torch>().rend.sharedMaterial.color == torch.GetComponent<Torch>().litColor);
    //}
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TorchIsLitCheckWithEnumeratorPasses()
    {
        torch.GetComponent<Torch>().isLit = true;
        torch.GetComponent<Torch>().UpdateVisual();


        yield return null;
        Assert.IsTrue(torch.GetComponent<Torch>().rend.sharedMaterial.color == torch.GetComponent<Torch>().litColor);
    }

    [SetUp]
    public void SetUpTorch()
    {
        torch = GameObject.CreatePrimitive(PrimitiveType.Cube);
        torch.AddComponent<Torch>();
        torch.GetComponent<Renderer>().material.color = Color.black;
    }
}
