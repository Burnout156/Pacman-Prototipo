using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject particula;

    // Start is called before the first frame update
    void Start()
    {
        if(particula == null)
        {
            particula = transform.GetChild(0).gameObject;
        }

        particula.SetActive(false);
    }

    public void ActivateParticle()
    {
        particula.SetActive(true);
        particula.GetComponent<ParticleSystem>().Simulate(0.0f, true, true);
        particula.GetComponent<ParticleSystem>().Play();
    }

    public IEnumerator DelayToDestroy()
    {
        ActivateParticle();
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }
}
