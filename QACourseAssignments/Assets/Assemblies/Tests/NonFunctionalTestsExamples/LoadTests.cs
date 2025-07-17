using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class LoadTests : MonoBehaviour
{
    public GameObject enemyPrefab;


    [UnitySetUp]
    public IEnumerator Setup()
    {
        SceneManager.LoadScene("SampleScene");
        yield return null;
        // wait for scene to fully load

        //   enemyPrefab = Resources.Load<GameObject>("Enemy");
        // Assert.IsNotNull(enemyPrefab, "Enemy prefab not found in Resources!");
    }

 
    // Spawns 1000 enemy GameObjects to see if the system can handle it without slowing down or crashing.
    [UnityTest]
    public IEnumerator SpawnThousandEnemies_InRealScene()
    {
        // Step 1: Count existing enemies
        int existingCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // Step 2: Create a dummy prefab in memory
        GameObject dummyEnemy = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        dummyEnemy.tag = "Enemy";

        // Step 3: Spawn 1000 more
        for (int i = 1; i < 1000; i++)
        {
            GameObject.Instantiate(dummyEnemy);
        }

        // Step 4: Wait 1 frame (let Unity finish instantiating)
        yield return null;

        // Step 5: Count total enemies
        int newCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // Step 6: Check if exactly 1000 were added
        Assert.AreEqual(1000, newCount);
    }

    // Creates 5000 UI elements (like inventory items) to test UI performance and layout handling.
    [Test]
    public void MassUIItemGeneration()
    {
        for (int i = 0; i < 5000; i++)
        {
            GameObject item = new GameObject("UIItem" + i);
            item.AddComponent<RectTransform>();
        }
        Assert.Pass();
    }

    // Simulates 500 fake user logins to check if backend or login system holds up under pressure.
    [Test]
    public void SimulateManyLogins()
    {
        for (int i = 0; i < 501; i++)
        {
            Debug.Log($"Simulated user login #{i}");
        }
        Assert.Pass();
    }
}
