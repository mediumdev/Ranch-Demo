using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    CsGlobals gl;

    public GameObject ground;
    public GameObject sheep;
    public GameObject health;
    public GameObject slowMotion;
    public List<GameObject> buildings;

    float tractorZTmp = 0f;
    float interval = 600f;

    void Awake()
    {
        gl = FindObjectOfType(typeof(CsGlobals)) as CsGlobals;

        AddGround();
    }

    void Update()
    {
        int posZ = (int)(gl.TRACTOR.transform.position.z);
        int trcLen = (posZ / (int)(gl.GROUND_SIZE)) + 2;
        if (trcLen > gl.TRACK_LENGTH)
        {
            AddGround();
        }

        if (gl.TRACTOR.transform.position.z > tractorZTmp + interval * Time.deltaTime)
        {
            tractorZTmp = gl.TRACTOR.transform.position.z;
            Generate();
        }
    }
    public void Generate(float ZOffset = 50, float ZLength = 5f, int build_count = 2, int sheep_count = 2)
    {
        while (build_count > 0)
        {
            int rndBuild = Random.Range(0, buildings.Count);
            GameObject build = Instantiate(buildings[rndBuild]);
            float rndDeg = Random.Range(0f, 360f);
            build.transform.rotation = Quaternion.Euler(0, rndDeg, 0);
            float rndX = Random.Range(-7.7f, 7.7f);
            float rndZ = Random.Range(gl.TRACTOR.transform.position.z + ZOffset - ZLength, gl.TRACTOR.transform.position.z + ZOffset + ZLength);
            build.transform.position = new Vector3(rndX, 0, transform.position.z + rndZ);
            build_count--;
        }

        while (sheep_count > 0)
        {
            GameObject shp = Instantiate(sheep);
            float rndDegS = Random.Range(0f, 360f);
            shp.transform.rotation = Quaternion.Euler(0, rndDegS, 0);
            float rndXS = Random.Range(-7.7f, 7.7f);
            float rndZS = Random.Range(gl.TRACTOR.transform.position.z + ZOffset - ZLength, gl.TRACTOR.transform.position.z + ZOffset + ZLength);
            shp.transform.position = new Vector3(rndXS, 2.5f, transform.position.z + rndZS);
            sheep_count--;
        }

        int hpProb = Random.Range(0, 10);
        if (hpProb == 0)
        {
            GameObject hp = Instantiate(health);
            float rndDegHp = Random.Range(0f, 360f);
            hp.transform.rotation = Quaternion.Euler(0, rndDegHp, 0);
            float rndXHp = Random.Range(-7.7f, 7.7f);
            float rndZHp = Random.Range(gl.TRACTOR.transform.position.z + ZOffset - ZLength, gl.TRACTOR.transform.position.z + ZOffset + ZLength);
            hp.transform.position = new Vector3(rndXHp, 2.5f, transform.position.z + rndZHp);
        }

        int smProb = Random.Range(0, 40);
        if (smProb == 0)
        {
            GameObject sm = Instantiate(slowMotion);
            float rndDegSm = Random.Range(0f, 360f);
            sm.transform.rotation = Quaternion.Euler(0, rndDegSm, 0);
            float rndXSm = Random.Range(-7.7f, 7.7f);
            float rndZSm = Random.Range(gl.TRACTOR.transform.position.z + ZOffset - ZLength, gl.TRACTOR.transform.position.z + ZOffset + ZLength);
            sm.transform.position = new Vector3(rndXSm, 2.5f, transform.position.z + rndZSm);
        }
    }

    void AddGround()
    {
        GameObject grnd = Instantiate(ground, transform);
        grnd.transform.position = new Vector3(0, 0, gl.TRACK_LENGTH * gl.GROUND_SIZE - 50);
        gl.TRACK_LENGTH++;
    }
}
