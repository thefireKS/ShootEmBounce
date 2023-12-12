using UnityEngine;

namespace ShootEmBounce.Scripts.Contents
{
    public class Content : ScriptableObject
    {
        public Sprite contentPreview;
        [Multiline] public string contentDescription;
        public string contentName;
        public int price;
    }
}