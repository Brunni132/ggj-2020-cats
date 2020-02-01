using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    //public Texture2D cursorTexture = new Texture2D(16,16);
  //  public SpriteRenderer;
  //  public CursorMode cursorMode = CursorMode.Auto;
  //  public Vector2 hotSpot = Vector2.zero;

    private void Start() {
    //    Texture2D tex ;
    //    mySprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
    //    sr.sprite = mySprite;
    }
    void OnMouseEnter()
    {
        UnityEngine.Debug.LogWarningFormat("Mouse entered");
        //Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        
    }

    void OnMouseExit()
    {
        UnityEngine.Debug.LogWarningFormat("Mouse left");
        //Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
