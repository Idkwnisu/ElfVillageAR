using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickable : MonoBehaviour
{
    SelectableItem item;
    Text debugText;
    public string itemToPick;
    // Start is called before the first frame update
    void Start()
    {
        item = GetComponent<SelectableItem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(item.isSelected())
            {
                if(Input.touchCount > 0)
                {
                    if(Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                     if(!HandManager.Instance.hasObject())
                     {
                         HandManager.Instance.pickUpObject(itemToPick);
                         Destroy(gameObject);
                     }
                    }
                }
            }

    }
}
