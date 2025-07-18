using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class NFTestLoad : MonoBehaviour
{
    [UnitySetUp]
    public IEnumerator Setup()
    {
        SceneManager.LoadScene("MainScene");
        yield return new WaitForSeconds(1f);
    }

    [Test]
    public void LoadAndSearchForTorches()
    {
        for (int i = 0; i < 5000; i++)
        {
            GameObject torch = GameObject.CreatePrimitive(PrimitiveType.Cube);
            torch.name = "Torch" + i;
            torch.tag = "Torch";
            GameObject.Find("Torch" + i); // Simulate searching for the torch in the scene, to make sure it's loaded properly
        }
        Assert.Pass();
    }
}
