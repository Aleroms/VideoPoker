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
	//private List<Cards> _deck;
	[SerializeField]
	private List<GameObject> _deck2;
	private Cards _card;

	private Stack<GameObject> _deck3;
	//private Queue<GameObject> _deck4;

    // Start is called before the first frame update
    void Awake()
    {
		//_deck = new List<Cards>();
		_deck2 = new List<GameObject>();
		_deck3 = new Stack<GameObject>();
		//_deck4 = new Queue<GameObject>();
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
				//_deck3.Push(tempCard);
				//_deck4.Enqueue(tempCard);
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
		//randomize then assign
		for(int i=0; i < _deck2.Count; i++)
		{
			GameObject temp = _deck2[i];
			//GameObject temp = _deck3[i];
			//GameObject temp = _deck4[i];

			randIndex = Random.Range(i, _deck2.Count);

			_deck2[i] = _deck2[randIndex];

			_deck2[randIndex] = temp;

			_deck3.Push(_deck2[i]);

		}
	}
	public GameObject GetSelection()
	{
		return _deck3.Pop();

		/*
		//print("capacity: " + _deck2.Count);
		GameObject t = _deck2[0];
		_deck2.RemoveAt(0);
		return t;*/
	}
}

