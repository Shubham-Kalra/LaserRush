using UnityEngine;

public class BuildManager : MonoBehaviour {


    // Singleton Pattern, To keep just a single BuildManager
    public static BuildManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }



    //public GameObject standardTurretPrefab;
    //public GameObject missleLauncherPrefab;
    //public GameObject laserBeamerPrefab;

    public GameObject buildEffect;

    //void Start()
    //{
    //    turretToBuild = standardTurretPrefab;
    //}

    private TurretBlueprint turretToBuild;

    //public GameObject getTurretToBuild()
    //{
    //    return turretToBuild;
    //}

    public bool canBuild { get { return turretToBuild != null; } }          // It can never be set. It's a property
    public bool hasMoney { get { return PlayerStats.money >= turretToBuild.Cost; } }

    public void selectTurretToBuild(TurretBlueprint turretBlueprint)
    {
        turretToBuild = turretBlueprint;
    }

    

    public void buildTurretOn(Node node)
    {
        // Build a turret
        // Using node script to to access this function
        // GameObject turretToBuild = getTurretToBuild();
        // turret = (GameObject)Instantiate(turretToBuild, , transform.rotation);

        if(PlayerStats.money < turretToBuild.Cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.money -= turretToBuild.Cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.getBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.getBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret built! Money left: " + PlayerStats.money);
    }
}
