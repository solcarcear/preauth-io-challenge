using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace game_01.test
{
    [TestFixture]
    public class ServicesGameUnitTest
    {
        private ServicesGame _services;

        [SetUp]
        public void Setup()
        {
            _services = new ServicesGame();
        }

        [Test]
        public void GetFirstPosibleArraySum_manySubsetsPosible_return_firstSubset()
        {
            //ARRANGE
            var arr = new[] { 11, 2, 6, 4, 8 ,5,5};
            var target = 10;

            //ACT
            var arrResult = _services.GetFirstPosibleArraySum(arr, target);
            var arrResultList = arrResult.ToList();


            //ASSERT
            Assert.AreEqual(arrResultList.Sum(), target);
        }

        [Test]
        public void GetFirstPosibleArraySum_oneSubsetPosible_return_firstSubset()
        {
            //ARRANGE
            var arr = new[] { 11, 2, 6, 4, 8, 5, 5 };
            var target = 19;

            //ACT
            var arrResult = _services.GetFirstPosibleArraySum(arr, target);
            var arrResultList = arrResult.ToList();


            //ASSERT
            Assert.AreEqual(arrResultList.Sum(), target);
        }

        [Test]
        public void GetFirstPosibleArraySum_notSubsetPosible_return_emptyArray()
        {
            //ARRANGE
            var arr = new[] { 11, 2, 6, 4, 8, 5, 5 };
            var target = 18;

            //ACT
            var arrResult = _services.GetFirstPosibleArraySum(arr, target);
            var arrResultList = arrResult.ToList();


            //ASSERT
            Assert.IsEmpty(arrResultList);
        }

        [Test]
        public void GetFirstPosibleArraySum_arrEntrieNull_return_emptyArray()
        {
            //ARRANGE
            int[] arr = null;
            var target = 17;

            //ACT
            var arrResult = _services.GetFirstPosibleArraySum(arr, target);
            var arrResultList = arrResult.ToList();


            //ASSERT
            Assert.IsEmpty(arrResultList);
        }
        [Test]
        public void GetFirstPosibleArraySum_arrOneLenght_return_emptyArray()
        {
            //ARRANGE
            int[] arr = new[] { 11 };
            var target = 17;

            //ACT
            var arrResult = _services.GetFirstPosibleArraySum(arr, target);
            var arrResultList = arrResult.ToList();


            //ASSERT
            Assert.IsEmpty(arrResultList);
        }
    }
}