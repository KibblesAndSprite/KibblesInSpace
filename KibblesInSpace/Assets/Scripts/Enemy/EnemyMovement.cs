using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] float _speed;
    [SerializeField] float _waitTime;

    [Tooltip("How far till the Enemy sees the player")]
    [SerializeField] int _radius;

    [Tooltip("Players Transform so enemy will follow players location")]
    [SerializeField] Transform _playerTransform;
    [Tooltip("Path the Enemy will follow")]
    [SerializeField] Transform[] _waypoints;

    int _currentWaypointIndex = 0;


}
