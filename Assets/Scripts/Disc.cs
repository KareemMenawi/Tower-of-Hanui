using UnityEngine;

public class Disc : MonoBehaviour
{
    public int Size;
    [SerializeField] private float _scale;

    public float Scale
    {
        get => _scale;
        set
        {
            _scale = value;
            ScaleDisc();
        }
    }

    private void ScaleDisc()
    {
        transform.localScale = new Vector3(Scale, 0.1f, Scale);
    }
}
