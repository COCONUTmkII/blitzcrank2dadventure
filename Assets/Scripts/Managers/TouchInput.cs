using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace Blitzcrank.Manager
{
    public class TouchInput : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler
    {
        public delegate void JoystickDelegate(Vector2 vector);
        public event JoystickDelegate JoystickEvent;
        private GameObject _leftController;
        private Image _bgJoystickImg;
        private Image _joystickImg;
        private Vector2 _inputVector;

        private void Start()
        {
            _leftController = GameObject.Find("LeftController");
            _bgJoystickImg = _leftController.transform.GetChild(0).GetComponent<Image>();
            _joystickImg = _bgJoystickImg.transform.GetChild(0).GetComponent<Image>();
        }
        public void OnDrag(PointerEventData eventData)
        {
            //Left rectangle zone Joystick UI
            if (eventData.pointerEnter == _leftController || eventData.pointerEnter == _joystickImg.gameObject)
            {
                JoystickEvent(OnJoystickDrag(eventData));
            }
        }
        
        private Vector2 OnJoystickDrag(PointerEventData eventData)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_bgJoystickImg.rectTransform,
                                                                           eventData.position,
                                                                           eventData.pressEventCamera,
                                                                           out Vector2 pos))
            {
                Vector2 sizeDelta = _bgJoystickImg.rectTransform.sizeDelta;
                pos.x /= sizeDelta.x;
                pos.y /= sizeDelta.y;
                _inputVector = new Vector2(pos.x * 2, pos.y * 2);
                _inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;
                _joystickImg.rectTransform.anchoredPosition = new Vector2(_inputVector.x * (sizeDelta.x / 3),
                                                                        _inputVector.y * (sizeDelta.y / 3));
            }
            return _inputVector;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //Срабатывает только после OnPointerUP
            // Debug.Log("Click - X:" + eventData.position.x +" Y:"+eventData.position.y);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
            Debug.Log(eventData.pointerEnter);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _inputVector = Vector2.zero;
            _joystickImg.rectTransform.anchoredPosition = Vector2.zero;
            JoystickEvent(_inputVector);
        }
    }
}

