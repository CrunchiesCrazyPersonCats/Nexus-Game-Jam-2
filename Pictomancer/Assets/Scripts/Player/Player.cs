using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Inventory")]
    public Image itemImage;
    [SerializeField] IObject _carriedItem = null;
    

    // Start is called before the first frame update
    void Start()
    {
        itemImage.enabled = false;
    }

    #region Inventory
    public bool IsCarrying() { return _carriedItem != null; }
    public bool SetItemCarried(IObject item)
    {
        if (item == null) Debug.Log("somethign is wrong here");
        if (_carriedItem != null)
        {
            return false;
        } else
        {
            _carriedItem = item;
            if (item is SpellObject_SO)
            {
                itemImage.sprite = ((SpellObject_SO)item)._itemIcon;
                itemImage.enabled = true;
                return true;
            }
            else if (item is FormObject_SO)
            {
                itemImage.sprite = ((FormObject_SO)_carriedItem)._itemIcon;
                itemImage.enabled = true;
                return true;
            } else if (item is ElementObject_SO)
            {
                itemImage.sprite = ((ElementObject_SO)_carriedItem)._itemIcon;
                itemImage.enabled = true;
                return true;
            }
        }
        return false;
    }
    public IObject GetCarriedItem()
    {
        return _carriedItem;
    }
    public void ConfirmRemovalCarriedItem()
    {
        _carriedItem = null;
        itemImage.enabled = false;
    }
    #endregion
}
