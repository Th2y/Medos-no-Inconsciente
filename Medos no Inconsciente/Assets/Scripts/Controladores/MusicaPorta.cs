using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaPorta : MonoBehaviour
{
    public AudioSource musicaDuranteInimigo, pausarMusicaAntes;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            pausarMusicaAntes.Pause();
            musicaDuranteInimigo.Play();
            Destroy(this.gameObject);
        }
    }
}
