using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
	[SerializeField]
	private GameObject _cardPrefab;
	[SerializeField]
	private GameObject _deckContainer;
	private List<Cards> _deck;
	private Cards _card;
    // Start is called before the first frame update
    void Start()
    {
		_deck = new List<Cards>();
		GenerateDeck();

		for(int i = 0; i < _deck.Count; i++)
		{
			print(_deck[i].GetSuit() + ":" + _deck[i].GetRank());
		}
		
    }
	void GenerateDeck()
	{
		

		for (int i = 0; i < 4; i++)
		{
			

			for (int j = 0; j < 13; j++)
			{
				GameObject tempCard = Instantiate(_cardPrefab, transform.position, Quaternion.identity);
				Cards temp = tempCard.GetComponent<Cards>();

				
				temp.setSuit(i);
				temp.setRank(j);
				_deck.Add(temp);

				tempCard.transform.parent = _deckContainer.transform;
			}

		}
	}
    // Update is called once per frame
    void Update()
    {
        
    }
	void shuffle()
	{
		//TODO shuffles the list
	}
}
/*
 if (i == 0)
				{
					_deck[i].setSuit(Cards.Suit.CLUB);
				}
				else if(i == 1)
				{
					_deck[i].setSuit(Cards.Suit.DIAMOND);
				}
				else if(i == 2)
				{
					_deck[i].setSuit(Cards.Suit.HEART);
				}
				else if(i == 3)

	 
	 
	 */
