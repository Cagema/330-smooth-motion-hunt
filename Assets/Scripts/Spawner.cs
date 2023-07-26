using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] _prefabs;

    [SerializeField] bool _spawnInTime = true;
    float _timeSpent;

	private void FixedUpdate()
	{
		if (GameManager.Single.GameActive)
		{
			if (_spawnInTime)
			{
				_timeSpent += Time.deltaTime;
				if (_timeSpent > GameManager.Single.Interval)
				{
					_timeSpent = 0;

					Spawn();
				}
			}
		}
	}

	private void Spawn()
	{
		var newGO = Instantiate(_prefabs[Random.Range(0, _prefabs.Length)], SetPosition(), Quaternion.identity);
		newGO.transform.SetParent(transform, true);
	}

	private Vector3 SetPosition()
	{
		return new Vector3(Random.Range(-GameManager.Single.RightUpperCorner.x, GameManager.Single.RightUpperCorner.x),
            Random.Range(-GameManager.Single.RightUpperCorner.y, GameManager.Single.RightUpperCorner.y), 0);
	}
}
