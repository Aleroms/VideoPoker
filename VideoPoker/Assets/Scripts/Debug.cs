using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug : MonoBehaviour
{
	//Cards card;
	List<Cards> deck;
	//Dictionary<Cards.Suit, int> test;
	
    // Start is called before the first frame update
    void Start()
    {
		deck = new List<Cards>();

		//card = GameObject.Find("Card").GetComponent<Cards>();

		//if (card == null)
		//	print("card is null");

		 
	}

    // Update is called once per frame
    void Update()
    {
		
	}
}
/*
 * test = new Dictionary<Cards.Suit, int>();
 card.setRank(5);
		card.setSuit(Cards.Suit.CLUB);
		test = card.GetCard();

	test.Add(card.GetSuit(), card.GetRank());

		print("Suit:" + test.Key);
		print("Rank:" + test.Value);
	 */
