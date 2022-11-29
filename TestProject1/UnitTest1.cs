using NUnit.Framework;
using FakerLib;
using System.Collections.Generic;

namespace TestProject1
{
    public class Tests
    {
        // Test random vars
        [Test]
        public void TestingOneVarBool()
        {
            Faker faker = new Faker();
            bool someBoolVar = faker.Create<bool>();
            Assert.IsNotNull(someBoolVar);
        }

        [Test]
        public void TestingOneVarChar()
        {
            Faker faker = new Faker();
            char someCharVar = faker.Create<char>();
            Assert.IsNotNull(someCharVar);
        }

        [Test]
        public void TestingOneVarDecimal()
        {
            Faker faker = new Faker();
            decimal someDecVar = faker.Create<decimal>();
            Assert.IsNotNull(someDecVar);
        }

        [Test]
        public void TestingOneVarFloat()
        {
            Faker faker = new Faker();
            float someFloatVar = faker.Create<float>();
            Assert.IsNotNull(someFloatVar);
        }

        [Test]
        public void TestingOneVarInt()
        {
            Faker faker = new Faker();
            int someIntVar = faker.Create<int>();
            Assert.IsNotNull(someIntVar);
        }

        // Testing of simple class
        public class TestClass
        {
            public int a;
            public int B { get; set; }

            public TestClass(int a, int b)
            {
                this.a = a;
                B = b;
            }
        }
        [Test]
        public void TestingOfTheClass()
        {
            Faker faker = new Faker();
            TestClass testObj = faker.Create<TestClass>();
            Assert.IsNotNull(testObj);
            Assert.IsNotNull(testObj.a);
            Assert.IsNotNull(testObj.B);
        }

        // Testing a class with a construster
        public class TestClass2
        {
            public int a;
            private TestClass2(int a) {
                this.a = 2;
            }
        }
       // [Test]
        //public void TestingOfTheClassWithPrivateConstructor()
        //{
        //    Faker faker = new Faker();
        //    TestClass2 testObj2 = faker.Create<TestClass2>();
        //    Assert.AreEqual(2, testObj2.a);
        //}

        public class TestClass3
        {
            public int a;
            public int b;
            public int c;

            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }

            public TestClass3(int a, int x)
            {
                this.a = a;
                X = x;
            }
        }

        [Test]
        public void CheckFieldsAndPropsFilling()
        {
            Faker faker = new Faker();
            TestClass3 testObj = faker.Create<TestClass3>();
            Assert.IsNotNull(testObj);
            Assert.IsNotNull(testObj.a);
            Assert.IsNotNull(testObj.b);
            Assert.IsNotNull(testObj.c);
            Assert.IsNotNull(testObj.X);
            Assert.IsNotNull(testObj.Y);
            Assert.IsNotNull(testObj.Z);
        }

        public class CyclingTestClass : TestClass
        {
            public List<CyclingTestClass> testList;
            public CyclingTestClass innerObj;
            public CyclingTestClass(int a, int x) : base(a, x) { }
        }

        [Test]
        public void TestCyclingClass()
        {
            Faker faker = new Faker();
            CyclingTestClass cyclingTestClass = faker.Create<CyclingTestClass>();
            Assert.IsNotNull(cyclingTestClass);
            Assert.IsNotNull(cyclingTestClass.testList);
            Assert.IsNull(cyclingTestClass.testList[0]);
            Assert.IsNull(cyclingTestClass.innerObj);
        }
        public class A
        {
            public int a;
        }
        public class B
        {
            public A objA;
            public int b;
        }
        public class C
        {
            public B objB;
            public int c;
        }

        [Test]
        public void TestNestedClasses()
        {

            Faker faker = new Faker();
            C objC = faker.Create<C>();
            Assert.IsNotNull(objC);
            Assert.IsNotNull(objC.c);
            Assert.IsNotNull(objC.objB);
            Assert.IsNotNull(objC.objB.b);
            Assert.IsNotNull(objC.objB.objA);
            Assert.IsNotNull(objC.objB.objA.a);
        }
        public class CoDependentClass1
        {
            public CoDependentClass2 cl2;

            public CoDependentClass1(CoDependentClass2 cl2)
            {
                this.cl2 = cl2;
            }
            public CoDependentClass1() { }
        }

        public class CoDependentClass2
        {
            public CoDependentClass1 cl1;
            public CoDependentClass2(CoDependentClass1 cl1)
            {
                this.cl1 = cl1;
            }
            public CoDependentClass2() { }
        }

        [Test]

        public void CoDependentClassesTest()
        {
            Faker faker = new Faker();
            var cl1 = faker.Create<CoDependentClass1>();
            var cl2 = faker.Create<CoDependentClass2>();

            Assert.IsNotNull(cl1);
            Assert.IsNotNull(cl2);

            Assert.IsNotNull(cl1.cl2);
            Assert.IsNotNull(cl2.cl1);

            Assert.IsNull(cl1.cl2.cl1);
            Assert.IsNull(cl2.cl1.cl2);
        }


        [Test]
        public void DllTest()
        {
            Faker faker = new Faker();
            int i = faker.Create<int>();
            bool b = faker.Create<bool>();

            Assert.IsNotNull(i);
            Assert.IsNotNull(b);
        }

    }
}