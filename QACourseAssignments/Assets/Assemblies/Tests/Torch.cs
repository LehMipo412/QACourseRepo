using UnityEngine;

public class Torch : MonoBehaviour
{
    public bool isLit = false;
    public Renderer rend ;
    public Color torchColor = Color.gray;
    public Color litColor = Color.yellow;

    void Start()
    {
        rend = GetComponent<Renderer>();
        UpdateVisual();
    }

    public void LightUp()
    {
        isLit = true;
        UpdateVisual();
    }

   public  void UpdateVisual()
    {
        
        if (rend != null)
        {
            rend.sharedMaterial.color = isLit ? litColor : torchColor;
        }
        Debug.Log("Updated visuals: " + rend.sharedMaterial.color);
    }
}
