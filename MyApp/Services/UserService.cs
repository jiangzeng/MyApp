using MyApp.DataModel;
using MyApp.DataModels;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MyApp.Services
{
    public class UserService
    {
        public User Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("Username(Email) cound not be empty!");
            }
            else if (!IsValidEmail(email))
            {
                throw new Exception("Email is invalid!");
            }
            else if (string.IsNullOrEmpty(password))
            {
                throw new Exception("Password cound not be empty!");
            } else
            {
                try
                {
                    using (var db = new MyAppContext())
                    {
                        User user = db.Users.Where(u => email.Equals(u.Email) && MD5Hash(password).Equals(u.Password)).FirstOrDefault();
                        if (user != null)
                        {
                            user.LastLoginTime = System.DateTime.Now;
                            db.SaveChanges();
                            return user;
                        } else
                        {
                            throw new Exception("User not found, invalid username or password!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public User Register(string email, string displayname, string password)
        {
            

            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("Username(Email) cound not be empty!");
            }
            else if (!IsValidEmail(email))
            {
                throw new Exception("Email is invalid!");
            }
            else if (string.IsNullOrEmpty(displayname))
            {
                throw new Exception("DisplayName cound not be empty!");
            }
            else if (string.IsNullOrEmpty(password))
            {
                throw new Exception("Password cound not be empty!");
            }
            else
            {
                try
                {
                    using (var db = new MyAppContext())
                    {
                        if(db.Users.Where( u => u.Email == email).Count() > 0)
                        {
                            throw new Exception("Email has been registered!");
                        }

                        DateTime currentTime = System.DateTime.Now;
                        var user = new User { Name = displayname, Password = MD5Hash(password), Email = email, LastLoginTime = currentTime, RegisterTime = currentTime };
                        db.Users.Add(user);
                        db.SaveChanges();
                        return user;
                    }
                } catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

    }
}
