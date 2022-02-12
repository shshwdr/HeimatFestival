using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;
using RhythmHeavenMania.Util;

namespace RhythmHeavenMania.Games.Bar
{
    public class BarMan : MonoBehaviour
    {
        private Animator anim;

        private int currentHitInList = 0;

        public int costume;

        public SpriteRenderer PlayerSprite;
        public List<SpriteSheet> PlayerSpriteSheets = new List<SpriteSheet>();

        [System.Serializable]
        public class SpriteSheet
        {
            public List<Sprite> sprites;
        }

        public static BarMan instance { get; set; }

        private void Awake()
        {
            instance = this;
        }
        NewPlayerInput PlayerInput;
        private void Start()
        {
            PlayerInput = GameObject.FindObjectOfType<NewPlayerInput>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Bar.instance.EligibleHits.Count == 0)
                currentHitInList = 0;

            if (PlayerInput.Pressed())
            {
                Swing(null,true);
                Jukebox.PlayOneShotGame("spaceball/swing");
            }
            else if (PlayerInput.AltPressed())
            {
                Swing(null,false); 
                Jukebox.PlayOneShotGame("spaceSoccer/highkicktoe1");
                
            }
        }

        public void SetCostume(int costume)
        {
            this.costume = costume;
            anim.Play("Idle", 0, 0);
        }

        public void Swing(BarDrink b, bool isOrigin = true)
        {
            if (b == null)
            {
               // Jukebox.PlayOneShotGame("spaceball/swing");
            }
            else
            {

                //if (b.type)
                //{
                //    Jukebox.PlayOneShotGame("spaceball/swing");
                //}
                //else
                //{
                //    Jukebox.PlayOneShotGame("spaceSoccer/highkicktoe1_hit");
                //}
            }
            if (isOrigin)
            {

                anim.Play("Swing", 0, 0);
            }
            else
            {

                anim.Play("SwingReverse", 0, 0);
            }
        }

        public void SetSprite(int id)
        {
            PlayerSprite.sprite = PlayerSpriteSheets[costume].sprites[id];
        }
    }
}