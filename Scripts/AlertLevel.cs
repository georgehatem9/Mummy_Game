using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AlertLevel : MonoBehaviour
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
        BryceMove pm = mainCha.GetComponent<BryceMove>();
        textMesh.text = pm.alertLevel.ToString();
    }
}
