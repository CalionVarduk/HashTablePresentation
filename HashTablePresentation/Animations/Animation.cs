using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTablePresentation.Animations
{
    public abstract class Animation
    {
        private sbyte done;
        public bool IsPreparing { get { return (done < 0); } }
        public bool InProgress { get { return (done == 0); } }
        public bool AnimationDone { get { return (done > 0); } }
        public bool WorkFinished { get { return (done > 1); } }

        protected Animation()
        {
            done = -1;
        }

        public void NextFrame()
        {
            if (!WorkFinished)
            {
                if(IsPreparing)
                {
                    Start();
                    done = 0;
                }
                else if (InProgress) PerformNextFrame();
                else
                {
                    AnimationFinished();
                    done = 2;
                }
            }
        }

        protected abstract void Start();
        protected abstract void PerformNextFrame();
        protected abstract void AnimationFinished();

        protected void AnimationIsDone()
        {
            done = 1;
        }
    }
}
