using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHelper : MonoBehaviour
{
    [SerializeField] GameObject upperButtonScrollLimit;
    [SerializeField] GameObject lowerButtonScrollLimit;
    private bool activeTop;
    private bool activeBottom;

    private void Start()
    {
        activeTop = true; 
        activeBottom = true; 
    }
    // Update is called once per frame
    void Update()
    {
        //hide buttons that go off the top
        if (activeTop && this.transform.position.y > upperButtonScrollLimit.transform.position.y - 30)
        {
            this.gameObject.transform.localScale = new Vector3(0, 0, 0);
            activeTop = !activeTop;
        }
        //show buttons that come back in at the top
        if (!activeTop && this.transform.position.y < upperButtonScrollLimit.transform.position.y - 30)
        {
            this.gameObject.transform.localScale = new Vector3(1,1,1);
            activeTop = !activeTop;
        }
        //hide buttons that go off the bottom
        if (activeBottom && this.transform.position.y < lowerButtonScrollLimit.transform.position.y - 30)
        {
            this.gameObject.transform.localScale = new Vector3(0, 0, 0);
            activeBottom = !activeBottom;
        }
        //show buttons that come back in at the bottom
        if (!activeBottom && this.transform.position.y > lowerButtonScrollLimit.transform.position.y - 30)
        {
            this.gameObject.transform.localScale = new Vector3(1,1,1);
            activeBottom = !activeBottom;
        }
    }
}
