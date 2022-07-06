using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class datastore : Singleton<datastore>
{
    public FloatVariable Level1Star;
    public FloatVariable Level2Star;
    public FloatVariable Level3Star;
    public FloatVariable PlayerHealth;
    public BooleanVariable TutorialCompeleted;
    public FloatVariable LevelCompleted;

    override public void Awake()
    {
        base.Awake();
        Debug.Log("awake called");
        // other instructions...
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
