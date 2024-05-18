using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class AttackPatterns : MonoBehaviour
{

    public int numOrbsPerArm, numArms;
    public float orbSpeed;
    public GameObject orbPrefab;

    private bool activateAttack1;
    private int numOrb;

    void Start()
    {
        StartCoroutine(AttackPatterns1());
    }

    Vector2 Spriral(float angle, float curl, float phase)
    {
        float Q = angle * Mathf.Deg2Rad;
        float F = phase * Mathf.Deg2Rad;
        float X = Q * Mathf.Cos(curl * Q + F);
        float Y = Q * Mathf.Sin(curl * Q + F);
        return new Vector2(X, Y);
    }

    void GenerateWave()
    {
        float angleInterval = 90f;
        float phaseInterval = 360f;

        for (int j = 0; j < numArms; j++)
        {
            float angle = numOrb * angleInterval / numOrbsPerArm;
            float beta = j * phaseInterval / numArms;
            Vector3 position = Spriral(angle, 2f / 3f, beta);
            Quaternion rotation = Quaternion.identity;
            GameObject orb = Instantiate(orbPrefab, position, rotation);
            orb.GetComponent<OrbBehaviour>().delayTime = 1f;
            orb.GetComponent<OrbBehaviour>().emissionVelocity = orbSpeed * (transform.forward);
            Destroy(orb, 10f);
        }
        numOrb++;
        if (numOrb == numOrbsPerArm)
        {
            activateAttack1 = false;
            numOrb = 0;
        }
    }

    private IEnumerator AttackPatterns1()
    {
        while (true)
        {
            if (activateAttack1)
            {
                Debug.Log("pew!");
                GenerateWave();
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && numOrb == 0 && !activateAttack1)
        {
            activateAttack1 = true;
        }
    }
}
