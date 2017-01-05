using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HashTablePresentation.Animations;
using HashTableLib;

namespace HashTablePresentation
{
    public partial class MainForm : Form
    {
        private HashMapView mapView;
        private HashMap<string, int> map;

        public MainForm()
        {
            map = new HashMap<string, int>(10) { MinimumSize = 2, MaximumSize = 30 };

            mapView = new HashMapView(map.Size);
            mapView.Location = new Point(-1, 50);
            mapView.Parent = this;

            InitializeComponent();

            MinimumSize = new Size(550, 400);
            Size bucketsSize = mapView.BucketsSize;
            ClientSize = new Size(mapView.BucketsLocation.X + bucketsSize.Width + 300,
                                  (mapView.BucketsLocation.Y << 1) + bucketsSize.Height + mapView.Top + statusStrip.Height + 2);

            Animator.AnimationComplete += this.Event_AnimationComplete;
            Animator.Enable(mapView);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            mapView.Size = new Size(ClientSize.Width + 2, ClientSize.Height - mapView.Top - statusStrip.Height + 1);
            base.OnSizeChanged(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Animator.Disable();
            base.OnFormClosed(e);
        }

        private void UpdateMapInfo()
        {
            labelBuckets.Text = mapView.Count.ToString();
            labelItems.Text = mapView.ItemCount.ToString();
            labelFactor.Text = mapView.LoadFactor.ToString("F3");
            labelBuckets.Invalidate();
            labelItems.Invalidate();
            labelFactor.Invalidate();
        }

        private void UpdateAnimationCount()
        {
            labelQueued.Text = Animator.Count.ToString();
            labelQueued.Invalidate();
        }

        private void UpdateAnimationInfo()
        {
            int count = Animator.Count;
            if (count > 0)
            {
                if (mapView.AutoScroll) mapView.AutoScroll = false;
                labelAnimation.Text = Animator.CurrentAnimation.ToString();
                labelAnimation.Visible = true;
                labelAnimation.Invalidate();
            }
            else
            {
                if (!mapView.AutoScroll) mapView.AutoScroll = true;
                labelAnimation.Visible = false;
                mapView.ResetLocations();
            }
        }

        private void AddAnimation(Action body)
        {
            bool first = (Animator.Count == 0);

            body();

            if (first) UpdateAnimationInfo();
            UpdateAnimationCount();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (AddItemForm form = new AddItemForm(map))
            {
                if(form.ShowDialog() == DialogResult.OK)
                {
                    AddAnimation(() =>
                    {
                        Animator.InsertItem(form.Key, form.Value);
                        if (form.MapResized) Animator.ResizeMap(map.Size);
                    });
                }
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            using (RemoveItemForm form = new RemoveItemForm(map))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    AddAnimation(() =>
                    {
                        Animator.RemoveItem(form.Key);
                        if (form.MapResized) Animator.ResizeMap(map.Size);
                    });
                }
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            using (SearchItemForm form = new SearchItemForm(map))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    AddAnimation(() =>
                    {
                        if (form.ValueChanged)
                            Animator.ChangeValueFor(form.Key, form.NewValue);
                        else Animator.SearchFor(form.Key);
                    });
                }
            }
        }

        private void buttonResize_Click(object sender, EventArgs e)
        {
            using (ResizeForm form = new ResizeForm(map))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    AddAnimation(() =>
                    {
                        Animator.ResizeMap(map.Size);
                    });
                }
            }
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            using (SettingsForm form = new SettingsForm(map))
            {
                if (form.ShowDialog() == DialogResult.OK && form.MapResized)
                {
                    AddAnimation(() =>
                    {
                        Animator.ResizeMap(map.Size);
                    });
                }
            }
        }

        private void checkPaused_CheckedChanged(object sender, EventArgs e)
        {
            Animator.Paused = checkPaused.Checked;
            if (Animator.Count > 0)
                mapView.AutoScroll = checkPaused.Checked;
        }

        private void Event_AnimationComplete(Animation animation)
        {
            UpdateAnimationInfo();
            UpdateAnimationCount();
            UpdateMapInfo();
        }

        private void boxSpeed_ValueChanged(object sender, EventArgs e)
        {
            Animator.Speed = (float)boxSpeed.Value;
        }
    }
}
