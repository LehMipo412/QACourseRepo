using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class NFTestStress : MonoBehaviour
{
    [Test]
    public void TeleportBread()
    {
        for (int i = 0; i < 3000; i++)
        {
            var bread = GameObject.CreatePrimitive(PrimitiveType.Cube);
            bread.transform.position = new Vector3(0, 0, 0);
            bread.transform.position = new Vector3(1000, 0, 0);
            bread.transform.position = new Vector3(0, 0, 0);
            bread.transform.position = new Vector3(1000, 0, 0);
            bread.transform.position = new Vector3(0, 0, 0);
            GameObject.DestroyImmediate(bread);
        }
        Assert.Pass();
    }
}
