using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> selectedCards;
	private List<GameObject> _displayedCards;

	private Deck _deck;
    // Start is called before the first frame update
    void Start()
    {
		_deck = GameObject.Find("Deck").GetComponent<Deck>();

		if (_deck == null)
			print("deck ref is null");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
