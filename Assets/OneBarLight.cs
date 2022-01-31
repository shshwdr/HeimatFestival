using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RhythmHeavenMania.Games.Bar
{
    public class OneBarLight : MonoBehaviour
    {
        private Animator anim;
        private float showBeat = 0;
        private bool isShowing = false;
        private bool isRotating = false;
        private bool isRotatingReverse = false;

        private void Update()
        {
            if (Conductor.instance.isPlaying && !isShowing)
            {
                // anim.Play("AlienSwing", 0, Conductor.instance.loopPositionInAnalog * 2);
                //anim.speed = 0;
            }
            else if (!Conductor.instance.isPlaying)
            {
                //anim.Play("AlienIdle", 0, 0);
            }

            if (isShowing)
            {
                float normalizedBeat = Conductor.instance.GetLoopPositionFromBeat(showBeat, 1f);
                anim.Play("Show", 0, normalizedBeat);
                //anim.speed = 0;

                if (normalizedBeat >= 2)
                {
                    isShowing = false;
                }
            }
            else if (isRotating)
            {

                float normalizedBeat = Conductor.instance.GetLoopPositionFromBeat(showBeat, 1f);
                anim.Play("Rotate", 0, normalizedBeat);
                //anim.speed = 0;
                if (normalizedBeat >= 2)
                {
                    isRotating = false;
                }

            }
            else if (isRotatingReverse)
            {

                float normalizedBeat = Conductor.instance.GetLoopPositionFromBeat(showBeat, 1f);
                anim.Play("RotateReverse", 0, normalizedBeat);
                //anim.speed = 0;
                if (normalizedBeat >= 2)
                {
                    isRotatingReverse = false;
                }

            }
        }
        public void Show(float showBeat, int type)
        {
            switch (type)
            {
                case 0:

                    isShowing = true;
                    this.showBeat = showBeat;
                    break;
                case 1:
                    isRotating = true;
                    this.showBeat = showBeat;
                    break;
                case 2:
                    isRotatingReverse = true;
                    this.showBeat = showBeat;
                    break;
            }
        }
        // Start is called before the first frame update
        void Start()
        {

            anim = GetComponent<Animator>();
            anim.Play("AlienIdle", 0, 0);
        }

        // Update is called once per frame

    }
}