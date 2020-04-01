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
        public static string GetHash(string password)
        {
            using (var hash = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(hash.ComputeHash(hashbytes));
            }
        }

        public static bool Login(UserModel user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.email))
                {
                    if (!string.IsNullOrEmpty(user.password))
                    {
                        using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                        {
                            string hashPassword = GetHash(user.password).ToString();
                            TblUser tblUser = rc.TblUsers.FirstOrDefault(u => u.email == user.email && u.password == hashPassword);


                            if (tblUser != null && tblUser.deactivated == false)
                            {
                                user.firstName = tblUser.firstName;
                                user.lastName = tblUser.lastName;
                                user.deactivated = tblUser.deactivated;
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
                email = "test@test.com",
                firstName = "test",
                lastName = "testAccount",
                password = "123",
                DOB = new DateTime(1997, 09, 11),
                phone = "123-456-7890",
                deactivated = false
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
                        userID = rc.TblUsers.Any()? rc.TblUsers.Max(u => u.userID) +1: 1,
                        email = user.email,
                        firstName = user.firstName,
                        lastName = user.lastName,
                        DOB = user.DOB,
                        password = GetHash(user.password).ToString(),
                        phone = user.phone,
                        deactivated = user.deactivated
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
        
        public static bool Insert(string email, string firstname, string lastname, string password, string phone)
        {
            try
            {
                using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                {
                    PL.TblUser newRow = new TblUser()
                    {
                        userID = rc.TblUsers.Any()? rc.TblUsers.Max(u => u.userID) +1: 1,
                        email = email,
                        firstName = firstname,
                        lastName = lastname,
                        password = password,
                        phone = phone
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
                        var tblUser = rc.TblUsers.FirstOrDefault(u => u.userID == id);

                        if (tblUser != null)
                        {
                            UserModel user = new UserModel
                            {
                                userID = tblUser.userID,
                                firstName = tblUser.firstName,
                                lastName = tblUser.lastName,
                                email = tblUser.email,
                                DOB = (DateTime)tblUser.DOB,
                                deactivated = tblUser.deactivated
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

                        tblUsers.ForEach(u => users.Add(new UserModel { userID = u.userID, email = u.email, firstName = u.firstName, lastName = u.lastName, deactivated = u.deactivated, DOB = (DateTime)u.DOB, phone = u.phone }));

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
                if (user.userID != 0)
                {
                    using (RoundTheCornerEntities rc = new RoundTheCornerEntities())
                    {
                        TblUser tblUser = rc.TblUsers.FirstOrDefault(u => u.userID == user.userID);

                        if (tblUser != null) 
                        {
                            tblUser.phone = user.phone;
                            tblUser.email = user.email;
                            tblUser.firstName = user.firstName;
                            tblUser.lastName = user.lastName;

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
                        TblUser tblUser = rc.TblUsers.FirstOrDefault(u => u.userID == id);

                        if (tblUser != null)
                        {
                            tblUser.deactivated = true;
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
                        var user = rc.TblUsers.FirstOrDefault(u => u.userID == id);

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
