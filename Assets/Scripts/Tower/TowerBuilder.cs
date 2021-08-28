using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float _levelCount;
    [SerializeField] private GameObject _beam;
    [SerializeField] private StartPlatform _startPlatform;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private Platform[] _platforms;
    [SerializeField] private Transform _spawnPoint;

    private float _beamHeight = 4;
    private float _beamEnd = 1.5f;
    private float _beamScale => _levelCount/2 * _beamEnd + _beamHeight/2 ;


    private void Awake()
    {
        Build();
    }

    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, _beamScale, 1);

        Vector3 Position = beam.transform.position;
        Position.y = beam.transform.localScale.y - _beamHeight + _beamEnd;

        SpawnPlatform(_startPlatform, ref Position, _spawnPoint);

        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)], ref Position, _spawnPoint);
        }

        SpawnPlatform(_finishPlatform, ref Position, _spawnPoint);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 position, Transform parent)
    {
        Instantiate(platform, position, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        position.y -= 1.5f;
    }

}
