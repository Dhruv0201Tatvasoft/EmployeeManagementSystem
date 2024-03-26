using Microsoft.Xaml.Behaviors;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace EmployeeManagementSystem.Behaviours
{
    internal class ListBoxSelectionBehaviour : Behavior<ListBox>
    {
        public static readonly DependencyProperty SelectedItemProperty =
        DependencyProperty.Register("SelectedItem", typeof(DataRowView), typeof(ListBoxSelectionBehaviour));

        public DataRowView SelectedItem
        {
            get { return (DataRowView)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += ListBox_SelectionChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SelectionChanged -= ListBox_SelectionChanged;
        }

        /// <summary>
        /// Whenever ListBox's selection is changed it sets selected Item to newly selected Item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                SelectedItem = (DataRowView)e.AddedItems[0]!;
            }

            if(e.RemovedItems.Count > 0)
            {
                SelectedItem = (DataRowView)e.RemovedItems[0]!;
            }

        }
    }
}
