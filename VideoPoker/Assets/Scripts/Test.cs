using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
	private List<GameObject> test;

	public GameObject tart;
    // Start is called before the first frame update
    void Start()
    {
		test = new List<GameObject>();

		for(int i = 0; i < 52; i++)
		{
			test.Add(Instantiate(tart, transform.position, Quaternion.identity));

			test[i].GetComponent<test2>().Set("Success");
			//test2 index = test[i].GetComponent<test2>();
			//test[i].

			
		}
		print("List<GameObject.count:" + test.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
		{
			Reset();
		}
    }
	void Reset()
	{
		for(int i=0;i<test.Count;i++)
		{
			Destroy(test[i]);
		}
		test = new List<GameObject>();

		print("List<GameObject.count:   " + test.Count);
		print("List<GameObject.capacity:" + test.Capacity);
	}
}
