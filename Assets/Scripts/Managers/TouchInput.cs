using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace Blitzcrank.Manager
{
    public class TouchInput : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler
    {
        public delegate void JoysticDelegate(Vector2 vector);
        public event JoysticDelegate JoysticEvent;
        private GameObject leftСontroller;
        private Image bgJoysticImg;
        private Image joysticImg;
        private Vector2 inputVector;

        private void Start()
        {
            leftСontroller = GameObject.Find("LeftСontroller");
            bgJoysticImg = leftСontroller.transform.GetChild(0).GetComponent<Image>();
            joysticImg = bgJoysticImg.transform.GetChild(0).GetComponent<Image>();
        }
        public void OnDrag(PointerEventData eventData)
        {
            Vector2 pos;
            if ((eventData.position.x < 500 && eventData.position.x > 0) && (eventData.position.y < 500 && eventData.position.y > 0))
            {
                
                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgJoysticImg.rectTransform,
                                                                            eventData.position,
                                                                            eventData.pressEventCamera,
                                                                            out pos))
                {
                    pos.x /= bgJoysticImg.rectTransform.sizeDelta.x;
                    pos.y /= bgJoysticImg.rectTransform.sizeDelta.y;
                    inputVector = new Vector2(pos.x * 2, pos.y * 2);
                    inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
                    joysticImg.rectTransform.anchoredPosition = new Vector2(inputVector.x * (bgJoysticImg.rectTransform.sizeDelta.x / 3),
                                                                            inputVector.y * (bgJoysticImg.rectTransform.sizeDelta.y / 3));
                }
                JoysticEvent(inputVector);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //Срабатывает только после OnPointerUP
            // Debug.Log("Click - X:" + eventData.position.x +" Y:"+eventData.position.y);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            inputVector = Vector2.zero;
            joysticImg.rectTransform.anchoredPosition = Vector2.zero;
            JoysticEvent(inputVector);
        }
    }
}

