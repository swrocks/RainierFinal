﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hw7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Q1()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query One: How many of the top 10(score) titles are PC games?";
            //SELECT TOP 10 IGN_Table.Score, NA_Sales, EU_Sales, Japan_Sales, Other_Sales, Global_Sales FROM IGN_Table JOIN VGSales_Table ON IGN_Table.Title = VGSales_Table.Title WHERE VGSales_Table.Platform = “PC”;

            var query1 = (from IGN_Table in model.IGN_Table
                          join VGSales_Table in model.VGSales_Table
                         on IGN_Table.Title equals VGSales_Table.Title
                         where VGSales_Table.Platform == "PC"
                         select IGN_Table).Take(10);

            List<IGN_Table> IGNList = query1.ToList();

            return View(IGNList);
        }


        public ActionResult Q2()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query Two: What are the platform(s) for top 5 selling games in ea.area?";
            //SELECT TOP 5 IGN_Table.Platform, NA_Sales, EU_Sales, Japan_Sales, Other_Sales, Global_Sales FROM VGSales_Table JOIN IGN_Table ON.VGSales_TableTitle = IGN_Table.Title JOIN SteamSpy_Table ON IGN_Table.title = SteamSpy_Table.Title;

            var query2 = (from IGN_Table in model.IGN_Table
                          join VGSales_Table in model.VGSales_Table on IGN_Table.Title equals VGSales_Table.Title
                          join Steamspy_Table in model.Steamspy_Table on VGSales_Table.Title equals Steamspy_Table.Title
                          select IGN_Table).Take(10);

            List<IGN_Table> IGNList = query2.ToList();

            return View(IGNList);
        }


        public ActionResult Q3()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query Three: What are the top selling game publishers in NA?";
            //SELECT TOP 3 Publisher, Publisher(s), NA_Sales FROM VGSales_Table JOIN SteamSpy_Table ON VGSales_Table.Title = SteamSpy_Table.Title;

            var query3 = (from VGSales_Table in model.VGSales_Table
                          join Steamspy_Table in model.Steamspy_Table on VGSales_Table.Title equals Steamspy_Table.Title
                          orderby VGSales_Table.NA_Sales descending
                          select VGSales_Table).Take(3);

            List<VGSales_Table> VGList = query3.ToList();

            return View(VGList);
        }

        public ActionResult Q4()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query 4: Of Top 10 games in NA What were the different ratings?";
            //SELECT TOP 10 VGSales_Table.Title, NA_Sales, SteamSpy_Table.Score, IGN_Table.Score from VGSales_Table JOIN SteamSpy_Table ON VGSales_Table.Title = SteamSpy_Table.Title JOIN IGN_Table ON SteamSpy_Table.Title = IGN_Table.Title;

            var query4 = (from IGN_Table in model.IGN_Table
                          join VGSales_Table in model.VGSales_Table on IGN_Table.Title equals VGSales_Table.Title
                          join Steamspy_Table in model.Steamspy_Table on VGSales_Table.Title equals Steamspy_Table.Title
                          orderby Steamspy_Table.Average_Score_Rank descending
                          select Steamspy_Table).Take(10);

            List<Steamspy_Table> SteamList = query4.ToList();

            return View(SteamList);
        }

 /*       public ActionResult Q5()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query 5: How many of the top 10 (# sold) titles are Valve games?";
            //SELECT TOP 10 Title, NA_Sales, EU_Sales, Japan_Sales, Other_Sales, Global_Sales  FROM VGSales_Table JOIN SteamSpy_Table ON VGSales_Table.Title = SteamSpy_Table.Title WHERE Publisher LIKE “Valve”;

            var query5 = (from Steamspy_Table in model.Steamspy_Tables
                          join VGSales_Table in model.VGSales_Tables on Steamspy_Table.Title equals VGSales_Table.Title
                          where VGSales_Table.Publisher.Contains("Valve")
                          orderby VGSales_Table.Global_Sales descending
                          select VGSales_Table).Take(10);

            List<vg> VGList = query5.ToList();

            return View(VGList);
        }

        public ActionResult Q6()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query 6:  What genre has sold the most copies?";
            //SELECT VGSales_Table.Genre, COUNT (VGSales_Table.Genre) AS Genre_Popularity, NA_Sales, EU_Sales, Japan_Sales, Other_Sales, Global_Sales  FROM VGSales_Table GROUP BY VGSales_Table.Genre ORDER BY Genre_Popularity DESC LIMIT 1;


            var query6 = (from VGSales_Table in model.VGSales_Tables
                              //group vg.Genre by vg.Genre into Genre_Popularity
                          orderby VGSales_Table.Genre.Count() descending
                          select VGSales_Table).Take(1);

            List<VGSales_Table> VGList = query6.ToList();

            return View(VGList);
        }

        public ActionResult Q7()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query Two: What are the platform(s) for top 5 selling games in ea.area?";

            var query2 = (from IGN_Table in model.IGN_Tables
                          join vg in model.vgs on IGN_Table.Title equals vg.Title
                          join steamspy in model.steamspies on vg.Title equals steamspy.Title
                          select ign).Take(10);

            List<IGN_Table> IGNList = query2.ToList();

            return View(IGNList);
        }

        public ActionResult Q8()
        {

            RainerEntities model = new RainerEntities();
            ViewBag.Message = "Query Two: What are the platform(s) for top 5 selling games in ea.area?";

            var query2 = (from ign in model.IGN_Tables
                          join vg in model.vgs on ign.Title equals vg.Title
                          join steamspy in model.steamspies on vg.Title equals steamspy.Title
                          select ign).Take(10);

            List<ign> IGNList = query2.ToList();

            return View(IGNList);
        }
        */

    }
}