using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTablePresentation.Animations
{
    public class ChangeValueAnimation : SearchAnimation
    {
        private ItemView target;

        public ChangeValueAnimation(ItemView keyView)
            : base(keyView)
        { }

        public override string ToString()
        {
            return "Changing Value <[Key: " + Item.Key.ToString() + "] => [New Value: " + Item.Value.ToString() + "]>";
        }

        protected override void SetIndex()
        {
            target = DestBucket.FindByKey(Item.Key);
            index = DestBucket.IndexOf(target);
        }

        protected override void AnimationFinished()
        {
            base.AnimationFinished();
            target.Value = Item.Value;
            target.ClientSize = new System.Drawing.Size(target.TextSize.Width + 2, target.ClientSize.Height);
            DestBucket.ResetItemsBounds();
        }
    }
}
