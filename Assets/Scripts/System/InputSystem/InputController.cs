using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    private List<Image> indexesMatrix;
    public static InputController Instance;
    [SerializeField] private Camera lineCamera;

    public Action<Vector3> hold;
    public Action endHold;
    private Transform mainMenu;
    
    void Awake()
    {
        Instance = this;
        indexesMatrix = new List<Image>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector2.zero);
            if (hit.collider != null)
            {
                mainMenu = hit.transform.parent;
                hold?.Invoke(lineCamera.ScreenToWorldPoint(Input.mousePosition));
                hit.transform.GetComponent<Image>().color = new Color(1, 0.1f, 0, 0.2f );
                Image img = hit.transform.GetComponent<Image>();
                if (!indexesMatrix.Contains(img))
                {
                    indexesMatrix.Add(img);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            endHold?.Invoke();
            foreach (var index in indexesMatrix)
            {
                index.color = new Color(1,1,1, 0.2f);
            }
            indexesMatrix.Clear();
        }
    }

    public Transform GetMenu => mainMenu;
    public List<Image> GetHolders => indexesMatrix;
}
