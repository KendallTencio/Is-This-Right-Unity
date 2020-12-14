using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Openable : Interactable
{
    public Texture2D cursor;
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    public Sprite open;
    public Sprite closed;

    private SpriteRenderer sr;
    private bool isOpen;

    public override void interact()
    {
        if (isOpen)
            sr.sprite = closed;
        else
            sr.sprite = open;
        isOpen = !isOpen;
    }
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closed;

    }
    
    void OnMouseEnter()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseDown()
    {
        interact();
    }

}
