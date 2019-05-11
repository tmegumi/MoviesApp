using System;
using System.Collections;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoviesApp.Behaviors
{
    public class InfiniteScroll : Behavior<ListView>
    {
        public static readonly BindableProperty LoadMoreCommandProperty = 
            BindableProperty.Create("LoadMoreCommand", typeof(ICommand), typeof(InfiniteScroll));

        public ICommand LoadMoreCommand
        {
            get => (ICommand)GetValue(LoadMoreCommandProperty);
            set => SetValue(LoadMoreCommandProperty, value);
        }

        public ListView AssociatedObject
        {
            get;
            private set;
        }

        protected override void OnAttachedTo(ListView listView)
        {
            base.OnAttachedTo(listView);
            AssociatedObject = listView;
            listView.BindingContextChanged += Bindable_BindingContextChanged;
            listView.ItemAppearing += InfiniteListView_ItemAppearing;
        }

        private void Bindable_BindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }

        protected override void OnDetachingFrom(ListView listView)
        {
            base.OnDetachingFrom(listView);
            listView.BindingContextChanged -= Bindable_BindingContextChanged;
            listView.ItemAppearing -= InfiniteListView_ItemAppearing;
        }

        private void InfiniteListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (AssociatedObject.ItemsSource is IList items && items.Count - 1 >= 0 && e.Item == items[items.Count - 1])
            {
                if (LoadMoreCommand != null && LoadMoreCommand.CanExecute(null))
                    LoadMoreCommand.Execute(null);
            }
        }
    }
}
