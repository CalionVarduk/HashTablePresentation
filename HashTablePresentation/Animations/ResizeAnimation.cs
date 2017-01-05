using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using HashTableLib;

namespace HashTablePresentation.Animations
{
    public class ResizeAnimation : Animation
    {
        private LinkedList<InsertAnimation> queue;
        private Random rng;
        private HashMapView view;
        private ItemView[] items;
        private BucketView[] buckets;
        private float[] virtLefts;
        private int sizeChange;
        private byte phase;
        private int itemWaypoint;
        private int oldCount;
        private int newCount;

        public ResizeAnimation(int newSize, Random rng)
        {
            this.rng = rng;
            newCount = newSize;
            sizeChange = 0;
            phase = 0;
        }

        public override string ToString()
        {
            return "Resizing <[New Size: " + newCount.ToString() + "]>";
        }

        protected override void Start()
        {
            view = Animator.View;
            oldCount = view.Count;

            items = view.ItemArray();
            virtLefts = new float[items.Length];
            for (int i = 0; i < items.Length; ++i)
                virtLefts[i] = (float)items[i].Left;

            sizeChange = newCount - oldCount;

            if (sizeChange < 0)
                PrepareForSizeDecreased();
            else PrepareForSizeIncreased();

            itemWaypoint = buckets[0].Left - 10;
        }

        private void PrepareForSizeDecreased()
        {
            buckets = new BucketView[oldCount];
            for (int i = 0; i < oldCount; ++i)
                buckets[i] = view[i];

            view.Count = newCount;
            for (int i = newCount; i < oldCount; ++i)
                buckets[i].Parent = view;
        }

        private void PrepareForSizeIncreased()
        {
            int y = view.BucketsLocation.Y + view.BucketsSize.Height + view.BucketSpacing;

            view.Count = newCount;
            buckets = new BucketView[newCount];
            for (int i = 0; i < newCount; ++i)
                buckets[i] = view[i];

            for (int i = oldCount; i < newCount; ++i)
            {
                buckets[i].Location = new Point(-buckets[i].Width - 10, y);
                y += buckets[i].Height + view.BucketSpacing;
            }
        }

        protected override void PerformNextFrame()
        {
            float speed = Animator.Speed;

            if (phase == 0) RemoveAllItems(speed);
            else if (phase == 1) MoveBuckets(speed);
            else NextItemInsertFrame();
        }

        private void RemoveAllItems(float speed)
        {
            int itemsDone = 0;

            for (int i = 0; i < items.Length; ++i)
            {
                ItemView item = items[i];
                if (item.Visible)
                {
                    if (item.Right < itemWaypoint)
                    {
                        item.Visible = false;
                        ++itemsDone;
                    }
                    else
                    {
                        virtLefts[i] -= speed;
                        item.Left = (int)(virtLefts[i] + 0.5f);
                    }
                }
                else ++itemsDone;
            }

            if (itemsDone == items.Length)
                AllItemsAreRemoved();
        }

        private void AllItemsAreRemoved()
        {
            for (int i = 0; i < buckets.Length; ++i)
                buckets[i].Clear();

            view.Controls.AddRange(items);

            virtLefts = new float[1];
            if (sizeChange < 0)
            {
                virtLefts[0] = (float)buckets[0].Left;
                view.ResetHashPanelBounds();
            }
            else virtLefts[0] = (float)buckets[oldCount].Left;
            ++phase;
        }

        private void MoveBuckets(float speed)
        {
            if (sizeChange < 0)
                MoveRemovedBuckets(speed);
            else MoveAddedBuckets(speed);

            if (phase == 2)
                PrepareItemsForInserting();
        }

        private void MoveRemovedBuckets(float speed)
        {
            virtLefts[0] -= speed * 1.5f;
            int left = (int)(virtLefts[0] + 0.5f);

            for (int i = newCount; i < oldCount; ++i)
                buckets[i].Left = left;

            if (buckets[newCount].Right < -10)
            {
                for (int i = newCount; i < oldCount; ++i)
                    buckets[i].Parent = null;
                ++phase;
            }
        }

        private void MoveAddedBuckets(float speed)
        {
            virtLefts[0] += speed * 1.5f;
            int left = (int)(virtLefts[0] + 0.5f);

            for (int i = oldCount; i < newCount; ++i)
                buckets[i].Left = left;

            if (buckets[oldCount].Left >= view.BucketsLocation.X)
            {
                for (int i = oldCount; i < newCount; ++i)
                    buckets[i].Left = view.BucketsLocation.X;
                ++phase;
            }
        }

        private void PrepareItemsForInserting()
        {
            if (sizeChange > 0) view.ResetHashPanelBounds();
            int maxY = view.BucketsLocation.Y + view.BucketsSize.Height + 1;

            queue = new LinkedList<InsertAnimation>();

            for (int i = 0; i < items.Length; ++i)
            {
                ItemView item = items[i];
                item.Location = new Point(-item.Width, rng.Next(-item.Height, maxY));
                item.ShowHash = false;
                item.Visible = true;
                queue.AddLast(new InsertAnimation(item));
            }
        }

        private void NextItemInsertFrame()
        {
            if (queue.Count > 0)
            {
                queue.First.Value.NextFrame();
                if (queue.First.Value.WorkFinished)
                    queue.RemoveFirst();
            }
            else AnimationIsDone();
        }

        protected override void AnimationFinished()
        {
            items = null;
            buckets = null;
        }
    }
}
