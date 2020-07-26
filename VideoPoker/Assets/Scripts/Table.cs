using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> _selectedCards;
	private List<GameObject> _displayedCards;

	[SerializeField]
	private Transform[] slot;
	[SerializeField]
	private bool[] _isSelected;
	private Deck _deck;

	private int _handSize;
	// Start is called before the first frame update
	void Start()
	{
		_handSize = 5;
		_isSelected = new bool[_handSize];
		_displayedCards = new List<GameObject>();
		_deck = GameObject.Find("Deck").GetComponent<Deck>();

		if (_deck == null)
			print("deck ref is null");

		SetDisplayCards();
	}
	void SetDisplayCards()
	{
		

		for(int i = 0; i < _handSize; i++)
		{
			_displayedCards.Add(_deck.GetSelection());
			_displayedCards[i].transform.position = slot[i].transform.position;
			_isSelected[i] = false;
			print(_displayedCards[i].name);
		}

	}
	public void SetIsSelected(int n, bool truth)
	{
		if (truth)
			_isSelected[n] = true;
		else
			_isSelected[n] = false;
	}
	public void Play()
	{
		print("hello");
	}
	


}
