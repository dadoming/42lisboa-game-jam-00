using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameplayMusic : MonoBehaviour
{

	public PlayableDirector playableDirector = null;

    void Start()
    {
		if (playableDirector != null)
			playableDirector.Play();
    }

    void Update()
    {

    }
}
