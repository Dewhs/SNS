using System;
using System.Collections.Generic;
using System.Text;


using System.Threading.Tasks;
using Xamarin.Forms;
namespace SNS.Anim
{
    public static class ExtraAnimations
    {

        public static Task<bool> HeightTo(this VisualElement view, double Height, uint length = 250, Easing easing = null)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));

            return AnimateTo(view, view.HeightRequest, Height, nameof(HeightTo), (v, value) => v.HeightRequest = value, length, easing);
        }
        public static Task<bool> WidthTo(this VisualElement view, double Width, uint length = 250, Easing easing = null)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));

            return AnimateTo(view, view.WidthRequest, Width, nameof(WidthTo), (v, value) => v.WidthRequest = value, length, easing);
        }
        static Task<bool> AnimateTo(this VisualElement view, double start, double end, string name,
            Action<VisualElement, double> updateAction, uint length = 250, Easing easing = null)
        {
            if (easing == null)
                easing = Easing.Linear;

            var tcs = new TaskCompletionSource<bool>();

            var weakView = new WeakReference<VisualElement>(view);

            void UpdateProperty(double f)
            {
                if (weakView.TryGetTarget(out VisualElement v))
                {
                    updateAction(v, f);
                }
            }

            new Animation(UpdateProperty, start, end, easing).Commit(view, name, 16, length, finished: (f, a) => tcs.SetResult(a));

            return tcs.Task;

        }
    }
}
