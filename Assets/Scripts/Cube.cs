using UnityEngine;

public class Cube : MonoBehaviour
{
    private int _splitChance = 100;

    public int SplitChance => _splitChance;

    public void SetParameters(Color color, float scale, int splitChance)
    {
        _splitChance = splitChance;

        Vector3 newScale = transform.localScale;
        newScale *= scale;
        transform.localScale = newScale;
        
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = color;
    }
}
