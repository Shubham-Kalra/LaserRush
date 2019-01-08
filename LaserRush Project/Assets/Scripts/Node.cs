using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor;

    private Renderer rend;
    private Color startColor;

    //[HideInInspector]
    //public GameObject turret;

    [Header("Optional")]
    public GameObject turret;
    //public GameObject[] preSetTurret;

    public Vector3 positionOffset;

    BuildManager buildManager;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.canBuild)
            return;

        if (buildManager.hasMoney)
        {
            rend.material.color = hoverColor;           // GetComponent<Renderer>().material.color = hoverColor;
        }                                               // In above way it finds component everytime but in the way used it finds it just once and stores it
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

    }                                               

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.canBuild)
            return;

        if(turret != null)
        {
            Debug.Log("Can't Build There! - TODO: Display on Screen");
            return;
        }

        buildManager.buildTurretOn(this);
    }

    public Vector3 getBuildPosition()
    {
        return transform.position + positionOffset;
    }
}
