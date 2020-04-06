using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoundTheCorner.BL.Models;
using RoundTheCorner.PL;

namespace RoundTheCorner.BL
{
    public class OrderItemManager
    {
        public static bool Seed()
        {
            OrderItemModel orderItem = new OrderItemModel
            {
                MenuItemID = 1,
                Price = 123
            };

            return Insert(orderItem);
        }

        public static bool Insert(OrderItemModel orderItem)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblOrderItem newRow = new TblOrderItem()
                    {
                        OrderItemID = rc.TblOrderItems.Any() ? rc.TblOrderItems.Max(u => u.OrderItemID) + 1 : 1,
                        MenuItemId = orderItem.MenuItemID,
                        Price = orderItem.Price
                        
                    };
                    rc.TblOrderItems.Add(newRow);
                    rc.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool Insert(int MenuItemID, decimal Price)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblOrderItem newRow = new TblOrderItem()
                    {
                        OrderItemID = rc.TblOrderItems.Any() ? rc.TblOrderItems.Max(u => u.OrderItemID) + 1 : 1,
                        MenuItemId = MenuItemID,
                        Price = Price
                    };
                    rc.TblOrderItems.Add(newRow);
                    rc.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static OrderItemModel GetOrderItem(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        var tblOrderItem = rc.TblOrderItems.FirstOrDefault(u => u.OrderItemID == id);

                        if (tblOrderItem != null)
                        {
                            OrderItemModel orderItem = new OrderItemModel
                            {
                                OrderItemID = tblOrderItem.OrderItemID,
                                Price = tblOrderItem.Price,
                                MenuItemID = tblOrderItem.MenuItemId
                            };

                            return orderItem;
                        }

                        throw new Exception("Item cannot be found");
                    }
                }
                else
                {
                    throw new Exception("ID cannot be 0");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool Update(OrderItemModel orderItem)
        {
            try
            {
                if (orderItem.OrderItemID != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        TblOrderItem tblOrderItem = rc.TblOrderItems.FirstOrDefault(u => u.OrderItemID == orderItem.OrderItemID);

                        if (tblOrderItem != null)
                        {
                            tblOrderItem.OrderItemID = orderItem.OrderItemID;
                            tblOrderItem.Price = orderItem.Price;
                            tblOrderItem.MenuItemId = orderItem.MenuItemID;
                           

                            rc.SaveChanges();
                            return true;
                        }
                        else
                        {
                            throw new Exception("Item was not found");
                        }
                    }
                }
                else
                {
                    throw new Exception("Must have a valid id");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        var orderItem = rc.TblOrderItems.FirstOrDefault(u => u.OrderItemID == id);

                        if (orderItem != null)
                        {
                            rc.TblOrderItems.Remove(orderItem);
                            rc.SaveChanges();
                            return true;
                        }
                        else
                        {
                            throw new Exception("Item cannot be found");
                        }
                    }
                }
                else
                {
                    throw new Exception("ID cannot be 0");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<OrderItemModel> GetOrderItems()
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    var tblOrderItems = rc.TblOrderItems.ToList();

                    if (tblOrderItems != null)
                    {
                        List<OrderItemModel> orderItems = new List<OrderItemModel>();

                        tblOrderItems.ForEach(u => orderItems.Add(new OrderItemModel { OrderItemID = u.OrderItemID, MenuItemID = u.MenuItemId, Price = u.Price }));

                        return orderItems;
                    }

                    throw new Exception("There currently are no orderItems");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<OrderItemModel> GetOrderItems(int menuID)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    var tblOrderItems = rc.TblOrderItems.Where(w => menuID == w.MenuItemId).ToList();

                    if (tblOrderItems != null)
                    {
                        List<OrderItemModel> orderItems = new List<OrderItemModel>();

                        tblOrderItems.ForEach(u => orderItems.Add(new OrderItemModel { OrderItemID = u.OrderItemID, MenuItemID = u.MenuItemId, Price = u.Price }));

                        return orderItems;
                    }

                    throw new Exception("There currently are no orderItems");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
