using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> selectedCards;
	private List<GameObject> _displayedCards;

	[SerializeField]
	private Transform[] slot;
	private Deck _deck;
	// Start is called before the first frame update
	void Start()
	{
		_displayedCards = new List<GameObject>();
		_deck = GameObject.Find("Deck").GetComponent<Deck>();

		if (_deck == null)
			print("deck ref is null");

		SetDisplayCards();
	}
	void SetDisplayCards()
	{
		for(int i=0; i<5;i++)
		{
			_displayedCards.Add(_deck.GetSelection());
			_displayedCards[i].transform.position = slot[i].transform.position;
			print(_displayedCards[i].name);
		}


	}

	// Update is called once per frame
	void Update()
	{

	}
	public void UserSelect(int n)
	{
		switch (n)
		{
			case 0:
				break;
			case 1:
				break;
			case 2:
				break;
			case 3:
				break;
			case 4:
				break;
			default:
				print("Table.cs::userselect something went wrong");
				break;
		}
	}
}
