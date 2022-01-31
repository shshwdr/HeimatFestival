using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RhythmHeavenMania.Games.Bar
{
    public class BarLight : MonoBehaviour
    {
        OneBarLight[] childs;
        private void Awake()
        {
            childs = GetComponentsInChildren<OneBarLight>();
        }
        public void Show(float showBeat, int type, int index)
        {
            if (index != -1)
            {
                childs[index].Show(showBeat, type);
            }
            else
            {
                foreach(var child in childs)
                {
                    child.Show(showBeat, type);
                }
            }
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}