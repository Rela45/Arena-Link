using UnityEngine;

public class MovingBackGround : MonoBehaviour
{
    [SerializeField] private Transform _background;
    [SerializeField] private float _speed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_background == null) return;
        _background.position = new Vector3(
            _background.position.x,
            _background.position.y - _speed * Time.deltaTime,
            _background.position.z
        );
    }
}
