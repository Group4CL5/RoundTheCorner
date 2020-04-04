using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoundTheCorner.BL.Models;
using RoundTheCorner.PL;

namespace RoundTheCorner.BL
{
    public class OrderManager
    {
        public static bool Seed()
        {
            OrderModel order = new OrderModel
            {
                orderID = 1,
                userID = 1,
                vendorID = 1,
                orderDate = new DateTime (1980,04,01)

            };

            return Insert(order);
        }

        public static bool Insert(OrderModel order)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblOrder newRow = new TblOrder()
                    {
                        orderID = rc.TblOrders.Any() ? rc.TblOrders.Max(u => u.orderID) + 1 : 1,
                        vendorID = order.orderID,
                        userID= order.orderID,                        
                        orderDate = order.orderDate
                    };
                    rc.TblOrders.Add(newRow);
                    rc.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool Insert(int orderID, int userID, int vendorID, DateTime orderDate )
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblOrder newRow = new TblOrder()
                    {
                        orderID = rc.TblOrders.Any() ? rc.TblOrders.Max(u => u.orderID) + 1 : 1,
                        
                        userID = userID,
                        vendorID = vendorID,
                        orderDate = orderDate
                    };
                    rc.TblOrders.Add(newRow);
                    rc.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static OrderModel GetOrder(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        var tblOrder = rc.TblOrders.FirstOrDefault(u => u.orderID == id);

                        if (tblOrder != null)
                        {
                            OrderModel order = new OrderModel
                            {                                                             
                                orderID = tblOrder.orderID,
                                userID = tblOrder.userID,
                                vendorID = tblOrder.vendorID,
                                orderDate = tblOrder.orderDate

                            };

                            return order;
                        }

                        throw new Exception("Order cannot be found");
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
        public static bool Update(OrderModel order)
        {
            try
            {
                if (order.orderID != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        TblOrder tblOrder = rc.TblOrders.FirstOrDefault(u => u.orderID == order.orderID);

                        if (tblOrder != null)
                        {
                            tblOrder.orderID = order.orderID;
                            tblOrder.userID= order.orderID;
                            tblOrder.vendorID = order.orderID;
                            tblOrder.orderDate = order.orderDate;
                            

                            rc.SaveChanges();
                            return true;
                        }
                        else
                        {
                            throw new Exception("Order was not found");
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
                        var order = rc.TblOrders.FirstOrDefault(u => u.orderID == id);

                        if (order != null)
                        {
                            rc.TblOrders.Remove(order);
                            rc.SaveChanges();
                            return true;
                        }
                        else
                        {
                            throw new Exception("Order cannot be found");
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

        public static List<OrderModel> GetOrders()
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    var tblOrder = rc.TblOrders.ToList();

                    if (tblOrder != null)
                    {
                        List<OrderModel> orders = new List<OrderModel>();

                        tblOrder.ForEach(u => orders.Add(new OrderModel { orderID = u.orderID, vendorID = u.vendorID, userID = u.userID, 
                        orderDate = u.orderDate }));

                        return orders;
                    }

                    throw new Exception("There currently are no orders");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<OrderModel> GetUserOrders(int userID)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    var tblOrders = rc.TblOrders.Where(w => userID == w.userID).ToList();

                    if (tblOrders != null)
                    {
                        List<OrderModel> orders = new List<OrderModel>();

                        tblOrders.ForEach(u => orders.Add(new OrderModel {
                            orderID = u.orderID,
                            vendorID = u.vendorID,
                            userID = u.userID,
                            orderDate = u.orderDate
                        }));

                        return orders;
                    }

                    throw new Exception("The user currently has no orders");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
