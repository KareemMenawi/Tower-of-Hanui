using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int diskCount;

    [SerializeField] private Pole polePrefab;
    [SerializeField] private Disc discPrefab;

    [SerializeField] private Vector3 _discOffset;
    private Pole[] _poles;

    [SerializeField] private float poleSpacing;
    [SerializeField][Range(0.1f, 2f)] private float diskScaling;

    public Vector3 DiskOffset 
    {
        get => _discOffset;
        private set => _discOffset = value;
    }

    public Pole[] Poles
    {
        get => _poles;
        private set => _poles = value;
    }

    public virtual void Awake()
    {
        Poles = new Pole[3];
        for (int i = 0; i<3; i++)
        {
            Poles[i] = Instantiate(polePrefab);
            Poles[i].transform.position = (4 + poleSpacing) * i * Vector3.right;
        }
    }
    private void Start()
    {
        SpawnDiscs(); 
    }

    private void SpawnDiscs()
    {
        for (int i = 0; i < diskCount; i++)
        {
            Disc disc = Instantiate(discPrefab, Poles[0].transform);
            disc.Scale = 4 - i * diskScaling;
            disc.Size = i;
            Poles[0].PutDisk(disc);
        }
    }

}
