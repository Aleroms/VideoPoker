using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
	
	private List<GameObject> _selectedCards;
	private List<GameObject> _displayedCards;
	private List<GameObject> _discardPile;

	[SerializeField]
	private Transform[] slot;

	[SerializeField]
	private bool[] _isSelected;

	private Deck _deck;
	private UIManager _uim;

	private int _handSize;
	
	void Start()
	{
		_handSize = 5;

		_isSelected = new bool[_handSize];

		_selectedCards = new List<GameObject>();
		_displayedCards = new List<GameObject>();
		_discardPile = new List<GameObject>();

		_deck = GameObject.Find("Deck").GetComponent<Deck>();
		_uim = GameObject.Find("Canvas").GetComponent<UIManager>();

		if (_deck == null)
			print("deck ref is null");

		if (_uim == null)
			print("uim is null");

		
	}
	public void SetDisplayCards()
	{
		

		for(int i = 0; i < _handSize; i++)
		{
			_displayedCards.Add(_deck.GetSelection());
			_displayedCards[i].transform.position = slot[i].transform.position;
			_isSelected[i] = false;
			
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
		_uim.OnDisableText();
		int num = _displayedCards.Count;

		for(int i = 0; i < num; i++)
		{
			if(_isSelected[i] == true)
			{
				_selectedCards.Add(_displayedCards[i]);
			}
			else
			{
				_discardPile.Add(_displayedCards[i]);


				_selectedCards.Add(_deck.GetSelection());
				_selectedCards[i].transform.position = slot[i].transform.position;


				_displayedCards[i].transform.position = new Vector3(-12, 0);

			}
		}

	}
	public List<GameObject> GetSelectedCards()
	{
		return _selectedCards;
	}

	public void Reset()
	{
		for (int i = 0; i < _displayedCards.Count; i++)
			_displayedCards[i].transform.position = new Vector3(-12, 0);

		_selectedCards.Clear();
		_displayedCards.Clear();

		_deck.Reset();

		SetDisplayCards();
	}


}