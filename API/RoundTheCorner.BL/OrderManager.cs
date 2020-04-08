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
                OrderID = 1,
                UserID = 1,
                VendorID = 1,
                OrderDate = new DateTime (1980,04,01)

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
                        OrderID = rc.TblOrders.Any() ? rc.TblOrders.Max(u => u.OrderID) + 1 : 1,
                        VendorID = order.OrderID,
                        UserID= order.OrderID,                        
                        OrderDate = order.OrderDate
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
        public static bool Insert( int UserID, int VendorID, DateTime OrderDate )
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblOrder newRow = new TblOrder()
                    {
                        OrderID = rc.TblOrders.Any() ? rc.TblOrders.Max(u => u.OrderID) + 1 : 1,
                        
                        UserID = UserID,
                        VendorID = VendorID,
                        OrderDate = OrderDate
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
                        var tblOrder = rc.TblOrders.FirstOrDefault(u => u.OrderID == id);

                        if (tblOrder != null)
                        {
                            OrderModel order = new OrderModel
                            {                                                             
                                OrderID = tblOrder.OrderID,
                                UserID = tblOrder.UserID,
                                VendorID = tblOrder.VendorID,
                                OrderDate = tblOrder.OrderDate

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
                if (order.OrderID != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        TblOrder tblOrder = rc.TblOrders.FirstOrDefault(u => u.OrderID == order.OrderID);

                        if (tblOrder != null)
                        {
                            tblOrder.OrderID = order.OrderID;
                            tblOrder.UserID= order.OrderID;
                            tblOrder.VendorID = order.OrderID;
                            tblOrder.OrderDate = order.OrderDate;
                            

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
                        var order = rc.TblOrders.FirstOrDefault(u => u.OrderID == id);

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

                        tblOrder.ForEach(u => orders.Add(new OrderModel { OrderID = u.OrderID, VendorID = u.VendorID, UserID = u.UserID, 
                        OrderDate = u.OrderDate }));

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
        public static List<OrderModel> GetUserOrders(int UserID)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    var tblOrders = rc.TblOrders.Where(w => UserID == w.UserID).ToList();

                    if (tblOrders != null)
                    {
                        List<OrderModel> orders = new List<OrderModel>();

                        tblOrders.ForEach(u => orders.Add(new OrderModel {
                            OrderID = u.OrderID,
                            VendorID = u.VendorID,
                            UserID = u.UserID,
                            OrderDate = u.OrderDate
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
