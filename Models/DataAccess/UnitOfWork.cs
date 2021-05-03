using ComputerPeripheralsShop.Models.DataAccess.repositories;
using System;

namespace ComputerPeripheralsShop.Models.DataAccess
{
    public class UnitOfWork : IDisposable
    {
        private bool IsDisposed = false;

        protected ComputerPeripheralsShopEntities context;

        protected OrderListRepository orderListRepository;
        protected ProductRepository productRepository;
        protected UserRepository userRepository;
        protected OrderRepository orderRepository;

        public OrderListRepository OrderList
        {
            get
            {
                if (orderListRepository == null)
                    orderListRepository = new OrderListRepository(context);
                return orderListRepository;
            }
        }

        public ProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(context);
                return productRepository;
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(context);
                return userRepository;
            }
        }

        public OrderRepository OrderRepository
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(context);
                return orderRepository;
            }
        }

        public void SaveChanges() => context.SaveChanges();
        public void SaveChangesAsync() => context.SaveChangesAsync();

        public UnitOfWork()
        {
            context = new ComputerPeripheralsShopEntities();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.IsDisposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.IsDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
