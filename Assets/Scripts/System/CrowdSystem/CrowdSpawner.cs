using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;
using UnityEngine.UI;

public class CrowdSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pingwinPrefab;
    private GameObject _player;
    private List<Transform> pointSpawn;
    private float countPointSpawn;

    public static CrowdSpawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InputController.Instance.endHold += EndDraw;
        _player = GameObject.FindWithTag("Player");
    }

    private void EndDraw()
    {
        List<Image> listSelected = InputController.Instance.GetHolders;
        pointSpawn = new List<Transform>();
        Transform mainMenu = InputController.Instance.GetMenu;

        for (int i = 0; i < listSelected.Count; ++i)
        {
            for (int j = 0; j < mainMenu.childCount; ++j)
            {
                if (listSelected[i].transform.Equals(mainMenu.GetChild(j)))
                {
                    pointSpawn.Add(_player.transform.GetChild(j));
                }
            }
        }

        countPointSpawn = pointSpawn.Count;
        
        SpawnCrowd();
    }

    private void SpawnCrowd()
    {
        foreach (var point in pointSpawn)
        {
            GameObject pingwin = Instantiate(pingwinPrefab);
            pingwin.transform.position = point.position;
            pingwin.transform.rotation = point.rotation;
            pingwin.transform.SetParent(point);
        }
        StartGameSystem.Instance.StartGame();
    }

    public void KilledCreature(Transform obj)
    {
        if (countPointSpawn > 0)
        {
            --countPointSpawn;
            pointSpawn.Remove(obj);
        }
        else
        {
            LoseSystem.Instance.Lose();
            _player.GetComponent<SplineFollower>().enabled = false;
        }
    }

    public void AddCreature()
    {
        for (int i = _player.transform.childCount - 1; i > -1; --i)
        {
            if (!pointSpawn.Contains(_player.transform.GetChild(i)))
            {
                Transform point = _player.transform.GetChild(i);
                pointSpawn.Add(point);
                GameObject pingwin = Instantiate(pingwinPrefab);
                pingwin.transform.position = point.position;
                pingwin.transform.rotation = point.rotation;
                pingwin.transform.SetParent(point);
                countPointSpawn = pointSpawn.Count;
                break;
            }
        }
    }
    
    
}
