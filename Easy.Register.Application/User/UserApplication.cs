﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;
using Easy.Register.Model.User;

namespace Easy.Register.Application.User
{
    public class UserApplication : BaseApplication
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>int = 用户ID ，string=用户姓名</returns>
        public Tuple<int,string> Login(string username,string password)
        {
            UserDescriptor user = new UserAuthenticationService().Authenticate(username, password);
            if(user == null)
            {
                return null;
            }

            return new Tuple<int, string>(user.Id, user.Name);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string Add(string username,string name,string password)
        {
            var user = new Model.User.User()
            {
                Username = username,
                Name = name,
                Password = new PasswordService().Encrypt(password)
            };

            if (user.Validate())
            {
                Model.RepositoryRegistry.User.Add(user);
                return string.Empty;
            }
            return user.GetBrokenRules()[0].Description;
        }

        public Models.User.User FindBy(int userId)
        {
            Model.User.User user = Model.RepositoryRegistry.User.FindBy(userId);

            return new Models.User.User()
            {
                Id = user.Id,
                CreateDate = user.CreateDate,
                Name = user.Name,
                Username = user.Username
            };
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string UpdatePassword(int userId,string password)
        {
            var user = Model.RepositoryRegistry.User.FindBy(userId);
            if (user == null)
            {
                return "账号不存在";
            }

            user.Password = new PasswordService().Encrypt(password);

            if (user.Validate())
            {
                Model.RepositoryRegistry.User.Update(user);
                return string.Empty;
            }
            return user.GetBrokenRules()[0].Description;
        }

        public string UpdateUser(int userId, string username, string name)
        {
            var user = Model.RepositoryRegistry.User.FindBy(userId);
            if (user == null)
            {
                return "账号不存在";
            }

            user.Username = username;
            user.Name = name;

            if (user.Validate())
            {
                Model.RepositoryRegistry.User.Update(user);
                return string.Empty;
            }
            return user.GetBrokenRules()[0].Description;
        }

        public IEnumerable<Models.User.User> FindAll()
        {
            var users = Model.RepositoryRegistry.User.FindAll();
            return users.Select(u => new Models.User.User()
            {
                Id = u.Id,
                CreateDate = u.CreateDate,
                Name = u.Name,
                Username = u.Username
            });
        }
    }
}
