using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] Sprite frontbackground;  // ī�� �ո� ���
    [SerializeField] Sprite backbackground;   // ī�� �޸� ���
    [SerializeField] Renderer tcgimage;         // ī�� �̹���


    public TextMesh cardname;       // ī�� �̸�
    public TextMesh description;    // ī�� ����


    // Start is called before the first frame update
    void Start()
    {
        SetOrder();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //���̾� ���� ����
    public void SetOrder() 
    {



    }
}
