using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QMaoPetSalon.Models;

namespace QMaoPetSalon.ViewModels
{
    public class CustomDetailViewModel : Bindable, IDataErrorInfo
    {
        private Customer mCustomer = new Customer();
        public Customer Customer
        {
            get { return mCustomer; }
            set { SetProperty(ref mCustomer, value); }
        }

        private Order mOrder = new Order();
        public Order Order
        {
            get { return mOrder; }
            set { SetProperty(ref mOrder, value); }
        }

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

        private ICommand mCreateCommand;
        public ICommand CreateCommand
        {
            get
            {
                return mCreateCommand ?? (mCreateCommand = new CommandHandler(Create, true));
            }
        }

        private string mSearchText;
        public string SearchText
        {
            get { return mSearchText; }
            set { SetProperty(ref mSearchText, value); }
        }
        private Visibility mSaveButtonVisibility = Visibility.Collapsed;
        public Visibility SaveButtonVisibility
        {
            get { return mSaveButtonVisibility; }
            set { SetProperty(ref mSaveButtonVisibility, value); }
        }

        public CustomDetailViewModel()
        {
            Orders = new ObservableCollection<Order>();
        }

        async private void Search()
        {
            Orders.Clear();

//            await MainDataSource.Instance.Context.Customers.LoadAsync();
//
//            foreach (var customer in MainDataSource.Instance.Context.Customers)
//            {
//
//            }
//           

            var items = MainDataSource.Instance.Context.Customers.FirstOrDefault(x => x.OwnerAddress == SearchText || x.OwnerName == SearchText || x.OwnerPhone == SearchText);

            this.Customer = items;

            if (items != null)
            {
                var orders = MainDataSource.Instance.Context.Orders.Where(x => x.CustomerId == items.Id);

                foreach (var order in orders)
                {
                    Orders.Add(order);
                }
            }

        }

        private void Create()
        {
            MainDataSource.Instance.Context.Customers.Add(Customer);
            MainDataSource.Instance.Context.SaveChanges();
            
            this.Order.CustomerId = this.Customer.Id;


            Orders.Add(Order);

            MainDataSource.Instance.Context.Orders.Add(Order);
            MainDataSource.Instance.Context.SaveChanges();

        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }
    }
}
