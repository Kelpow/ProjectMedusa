using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace EventHorizon {
	[System.Serializable]
	public class DirectorEvent{
		public string name;
		[SerializeField] [Multiline] string description;
		public UnityEvent actions;
		[Space(2f)]
		public float delay;

		public void Call()
		{
			Debug.Log ("Event Call: "+ name);
			actions.Invoke ();
		}

		//Constructors
		public DirectorEvent(string name, UnityEvent actions)
		{
			this.name = name;
			this.actions = actions;
			this.delay = 0f;
		}
	}

	[System.Serializable]
	public class Act{
		public string name;
		public DirectorEvent[] events;

		[HideInInspector] public int stage;

		public float Call()
		{
			Debug.Log ("Act Call: " + name);
			events [stage].Call ();
			return events [stage].delay;
		}

	}
}
