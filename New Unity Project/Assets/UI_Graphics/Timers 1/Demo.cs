﻿using UnityEngine ;

public class Demo : MonoBehaviour {

   [SerializeField] Timer timer1 ;


   private void Start () {
      timer1
      .SetDuration (60)
      .OnEnd (() => Debug.Log ("Timer 1 ended"))
      .Begin () ;

   }

}
