﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
	[SerializeField]
	private GameObject _cardPrefab;
	[SerializeField]
	private GameObject _deckContainer;
	[SerializeField]
	private Sprite[] _cardFaces;
	//private List<Cards> _deck;
	[SerializeField]
	private List<GameObject> _deck2;
	private Cards _card;
    // Start is called before the first frame update
    void Start()
    {
		//_deck = new List<Cards>();
		_deck2 = new List<GameObject>();
		GenerateDeck();
		Shuffle();

		/*for(int i = 0; i < _deck2.Count; i++)
		{
			print(_deck[i].GetSuit() + ":" + _deck[i].GetRank());
		}*/
		
    }
	void GenerateDeck()
	{
		int spriteIndex = 0;

		for (int i = 0; i < 4; i++)
		{
			

			for (int j = 1; j < 14; j++)
			{
				GameObject tempCard = Instantiate(_cardPrefab, transform.position, Quaternion.identity);
				Cards temp = tempCard.GetComponent<Cards>();

				
				temp.setSuit(i);
				temp.setRank(j);
				tempCard.GetComponent<SpriteRenderer>().sprite = _cardFaces[spriteIndex];
				
				tempCard.transform.parent = _deckContainer.transform;
				tempCard.name = temp.GetSuit().ToString() + temp.GetRank().ToString();

				//_deck.Add(temp);
				_deck2.Add(tempCard);
				spriteIndex++;

			}

		}
	}
    // Update is called once per frame
    void Update()
    {
        
    }
	void Shuffle()
	{
		int randIndex;

		for(int i=0; i < _deck2.Count; i++)
		{
			GameObject temp = _deck2[i];

			randIndex = Random.Range(i, _deck2.Count);

			_deck2[i] = _deck2[randIndex];

			_deck2[randIndex] = temp;

		}
	}
}

