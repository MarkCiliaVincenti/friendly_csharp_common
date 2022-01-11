﻿using FsLib.CreditCardUtils;
using FsLib.TuChuangUtils;
using Hikari.Common;
using Hikari.Common.Office;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using System.Net.Http;
using Hikari.Common.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace XUnitTestProject1
{
    public class UnitTest2
    {
        private ITestOutputHelper _output;

        public UnitTest2(ITestOutputHelper output)
        {
            _output = output;
        }
        //public static IEnumerable<TestCaseData> InvalidCardNumbersData
        //{
        //    get
        //    {
        //        yield return new TestCaseData(null);
        //        yield return new TestCaseData("");
        //        yield return new TestCaseData(" ");
        //        yield return new TestCaseData("123");
        //        yield return new TestCaseData("abc");
        //        yield return new TestCaseData("123abc");
        //        yield return new TestCaseData("abc123");
        //        yield return new TestCaseData("1111 2222");
        //    }
        //}

        //[TestCaseSource("InvalidCardNumbersData")]
        //public void TestInvalidCardNumberFormat(string cardNumber)
        //{
        //    var result = CreditCardValidator.ValidCardNumber(cardNumber);
        //    Assert.IsTrue(result.CardNumberFormat == CardNumberFormat.Invalid_BadStringFormat);
        //}

        [Fact]
        public void TestLuhnMod10Failure()
        {
            CreditCardValidator creditCardValidator = new CreditCardValidator();
            var result = creditCardValidator.ValidCardNumber("9962514040073500");
            Assert.True(result.CardNumberFormat == CardNumberFormat.Invalid_LuhnFailure);
        }

        [Fact]
        public void TestLuhnMod10Success()
        {
            CreditCardValidator creditCardValidator = new CreditCardValidator();
            var result = creditCardValidator.ValidCardNumber("5371381647477037");
            Assert.True(result.CardNumberFormat == CardNumberFormat.Valid_LuhnOnly);
        }

        //[Test]
        //public void TestValidVisa()
        //{
        //    var result = CreditCardValidator.ValidCardNumber("4012888888881881");
        //    Assert.IsTrue(result.CardNumberFormat == CardNumberFormat.Valid_BINTest && result.CardTypes.Contains("Visa"));
        //}

        //[Test]
        //public void TestValidMasterCard()
        //{
        //    var result = CreditCardValidator.ValidCardNumber("5105105105105100");
        //    Assert.IsTrue(result.CardNumberFormat == CardNumberFormat.Valid_BINTest && result.CardTypes.Contains("MasterCard"));
        //}

        //public class WellsFargoBankValidator : ICardTypeValidator
        //{
        //    public string Name => "Wells Fargo Bank";
        //    public string RegEx => @"^(485246)\d{10}$";
        //}

        //[Test]
        //public void TestCardTypeValidator()
        //{
        //    var result = CreditCardValidator.ValidCardNumber("4852461030260066", new ICardTypeValidator[]
        //    {
        //        new WellsFargoBankValidator()
        //    });
        //    Assert.IsTrue(result.CardNumberFormat == CardNumberFormat.Valid_BINTest && result.CardTypes.Contains("Wells Fargo Bank"));
        //}
        [Fact]
        public void Test1()
        {
            TuChuangClient client = new TuChuangClient();
            var s = client.UploadFile("").GetAwaiter().GetResult();


            Assert.True(true);
        }

        [Fact]
        public void Test3()
        {

            DataTable dt = new DataTable("cart");
            DataColumn dc1 = new DataColumn("prizename");
            dt.Columns.Add(dc1);
            dc1 = new DataColumn("point");
            dt.Columns.Add(dc1);
            dc1 = new DataColumn("number");
            dt.Columns.Add(dc1);
            dc1 = new DataColumn("totalpoint");
            dt.Columns.Add(dc1);
            dc1 = new DataColumn("prizeid");
            dt.Columns.Add(dc1);
            //dt.Columns.Add(dc1);
            //dt.Columns.Add(dc2);
            //dt.Columns.Add(dc3);
            //dt.Columns.Add(dc4);
            //dt.Columns.Add(dc5);
            //以上代码完成了DataTable的构架，但是里面是没有任何数据的  
            for (int i = 0; i < 10; i++)
            {
                DataRow dr = dt.NewRow();
                dr["prizename"] = "娃娃";
                dr["point"] = 10;
                dr["number"] = 1;
                dr["totalpoint"] = 10;
                dr["prizeid"] = "001";
                dt.Rows.Add(dr);
            }

            var v = ExcelHelper.ExcelToDataTable("D:\\1.xlsx", "Sheet1", true);
            Assert.True(true);
        }
        private static readonly List<Task> _tasks = new List<Task>();
        [Fact]
        public void Test4()
        {
            HttpClientHelper clientHelper = new HttpClientHelper();
            ThreadPoolHelper.BeginThreadPool();
            ThreadPoolHelper.CheckThreadPool();
            for (int i = 0; i < 1000; i++)
            {
                async void CallBack(object state)
                {
                    var h = await clientHelper.GetAsync("https://www.baidu.com/");
                    System.Diagnostics.Debug.WriteLine(h);
                }

                ThreadPool.QueueUserWorkItem(CallBack);
            }
            while (true)
            {
                
            }

            Assert.True(true);
        }

        /// <summary>
        /// 生成当前时间戳
        /// </summary>
        /// <returns></returns>
        private long timeGen()
        {
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }
    }
}