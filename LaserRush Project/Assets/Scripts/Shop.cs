using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    public TurretBlueprint StandardTurret;
    public TurretBlueprint MissleLauncher;
    public TurretBlueprint LaserBeamer;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void selectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.selectTurretToBuild(StandardTurret);
    }
    public void selectMissleLauncher()
    {
        Debug.Log("Missle Launcher Selected");
        buildManager.selectTurretToBuild(MissleLauncher);
    }
    public void selectLaserBeamer()
    {
        Debug.Log("Laser Beamer Selected");
        buildManager.selectTurretToBuild(LaserBeamer);
    }
}
