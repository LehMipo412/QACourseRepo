using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TorchIsLitCheck
{

    GameObject myTorch;

    [SetUp]
    public void SetUpTorch()
    {
        myTorch = GameObject.CreatePrimitive(PrimitiveType.Cube);
        myTorch.AddComponent<Torch>();
        myTorch.GetComponent<Renderer>().material.color = Color.black;
    }

    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator TorchIsLitCheckSimplePasses()
    {
        
        myTorch.GetComponent<Torch>().LightUp();
        Debug.LogWarning("LIGHT UP");

        yield return null;
        Assert.IsTrue(myTorch.GetComponent<Torch>().isLit);
    }

    
    [UnityTest]
    public IEnumerator TorchIsLitCheckWithEnumeratorPasses()
    {
        myTorch.GetComponent<Torch>().isLit = true;
        myTorch.GetComponent<Torch>().UpdateVisual();


        yield return null;
        Assert.IsTrue(myTorch.GetComponent<Torch>().rend.sharedMaterial.color == myTorch.GetComponent<Torch>().litColor);
    }

   
}
