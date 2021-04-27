using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.scripts
{
    public class TimeScaledObjects : MonoBehaviour
    {


        #region time scale
        public enum Status
        {
            Normal,
            Slowed
        };
        public Status status = Status.Normal;
        [Range(0f, 100f)]
        public float slowedTimeScale = 50f;

        private bool timedSlowMotion = true;
        private bool wasSlowed = false;
        public float slowTimer = 0; // in sec
        int skippedFrames = 1;

        // Update is called once per frame
        void Update()
        {
            if (status == Status.Normal)
            {
                play();
            }
            else if (status == Status.Slowed)
            {
                if (timedSlowMotion)
                {
                    //reduce the slowTimer
                    if (wasSlowed)
                        slowTimer -= Time.deltaTime;
                    wasSlowed = true;
                    if (slowTimer < 0)
                    {
                        slowTimer = 0;
                        wasSlowed = false;
                        status = Status.Normal;
                    }
                }
            
                //slow the object
                float decimalPercent = slowedTimeScale / 100;
                //Debug.Log($" f {decimalPercent}, count {skippedFrames}");
                if(skippedFrames * decimalPercent >= 1)
                {
                    skippedFrames = 1;
                    play();
                }
                else
                {
                    skippedFrames++;
                }
            }
            
        }
        #endregion

        int accelaration = 1;
        Vector3 deplacement = new Vector3(0, 0, 1);
        private void play()
        {
            //usual comportement
            transform.Translate(deplacement * accelaration * Time.deltaTime);
            if (accelaration < 30 && Time.frameCount % 30 == 0)
                accelaration++;
        }

        public void setStatus(Status state)
        {
            status = state;
        }
    }
}