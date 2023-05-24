using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _width = 2f;

    public float width
    {
        get { return _width; }
        private set { _width = value; }
    }
}
