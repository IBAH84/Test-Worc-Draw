using UnityEngine;
using System.Collections;


public class GameController : MonoBehaviour {

    [SerializeField] private GameObject _drawObgect;
    [SerializeField] private GameObject _youWin;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private GameObject[] _figure;
    [SerializeField] private TextMesh _timerText;
    [SerializeField] private TextMesh _countText;
    [SerializeField] private GameObject _next;
    private Menenger _menenger;
    string _textLevel = "";
    public bool winRound;
    public bool mousePressed;
    public float timer;
    public int figureIndex;


    private void Start()
    {
    
        _menenger = FindObjectOfType<Menenger>();
        if (_menenger.countLevel == 7)
        {
            _menenger.Restart();
        }
        _textLevel = "Level " + _menenger.countLevel.ToString();
        _countText.text =  _textLevel;
        figureIndex = _menenger.countLevel;
        winRound = false;
        mousePressed = false;
        _youWin.SetActive(false);
        _gameOver.SetActive(false);
        _next.SetActive(false);
        foreach (var item in _figure)
        {
            item.SetActive(false);
        }
       
        _figure[figureIndex].SetActive(true);
        timer = _menenger.timerStart;
        
    }
    private void Update()
    {
        if (timer > 0 && !winRound)
        {
            timer -= Time.deltaTime * 100;
            _timerText.color = Color.green;
        }
       
            _timerText.text = timer.ToString("000");
       
        if (timer <= 0)
        {
            timer = 0;
            _timerText.color = Color.red;
            _gameOver.SetActive(true);
            _figure[figureIndex].SetActive(false);
            _drawObgect.SetActive(false);
            StartCoroutine(ReturnStart());
        }
    }

    public void DrawInstantiete(Vector2 pos)
    {
    
        _drawObgect.transform.position = pos;
        _drawObgect.GetComponent<Draw>().activDraw = true;
    }
    public void DrawPos(Vector2 pointPos)
    {
        _drawObgect.GetComponent<Draw>().SecurePosition(pointPos);
    }
    public void StopDraw()
    {
        _drawObgect.GetComponent<Draw>().activDraw = false;
        winRound = true;
        _youWin.SetActive(true);
        _next.SetActive(true);
        _menenger.Levels();
    }
    private IEnumerator ReturnStart()
    {
        yield return new WaitForSeconds(3);
        _menenger.Restart();
        Application.LoadLevel(0);
        yield return null;
    }
}
