using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollDeath : MonoBehaviour
{
    [SerializeField] private Animator animator = null;

    private Rigidbody[] ragdollBodies;
    private Collider[] ragdollColliders;

    // Start is called before the first frame update
    void Start()
    {
        ragdollBodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();

        ToggleRagdoll(false);
    }

    private void death(Vector3 positionOfHit)
    {
        ToggleRagdoll(true);
        foreach (Rigidbody item in ragdollBodies)
        {
            item.AddExplosionForce(78f, positionOfHit, 1f);
        }
        Invoke("DestroyObject", 6f);

    }

    private void DestroyObject()
    {
        Destroy(this.gameObject.transform.gameObject);

    }

    private void ToggleRagdoll (bool state)
    {
        animator.enabled = !state;
        foreach(Rigidbody rb in ragdollBodies)
        {
            rb.isKinematic = !state;
        }
        foreach (Collider collider in ragdollColliders)
        {
            collider.enabled = state;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
