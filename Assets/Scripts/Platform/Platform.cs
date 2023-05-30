using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _width = 2f;

    public float width
    {
        get { return _width; }
        private set { _width = value; }
    }
}
