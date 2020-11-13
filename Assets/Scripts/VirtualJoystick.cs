using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{

    public RectTransform thumb; //Перемещаемый спрайт
    private Vector2 originalPosition; //point A
    public Vector2 originalThumbPosition; //point A
    public Vector2 delta; //point B смещение
    public Rigidbody2D frog;
    public float movespeed;

    

    void Start () {
        originalPosition = this.GetComponent<RectTransform>().localPosition;
        originalThumbPosition = thumb.localPosition;
        //запомнить исходные координаты point A

        thumb.gameObject.SetActive(false); //выключить thumb

        delta = Vector2.zero; //величина point B (смещения) в нуле

        frog = GetComponent<Rigidbody2D>();
        movespeed = 4.0f;
        
    }
    //вызывается, когда начинается перемещение (палец жамает на экран)
    public void OnBeginDrag (PointerEventData eventData) {
        //включить thumb
        thumb.gameObject.SetActive(true);
        
        

         //зафиксировать мировые координаты, (где палец жамнул на экран) откуда начато перемещение
        Vector3 worldPoint = new Vector3();
        RectTransformUtility.ScreenPointToWorldPointInRectangle(this.transform as RectTransform, eventData.position, eventData.enterEventCamera, out worldPoint);

        //переместить VirtualJoystick (this) в позицию, (куда палец жамнул на экран) откуда начато перемещение
        this.GetComponent<RectTransform>().position = worldPoint;

        thumb.localPosition = originalPosition;
    }

          //начато перемещение
    public void OnDrag (PointerEventData eventData) {
        Vector3 worldPoint = new Vector3();
        RectTransformUtility.ScreenPointToWorldPointInRectangle(this.transform as RectTransform, eventData.position, eventData.enterEventCamera, out worldPoint);
        thumb.position = worldPoint;
        
              
        /*вычисление смещения от исходной позиции
        измеряется величиная смещения thumb от центра контактной панели
        и сохраняется в свойстве delta*/
        var size = GetComponent<RectTransform>().rect.size;

        delta = thumb.localPosition;

        delta.x /= size.x / 2.0f;
        delta.y /= size.y / 2.0f;

        delta.x = Mathf.Clamp(delta.x, -1.0f, 1.0f);
        delta.y = Mathf.Clamp(delta.y, -1.0f, 1.0f);

        /*if (delta.x > 0.1f) {
            frog.velocity = new Vector2(-movespeed, frog.velocity.y);
        }

        if (delta.x > -0.1f) {
            frog.velocity = new Vector2(movespeed, frog.velocity.y);
        }*/

    }

    public void OnEndDrag (PointerEventData eventData) {
        this.GetComponent<RectTransform>().localPosition = originalPosition;

        delta = Vector2.zero;

        thumb.gameObject.SetActive(false);

    }
}
