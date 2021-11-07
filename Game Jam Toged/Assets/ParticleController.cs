using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public PlayerMovements player;
    public ParticleSystem particleBlood;

    void Start()
    {
        particleBlood = GetComponentInChildren<ParticleSystem>();
        StartCoroutine(CheckPlayerIsBleeding());

    }
    public void BloodParticle()
    {
        StartCoroutine(CheckPlayerIsBleeding());
    }
    public void StopBloodParticle()
    {
        StopCoroutine(StartBleeding());
    }

    IEnumerator StartBleeding()
    {
        particleBlood.transform.position = player.transform.position + new Vector3(0, 2f, 0);
        particleBlood.Play();
        yield return new WaitForSeconds(5);
        StartCoroutine(CheckPlayerIsBleeding());
    }

    IEnumerator CheckPlayerIsBleeding()
    {
        if (player.isPlayerBleeding)
        {
            StartCoroutine(StartBleeding());
            yield return new WaitForSeconds(2);
        }
        else
        {
            yield return new WaitForSeconds(2);
            StartCoroutine(CheckPlayerIsBleeding());
        }
    }
}
