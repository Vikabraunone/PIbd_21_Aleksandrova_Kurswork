﻿using CafeteriaBarnyardBisinessLogic.BusinessLogics;
using CafeteriaBarnyardBisinessLogic.Interfaces;
using System;
using CafeteriaBarnyardDatabaseImplement;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace CafeteriaBarnyardView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormEnter>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IDishLogic, DishLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderLogic, OrderLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProductLogic, ProductLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientLogic, ClientLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IRequestProduct, RequestProduct>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<HelpOrderLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
