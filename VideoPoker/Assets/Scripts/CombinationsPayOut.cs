using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationsPayOut : MonoBehaviour
{
	private string _suitChecker;
	private int _rankChecker;

	private List<GameObject> _selectedCards;
	private List<int> _pairChecker;
	private string _highestPair;
	private bool _playerWon;
	private Cards _card;
	

	public bool CheckCards(List<GameObject> selected)
	{
		_selectedCards = selected;
	    _pairChecker = GetSortedRankList();

		//you were stuck on an issue where _paircheker was mispelled

		_playerWon = CheckForPair();//works
		//_playerWon = CheckForThreeK();//works
		//_playerWon = CheckForQuad();//works
		//_playerWon = CheckForStraight();
		//_playerWon = CheckForRoyalFlush();//works
		

		return _playerWon;
	}
	bool StraightHelper(int r)
	{
		for (int i = 1; i < _pairChecker.Count; i++)
		{
			if (_pairChecker[i] == r)
			{
				r++;
			}
			else
				return false;
		}
		return true;
	}
	bool CheckForRoyalFlush()
	{
		int r = 10;
		bool temp = false;

		if (_pairChecker[0] == 1)
		{
			temp = StraightHelper(r);
		}

		return temp;
	}
	bool CheckForStraight()
	{
		int r = _pairChecker[0] + 1;

		return StraightHelper(r);
	}
	bool CheckForQuad()
	{
		ResetCheckers();

		bool p0123, p1234;

		p0123 = _pairChecker[0] == _pairChecker[1] && _pairChecker[1] == _pairChecker[2]
			   && _pairChecker[2] == _pairChecker[3];

		p1234 = _pairChecker[1] == _pairChecker[2] && _pairChecker[2] == _pairChecker[3]
			   && _pairChecker[3] == _pairChecker[4];

		return p0123 || p1234;
	}
	bool CheckForThreeK()
	{
		ResetCheckers();
		

		bool p012, p123;

		p012 = _pairChecker[0] == _pairChecker[1] && _pairChecker[1] == _pairChecker[2];
		p123 = _pairChecker[1] == _pairChecker[2] && _pairChecker[2] == _pairChecker[3];

		return p012 || p123;
	}
	List<int> GetSortedRankList()
	{
		List<int> pc = new List<int>();

		for (int i = 0; i < _selectedCards.Count; i++)
		{
			_card = _selectedCards[i].GetComponent<Cards>();
			pc.Add(_card.GetRank());
		}
		pc.Sort();

		return pc;
	}
	bool CheckForPair()
	{
		//ResetCheckers();
		
		bool p0123;
		bool p1234;

		


		p0123 = _pairChecker[0] == _pairChecker[1] && _pairChecker[2] == _pairChecker[3];
		p1234 = _pairChecker[1] == _pairChecker[2] && _pairChecker[3] == _pairChecker[4];

		return p0123 || p1234;
	}
	
	bool CheckForFlush()
	{
		ResetCheckers();
		

		_card = _selectedCards[0].GetComponent<Cards>();
		_suitChecker = _card.GetSuit().ToString();

		for (int i = 1; i < _selectedCards.Count; i++)
		{
			_card = _selectedCards[i].GetComponent<Cards>();

			if (!_suitChecker.Equals(_card.GetSuit().ToString()))
				return false;

			_suitChecker = _card.GetSuit().ToString();
			
		}
		
		return true;
	}
    // Start is called before the first frame update
    void Start()
    {
		_selectedCards = new List<GameObject>();
		_pairChecker = new List<int>();
		_playerWon = false;
		_highestPair = "default";
    }


	void Debug()
	{
		//print(_card.GetSuit().ToString() + _card.GetRank().ToString());//print(_card.GetSuit().ToString() + _card.GetRank().ToString());
		print("selected.size:" + _selectedCards.Count);
		for(int i = 0; i < _selectedCards.Count; i++)
		{
			print(_selectedCards[i].name);
		}
	}
	void ResetCheckers()
	{
		_card = null;
		_rankChecker = -1;
		_suitChecker = "default";
	}
}
