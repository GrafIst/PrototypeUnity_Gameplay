using UnityEngine ;

public class Demo : MonoBehaviour {

   [SerializeField] Timer timer1 ;
    //[SerializeField] Timer timer2 ;
    //[SerializeField] Timer timer3;
    //[SerializeField] Timer timer4;


    private void Start () {
      timer1.SetDuration(20).OnEnd (() => Debug.Log ("Timer 1 ended")).Begin () ;
     
    }


}
