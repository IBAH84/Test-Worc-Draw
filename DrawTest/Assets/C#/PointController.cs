using UnityEngine;
using System.Collections;

public class PointController : MonoBehaviour {

    public delegate void EnterAction();
    public static event EnterAction OnEnter;

    [SerializeField] private GameObject[] _neighbors;
    [SerializeField] private GameController _gameController;
    Color _color;
    public bool usedPoin;
    public bool acivPoin;
    public bool startPoint;

    private void Awake()
    {
        PointController.OnEnter += PointController_OnEnter;
    }

    private void PointController_OnEnter()
    {
       
            foreach (var item in _neighbors)
            {
                if (item.GetComponent<PointController>().usedPoin == false)
                {
                    item.GetComponent<PointController>().acivPoin = false;
                }
            }
        
    }

    private void Start()
    { 
        _color = GetComponent<Renderer>().material.color;
        usedPoin = false;
        acivPoin = false;
      }
    private void Update()
    {
       
        if (Input.GetMouseButtonUp(0))
        {
            usedPoin = false;
            acivPoin = false;
            _gameController.mousePressed = false;
        }
      
        if (acivPoin && !usedPoin)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else if (!acivPoin & !usedPoin)
        {
            GetComponent<Renderer>().material.color = _color;
        }
        else if (acivPoin && usedPoin)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else if (!acivPoin && usedPoin)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        if (_gameController.winRound)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnMouseDown()
    {
      
            usedPoin = true;
            startPoint = true;
            _gameController.mousePressed = true;
            _gameController.DrawInstantiete(transform.position);
       
        ActiveNeighbors();
    }

    private void OnMouseEnter()
    {
        if (_gameController.mousePressed)
        {

            if (!usedPoin && acivPoin)
            {
                if (OnEnter != null)
                {
                    OnEnter();
                }
             
                ActiveNeighbors();
                usedPoin = true;
                _gameController.DrawPos(transform.position);
            }
            if (startPoint)
            {
                int count = 0;
                for (int i = 0; i < _neighbors.Length; i++)
                {
                    if (_neighbors[i].GetComponent<PointController>().usedPoin)
                    {
                        count++;
                    }
                }
                if (count == _neighbors.Length)
                {
                    _gameController.DrawPos(transform.position);
                    _gameController.StopDraw();
                }
            }
        }
    }
    private void ActiveNeighbors()
    {
        foreach (var item in _neighbors)
        {
            if (!item.GetComponent<PointController>().usedPoin)
            {
                item.GetComponent<PointController>().acivPoin = true;
            }
        }
    }
    private void OnDestroy()
    {
        PointController.OnEnter -= PointController_OnEnter;
    }
}
