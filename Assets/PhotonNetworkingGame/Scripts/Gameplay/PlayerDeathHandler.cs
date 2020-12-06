using System.Collections;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particleSystemDeath;

    public void OnPlayerDead(Vector3 position)
    {
        var particleSystem = Instantiate(particleSystemDeath, position, Quaternion.identity, this.transform);
        particleSystem.gameObject.SetActive(true);
        StartCoroutine(WaitThenDestroy(particleSystem.gameObject));
    }

    private IEnumerator WaitThenDestroy(GameObject particleSystemInstance)
    {
        yield return new WaitForSeconds(1);
        Destroy(particleSystemInstance);
    }
}
