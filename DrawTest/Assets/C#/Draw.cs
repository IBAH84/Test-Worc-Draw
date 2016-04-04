using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Draw : MonoBehaviour {

    [SerializeField] private LineRenderer _line;
    private Vector3 _mousePos;
    public bool activDraw;
    public int pointCount;

    private void Start()
    {
        _line.SetVertexCount(0);
        _line.SetWidth(0.1f, 0.1f);
        pointCount = 2;
        activDraw = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (activDraw)
            {
                Start();
            }
        }
        if (activDraw)
        {
           
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _mousePos.z = 0;
            _line.SetVertexCount(pointCount);
            _line.SetPosition(0, transform.position);
            _line.SetPosition(pointCount-1, _mousePos);
        }
    }
    public void SecurePosition(Vector2 pos)
    {
        if (activDraw)
        {
            _line.SetPosition(pointCount - 1, pos);
            pointCount++;
        }
    }
}
