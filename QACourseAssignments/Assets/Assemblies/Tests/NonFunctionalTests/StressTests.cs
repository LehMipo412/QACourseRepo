using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class StressTests : MonoBehaviour
{
    // Loads the same scene 30 times in a loop to test for memory leaks or crashes from frequent scene switches.
    [UnityTest]
    public IEnumerator RepeatSceneReload()
    {
        for (int i = 0; i < 30; i++)
        {
            yield return SceneManager.LoadSceneAsync("SampleScene");
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Creates and immediately destroys 1000 GameObjects to see if Unity handles fast object churn without issues.
    [Test]
    public void CreateAndDestroyRapidly()
    {
        for (int i = 0; i < 1000; i++)
        {
            var go = new GameObject("Temp");
            GameObject.DestroyImmediate(go);
        }
        Assert.Pass();
    }

    //Drops 1000 heavy spheres on top of each other to stress-test the physics engine.

    [Test]
    public void PhysicsCollisionStorm()
    {
        for (int i = 0; i < 1000; i++)
        {
            var obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            obj.AddComponent<Rigidbody>().mass = 1000;
            obj.transform.position = new Vector3(0, i * 1.1f, 0);
        }
        Assert.Pass();
    }
}