using System.Collections.Generic;
using UnityEngine;

public class DatabaseManger : Singleton<DatabaseManger>
{
    [SerializeField] private List<Sop> _sops = new List<Sop>();
    

    public List<Sop> FetchSOPData()
    {
        return _sops;
    }
}
