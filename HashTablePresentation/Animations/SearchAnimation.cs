using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTablePresentation.Animations
{
    public class SearchAnimation : InsertAnimation
    {
        public SearchAnimation(ItemView keyView)
            : base(keyView)
        { }

        public override string ToString()
        {
            return "Searching <[Key: " + Item.Key.ToString() + "]>";
        }

        protected override void SetIndex()
        {
            ItemView targetItem = DestBucket.FindByKey(Item.Key);
            index = DestBucket.IndexOf(targetItem);
            Item.Size = targetItem.Size;
        }

        protected override void AnimationFinished()
        {
            Item.Parent = null;
        }
    }
}
