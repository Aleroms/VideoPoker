using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationsPayOut : MonoBehaviour
{

	private List<GameObject> _selectedCards;
	private List<int> _pairChecker;
	private string _highestPair;
	private Cards _card;

	void Start()
	{
		_selectedCards = new List<GameObject>();
		_pairChecker = new List<int>();
		//_playerWon = false;
		_highestPair = "default";
	}
	public string GetWinningHand()
	{
		return _highestPair;
	}
	public bool CheckCards(List<GameObject> selected)
	{
		_selectedCards = selected;
	    _pairChecker = GetSortedRankList();

		if(CheckForRoyalFlush())
		{
			_highestPair = "RoyalFlush";
			return true;
		}
		else if(CheckForStraightFlush())
		{
			_highestPair = "StraightFlush";
			return true;
		}
		else if(CheckForQuad())
		{
			_highestPair = "FourOfAKind";
			return true;
		}
		else if (CheckForFlush())
		{
			_highestPair = "Flush";
			return true;
		}
		else if (CheckForStraight())
		{
			_highestPair = "Straight";
			return true;
		}
		else if (CheckForThreeK())
		{
			_highestPair = "ThreeOfAKind";
			return true;
		}
		else if (CheckForPair())
		{
			_highestPair = "TwoPairs";
			return true;
		}
		else if (CheckForJacksOrBetter())
		{
			_highestPair = "JacksOrBetter";
			return true;
		}

		//player lost
		return false;
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
	bool CheckForFullHouse()
	{
		bool p34,p01;

		p34 = _pairChecker[3] == _pairChecker[4];
		p01 = _pairChecker[0] == _pairChecker[1];

		return CheckForThreeK() && p34 || CheckForThreeK() && p01;
	}
	bool CheckForJacksOrBetter()
	{
		int highCard = 0;

		for(int i = 0; i < _pairChecker.Count; i++)
		{
			if (_pairChecker[i] == 1 || _pairChecker[i] > 10)
				highCard++;
		}

		return highCard > 1;
	}
	bool CheckForStraightFlush()
	{
		return CheckForFlush() && CheckForStraight();
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
		//ResetCheckers();

		bool p0123, p1234;

		p0123 = _pairChecker[0] == _pairChecker[1] && _pairChecker[1] == _pairChecker[2]
			   && _pairChecker[2] == _pairChecker[3];

		p1234 = _pairChecker[1] == _pairChecker[2] && _pairChecker[2] == _pairChecker[3]
			   && _pairChecker[3] == _pairChecker[4];

		return p0123 || p1234;
	}
	bool CheckForThreeK()
	{
		//ResetCheckers();


		bool p012, p123, p234;

		p012 = _pairChecker[0] == _pairChecker[1] && _pairChecker[1] == _pairChecker[2];
		p123 = _pairChecker[1] == _pairChecker[2] && _pairChecker[2] == _pairChecker[3];
		p234 = _pairChecker[2] == _pairChecker[3] && _pairChecker[3] == _pairChecker[4];

		return p012 || p123 || p234;
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
		//ResetCheckers();
		string _suitChecker;

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
    

}
