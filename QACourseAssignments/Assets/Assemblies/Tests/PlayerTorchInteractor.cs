using UnityEngine;

public class PlayerTorchInteractor : MonoBehaviour
{
    public float interactionRange = 2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            LitNearbyTorches();
        }
    }
    public void LitNearbyTorches()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, interactionRange);
        foreach (var hit in hits)
        {
            var torch = hit.GetComponent<Torch>();
            if (torch != null && !torch.isLit)
                torch.LightUp();
        }
    }
}
