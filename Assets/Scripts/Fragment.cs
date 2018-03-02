using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Fragment")]
public class Fragment : ScriptableObject {

	public enum Category { Character, Location, Event, Date, Argument }

    [System.Serializable]
    public struct Phrase
    {
        public Category categoria;
        public string contenido;
    }


    public Phrase[] Contenido;
}
