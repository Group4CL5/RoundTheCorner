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
                menuItemID = 1,
                price = 1
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
                        orderItemID = rc.TblOrderItems.Any() ? rc.TblOrderItems.Max(u => u.orderItemID) + 1 : 1,
                        menuItemId = orderItem.menuItemID,
                        price = orderItem.price
                        
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
        public static bool Insert(int menuItemID, decimal price)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblOrderItem newRow = new TblOrderItem()
                    {
                        orderItemID = rc.TblOrderItems.Any() ? rc.TblOrderItems.Max(u => u.orderItemID) + 1 : 1,
                        menuItemId = menuItemID,
                        price = price
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
                        var tblOrderItem = rc.TblOrderItems.FirstOrDefault(u => u.orderItemID == id);

                        if (tblOrderItem != null)
                        {
                            OrderItemModel orderItem = new OrderItemModel
                            {
                                orderItemID = tblOrderItem.orderItemID,
                                price = tblOrderItem.price,
                                menuItemID = tblOrderItem.menuItemId
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
                if (orderItem.orderItemID != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        TblOrderItem tblOrderItem = rc.TblOrderItems.FirstOrDefault(u => u.orderItemID == orderItem.orderItemID);

                        if (tblOrderItem != null)
                        {
                            tblOrderItem.orderItemID = orderItem.orderItemID;
                            tblOrderItem.price = orderItem.price;
                            tblOrderItem.menuItemId = orderItem.menuItemID;
                           

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
                        var orderItem = rc.TblOrderItems.FirstOrDefault(u => u.orderItemID == id);

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

                        tblOrderItems.ForEach(u => orderItems.Add(new OrderItemModel { orderItemID = u.orderItemID, menuItemID = u.menuItemId, price = u.price }));

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
                    var tblOrderItems = rc.TblOrderItems.Where(w => menuID == w.menuItemId).ToList();

                    if (tblOrderItems != null)
                    {
                        List<OrderItemModel> orderItems = new List<OrderItemModel>();

                        tblOrderItems.ForEach(u => orderItems.Add(new OrderItemModel { orderItemID = u.orderItemID, menuItemID = u.menuItemId, price = u.price }));

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
