using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // For Waypoint movement
    [SerializeField] float _speed;
    [SerializeField] float _waitTime;
    
    [Tooltip("How far till the Enemy sees the player")]
    [SerializeField] int _radius;

    [Tooltip("Players Transform so enemy will follow players location")]
    [SerializeField] Transform _playerTransform;
    [Tooltip("Path the Enemy will follow")]
    [SerializeField] Transform[] _waypoints;

    int _currentWaypointIndex = 0;


    private void Start()
    {
        StartCoroutine(Patrol());
    }

    //When next waypoint is reached loop and go to the next point
    IEnumerator Patrol()
    {
        Transform waypoint = _waypoints[_currentWaypointIndex];
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y); // Flips sprite
        while (Vector3.Distance(transform.position, waypoint.position) > 0.01f)
        {
            if (Vector3.Distance(transform.position, _playerTransform.position) <= _radius)
                transform.position = Vector3.MoveTowards(transform.position, waypoint.position, _speed * Time.deltaTime);
            yield return null;
        }

        transform.position = waypoint.position;

        yield return new WaitForSeconds(_waitTime);
        _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
        StartCoroutine(Patrol());
    }
}
