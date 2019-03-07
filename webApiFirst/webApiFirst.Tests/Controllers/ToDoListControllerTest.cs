using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using webApiFirst.Controllers;
using webApiFirst.Models;

namespace webApiFirst.Tests.Controllers
{
    [TestClass]
    public class ToDoListControllerTest
    {
               
        //打某隻 post api 可以新增一個 todo 事件。
        [TestMethod]
        public void Post()
        {
           
            ToDoListController controller = new ToDoListController();       
            var response = controller.POST("WW");
            //OkNegotiatedContentResult 將結果轉換為來訪問返回的字串符<看是什麼型態>，並訪問他content屬性
            var result = response as OkNegotiatedContentResult<Boolean>;
            Assert.AreEqual(true, result.Content);
        }



        //打某隻 get api 可以取得所有的 todo 事件
        [TestMethod]
        public void Get()
        {
            // 排列
            ToDoListController controller = new ToDoListController();
            var response = controller.GET();
            var result = response as OkNegotiatedContentResult<int>;
            Assert.AreEqual(11, result.Content);
        }


        // 打某隻 delete api 可以移除某個 todo 事件。
        //update delTime
        [TestMethod]
        public void Delete()
        {
            // 排列
            ToDoListController controller = new ToDoListController();
            var response = controller.DELETE("16");
            var result = response as OkNegotiatedContentResult<string>;
            Assert.AreEqual("16", result.Content);
        }
        
        //打某集 put api 可以修改某個 todo 事件。
        [TestMethod]
        public void Put()
        {
            // 排列
            var controller = new ToDoListController();
            
            var response = controller.PUT("15", "new");
            var result = response as OkNegotiatedContentResult<string>;
            Assert.AreEqual("new", result.Content);


            //如果素  List<MsgModels> 才是用 <IEnumerable<MsgModels>> 接
            //JsonResult<IEnumerable<MsgModels>> contentResult = actionResult as JsonResult<IEnumerable<MsgModels>>;

            //JsonResult<MsgModels> contentResult = actionResult as JsonResult<MsgModels>;
            //Assert.AreEqual(true, contentResult.Content.success);
            //Assert.AreEqual(true, controller.Put("6", "buyyyyy"));
  

        }   

    }
}
