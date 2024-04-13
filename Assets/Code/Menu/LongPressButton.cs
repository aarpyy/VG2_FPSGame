using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Menu
{
    public class LongPressButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public bool IsPressing { get; private set; }

        public void OnPointerDown(PointerEventData eventData)
        {
            IsPressing = true;
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            IsPressing = false;
        }
    }
}