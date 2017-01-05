using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HashTablePresentation.Animations
{
    public class InsertAnimation : Animation
    {
        private PointF virtLoc;
        private PointF vector;
        private Point[] waypoints;
        private int iWaypoint;
        private int hashWait;
        private int hashWaitDone;
        private sbyte moveLeft;
        private sbyte moveUp;
        protected int index;

        public ItemView Item { get; protected set; }
        public BucketView DestBucket { get; private set; }

        public InsertAnimation(ItemView item)
            : base()
        {
            Item = item;
            Item.Visible = false;
        }

        public override string ToString()
        {
            return "Inserting <[Key: " + Item.Key.ToString() + "] => [Value: " + Item.Value.ToString() + "]>";
        }

        protected virtual void SetIndex()
        {
            index = DestBucket.Count;
        }

        protected override void Start()
        {
            DestBucket = Animator.View.BucketOf(Item);
            Item.Height = DestBucket.PreferredItemHeight;

            SetIndex();

            Item.Visible = true;
            Item.BringToFront();

            hashWait = 0;
            hashWaitDone = (int)(125 / Animator.Speed + 0.5f);

            iWaypoint = 0;
            waypoints = new Point[4];
            waypoints[0] = Animator.HashPanelWaypoint;
            waypoints[0].X -= (Item.Width >> 1);
            waypoints[0].Y -= (Item.Height >> 1);
            waypoints[1] = new Point(DestBucket.Left - Item.Width - 10, waypoints[0].Y);
            waypoints[2] = new Point(waypoints[1].X, DestBucket.PreferredItemTop);
            waypoints[3] = new Point(DestBucket.PreferredItemLeft(index), waypoints[2].Y);

            virtLoc = (PointF)Item.Location;
            CalcVector();
        }

        protected override void PerformNextFrame()
        {
            float speed = Animator.Speed;

            if (iWaypoint == 1)
            {
                hashWaitDone = (int)(125 / speed + 0.5f);
                if (WaitForHash()) return;
            }

            virtLoc.X += vector.X * speed;
            virtLoc.Y += vector.Y * speed;

            if (IsHorizontalMoveOk() && IsVerticalMoveOk())
                UpdateItemLocation();
            else NextWaypoint();
        }

        private bool WaitForHash()
        {
            if (hashWait <= hashWaitDone)
            {
                ++hashWait;
                return true;
            }
            else hashWait = int.MaxValue;
            return false;
        }

        private void UpdateItemLocation()
        {
            Item.Location = new Point((int)(virtLoc.X + 0.5f), (int)(virtLoc.Y + 0.5f));
        }

        private void NextWaypoint()
        {
            Item.Location = waypoints[iWaypoint];
            virtLoc = (PointF)Item.Location;

            if (++iWaypoint < 4)
            {
                if (iWaypoint == 1)
                {
                    Item.ShowHash = true;
                    Item.Refresh();
                }
                CalcVector();
            }
            else AnimationIsDone();
        }

        protected override void AnimationFinished()
        {
            waypoints = null;
            DestBucket.AddItem(Item);
        }

        private void CalcVector()
        {
            float dx = waypoints[iWaypoint].X - Item.Left;
            float dy = waypoints[iWaypoint].Y - Item.Top;
            float l = (float)Math.Sqrt((dx * dx) + (dy * dy));
            vector.X = dx / l;
            vector.Y = dy / l;
            moveLeft = (sbyte)((dx < 0) ? -1 : (dx > 0) ? 1 : 0);
            moveUp = (sbyte)((dy < 0) ? -1 : (dy > 0) ? 1 : 0);
        }

        private bool IsHorizontalMoveOk()
        {
            return (moveLeft * (waypoints[iWaypoint].X - virtLoc.X) >= 0);
        }

        private bool IsVerticalMoveOk()
        {
            return (moveUp * (waypoints[iWaypoint].Y - virtLoc.Y) >= 0);
        }
    }
}
