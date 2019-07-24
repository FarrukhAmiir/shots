using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShotManager : MonoBehaviour {

	public GameObject ball;
	public Transform leftAnchor;
	public Transform rightAnchor;

	public Transform ObjectHolder;

	public Transform aimer;

	public LineRenderer[] lines;
    public int NoOfBallz;
	public static SlingShotManager instance;
     int LevelNumber;
    public int totalEnimiesInLevel;
    UIManager ui;
    public static bool pull;
    GameManager Manager;
	void Awake()
	{
		instance = this;
	}
	// Use this for initialization
	void Start () 
	{
        LevelNumber = PlayerPrefs.GetInt("LevelNumber");
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ui = GameObject.Find("Canvas").GetComponent<UIManager>();
        lines [0].SetPosition (0, leftAnchor.position);
		lines [1].SetPosition (0,rightAnchor.position);
		setPath (true);
        GameObject level=  Instantiate(Manager.Levels[LevelNumber]);
        level.name = "Level" + LevelNumber;
        totalEnimiesInLevel = GameObject.Find("Level" + LevelNumber).transform.childCount;
	}
	
	// Update is called once per frame
	void Update ()
	{
		for (int i = 0; i < lines.Length; i++) {
			lines [i].SetPosition (1,ObjectHolder.position);
		}
	}
	public GameObject[] points;

	public void setPath(bool b)
	{
		float yPos = (aimer.up.y * 25) / (points.Length+7);
		float val = yPos;
		for (int i = 0; i < points.Length; i++) {
			points [i].SetActive (b);
			points [i].transform.parent = aimer;
			points [i].transform.localPosition = new Vector3 (0,val,-0.8f);
			val += yPos;
		}
	}

	public float speed;
	public void throwBall()
	{
		ObjectHolder.GetComponent<Collider> ().enabled = false;
		GameObject clone = Instantiate (ball,ball.transform.position,Quaternion.identity)as GameObject;
		clone.SetActive (true);
		clone.GetComponent<Rigidbody> ().AddForce (aimer.up*speed,ForceMode.Impulse);
        NoOfBallz--;
        ui.ballz[NoOfBallz].SetActive(false);
        Invoke("checkballz", 1f);
        Debug.Log(NoOfBallz);
	//	Destroy (clone,3f);
	}

    void checkballz()
    {
        if (NoOfBallz == 0)
        {
            ui.GameFailed.SetActive(true);
            Debug.Log("fail");
        }
    }
}
