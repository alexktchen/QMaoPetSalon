using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QMaoPetSalon.Models;

namespace QMaoPetSalon.ViewModels
{
    public class HistoryViewModel : Bindable
    {
        private ObservableCollection<Order> mOrders;
        public ObservableCollection<Order> Orders
        {
            get { return mOrders; }
            set { SetProperty(ref mOrders, value); }
        }

        private ICommand mSearchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return mSearchCommand ?? (mSearchCommand = new CommandHandler(Search, true));
            }
        }

        private DateTime mStartDateTime = DateTime.Now;
        public DateTime StartDateTime
        {
            get { return mStartDateTime; }
            set { SetProperty(ref mStartDateTime, value); }
        }

        private DateTime mEndDateTime = DateTime.Now;
        public DateTime EndDateTime
        {
            get { return mEndDateTime; }
            set { SetProperty(ref mEndDateTime, value); }
        }

        private string mTotalPrice;
        public string TotalPrice
        {
            get { return mTotalPrice; }
            set { SetProperty(ref mTotalPrice, value); }
        }

        public HistoryViewModel()
        {
            Orders = new ObservableCollection<Order>();
        }
        private void Search()
        {
            Orders.Clear();

            double total = 0;
            // var orders = MainDataSource.Instance.Context.Orders.Where(x => x.OrderDateTime > StartDateTime && x.OrderDateTime < EndDateTime);
            var orders = MainDataSource.Instance.Context.Orders;
            foreach (var order in orders)
            {
                Orders.Add(order);
                total += order.Price;
            }

            TotalPrice = total.ToString("C");
        }
    }
}
