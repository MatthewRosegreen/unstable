using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteController : MonoBehaviour
{
    private float elapsedTime;
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0;
        //_audioSource = GetComponent<AudioSource>();
        //var _fizzleResource = Resources.Load<AudioClip>("Sounds/fizzle");
       // _audioSource.clip = _fizzleResource;
		//_audioSource.PlayOneShot(_fizzleResource, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += (Time.deltaTime);
        if (elapsedTime > 3){
            Destroy(this.gameObject);
        }
    }
}
