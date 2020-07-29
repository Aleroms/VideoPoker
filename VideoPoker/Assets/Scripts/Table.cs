using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
	
	private List<GameObject> _selectedCards;
	private List<GameObject> _displayedCards;
	private List<GameObject> _faceDownCards;

	[SerializeField]
	private Transform[] slot;

	[SerializeField]
	private bool[] _isSelected;

	[SerializeField]
	private GameObject _faceDownPrefab;

	private Deck _deck;
	

	private int _handSize;
	private bool _isFaceDown;

	
	public void StartGame()
	{
		_handSize = 5;

		_isSelected = new bool[_handSize];

		_selectedCards = new List<GameObject>();
		_displayedCards = new List<GameObject>();
		_faceDownCards = new List<GameObject>();

		_deck = GameObject.Find("Deck").GetComponent<Deck>();
		

		if (_deck == null)
			print("deck ref is null");

	
		SetDisplayCards();
		SetBackFaceCards();
	}
	public bool IsFaceDown()
	{
		return _isFaceDown;
	}
	public void DisableBackFaceCards()
	{
		_isFaceDown = false; 

		for (int i = 0; i < _faceDownCards.Count; i++)
			Destroy(_faceDownCards[i].gameObject);
	}
	void SetBackFaceCards()
	{
		_isFaceDown = true;

		for(int i = 0; i < _displayedCards.Count;i++)
		{
			_faceDownCards.Add(Instantiate(_faceDownPrefab, slot[i].transform.position, Quaternion.identity));
			float x = _faceDownCards[i].transform.position.x;
			float y = _faceDownCards[i].transform.position.y;
			_faceDownCards[i].transform.position = new Vector3(x, y, -0.1f);
		}
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
		
		int num = _displayedCards.Count;

		for(int i = 0; i < num; i++)
		{
			if(_isSelected[i] == true)
			{
				_selectedCards.Add(_displayedCards[i]);
			}
			else
			{

				_selectedCards.Add(_deck.GetSelection());
				_selectedCards[i].transform.position = slot[i].transform.position;


				_displayedCards[i].transform.position = new Vector3(-12,5);
			
			}
		}

	}
	public List<GameObject> GetSelectedCards()
	{
		return _selectedCards;
	}

	public void Reset()
	{

		_displayedCards = new List<GameObject>();
		_selectedCards = new List<GameObject>();

		print("displayCards count:" + _displayedCards.Count);
		

	}


}