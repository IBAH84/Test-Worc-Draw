using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {
    
  [SerializeField] private ButtonController _button;
    private void OnMouseDown()
    {
        if (_button == ButtonController.Start)
        {
            Application.LoadLevel(1);
        }
        if (_button == ButtonController.Next)
        {

            Application.LoadLevel(1);
        }
        if (_button == ButtonController.Exit)
        {
            Application.Quit();
        }
    }
}
public enum ButtonController
{
Start,
Exit,
Next
}
