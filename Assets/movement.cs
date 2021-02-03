using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Animator animator;
    [SerializeField] GameObject[] skillParticles;
    private IEnumerator coroutine;
    [SerializeField] AudioClip[] skillsAudioclips;
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        for(int i=0; i < skillParticles.Length; i++)
        {
            skillParticles[i].SetActive(false);
        }
    }

    void Update()
    {
        animator.SetFloat("vertical", Input.GetAxis("Vertical"));
        animator.SetFloat("horizontal", Input.GetAxis("Horizontal"));
        if (Input.GetKeyUp(KeyCode.Space)) Jump();
        if (Input.GetKeyUp(KeyCode.Alpha1)) UseSkill(1);
        if (Input.GetKeyUp(KeyCode.Alpha2)) UseSkill(2);
        if (Input.GetKeyUp(KeyCode.Alpha3)) UseSkill(3);
        if (Input.GetKeyUp(KeyCode.Alpha4)) UseSkill(4);

    }

    public void UseSkill(int skillNumber)
    {
        animator.SetTrigger("Spell" + skillNumber);
        skillParticles[skillNumber - 1].SetActive(true);
        audioSource.clip = skillsAudioclips[skillNumber - 1];
        audioSource.Play();
        switch (skillNumber)
        {
            case 1:
                coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 4.267f);
                break;
            case 2:
                coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 2.167f);
                break;
            case 3:
                coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 2.7f);
                break;
            case 4:
                coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 3.533f);
                break;
        }

        coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 2);
        StartCoroutine(coroutine);
    }

    IEnumerator WaitToEnableObject(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
    }

    public void Jump()
    {
        animator.SetTrigger("Jump");
    }
}
