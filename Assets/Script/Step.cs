using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
//[CreateAssetMenu(fileName = "Step", menuName = "ScriptableObjects/Step")]
public class Step //: ScriptableObject
{
    [SerializeField] private string _title;

    public string GetTitle()
    {
        return _title ;
    }

    public void DoStep()
    {
        Debug.Log("Done step" + _title);
    }
}
