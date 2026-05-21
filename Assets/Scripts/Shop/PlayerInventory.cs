using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
   public List<string> items = new List<string>();

    public bool HasItem(string id)
    {
        return items.Contains(id);
    }
}
