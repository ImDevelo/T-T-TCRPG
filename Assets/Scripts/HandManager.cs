using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandManager : MonoBehaviour
{
    [SerializeField] GameObject cardPrefeb;
    [SerializeField] DeckManager Mydeck;

    [SerializeField] Transform deckPoint;
    [SerializeField] Transform handsPoint;

    [SerializeField] List<Card> decks;
    [SerializeField] List<GameObject> hands;

    // Hand Setting
    [SerializeField] int maxCard; //�ִ�� ���� �� �ִ� ī�� ����

    int selected; //���õ� ī��

    // Start is called before the first frame update
    void Start()
    {
        handsPoint = this.transform;
        decks = Mydeck.RandomDeck(100); //���� �����ɴϴ�.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            DrowCard();
        }
    }

    Card PopItem() {
        Card card = decks[0];
        decks.RemoveAt(0);
        return card;
    }

    // ī�� ���常 �̱�
    void DrowCard() {
        if (maxCard <= hands.Count) return;

        //ī�� �ν��Ͻ� ����
        var cardInstance = Instantiate(cardPrefeb, deckPoint.position, Quaternion.identity, this.transform);
        var cardComponet = cardInstance.GetComponent<CardComponent>();
        cardComponet.Setup(PopItem());
        
        //�ڵ忡 ī�� �߰�
        hands.Add(cardInstance);
        SortingCard();
    }

    void SortingCard() {
        for(int i=0; i< hands.Count; i++) {
            var layerComponet = hands[i].GetComponent<SortingLayer>();
            var cardComponet = hands[i].GetComponent<CardComponent>();
            var pos = RadiansPRS(i);
            cardComponet.MoveTransform(pos, true, 0.5f);
            cardComponet.SetOriginPosision(pos);
            layerComponet.SortingLayers(i);
        }
    }

    PRS RadiansPRS(int number) {
        float gap = 1f;
        float slope = 1f;
        float radius = 25f;
        float count = hands.Count;
        float portion = 1 / count * number;
        float center = handsPoint.position.x;
        float LPos = center - ((count-1) / 2  * gap);

        float Xpos = LPos + number * gap;
        float Ymin = (radius - Math.Base(radius, LPos)) / 2;
        float Ypos = this.transform.position.y + Math.Base(radius, Xpos) - Math.Base(radius, LPos) - Ymin;
        float LRot = count * slope;

        var pos = new Vector3(Xpos, Ypos);
        var rot = Quaternion.Slerp(Quaternion.Euler(0, 0, LRot), Quaternion.Euler(0, 0, -LRot), portion);
        
        return new PRS(pos, rot, Vector3.one);
    }
}
