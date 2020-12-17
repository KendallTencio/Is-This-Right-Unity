using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerActive : Interactable
{
    public Texture2D cursor;
    [SerializeField] private DoorAnimated door;
    [SerializeField] private plantAttack leg;
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    public Sprite open;
    public Sprite closed;
    public AudioClip objectSound;

    private SpriteRenderer sr;
    private AudioSource auSo;
    private bool isOpen;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        auSo = GetComponent<AudioSource>();
        auSo.clip = objectSound;

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
        auSo.Play();        
        interact();
    }

    private void OnMouseUp()
    {
        leg.stop();
    }
    public override void interact()
    {

        if (isOpen)
        {            
            sr.sprite = closed;
            door.closeDoor();
        }
        else
        {
            leg.attack();
            sr.sprite = open;
            door.openDoor();
        }            
        isOpen = !isOpen;        
    }
}
