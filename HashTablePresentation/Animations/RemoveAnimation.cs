using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HashTablePresentation.Animations
{
    public class RemoveAnimation : Animation
    {
        private float virtItemLeft;
        private float virtBucketLeft;
        private int itemWaypoint;
        private int bucketWaypoint;
        private bool itemMoveDone;
        private bool bucketMoveDone;
        private int index;
        private string key;

        public ItemView Item { get; protected set; }
        public BucketView DestBucket { get; private set; }

        public RemoveAnimation(string key)
            : base()
        {
            this.key = key;
            itemMoveDone = false;
        }

        public override string ToString()
        {
            return "Removing <[Key: " + key + "]>";
        }

        protected override void Start()
        {
            int hash = key.GetHashCode() % Animator.View.Count;
            if (hash < 0) hash += Animator.View.Count;

            DestBucket = Animator.View[hash];
            Item = DestBucket.FindByKey(key);
            index = DestBucket.IndexOf(Item) + 1;

            virtItemLeft = (float)Item.Left;
            itemWaypoint = DestBucket.Left - Item.Width - 10;

            if (index < DestBucket.Count)
            {
                virtBucketLeft = (float)DestBucket.PreferredItemLeft(index);
                bucketWaypoint = Item.Left;
                bucketMoveDone = false;
            }
            else bucketMoveDone = true;
        }

        protected override void PerformNextFrame()
        {
            float speed = Animator.Speed;

            if (!itemMoveDone) MoveItem(speed);
            if (!bucketMoveDone) MoveSuccessors(speed);

            if (itemMoveDone && bucketMoveDone)
                AnimationIsDone();
        }

        private void MoveItem(float speed)
        {
            virtItemLeft -= speed;
            Item.Left = (int)(virtItemLeft + 0.5f);

            if (Item.Left <= itemWaypoint)
            {
                Item.Left = itemWaypoint;
                Item.Visible = false;
                itemMoveDone = true;
            }
        }

        private void MoveSuccessors(float speed)
        {
            virtBucketLeft -= speed * 0.5f;
            DestBucket[index].Left = (int)(virtBucketLeft + 0.5f);

            if (DestBucket[index].Left <= bucketWaypoint)
            {
                DestBucket[index].Left = bucketWaypoint;
                bucketMoveDone = true;
            }

            int count = DestBucket.Count;
            for (int i = index + 1; i < count; ++i)
                DestBucket[i].Left = DestBucket[i - 1].Right - 1;
        }

        protected override void AnimationFinished()
        {
            DestBucket.RemoveItem(Item);
        }
    }
}
