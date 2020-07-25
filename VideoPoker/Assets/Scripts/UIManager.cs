using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[SerializeField]
	private Text[] _heldText;
	[SerializeField]
	private Text _wager;
	[SerializeField]
	private Text _win;
	[SerializeField]
	private Text _credits;

	private Player _player;

	private int _maxWager;
	private int _wagerInt;
    // Start is called before the first frame update
    void Start()
    {
		_player = GameObject.Find("Player").GetComponent<Player>();

		if (_player != null)
		{
			_credits.text = "CREDITS     " + _player.GetCredits();
			_maxWager = _player.GetMaxWager();

		}
		_wagerInt = 0;
		_wager.text = "WAGER    " + _wagerInt;
		_win.gameObject.SetActive(false);
		OnDisableText();
    }
	void OnDisableText()
	{
		for(int i=0; i < _heldText.Length; i++)
		{
			_heldText[i].gameObject.SetActive(false);
		}
	}
	public void UserSelect(int n)
	{
		if( n >= 0 && n < _heldText.Length)
		{
			if (_heldText[n].gameObject.activeSelf == false)
				_heldText[n].gameObject.SetActive(true);
			else
				_heldText[n].gameObject.SetActive(false);
		}

		
	}
	public void AddWager()
	{
		if(_wagerInt != _maxWager)
			_wagerInt++;

		_wager.text = "WAGER    " + _wagerInt;
		_player.SetWager();
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
