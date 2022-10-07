using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Color white;

    [SerializeField]
    private Color red;

    [SerializeField]
    private Color green;

    public Button alienBtn;
    public Button guardianBtn;

    public int activeEntityIndex;
   
    public enum EntityIndices{
        AlienIndex, 
        GuardianIndex
    }

    public void SelectEntity(int index)
    {
        if (index == (int)EntityIndices.AlienIndex)
        {
            alienBtn.image.color = red;
            guardianBtn.image.color = white;
            activeEntityIndex = index;
        }
        else if (index == (int)EntityIndices.GuardianIndex)
        {
            activeEntityIndex = index;
            guardianBtn.image.color = green;
            alienBtn.image.color = white;
        }
    }

}
