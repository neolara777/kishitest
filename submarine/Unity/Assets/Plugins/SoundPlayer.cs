using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundPlayer {
	
	GameObject soundPlayerObj;
	AudioSource audioSource;
	Dictionary<string, AudioClipInfo> audioClips = new Dictionary<string, AudioClipInfo>();
	
	// AudioClip information
	class AudioClipInfo {
		public string resourceName;
		public string name;
		public AudioClip clip;
		
		public AudioClipInfo( string resourceName, string name ) {
			this.resourceName = resourceName;
			this.name = name;
		}
	}
	
	public SoundPlayer() {
		audioClips.Add( "ex", new AudioClipInfo( "ex", "ex" ) );
		audioClips.Add( "top", new AudioClipInfo( "top", "top" ) );
		audioClips.Add( "fire", new AudioClipInfo( "fire", "fire" ) );
	}
	
	public bool playSE( string seName ) {
		if ( audioClips.ContainsKey( seName ) == false )
			return false; // not register
		
		AudioClipInfo info = audioClips[ seName ];
		
		// Load
		if ( info.clip == null )
			info.clip = (AudioClip)Resources.Load( info.resourceName );
		
		if ( soundPlayerObj == null ) {
			soundPlayerObj = new GameObject( "SoundPlayer" ); 
			audioSource = soundPlayerObj.AddComponent<AudioSource>();
		}
		
		// Play SE
		audioSource.PlayOneShot( info.clip );
		
		return true;
	}
}