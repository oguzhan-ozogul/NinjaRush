using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
	[SerializeField] private float _firstLine;
	[SerializeField] private float _secondLine;
	[SerializeField] private float _thirdLine;

	[SerializeField] private float _moveThreshold;
	[SerializeField] private float _speed;
	[SerializeField] private float _moveSpeed;
	public GameManager managerGame;

	private float _lastMoveTime;
	public Rigidbody _rigidbody;
	public int maxHealth = 100;
	public int currentHealth;
	public HealthBar healthBar;
	public GameObject _Finish;
	public AudioClip coinSound;
	public AudioClip knifeSound;


	private Vector3 moveTo;

	enum Lane
	{
		First,
		Second,
		Third
	}

	private Lane _lane = Lane.Second;



	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		
	}
    private void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }


    private void Update()
	{
		if (Input.touchCount > 0)
		{
			Touch touch = Input.touches[0];
			float movePow = touch.deltaPosition.normalized.x;
			if (Mathf.Abs(movePow) > _moveThreshold && Time.time - _lastMoveTime > 0.5f)
			{
				_lastMoveTime = Time.time;
				if (movePow < 0)
				{
					switch (_lane)
					{
						case Lane.First:
							break;
						case Lane.Second:
							moveTo = new Vector3(_firstLine, 0, transform.position.z);
							_lane = Lane.First;
							break;
						case Lane.Third:
							moveTo = new Vector3(_secondLine, 0, transform.position.z);
							_lane = Lane.Second;
							break;
					}
				}

				if (movePow > 0)
				{
					switch (_lane)
					{
						case Lane.First:
							moveTo = new Vector3(_secondLine, 0, transform.position.z);
							_lane = Lane.Second;
							break;
						case Lane.Second:
							moveTo = new Vector3(_thirdLine, 0, transform.position.z);
							_lane = Lane.Third;
							break;
						case Lane.Third:
							break;
					}
				}
			}
		}

		Move(moveTo);

	}

	private void FixedUpdate()
	{

		_rigidbody.velocity = transform.forward * (Time.deltaTime * _moveSpeed);
	}





	private void Move(Vector3 moveTo)
	{
		moveTo = new Vector3(moveTo.x, 0, transform.position.z);
		transform.position = Vector3.MoveTowards(transform.position, moveTo, Time.deltaTime * _speed);

	}
    private void OnTriggerEnter(Collider rotor)
    {
        if(rotor.gameObject.tag == "HealthDown")
        {
			TakeDamage(25);
			AudioSource.PlayClipAtPoint(knifeSound, transform.position);
		}
		if(rotor.gameObject.tag == "GoldCoin")
        {
			managerGame.UpdateScore();
			Destroy(rotor.gameObject);
			AudioSource.PlayClipAtPoint(coinSound, transform.position);
        }
		if (rotor.gameObject.tag == "FinishLane")
		{
			managerGame.CurrentGameState = GameManager.GameState.Finish;
		}
	}
	void TakeDamage(int damage)
    {
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
    }


}