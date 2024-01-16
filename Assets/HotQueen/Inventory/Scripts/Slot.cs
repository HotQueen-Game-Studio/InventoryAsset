using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HotQueen.Inventory
{
    public class Slot : Button
    {
        [SerializeField] private TMP_Text m_name;
        [SerializeField] private TMP_Text m_count;
        public TMP_Text name { get { return m_name; } }
        public TMP_Text count { get { return m_count; } }

        //Hold
        public event Action whenHold;
        private Coroutine holdCoroutine;
        private float holdTime = 1;

        public event Action whenHover;
        public event Action whemStopHover;

        private void Start()
        {
            m_name = this.transform.Find("Name").GetComponent<TMP_Text>();
            m_count = this.transform.Find("Count").GetComponent<TMP_Text>();
            whenHold += () => { Debug.Log("being hold"); };

        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            whenHover?.Invoke();

        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            whemStopHover?.Invoke();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            if (holdCoroutine != null)
            {
                StopCoroutine(holdCoroutine);
            }

        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            holdCoroutine = StartCoroutine(TryHold());
        }

        private IEnumerator TryHold()
        {
            float current_holdtime = holdTime;
            while (current_holdtime > 0)
            {
                current_holdtime -= Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            whenHold?.Invoke();
        }
    }

}