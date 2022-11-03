using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BugsFound : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_Object;
    public string bug0, bug1, bug2;

    // Start is called before the first frame update
    void Start()
    {
        bug0 = "+ yeh ma";
        bug1 = "+ yeh da";
        bug2 = "+ yeh gran";
        m_Object.text = bug0 + "\n" + bug1 + "\n" + bug2 + "\n";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
