using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using HashTableLib;

namespace HashTablePresentation.Animations
{
    public static class Animator
    {
        private static Random rng;
        private static BackgroundWorker worker;
        private static LinkedList<Animation> queue;

        public static HashMapView View { get; private set; }

        private static float speed;
        public static float Speed
        {
            get { return speed; }
            set { speed = (value < 0.5f) ? 0.5f : (value > 25) ? 25 : value; }
        }

        public static bool Paused { get; set; }
        public static bool Enabled { get { return (worker != null); } }
        public static int Count { get { return queue.Count; } }
        public static Animation CurrentAnimation { get { return (Count > 0) ? queue.First.Value : null; } }

        static Animator()
        {
            Paused = false;
            worker = null;
            rng = new Random();
            queue = new LinkedList<Animation>();
            speed = 4;
        }

        public static Point HashPanelWaypoint
        {
            get
            {
                return new Point(View.HashPanelLocation.X + (View.HashPanelSize.Width >> 1),
                                 View.HashPanelLocation.Y + (View.HashPanelSize.Height >> 1));
            }
        }

        public static void Enable(HashMapView view)
        {
            Disable();
            View = view;
            worker = new BackgroundWorker() { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
            worker.DoWork += Event_Loop;
            worker.ProgressChanged += Event_NextFrameRequested;
            worker.RunWorkerCompleted += Event_Disabled;
            worker.RunWorkerAsync();
        }

        public static void Disable()
        {
            if (Enabled && worker.IsBusy)
                worker.CancelAsync();
        }

        public static event Action<Animation> AnimationComplete;

        public static void InsertItem(string key, int val)
        {
            ItemView item = new ItemView();
            item.ShowHash = true;
            item.Key = key;
            item.Value = val;
            item.ClientSize = new Size(item.TextSize.Width + 2, 45);
            item.ShowHash = false;

            item.Location = new Point(-item.Width, rng.Next(-item.Height, View.BucketsLocation.Y + View.BucketsSize.Height + 1));
            item.Parent = View;

            queue.AddLast(new InsertAnimation(item));
        }

        public static void RemoveItem(string key)
        {
            SearchFor(key);
            queue.AddLast(new RemoveAnimation(key));
        }

        public static void SearchFor(string key)
        {
            ItemView keyView = new ItemView();
            keyView.Key = key;
            keyView.Location = new Point(-keyView.Width, rng.Next(-keyView.Height, View.BucketsLocation.Y + View.BucketsSize.Height + 1));
            keyView.BackColor = Color.LightSkyBlue;
            keyView.Parent = View;

            queue.AddLast(new SearchAnimation(keyView));
        }

        public static void ChangeValueFor(string key, int newValue)
        {
            ItemView keyView = new ItemView();
            keyView.Key = key;
            keyView.Value = newValue;
            keyView.ClientSize = new Size(keyView.TextSize.Width + 2, 45);
            keyView.Location = new Point(-keyView.Width, rng.Next(-keyView.Height, View.BucketsLocation.Y + View.BucketsSize.Height + 1));
            keyView.BackColor = Color.LightSkyBlue;
            keyView.Parent = View;

            queue.AddLast(new ChangeValueAnimation(keyView));
        }

        public static void ResizeMap(int newSize)
        {
            queue.AddLast(new ResizeAnimation(newSize, rng));
        }

        private static void Event_Loop(object sender, DoWorkEventArgs e)
        {
            while (!worker.CancellationPending)
            {
                worker.ReportProgress(0);
                Thread.Sleep(15);
            }
        }

        private static void Event_NextFrameRequested(object sender, ProgressChangedEventArgs e)
        {
            if (!Paused && Count > 0)
            {
                Animation a = queue.First.Value;
                a.NextFrame();

                if (a.WorkFinished)
                {
                    queue.RemoveFirst();
                    if (AnimationComplete != null) AnimationComplete(a);
                }
            }
        }

        private static void Event_Disabled(object sender, RunWorkerCompletedEventArgs e)
        {
            worker.DoWork -= Event_Loop;
            worker.ProgressChanged -= Event_NextFrameRequested;
            worker.RunWorkerCompleted -= Event_Disabled;
            worker = null;
            View = null;
        }
    }
}
