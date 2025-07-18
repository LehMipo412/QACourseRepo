using Unity.PerformanceTesting;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NFTestPerformance : MonoBehaviour
{
    [UnityTest, Performance]
    public IEnumerator LagTest()
    {
        SimulateLag();
        yield return Measure.Frames().SampleGroup("FPS").WarmupCount(5).MeasurementCount(50).Run();
    }

    private void SimulateLag()
    {
        for (int i = 0; i < 100000; i++)
        {
            int x = 0;
            x++;
            x--;
        }
    }
}
