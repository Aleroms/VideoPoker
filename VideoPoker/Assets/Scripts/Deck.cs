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
	

	private List<GameObject> _deck2;
	private Cards _card;

	private Stack<GameObject> _deck3;
	
    void Awake()
    {

		_deck2 = new List<GameObject>();
		
		GenerateDeck();
		_deck3 = Shuffle();
		
    }
	
   
	Stack<GameObject> Shuffle()
	{
		int randIndex;
		Stack<GameObject> tempStack = new Stack<GameObject>();

		for(int i=0; i < _deck2.Count; i++)
		{
			GameObject temp = _deck2[i];
			

			randIndex = Random.Range(i, _deck2.Count);

			_deck2[i] = _deck2[randIndex];

			_deck2[randIndex] = temp;

			tempStack.Push(_deck2[i]);

		}
		return tempStack;
	}

	public GameObject GetSelection()
	{
		return _deck3.Pop();
	}

	public void Reset()
	{
		_deck3.Clear();
		_deck3 = Shuffle();
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


				_deck2.Add(tempCard);
				spriteIndex++;

			}

		}


	}


}