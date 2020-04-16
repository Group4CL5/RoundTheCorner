using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoundTheCorner.PL;
using RoundTheCorner.BL.Models;
namespace RoundTheCorner.BL
{
    public class UserManager
    {
        public static string GetHash(string Password)
        {
            using (var hash = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(Password);
                return Convert.ToBase64String(hash.ComputeHash(hashbytes));
            }
        }

        public static bool Login(UserModel user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.Email))
                {
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                        {
                            string hashPassword = GetHash(user.Password).ToString();
                            TblUser tblUser = rc.TblUsers.FirstOrDefault(u => u.Email == user.Email && u.Password == hashPassword);


                            if (tblUser != null && tblUser.Deactivated == false)
                            {
                                user.UserID = tblUser.UserID;
                                user.FirstName = tblUser.FirstName;
                                user.LastName = tblUser.LastName;
                                user.Deactivated = tblUser.Deactivated;
                                user.DOB = (DateTime)tblUser.DOB;

                                return true;
                            }

                            return false;
                        }
                    }
                    else
                    {
                        throw new Exception("Password cannot be empty");
                    }
                }
                else
                {
                    throw new Exception("Email cannot be empty");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Seed()
        {
            UserModel user = new UserModel
            {
                Email = "test@test.com",
                FirstName = "test",
                LastName = "testAccount",
                Password = "123",
                DOB = new DateTime(1997, 09, 11),
                Phone = "123-456-7890",
                Deactivated = false
            };

            return Insert(user);
        }

        public static bool Insert(UserModel user)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblUser newRow = new TblUser()
                    {
                        UserID = rc.TblUsers.Any()? rc.TblUsers.Max(u => u.UserID) +1: 1,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        DOB = user.DOB,
                        Password = GetHash(user.Password).ToString(),
                        Phone = user.Phone,
                        Deactivated = user.Deactivated
                    };
                    rc.TblUsers.Add(newRow);
                    rc.SaveChanges();
                    return true; 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static bool Insert(string Email, string firstname, string lastname, string Password, string Phone)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblUser newRow = new TblUser()
                    {
                        UserID = rc.TblUsers.Any()? rc.TblUsers.Max(u => u.UserID) +1: 1,
                        Email = Email,
                        FirstName = firstname,
                        LastName = lastname,
                        Password = Password,
                        Phone = Phone
                    };
                    rc.TblUsers.Add(newRow);
                    rc.SaveChanges();
                    return true; 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static UserModel GetUser(int id)
        {
            try
            {
                if (id != 0) {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        var tblUser = rc.TblUsers.FirstOrDefault(u => u.UserID == id);

                        if (tblUser != null)
                        {
                            UserModel user = new UserModel
                            {
                                UserID = tblUser.UserID,
                                FirstName = tblUser.FirstName,
                                LastName = tblUser.LastName,
                                Email = tblUser.Email,
                                DOB = (DateTime)tblUser.DOB,
                                Deactivated = tblUser.Deactivated
                            };

                            return user;
                        }

                        throw new Exception("User cannot be found");
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

        public static List<UserModel> GetUsers()
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    var tblUsers = rc.TblUsers.ToList();

                    if (tblUsers != null)
                    {
                        List<UserModel> users = new List<UserModel>();

                        tblUsers.ForEach(u => users.Add(new UserModel { UserID = u.UserID, Email = u.Email, FirstName = u.FirstName, LastName = u.LastName, Deactivated = u.Deactivated, DOB = (DateTime)u.DOB, Phone = u.Phone }));

                        return users;
                    }

                    throw new Exception("There currently are no users");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static bool Update(UserModel user)
        {
            try
            {
                if (user.UserID != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        TblUser tblUser = rc.TblUsers.FirstOrDefault(u => u.UserID == user.UserID);

                        if (tblUser != null) 
                        {
                            tblUser.Phone = user.Phone;
                            tblUser.Email = user.Email;
                            tblUser.FirstName = user.FirstName;
                            tblUser.LastName = user.LastName;

                            rc.SaveChanges();
                            return true;
                        }
                        else
                        {
                            throw new Exception("User was not found");
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

        public static bool Deactivate(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        TblUser tblUser = rc.TblUsers.FirstOrDefault(u => u.UserID == id);

                        if (tblUser != null)
                        {
                            tblUser.Deactivated = true;
                            rc.SaveChanges();
                            return true;
                        }
                        else
                        {
                            throw new Exception("User was not found");
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


        // Unit tests only
        public static bool Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        var user = rc.TblUsers.FirstOrDefault(u => u.UserID == id);

                        if (user != null)
                        {
                            rc.TblUsers.Remove(user);
                            rc.SaveChanges();
                            return true;
                        }
                        else
                        {
                            throw new Exception("User cannot be found");
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
    }
}
