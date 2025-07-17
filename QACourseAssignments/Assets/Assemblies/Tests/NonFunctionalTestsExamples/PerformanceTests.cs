using Unity.PerformanceTesting;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PerformanceTests
{

  //  Measures how long a specific method takes to run(like an expensive calculation)
    [Test, Performance]
    public void MeasureMethodExecutionTime()
    {
        Measure.Method(() =>
        {
            ExpensiveOperation();
        })
        .SampleGroup("Method Time")
        .WarmupCount(5)
        .MeasurementCount(20)
        .Run();
    }

    //Measures and logs frame rate (FPS) over time to check if performance is smooth.
    [UnityTest, Performance]
    public IEnumerator FrameRateStabilityTest()
    {
        yield return Measure.Frames().SampleGroup("FPS").WarmupCount(10).MeasurementCount(30).Run();
    }

    // Measures how much memory is allocated during execution, useful for spotting garbage collection spikes.


    [Test, Performance]
    public void MemoryAllocationCheck()
    {
        Measure.Method(() =>
        {
            var list = new System.Collections.Generic.List<int>();
            for (int i = 0; i < 10000; i++) list.Add(i);
        }).GC().Run();
    }


    void ExpensiveOperation()
    {
        //Rigidbody.Sleep()
        for (int i = 0; i < 1000000; i++)
        {
            float x = Mathf.Sqrt(i);
        }
    }
}
