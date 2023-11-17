using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    [Header("Elements")]
    public AudioClip[] GunSounds;
    public AudioClip MeleeSound;

    public AudioSource PlayerAttack_AudioSource;

    public AudioSource Enemy_Attack_AudioSource;
    public AudioSource Enemy_Rise_AudioSource;
    public AudioSource Enemy_Die_AudioSource;

    public AudioClip EnemyRise_Clip, EnemyDie_Clip;
    public AudioClip[] EnemyAttack_Clip;

    public AudioSource Fence_Explosion_AudioSource;
    public AudioClip Fence_Explosion_Clip;

    void Awake()
    {
        MakeSingleton();
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void GunSound(int index)
    {
        PlayerAttack_AudioSource.PlayOneShot(GunSounds[index], 1.0f);
    }

    public void MeleeAttackSound()
    {
        PlayerAttack_AudioSource.PlayOneShot(MeleeSound, 1.0f);
    }

    public void ZombieRiseSound()
    {
        Enemy_Rise_AudioSource.PlayOneShot(EnemyRise_Clip, 1.0f);
    }

    public void ZombieDieSound()
    {
        Enemy_Die_AudioSource.PlayOneShot(EnemyDie_Clip, 1.0f);
    }

    public void ZombieAttackSound()
    {
        int index = Random.Range(0, EnemyAttack_Clip.Length);
        Enemy_Attack_AudioSource.PlayOneShot(EnemyAttack_Clip[index], 1.0f);
    }

    public void FenceExplosion()
    {
        Fence_Explosion_AudioSource.PlayOneShot(Fence_Explosion_Clip, 1.0f);
    }

} // class