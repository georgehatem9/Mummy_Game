using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public Object mainCha;
    TextMeshProUGUI textMesh;
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        MummyController pm = mainCha.GetComponent<MummyController>();
        textMesh.text = pm.BryceLives.ToString();
    }
}
