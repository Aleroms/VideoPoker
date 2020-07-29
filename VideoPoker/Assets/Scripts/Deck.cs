using System.Collections;
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
	private List<GameObject> _discardPile;
	private Stack<GameObject> _deck3;

	private Cards _card;

	public void StartGame()
	{
		_deck2 = new List<GameObject>();
		_discardPile = new List<GameObject>();

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
		_discardPile.Add(_deck3.Peek());
		return _deck3.Pop();
	}

	public void Reset()
	{
		for(int i = 0; i < _deck2.Count; i++)
		{
			Destroy(_deck2[i].gameObject);
		}
		_deck2 = new List<GameObject>();
		GenerateDeck();
		_deck3 = Shuffle();
		
	}

	void GenerateDeck()
	{

		int spriteIndex = 0;
		int deckIndex = 0;

		for (int i = 0; i < 4; i++)
		{

			
			for (int j = 0; j < 13; j++)
			{
				
				_deck2.Add(Instantiate(_cardPrefab, transform.position, Quaternion.identity));
				Cards tempCard = _deck2[deckIndex].GetComponent<Cards>();

				if (tempCard != null)
				{
					tempCard.setSuit(i);
					tempCard.setRank(j);

					_deck2[deckIndex].name = tempCard.GetSuit().ToString() + tempCard.GetRank().ToString();
				}
				

				_deck2[deckIndex].GetComponent<SpriteRenderer>().sprite = _cardFaces[spriteIndex];

				_deck2[deckIndex].transform.parent = _deckContainer.transform;

				deckIndex++;
				spriteIndex++;
				

			}

		}


	}


}