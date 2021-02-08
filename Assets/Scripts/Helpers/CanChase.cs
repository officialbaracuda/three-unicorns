using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class CanChase : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    private Animator animator;
    private AudioSource audioSource;
    [SerializeField]
    private List<AudioClip> clips;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        target = GameObject.FindGameObjectWithTag(Constants.PLAYER).transform;
    }

    void Update()
    {
        if (ShouldChase())
        {
            Vector3 destination = target.position;
            agent.SetDestination(destination);

            if (agent.remainingDistance >= 0.5f)
            {
                animator.SetBool(Constants.IS_WALKING, true);
                int index = UnityEngine.Random.Range(0, clips.Count);
                audioSource.clip = clips[index];
                audioSource.Play();
            }
            else
            {
                animator.SetBool(Constants.IS_WALKING, false);
                audioSource.Stop();
            }
        }
        else
        {
            agent.SetDestination(transform.position);
            audioSource.Stop();
        }

        if (agent.velocity.magnitude <= 0.1f)
        {
            animator.SetBool(Constants.IS_WALKING, false);
            audioSource.Stop();
        }
    }

    private bool ShouldChase()
    {
        if (GameManager.Instance.IsGameRunning())
        {
            float distance = Vector3.Distance(transform.position, target.position);
            return distance < 4.0f;
        }
        return false;
    }

    public static event Action OnCatch;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Constants.PLAYER)
        {
            OnCatch?.Invoke();
        }
    }
}
