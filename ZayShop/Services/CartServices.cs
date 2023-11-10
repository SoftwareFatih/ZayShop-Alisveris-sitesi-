using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZayShop.Data;
using ZayShop.Data.Repositories;

namespace ZayShop.Services
{
    public class CartServices
    {
        private CartRepository _cartRepository;
        private CartItemRepository _cartItemRepository;
        public CartServices()
        {
            _cartRepository = new CartRepository();
            _cartItemRepository = new CartItemRepository();
        }

        public void AddToCart(int productId, int quantity)
        {
            Cart cart = _cartRepository.ReadFirst();
            if (cart == null)
            {
                cart = new Cart
                {
                    CustomerId=1,
                    CartItems = new HashSet<CartItem>()
                };
                _cartRepository.CreateOne(cart);
                _cartRepository.Save();
            }
            CartItem item = _cartItemRepository.ReadFirst(x=>x.ProductId == productId);
            if (item != null)
            {
                item.Quantity += quantity;
                _cartItemRepository.Update(item);
            }
            else
            {
                item = new CartItem { 
                CartId=cart.Id,
                Quantity = quantity,
                ProductId=productId
                };
                _cartItemRepository.CreateOne(item);
            }
            _cartItemRepository.Save();
        }

        public void RemoveFromCart(int productId, int quantity)
        {

        }

        public void CompleteShping()
        {

        }

        public IEnumerable<CartItem> GetCartItems()
        {
            Cart cart = _cartRepository.ReadFirst();
            if (cart == null)
            {
                cart = new Cart
                {
                    CustomerId = 1,
                    CartItems = new HashSet<CartItem>()
                };
                _cartRepository.CreateOne(cart);
                _cartRepository.Save();
            }
            return cart.CartItems;
        }
    }
}