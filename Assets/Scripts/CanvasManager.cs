using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public void Lyago()
    {
        GetComponent<SeleccionPersonaje>().ChangeAvatarByIndex(0);
        Time.timeScale = 1f;
    }
    public void MasterChiefTemu()
    {
        GetComponent<SeleccionPersonaje>().ChangeAvatarByIndex(1);
        Time.timeScale = 1f;
    }
    public void Ninja()
    {
        GetComponent<SeleccionPersonaje>().ChangeAvatarByIndex(2);
        Time.timeScale = 1f;
    }
    void ShowCursor(bool show)
    {
        Cursor.visible = show;
        Cursor.lockState = show ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
