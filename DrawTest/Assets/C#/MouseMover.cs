using UnityEngine;
using System.Collections;

public class MouseMover : MonoBehaviour {

    [SerializeField] private ParticleSystem _partical;
    Vector3 _mousePos;

    private void Start()
    {
        _partical.Stop();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _partical.Play();
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _mousePos.z = 0;
            transform.position = _mousePos;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _partical.Stop();
        }
    }


}
